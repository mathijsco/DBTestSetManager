using DatabaseTestSetManager.Lib.Models.Generation;

namespace DatabaseTestSetManager.Lib.ScriptBuilders.CellFormatters
{
    public interface ICellFormatter
    {
        ResolvedValue FormatCell(CellContext context);
    }
}
