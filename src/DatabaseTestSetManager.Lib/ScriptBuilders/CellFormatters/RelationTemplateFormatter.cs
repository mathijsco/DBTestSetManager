using System.Linq;
using DatabaseTestSetManager.Lib.Models.Generation;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters
{
    public class RelationTemplateFormatter : ICellFormatter
    {
        public ResolvedValue FormatCell(CellContext context)
        {
            // Relation does not require any lookups if the value is not set
            if (context.Value == null)
                return new ResolvedValue(context.CurrentColumn.Type, null);

            // Try to get it. It should be a ResolvedValue.
            // TODO: Check for column.RelationSpecification == null and others.
            var relSpec = context.CurrentColumn.RelationSpecification;
            var targetTable = context.CompleteDefinition.Sets.First(s => s.Specification.Guid == relSpec.SourceTable);
            var renderedColumnIndex = targetTable.Content.Columns.FindIndex(c => c.Guid == relSpec.ValueColumn).Value;
            var renderedColumn = targetTable.Content.Columns.Skip(renderedColumnIndex).First();
            var lookupColumnIndex = targetTable.Content.Columns.FindIndex(c => c.Guid == relSpec.LookupColumn).Value;
            var lookupColumn = targetTable.Content.Columns.Skip(lookupColumnIndex).First();

            var foundRow = targetTable.Content.Rows.FirstOrDefault(c => (c[lookupColumnIndex] as ResolvedValue)?.Value?.ToString() == context.Value.ToString());
            var foundValue = foundRow != null ? (ResolvedValue)foundRow[renderedColumnIndex] : null;
            var foundLookupValue = foundRow != null ? (ResolvedValue)foundRow[lookupColumnIndex] : null;

            // Convert to a ResolvedReference class with the name of the target table, SELECT and WHERE columns.
            if (foundValue is ResolvedValue)
            {
                return new ResolvedReference(
                    renderedColumn.Type,
                    foundValue.Value,
                    targetTable.Specification.Name,
                    renderedColumn.Name,
                    lookupColumn.Name,
                    lookupColumn.Type,
                    foundLookupValue.Value
                );
            }

            return null;
        }
    }
}