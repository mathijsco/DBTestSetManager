using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules.DataGridModules
{
    public class ReadOnlyStylingModule : IControlModule<DataGridView>
    {
        public DataGridView Control { get; set; }

        public void Register()
        {
            this.Control.ColumnAdded += Grid_ColumnAdded;
        }

        public void Unregister()
        {
            this.Control.ColumnAdded -= Grid_ColumnAdded;
        }

        private void Grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.ReadOnly)
            {
                e.Column.DefaultCellStyle = CellStyles.ReadOnlyStyle;
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
