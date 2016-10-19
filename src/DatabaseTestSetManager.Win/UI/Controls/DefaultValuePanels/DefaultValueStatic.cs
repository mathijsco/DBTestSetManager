using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using System.Drawing;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.DefaultValuePanels
{
    public partial class DefaultValueStatic : UserControl, IDefaultValuePanel
    {
        public DefaultValueStatic()
        {
            InitializeComponent();
            textBox1.Font = new Font(FontFamily.GenericMonospace, 8.5f);
        }

        public IDefaultDataProvider Value
        {
            get { return new StaticDataProvider { Value = textBox1.Text }; }
            set { textBox1.Text = ((StaticDataProvider)value).Value; }
        }
    }
}
