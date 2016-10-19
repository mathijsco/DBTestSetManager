using DatabaseTestSetManager.Win.UI.Elements;
using System.Diagnostics;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules.DataGridModules
{
    public class ComboBoxInvalidValueModule : IControlModule<DataGridView>
    {
        public DataGridView Control { get; set; }

        public void Register()
        {
            this.Control.DataError += Grid_DataError;
        }

        public void Unregister()
        {
            this.Control.DataError -= Grid_DataError;
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // The value in the combobox is not present
            if ((e.Context & DataGridViewDataErrorContexts.Formatting) > 0)
            {
                var column = this.Control.Columns[e.ColumnIndex];
                var row = this.Control.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];

                var comboColumn = column as DataGridViewComboBoxColumn;
                if (comboColumn != null)
                {
                    cell.ErrorText = "Invalid value selected from the available options";
                    var comboCell = (DataGridViewComboBoxCell)cell;

                    var cal = cell.Value;
                    comboCell.Items.Add(new ComboBoxErrorElement(cal, "INVALID: " + cal.ToString(), cell.ErrorText));
                }
                else
                    Trace.TraceError("Cell has invalid value at column {0}, row {1}. {2}", e.ColumnIndex, e.RowIndex, e.Exception.Message);
            }
        }
    }
}
