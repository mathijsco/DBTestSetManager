using DatabaseTestSetManager.Lib.DataHandlers.DataValidators;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Win.UI.Elements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI
{
    public partial class ManageKeyValueForm : Form
    {
        public ManageKeyValueForm()
        {
            InitializeComponent();

            typeColumn.DisplayMember = "Description";
            typeColumn.ValueMember = "Value";
            typeColumn.Items.AddRange(Enum.GetValues(typeof(FieldType)).Cast<FieldType>().Select(c => new EnumComboBoxElement<FieldType>(c)).ToArray());
        }

        public bool ReadOnlyName
        {
            get { return nameColumn.ReadOnly; }
            set
            {
                nameColumn.ReadOnly = value;
                dataGridView.AllowUserToAddRows = !value;
                dataGridView.AllowUserToDeleteRows = !value;
            }
        }

        public IList<TypedVariable> CurrentVariables { get; private set; }

        public void LoadData(IList<TypedVariable> data)
        {
            if (data == null) return;

            foreach (var item in data)
            {
                dataGridView.Rows.Add(new object[]
                {
                    item.Key,
                    item.Type,
                    item.Value
                });
            }
        }

        protected virtual void SaveData(IList<TypedVariable> data)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var specialCharsRegex = new Regex("^[A-Z0-9_]+$", RegexOptions.IgnoreCase);
            var error = false;

            // Do some validation.
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var nameCell = row.Cells[nameColumn.Index];
                var fieldTypeCell = row.Cells[typeColumn.Index];
                var valueCell = row.Cells[valueColumn.Index];

                var name = (string)nameCell.Value;
                var fieldType = (FieldType)fieldTypeCell.Value;
                var value = (string)valueCell.Value;

                if (string.IsNullOrWhiteSpace(name) && (error = true))
                    nameCell.ErrorText = "Specify a name";
                else if (!specialCharsRegex.IsMatch(name) && (error = true))
                    nameCell.ErrorText = "Name cannot contain special characters";
                else
                    nameCell.ErrorText = null;

                var factory = DataValidatorFactory.Create(fieldType);
                if (factory != null && !factory.Validate(value) && (error = true))
                    valueCell.ErrorText = "Value is not valid for the specified type";
                else
                    valueCell.ErrorText = null;
            }
            if (error)
            {
                MessageBox.Show("The content of the whiteboard contains errors.\r\nPlease fix them accordingly and try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set the whiteboard variable
            var list = new List<TypedVariable>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                var name = (string)row.Cells[nameColumn.Index].Value;
                var fieldType = (FieldType)row.Cells[typeColumn.Index].Value;
                var value = (string)row.Cells[valueColumn.Index].Value;

                list.Add(new TypedVariable
                {
                    Key = name,
                    Type = fieldType,
                    Value = value
                });
            }
            this.CurrentVariables = list;
            SaveData(list);

            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[typeColumn.Index].Value = FieldType.String;
        }
    }
}
