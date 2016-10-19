using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseTestSetManager.Lib.Models;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class RelationConfiguration : UserControl
    {
        public RelationConfiguration()
        {
            InitializeComponent();

            cmbSource.BeginUpdate();
            ApplicationState.Instance.CurrentDataSet
                .Where(o => o.Content.Columns.Any(c => c.MustBeUnique))
                .Select(o => o.Specification)
                .ForEach(o => cmbSource.Items.Add(o));
            cmbSource.EndUpdate();
        }

        public RelationSpec GenerateSpec()
        {
            if (cmbSource.SelectedItem == null || cmbValue.SelectedItem == null || cmbLookup.SelectedItem == null || cmbDisplay.SelectedItem == null)
                return null;

            return new RelationSpec()
            {
                SourceTable = ((TableSpec)cmbSource.SelectedItem).Guid,
                ValueColumn = ((ColumnSpec)cmbValue.SelectedItem).Guid,
                LookupColumn = ((ColumnSpec)cmbLookup.SelectedItem).Guid,
                DisplayColumn = ((ColumnSpec)cmbDisplay.SelectedItem).Guid
            };
        }

        public void LoadSpec(RelationSpec spec)
        {
            if (spec == null) return;

            cmbSource.SelectedItem = cmbSource.Items.Cast<TableSpec>().Where(s => s.Guid == spec.SourceTable).FirstOrDefault();
            cmbValue.SelectedItem = cmbValue.Items.Cast<ColumnSpec>().Where(s => s.Guid == spec.ValueColumn).FirstOrDefault();
            cmbLookup.SelectedItem = cmbLookup.Items.Cast<ColumnSpec>().Where(s => s.Guid == spec.LookupColumn).FirstOrDefault();
            cmbDisplay.SelectedItem = cmbDisplay.Items.Cast<ColumnSpec>().Where(s => s.Guid == spec.DisplayColumn).FirstOrDefault();
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (TableSpec)cmbSource.SelectedItem;
            var currentSet = ApplicationState.Instance.CurrentDataSet.Where(o => o.Specification.Guid == selectedItem.Guid).Select(o => o.Content).First();

            cmbValue.BeginUpdate();
            cmbDisplay.BeginUpdate();
            cmbLookup.BeginUpdate();
            cmbValue.Items.Clear();
            cmbDisplay.Items.Clear();
            cmbLookup.Items.Clear();
            foreach (var spec in currentSet.Columns.Where(c => c.MustBeUnique))
            {
                cmbValue.Items.Add(spec);
                cmbDisplay.Items.Add(spec);

                if (spec.Behavior != FieldBehavior.Generated)
                    cmbLookup.Items.Add(spec);
            }
            if (cmbValue.Items.Count > 0)
            {
                cmbValue.SelectedIndex = 0;
                cmbDisplay.SelectedIndex = cmbDisplay.Items.Count > 1 ? 1 : 0;
                cmbLookup.SelectedIndex = 0;
            }
            cmbLookup.EndUpdate();
            cmbDisplay.EndUpdate();
            cmbValue.EndUpdate();
        }

        private void cmbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only enable the lookup if it is necessary. So that the KEY is a generated field.
            var item = (ColumnSpec)cmbValue.SelectedItem;
            if (item.Behavior == FieldBehavior.Generated)
                cmbLookup.Enabled = true;
            else
            {
                cmbLookup.Enabled = false;
                cmbLookup.SelectedItem = item;
            }
        }
    }
}
