using DatabaseTestSetManager.Win.UI.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.DataGridModules
{
    public class ExtensibleDataGridView : DataGridView
    {
        public event EventHandler<SelectedCellsChangedEventArgs> SelectedCellsChanged;

        public ExtensibleDataGridView()
        {
            // Enable double buffering for better draw performance
            this.DoubleBuffered = true;
        }

        public void JumpToNewRow()
        {
            this.FirstDisplayedScrollingRowIndex = this.NewRowIndex;

            var cells = this.Rows[this.NewRowIndex].Cells;
            if (cells.Count > 1)
            {
                this.CurrentCell = cells[1];
                this.Focus();
            }
        }

        public void SetCellValue(DataGridViewCell cell, object value)
        {
            if (cell.OwningColumn.ReadOnly)
                return;

            cell.Value = value;
            // TODO: Enable the validation of the cell again
            //ValidateCell(cell);
        }

        public IEnumerable<DataGridViewCell> FindCellsForColumn(int columnIndex)
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                yield return row.Cells.Cast<DataGridViewCell>().First(c => c.ColumnIndex == columnIndex);
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            var handler = this.SelectedCellsChanged;
            if (handler != null)
                handler(this, new SelectedCellsChangedEventArgs(this.SelectedCells.Count));

            base.OnSelectionChanged(e);
        }

        protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            BeginEdit(true);
            base.OnCellDoubleClick(e);
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            // After edit, always remove the error text.
            // If the error is needed, let it figure it out again.

            // this.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = null;
            this.CurrentCell.ErrorText = null;

            base.OnCellEndEdit(e);
        }
    }
}
