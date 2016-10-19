using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Elements
{
    public class DataGridViewTypedVariableColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewTypedVariableColumn()
        {
            this.CellTemplate = new DataGridViewTypedVariableCell();
        }
    }
}
