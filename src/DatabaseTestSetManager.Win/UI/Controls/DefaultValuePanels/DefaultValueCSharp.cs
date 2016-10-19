using System.Windows.Forms;
using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using System.Drawing;

namespace DatabaseTestSetManager.Win.UI.Controls.DefaultValuePanels
{
    public partial class DefaultValueCSharp : UserControl, IDefaultValuePanel
    {
        private CSharpDataProvider _currentProvider;

        public DefaultValueCSharp()
        {
            InitializeComponent();

            txtCode.Font = new Font(FontFamily.GenericMonospace, 8.5f);
            _currentProvider = new CSharpDataProvider
            {
                IsStatement = true
            };
        }

        public IDefaultDataProvider Value
        {
            get
            {
                _currentProvider.CodeBlock = txtCode.Text;
                return _currentProvider;
            }
            set { txtCode.Text = ((CSharpDataProvider)value).CodeBlock; }
        }

        private async void btnTest_Click(object sender, System.EventArgs e)
        {
            btnTest.Enabled = false;
            txtTestResult.Text = await ((CSharpDataProvider)this.Value).GenerateAsync();
            btnTest.Enabled = true;
        }
    }
}
