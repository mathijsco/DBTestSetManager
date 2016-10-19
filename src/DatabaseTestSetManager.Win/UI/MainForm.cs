using DatabaseTestSetManager.Win.IO;
using System;
using System.Windows.Forms;
using DatabaseTestSetManager.Win.Properties;
using DatabaseTestSetManager.Lib.ScriptBuilders;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using DatabaseTestSetManager.Lib.Razor;
using DatabaseTestSetManager.Win.UI.Debugging;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class MainForm : Form
    {
        private string _currentFile;

        public MainForm()
        {
            InitializeComponent();
            this.LoadState();

            this.Icon = Resources.Icon;
            Trace.Listeners.Add(new TraceToControl(splitContainer1, txtLogs));
            txtLogs.Font = new Font(FontFamily.GenericMonospace, 8.5f);
            splitContainer1.Panel2Collapsed = true;
        }

        public void LoadFile(string path)
        {
            var repo = new SavedFileRepository();
            var set = repo.Load(path);
            objectManagementTabs.LoadTableSets(set.Sets);
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            _currentFile = null;
            objectManagementTabs.NewTestSet();
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                _currentFile = path;
                LoadFile(path);
            }
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (_currentFile == null)
            {
                menuSaveAs_Click(sender, e);
                return;
            }

            var set = objectManagementTabs.GenerateTableSet();
            var repo = new SavedFileRepository();
            repo.Save(_currentFile, set);
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var set = objectManagementTabs.GenerateTableSet();
                var path = saveFileDialog.FileName;
                _currentFile = path;

                var repo = new SavedFileRepository();
                repo.Save(path, set);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async void tbtnGenerateRows_Click(object sender, EventArgs e)
        {
            await objectManagementTabs.CurrentGrid.GenerateNewRow(5);
        }

        private void tbtnAddNewObject_Click(object sender, EventArgs e)
        {
            objectManagementTabs.OpenAddNewTable();
        }

        private void tbtnAddNewField_Click(object sender, EventArgs e)
        {
            objectManagementTabs.CurrentGrid.OpenAddNewColumn();
        }

        private void tbtnAddNewRow_Click(object sender, EventArgs e)
        {
            objectManagementTabs.CurrentGrid.JumpToNewRow();
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to quit?\r\nAll unsaved changes will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                e.Cancel = true;
            else
            {
                statusLabel.Text = "Saving layout...";
                this.ForceSaveState();
                AssemblyConfig.Load().Save();
                statusLabel.Text = "Clearing temporary files...";
                await Task.Factory.StartNew(() => { TemplateEngineFactory.ClearCache(); });
                statusLabel.Text = "Ready";
            }
        }

        private async void tbtnGenerateCsv_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Exporting the data set...";

            var repo = new SavedFileRepository();
            var clone = repo.Clone(new Lib.Models.FullTestSet
            {
                Whiteboard = ApplicationState.Instance.Whiteboard,
                Sets = objectManagementTabs.GenerateTableSet()
            });

            var builder = new CsvScriptBuilder();
            var result = await builder.Build(clone);

            if (result.Count > 0)
            {
                var form = new ExportResultsForm();
                form.LoadResults(result);
                form.Show();
            }
            else
            {
                MessageBox.Show("No export result are generated.\r\nPlease check the logs for any issue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            statusLabel.Text = "Ready";
        }

        private async void tbtnGenerateSql_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Exporting the data set...";
            objectManagementTabs.Enabled = false;

            var repo = new SavedFileRepository();
            var clone = repo.Clone(new Lib.Models.FullTestSet {
                Whiteboard = ApplicationState.Instance.Whiteboard,
                Sets = objectManagementTabs.GenerateTableSet()
            });

            var builder = new SqlServerScriptBuilder();
            var result = await builder.Build(clone);

            var form = new ExportResultsForm();
            form.LoadResults(result);
            form.Show();

            objectManagementTabs.Enabled = true;
            statusLabel.Text = "Ready";
        }

        private void menuWhiteboard_Click(object sender, EventArgs e)
        {
            var form = new WhiteboardForm();
            form.ShowDialog();
        }

        private void menuSharedTemplates_Click(object sender, EventArgs e)
        {
            var form = new SharedTemplatesForm();
            form.ShowDialog();
        }

        private void tbtnClearLog_Click(object sender, EventArgs e)
        {
            txtLogs.Text = null;
        }

        private void tbtnCloseLog_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void objectManagementTabs_SelectedCellsChanged(object sender, EventArguments.SelectedCellsChangedEventArgs e)
        {
            statusSelectedCells.Text = string.Format("{0} cell{1} selected", e.SelectedCells, e.SelectedCells != 1 ? "s" : "");
        }
    }
}
