using DatabaseTestSetManager.Lib.Models.Generation;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters
{
    public class DefaultTemplateFormatter : ICellFormatter
    {
        public ResolvedValue FormatCell(CellContext context)
        {
            return new ResolvedValue(context.CurrentColumn.Type, context.Value);
        }
    }
}
