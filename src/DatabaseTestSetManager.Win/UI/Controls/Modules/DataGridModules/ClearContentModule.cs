using DatabaseTestSetManager.Win.UI.DataGridModules;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules.DataGridModules
{
    public class ClearContentModule : IControlModule<ExtensibleDataGridView>
    {
        public ExtensibleDataGridView Control { get; set; }

        public void Register()
        {
            this.Control.KeyDown += Grid_KeyDown;
        }

        public void Unregister()
        {
            this.Control.KeyDown -= Grid_KeyDown;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled) return;

            // Allow clearing the cell
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Delete)
            {
                e.Handled = TryClearCells();
            }
        }

        private bool TryClearCells()
        {
            if (this.Control.SelectedColumns.Count == 0 && this.Control.SelectedRows.Count == 0)
            {
                foreach (DataGridViewCell selectedCell in this.Control.SelectedCells)
                {
                    this.Control.SetCellValue(selectedCell, null);
                }
                return true;
            }
            return false;
        }
    }
}
