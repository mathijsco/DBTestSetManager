using DatabaseTestSetManager.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class TableProperties : Form
    {
        private Guid? _tableGuid;

        public TableProperties()
        {
            InitializeComponent();
        }

        public TableSpec GenerateSpec()
        {
            return new TableSpec
            {
                Guid = _tableGuid ?? Guid.NewGuid(),
                Name = txtName.Text,
                NoExport = chkNoExport.Checked
            };
        }

        public void LoadSpec(TableSpec spec)
        {
            this.Text = "Edit table";

            _tableGuid = spec.Guid;
            txtName.Text = spec.Name;
            chkNoExport.Checked = spec.NoExport;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
