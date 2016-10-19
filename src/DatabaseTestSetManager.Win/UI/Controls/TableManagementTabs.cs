using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Win.UI.EventArguments;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class TableManagementTabs : UserControl
    {
        private TabPage _contentOpenForTab;
        private IDictionary<TabPage, TableSet> _tableMapping;

        public event EventHandler<SelectedCellsChangedEventArgs> SelectedCellsChanged;

        public TableManagementTabs()
        {
            InitializeComponent();

            _tableMapping = new Dictionary<TabPage, TableSet>();

            // Create the default tab
            NewTestSet();
        }

        public IList<TableSet> GenerateTableSet()
        {
            var set = new List<TableSet>();
            foreach (var o in _tableMapping)
            {
                var myGrid = o.Key.Controls.OfType<ContentSetGrid>().First();
                set.Add(new TableSet
                {
                    Specification = o.Value.Specification,
                    Content = new ContentSet
                    {
                        Columns = myGrid.ColumnSpecs.ToList(),
                        Rows = myGrid.ObjectRows.ToList()
                    }
                });
            }
            return set;
        }

        public void NewTestSet()
        {
            // Create the default tab
            IntPtr h = tabObjects.Handle;
            LoadTableSets(new List<TableSet>()
            {
                new TableSet
                {
                    Specification = new TableSpec { Name = "NewTable1", Guid = Guid.NewGuid() },
                    Content = new ContentSet
                    {
                        Columns = new List<ColumnSpec>(),
                        Rows = new List<ContentRow>()
                    }
                }
            });
            tabObjects.SelectedIndex = 0;
        }

        public void LoadTableSets(IList<TableSet> sets)
        {
            // Remove the existing objects
            var oldMapping = _tableMapping;
            _tableMapping = new Dictionary<TabPage, TableSet>();
            ApplicationState.Instance.CurrentDataSet.Clear();

            // Load the new set
            foreach (var set in sets)
            {
                var tab = CreateTabAndCreateTableSet(set.Specification);
                FindGridForTab(tab).LoadDataSet(set.Content);
                tabObjects.TabPages.Insert(tabObjects.TabPages.Count - 1, tab);
            }

            // Remove the old tabs
            foreach (var o in oldMapping)
                tabObjects.TabPages.Remove(o.Key);
        }

        public ContentSetGrid CurrentGrid
        {
            get
            {
                return FindGridForTab(tabObjects.SelectedTab);
            }
        }

        private ContentSetGrid FindGridForTab(TabPage tabPage)
        {
            return tabPage.Controls.OfType<ContentSetGrid>().First();
        }

        
        public void OpenAddNewTable()
        {
            var form = new TableProperties();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var spec = form.GenerateSpec();
                var tab = CreateTabAndCreateTableSet(spec);
                tabObjects.TabPages.Insert(tabObjects.TabPages.Count - 1, tab);
            }
        }

        public void OpenEditTable(TableSpec spec)
        {
            var form = new TableProperties();
            form.LoadSpec(spec);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var updatedSpec = form.GenerateSpec();
                var kv = _tableMapping.First(m => m.Value.Specification == spec);
                _tableMapping[kv.Key].Specification = updatedSpec;
                kv.Key.Text = !updatedSpec.NoExport ? updatedSpec.Name : ("[" + updatedSpec.Name + "]");
            }
        }

        private TabPage CreateTabAndCreateTableSet(TableSpec spec)
        {
            var grid = new ContentSetGrid { Dock = DockStyle.Fill };
            grid.SelectedCellsChanged += (sender, e) => SelectedCellsChanged?.Invoke(sender, e);
            var tab = new TabPage(!spec.NoExport ? spec.Name : ("[" + spec.Name + "]"));
            tab.Controls.Add(grid);

            var tableSet = new TableSet
            {
                Specification = spec,
                Content = new ContentSet
                {
                    Columns = grid.ColumnSpecs,
                    Rows = grid.ObjectRows
                }
            };
            _tableMapping.Add(tab, tableSet);
            ApplicationState.Instance.CurrentDataSet.Add(tableSet);

            return tab;
        }


        private void cmenuItemEdit_Click(object sender, EventArgs e)
        {
            if (_contentOpenForTab == null) return;

            var tableSet = _tableMapping[_contentOpenForTab];
            OpenEditTable(tableSet.Specification);
        }

        private void cmenuItemDelete_Click(object sender, EventArgs e)
        {
            if (_contentOpenForTab == null) return;

            var tableSet = _tableMapping[_contentOpenForTab];

            if (MessageBox.Show("Are you sure to remove the " + tableSet.Specification.Name + " object?\r\n\r\nThis action cannot be undone!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var grid = FindGridForTab(_contentOpenForTab);
            grid.SelectedCellsChanged -= SelectedCellsChanged;
            grid.Dispose();

            _tableMapping.Remove(_contentOpenForTab);
            ApplicationState.Instance.CurrentDataSet.Remove(tableSet);
            tabObjects.TabPages.Remove(_contentOpenForTab);
        }

        private void tabObjects_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Add a new one
            if (e.TabPage == tabAdd)
            {
                e.Cancel = true;
                OpenAddNewTable();
                return;
            }
            this.CurrentGrid.RefreshGridDependencies();
        }

        private void tabObjects_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            for (int i = 0; i < tabObjects.TabCount; ++i)
            {
                if (tabObjects.GetTabRect(i).Contains(e.Location))
                {
                    var t = (TabPage)tabObjects.Controls[i];
                    if (t != tabAdd)
                    {
                        _contentOpenForTab = t;
                        cmenuTabs.Show(Control.MousePosition);
                    }
                }
            }
        }
    }
}
