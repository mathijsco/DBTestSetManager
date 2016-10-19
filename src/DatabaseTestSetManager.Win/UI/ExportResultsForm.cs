using DatabaseTestSetManager.Lib.Models.Generation;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using DatabaseTestSetManager.Win.Properties;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class ExportResultsForm : Form
    {
        public ExportResultsForm()
        {
            InitializeComponent();
            this.Icon = Resources.Icon;
            txtFileContent.Font = new Font(FontFamily.GenericMonospace, 8.5f);
        }

        public void LoadResults(IList<GeneratedScript> results)
        {
            lstFiles.BeginUpdate();
            lstFiles.Items.Add("COMBINED EXPORT");
            lstFiles.Items.AddRange(results.ToArray());
            lstFiles.EndUpdate();

            lstFiles.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void lstFiles_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Combined
            if (lstFiles.SelectedIndex == 0)
            {
                txtFileContent.Text = lstFiles.Items.OfType<GeneratedScript>().Select(s => s.Output).DefaultIfEmpty().Aggregate((a, b) => a + "\r\n\r\n" +  b);
                return;
            }

            var selectedItem = lstFiles.SelectedItem as GeneratedScript;
            if (selectedItem == null) return;

            txtFileContent.Text = selectedItem.Output;
        }
    }
}
