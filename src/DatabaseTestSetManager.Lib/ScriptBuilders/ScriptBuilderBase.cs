using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Lib.Models.Generation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System;
using DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters;
using DatabaseTestSetManager.Lib.Razor.Models;

namespace DatabaseTestSetManager.Lib.ScriptBuilders
{
    public abstract class ScriptBuilderBase
    {
        private readonly ICellFormatter _defaultCellFormatter;
        private readonly ICellFormatter _idCellFormatter;
        private readonly ICellFormatter _relationCellFormatter;
        private readonly ICellFormatter _razorCellFormatter;

        protected ScriptBuilderBase(IActionTemplateModel actionTemplateModel)
        {
            _defaultCellFormatter = new DefaultTemplateFormatter();
            _idCellFormatter = new GeneratedIdFromRow();
            _relationCellFormatter = new RelationTemplateFormatter();
            _razorCellFormatter = new RazorTemplateFormatter(actionTemplateModel);
        }


        public async Task<IList<GeneratedScript>> Build(FullTestSet completeDefinition)
        {
            return await Task.Factory.StartNew(() =>
            {
                Trace.TraceInformation("Export started...");

                // STAGE 1: Resolve all references and templates
                Trace.TraceInformation("Resolving all fields...");
                ResolveAllFields(completeDefinition);

                IList<GeneratedScript> result = new GeneratedScript[0];

                // STAGE 2: Order the tables, based on when they where ready
                Trace.TraceInformation("Ordering tables...");
                OrderTables(completeDefinition);

                // STAGE 3: Generate the scripts for all the objects
                Trace.TraceInformation("Creating output...");
                result = DumpOutput(completeDefinition);

                Trace.TraceInformation("Export completed.");
                return result;
            });
        }

        protected abstract IList<GeneratedScript> DumpOutput(FullTestSet completeDefinition);

        private ResolvedValue FormatCell(CellContext context)
        {
            switch (context.CurrentColumn.Behavior)
            {
                case FieldBehavior.Generated:
                    return _idCellFormatter.FormatCell(context);

                case FieldBehavior.Relation:
                    return _relationCellFormatter.FormatCell(context);

                case FieldBehavior.RazorTemplate:
                    return _razorCellFormatter.FormatCell(context);

                default:
                    return _defaultCellFormatter.FormatCell(context);
            }
        }

        private void ResolveAllFields(FullTestSet completeDefinition)
        {
            // Keep track of all tables that are done.
            var skipTableSets = new HashSet<Guid>();

            bool hasFoundUnresolvedFields;
            do
            {
                hasFoundUnresolvedFields = false;
                // Boolean indicating that at least 1 field is resolved.
                var hasResolvedSomeFields = false;

                foreach (var tableSet in completeDefinition.Sets)
                {
                    if (skipTableSets.Contains(tableSet.Specification.Guid))
                        continue;

                    var rowIndex = -1;
                    bool tableIsDone = true;

                    // Change the columns to a list, but only is it is not a list yet.
                    if (!(tableSet.Content.Columns is IList<ColumnSpec>))
                        tableSet.Content.Columns = tableSet.Content.Columns.ToList();

                    // Change the rows to a list, but only is it is not a list yet.
                    if (!(tableSet.Content.Rows is IList<ContentRow>))
                        tableSet.Content.Rows = tableSet.Content.Rows.ToList();

                    // Keep track of all columns that fail. Those can have a very high likelyhood that others are also failing.
                    var skipColumnIndexes = new HashSet<Guid>();

                    foreach (var rowSet in tableSet.Content.Rows)
                    {
                        rowIndex++;
                        var columnIndex = -1;
                        foreach (var column in tableSet.Content.Columns)
                        {
                            columnIndex++;
                            if (skipColumnIndexes.Contains(column.Guid))
                                continue;

                            var fieldValue = rowSet[columnIndex];

                            // If the field is already resolved, continue with the next one
                            if (fieldValue is ResolvedValue)
                                continue;

                            var context = new CellContext(completeDefinition, tableSet, rowSet, rowIndex, column, columnIndex, fieldValue);
                            var newValue = FormatCell(context);

                            if (newValue != null)
                            {
                                rowSet[columnIndex] = newValue;
                                hasResolvedSomeFields = true;
                            }
                            else
                            {
                                hasFoundUnresolvedFields = true;
                                tableIsDone = false;
                            }

                            // Skip this column for all other rows.
                            if (context.ResultSkipColumn)
                                skipColumnIndexes.Add(column.Guid);
                        }
                    }

                    // If the table is done, mark it so.
                    if (tableIsDone)
                    {
                        skipTableSets.Add(tableSet.Specification.Guid);
                        Trace.WriteLine("Completed the export for " + tableSet.Specification.Name + ".");
                    }
                }

                if (!hasResolvedSomeFields)
                {
                    var unresolved = completeDefinition.Sets
                        .Where(s => !skipTableSets.Contains(s.Specification.Guid))
                        .Select(s => s.Specification.Name).ToList();

                    if (unresolved.Count > 0)
                        Trace.TraceError("Testset cannot be exported because some fields cannot be resolved. Please check the following table(s): {0}",
                            unresolved.Aggregate((a, b) => a + ", " + b)
                        );
                    else
                        Trace.TraceWarning("There is no table to export.");
                    return;
                }
            } while (hasFoundUnresolvedFields);
        }

        private void OrderTables(FullTestSet completeDefinition)
        {
            var resolvedTables = new HashSet<Guid>();
            var resultSets = new List<TableSet>();
            int resolved;

            while (resultSets.Count != completeDefinition.Sets.Count)
            {
                resolved = 0;
                foreach (var set in completeDefinition.Sets.Where(s => !resolvedTables.Contains(s.Specification.Guid)))
                {
                    var dependencies = set.Content.Columns.Where(c => c.Behavior == FieldBehavior.Relation && !resolvedTables.Contains(c.RelationSpecification.SourceTable)).ToList();
                    if (dependencies.Count == 0)
                    {
                        resolvedTables.Add(set.Specification.Guid);
                        resultSets.Add(set);
                        resolved++;
                    }
                }

                // Cannot resolve more tables
                if (resolved == 0)
                {
                    var missingTables = completeDefinition.Sets.Where(s => !resolvedTables.Contains(s.Specification.Guid)).ToList();
                    Trace.TraceWarning("Some tables have circular dependencies which can cause issues when importing the data: {0}", string.Join(", ", missingTables.Select(t => t.Specification.Name)));
                    resultSets.AddRange(missingTables);
                    break;
                }
            }

            // Create the final list of sets, and remove the items that should not be exported and the ones without data.
            completeDefinition.Sets = new List<TableSet>(resultSets.Where(s => !s.Specification.NoExport && s.Content.Columns.Any() && s.Content.Rows.Any()));
        }
    }
}
