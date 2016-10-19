using DatabaseTestSetManager.Lib.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using DatabaseTestSetManager.Win.UI.Elements;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class ColumnProperties : Form
    {
        private Guid? _columnGuid;
        private readonly IList<ColumnSpec> _existingColumns;

        public ColumnProperties(IList<ColumnSpec> existingColumns, ColumnSpec currentColumn)
        {
            InitializeComponent();
            this.LoadState();

            _existingColumns = existingColumns;

            cmbType.Items.AddRange(Enum.GetValues(typeof(FieldType)).Cast<FieldType>().Select(c => new EnumComboBoxElement<FieldType>(c)).ToArray());
            cmbBehavior.Items.AddRange(Enum.GetValues(typeof(FieldBehavior)).Cast<FieldBehavior>().Select(c => new EnumComboBoxElement<FieldBehavior>(c)).ToArray());

            cmbType.SelectedIndex = 0;
            cmbBehavior.SelectedIndex = 0;

            // Load the template engine with all the existing column names
            templateConfiguration.LoadModel(existingColumns, currentColumn);
        }

        public ColumnSpec GenerateSpec()
        {
            var fieldType = this.CurrentFieldType;
            var fieldBehavior = this.CurrentFieldBehavior;

            // Always behave as a string for the generated or relation. Relation will use its target, and generated will ignore it.
            if (fieldBehavior == FieldBehavior.Relation)
                fieldType = FieldType.String;
            else if (fieldBehavior == FieldBehavior.Generated)
                fieldType = FieldType.Number;

            return new ColumnSpec
            {
                Guid = _columnGuid ?? Guid.NewGuid(),
                Name = txtName.Text.Trim(),
                Type = fieldType,
                Behavior = fieldBehavior,
                MustBeUnique = chkMustBeUnique.Checked,
                AllowNull = chkAllowNull.Checked,
                NoExport = chkExcludeFromExport.Checked,
                DefaultDataType = defaultValueConfiguration.HasDefaultValue ? defaultValueConfiguration.SelectedDataType : DefaultDataType.Static,
                DefaultDataProvider = defaultValueConfiguration.HasDefaultValue ? defaultValueConfiguration.Value : null,
                RelationSpecification = fieldBehavior == FieldBehavior.Relation ? relationConfiguration.GenerateSpec() : null,
                TemplateSpecification = fieldBehavior == FieldBehavior.RazorTemplate ? templateConfiguration.GenerateSpec() : null
            };
        }

        public void LoadSpec(ColumnSpec columnInfo)
        {
            this.Text = "Edit column";
            cmbType.Enabled = false;
            cmbBehavior.Enabled = false;

            _columnGuid = columnInfo.Guid;
            txtName.Text = columnInfo.Name;
            cmbType.SelectedIndex = (int)columnInfo.Type;
            cmbBehavior.SelectedIndex = (int)columnInfo.Behavior;
            chkMustBeUnique.Checked = columnInfo.MustBeUnique;
            chkAllowNull.Checked = columnInfo.AllowNull;
            chkExcludeFromExport.Checked = columnInfo.NoExport;
            defaultValueConfiguration.SelectedDataType = columnInfo.DefaultDataType;
            relationConfiguration.LoadSpec(columnInfo.RelationSpecification);
            templateConfiguration.LoadSpec(columnInfo.TemplateSpecification);

            if (columnInfo.DefaultDataProvider != null)
            {
                defaultValueConfiguration.HasDefaultValue = true;
                defaultValueConfiguration.Value = columnInfo.DefaultDataProvider;
            }
        }

        private FieldType CurrentFieldType
        {
            get { return ((EnumComboBoxElement<FieldType>)cmbType.SelectedItem).Value; }
        }

        private FieldBehavior CurrentFieldBehavior
        {
            get { return ((EnumComboBoxElement<FieldBehavior>)cmbBehavior.SelectedItem).Value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtName.Text) || _existingColumns.Any(c => c.Name == txtName.Text.Trim()))
            //{
            //    MessageBox.Show("Please specify an unique name before saving.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            this.DialogResult = DialogResult.OK;
        }


        private void cmbBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            defaultValueConfiguration.Visible = false;
            relationConfiguration.Visible = false;
            templateConfiguration.Visible = false;
            sharedTemplateConfiguration.Visible = false;
            customBehaviorConfiguration.Visible = false;
            defaultValueConfiguration.SupportDefaultValue = false;

            bool valueIsUnmanaged = false;

            switch (this.CurrentFieldBehavior)
            {
                case FieldBehavior.Generated:
                    //defaultValueConfiguration.SupportDefaultValue = false;
                    defaultValueConfiguration.Visible = true;
                    cmbType.Enabled = false;
                    cmbType.SelectedIndex = (int)FieldType.Number;
                    break;
                case FieldBehavior.Relation:
                    relationConfiguration.Visible = true;
                    cmbType.Enabled = false;
                    cmbType.SelectedIndex = (int)FieldType.String;
                    break;
                case FieldBehavior.RazorTemplate:
                    templateConfiguration.Visible = true;
                    valueIsUnmanaged = true;
                    cmbType.Enabled = true;
                    break;
                case FieldBehavior.SharedRazorTemplate:
                    sharedTemplateConfiguration.Visible = true;
                    valueIsUnmanaged = true;
                    cmbType.Enabled = false;
                    cmbType.SelectedIndex = (int)FieldType.String;
                    break;
                case FieldBehavior.Custom:
                    customBehaviorConfiguration.Visible = true;
                    valueIsUnmanaged = true;
                    cmbType.Enabled = false;
                    cmbType.SelectedIndex = (int)FieldType.String;
                    break;
                default:
                    defaultValueConfiguration.SupportDefaultValue = true;
                    defaultValueConfiguration.Visible = true;
                    cmbType.Enabled = true;
                    break;
            }

            // Check if null is forces and check if no unique is possible
            if (valueIsUnmanaged)
            {
                chkAllowNull.Enabled = false;
                chkAllowNull.Checked = true;
                chkMustBeUnique.Enabled = false;
                chkMustBeUnique.Checked = false;
            }
            else
            {
                chkAllowNull.Enabled = true;
                chkMustBeUnique.Enabled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Disabled because of the split in type and behavior

            //if (!cmbType.Enabled) return;

            //var regex = Regex.Match(txtName.Text, "^([0-9])[:\\. ](.*)$");
            //if (regex.Success)
            //{
            //    txtName.Text = regex.Groups[2].Value;
            //    var index = int.Parse(regex.Groups[1].Value) - 1;
            //    if (cmbType.Items.Count > index)
            //        cmbType.SelectedIndex = index;
            //}
        }

        private void chkMustBeUnique_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMustBeUnique.Checked)
            {
                chkAllowNull.Checked = false;
                chkAllowNull.Enabled = false;
            }
            else
                chkAllowNull.Enabled = true;
        }
    }
}
