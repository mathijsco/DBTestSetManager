using System;
using System.Windows.Forms;
using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using System.Drawing;

namespace DatabaseTestSetManager.Win.UI.Controls.DefaultValuePanels
{
    public partial class DefaultValueStaticList : UserControl, IDefaultValuePanel
    {
        public DefaultValueStaticList()
        {
            InitializeComponent();
            textBox1.Font = new Font(FontFamily.GenericMonospace, 8.5f);
        }

        public IDefaultDataProvider Value
        {
            get
            {
                var split = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                return new ListDataProvider { Values = split };
            }
            set { textBox1.Text = string.Join("\r\n", ((ListDataProvider)value).Values); }
        }
    }
}
