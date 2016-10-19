using System;
using System.Windows.Forms;
using DatabaseTestSetManager.Win.UI.Controls.DefaultValuePanels;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders;
using System.Linq;
using DatabaseTestSetManager.Win.UI.Elements;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class DefaultValueConfiguration : UserControl
    {
        private IDefaultValuePanel[] _defaultValuePanels = new IDefaultValuePanel[]
        {
            new DefaultValueStatic(), new DefaultValueStaticList(), new DefaultValueCSharp()
        };

        public DefaultValueConfiguration()
        {
            InitializeComponent();

            foreach (Control p in _defaultValuePanels)
            {
                p.Dock = DockStyle.Fill;
                panelDefaultValuePlaceholder.Controls.Add(p);
            }

            cmbDefaultValueSource.Items.AddRange(Enum.GetValues(typeof(DefaultDataType)).Cast<DefaultDataType>().Select(c => new EnumComboBoxElement<DefaultDataType>(c)).ToArray());
            cmbDefaultValueSource.SelectedIndex = 0;
        }

        public bool HasDefaultValue
        {
            get { return chkEnableValue.Checked; }
            set { chkEnableValue.Checked = value; }
        }

        public bool SupportDefaultValue
        {
            get { return chkEnableValue.Enabled; }
            set
            {
                this.HasDefaultValue = false;
                chkEnableValue.Enabled = value;
                groupOuter.Enabled = chkEnableValue.Checked;
            }
        }

        public DefaultDataType SelectedDataType
        {
            get { return this.HasDefaultValue ? (DefaultDataType)cmbDefaultValueSource.SelectedIndex : DefaultDataType.Static; }
            set { cmbDefaultValueSource.SelectedIndex = (int)value; }
        }

        public IDefaultDataProvider Value
        {
            get { return _defaultValuePanels[cmbDefaultValueSource.SelectedIndex].Value; }
            set { _defaultValuePanels[cmbDefaultValueSource.SelectedIndex].Value = value; }
        }

        private void cmbDefaultValueSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            _defaultValuePanels.ForEach((p, i) => p.Visible = i == cmbDefaultValueSource.SelectedIndex);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupOuter.Enabled = chkEnableValue.Checked;
        }
    }
}
