using DatabaseTestSetManager.Lib.Razor;
using System.Collections.Generic;

namespace DatabaseTestSetManager.Lib.Models.Generation
{
    public class CellContext
    {
        public CellContext(
            FullTestSet completeDefinition,
            TableSet currentTable,
            ContentRow currentRow,
            int rowIndex,
            ColumnSpec currentColumn,
            int columnIndex,
            object fieldValue)
        {
            this.CompleteDefinition = completeDefinition;
            this.CurrentTable = currentTable;
            this.CurrentRow = currentRow;
            this.CurrentRowIndex = rowIndex;
            this.CurrentColumn = currentColumn;
            this.CurrentColumnIndex = columnIndex;
            this.Value = fieldValue;
            this.ResultSkipColumn = false;
        }

        public FullTestSet CompleteDefinition { get; private set; }

        public TableSet CurrentTable { get; private set; }

        public ContentRow CurrentRow { get; private set; }

        public int CurrentRowIndex { get; private set; }

        public ColumnSpec CurrentColumn { get; private set; }

        public int CurrentColumnIndex { get; private set; }

        public object Value { get; private set; }


        public bool ResultSkipColumn { get; set; }
    }
}
