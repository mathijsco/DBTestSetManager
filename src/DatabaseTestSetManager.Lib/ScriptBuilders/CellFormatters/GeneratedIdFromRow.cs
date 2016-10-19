using DatabaseTestSetManager.Lib.Models.Generation;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters
{
    public class GeneratedIdFromRow : ICellFormatter
    {
        public ResolvedValue FormatCell(CellContext context)
        {
            return new ResolvedValue(context.CurrentColumn.Type, (context.CurrentRowIndex + 1).ToString());
        }
    }
}
