using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DatabaseTestSetManager.Lib.Models;
using DatabaseTestSetManager.Win.UI.Elements;
using DatabaseTestSetManager.Lib.DataHandlers.DataValidators;
using DatabaseTestSetManager.Win.UI.EventArguments;
using System.Threading.Tasks;
using DatabaseTestSetManager.Win.UI.Controls.Modules.DataGridModules;
using DatabaseTestSetManager.Lib.Helpers;

namespace DatabaseTestSetManager.Win.UI.Controls
{
    public partial class ContentSetGrid : UserControl
    {
        private readonly IDictionary<DataGridViewColumn, ColumnSpec> _columnMapping;
        private DataGridViewColumn _contentMenuOpenedFor;
        private Font _italicFont;

        public event EventHandler<SelectedCellsChangedEventArgs> SelectedCellsChanged;

        public ContentSetGrid()
        {
            InitializeComponent();

            // Add the modules for this data grid view
            dataGridView.AddModules(
                new ClearContentModule(),
                new CopyPastModule(),
                new ComboBoxInvalidValueModule(),
                new ReadOnlyStylingModule()
            );
            dataGridView.SelectedCellsChanged += (sender, e) => SelectedCellsChanged(sender, e);

            _columnMapping = new Dictionary<DataGridViewColumn, ColumnSpec>();
        }

        public IEnumerable<ColumnSpec> ColumnSpecs
        {
            get
            {
                return _columnMapping.OrderBy(c => c.Key.DisplayIndex).Select(c => c.Value);
            }
        }

        public IEnumerable<ContentRow> ObjectRows
        {
            get
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow) continue;

                    var objectRow = new ContentRow(_columnMapping.Count);
                    foreach (DataGridViewColumn column in dataGridView.Columns.Cast<DataGridViewColumn>().OrderBy(c => c.DisplayIndex))
                    {
                        if (column == AddField) continue;
                        objectRow.Add(row.Cells[column.Index].Value);
                    }
                    yield return objectRow;
                }
            }
        }

        public bool ReadOnly
        {
            get { return !AddField.Visible; }
            set
            {
                if (this.ReadOnly == value)
                    return;

                AddField.Visible = !value;
                dataGridView.AllowUserToAddRows = !value;
                dataGridView.AllowUserToDeleteRows = !value;
                dataGridView.ReadOnly = value;
            }
        }

        public void LoadDataSet(ContentSet collection)
        {
            foreach (var spec in collection.Columns)
            {
                var column = CreateColumn(spec, AddField.DisplayIndex);
                _columnMapping.Add(column, spec);
                dataGridView.Columns.Add(column);
            }

            int columns = collection.Rows.FirstOrDefault()?.Count ?? 0;
            foreach (var row in collection.Rows)
            {
                // Always add 1, for the Add column
                var dataRow = new object[columns + 1];
                row.CopyTo(dataRow, 1);
                dataGridView.Rows.Add(dataRow);
            }
        }

        public async Task GenerateNewRow(int rowCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                // Always add 1, for the Add column
                var dataRow = new object[dataGridView.Columns.Count];
                var dri = 0;
                foreach (var provider in _columnMapping.Select(c => c.Value.DefaultDataProvider))
                {
                    dri++;
                    if (provider != null) dataRow[dri] = await provider.GenerateAsync();
                }

                dataGridView.Rows.Add(dataRow);
            }
        }

        public void OpenAddNewColumn()
        {
            var form = new ColumnProperties(_columnMapping.Values.ToList(), null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //var totalColumns = dataGridView.Columns.GetColumnCount(DataGridViewElementStates.None);
                var columnSpec = form.GenerateSpec();
                var column = CreateColumn(columnSpec, AddField.DisplayIndex);

                _columnMapping.Add(column, columnSpec);
                dataGridView.Columns.Add(column);

                // Add the default data to the new column
                if (columnSpec.DefaultDataProvider != null)
                {
                    foreach (var cell in dataGridView.FindCellsForColumn(column.Index))
                        cell.Value = columnSpec.DefaultDataProvider.Generate();
                }

                // Do some post column content processing
                AfterColumnChangeProcessing(columnSpec, column);
            }
        }

        public void OpenEditColumn(ColumnSpec spec)
        {
            var form = new ColumnProperties(_columnMapping.Values.ToList(), spec);
            form.LoadSpec(spec);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var updatedSpec = form.GenerateSpec();
                var kv = _columnMapping.First(m => m.Value == spec);
                _columnMapping[kv.Key] = updatedSpec;
                kv.Key.Name = updatedSpec.Name;
                kv.Key.HeaderText = updatedSpec.Name;

                // Add additional brackets if the column is not exported
                if (updatedSpec.NoExport)
                    kv.Key.HeaderText = "[" + kv.Key.HeaderText + "]";

                // Do some post column content processing
                AfterColumnChangeProcessing(updatedSpec, kv.Key);
            }
        }

        public void JumpToNewRow()
        {
            dataGridView.JumpToNewRow();
        }

        public void RefreshGridDependencies()
        {
            // Refresh all combo boxes
            foreach (var columnSpec in _columnMapping.Values)
                RefreshGridDependencies(columnSpec);
        }

        public void RefreshGridDependencies(ColumnSpec columnSpec)
        {
            var column = _columnMapping.First(m => m.Value == columnSpec).Key as DataGridViewComboBoxColumn;

            // Check if this column is used for relations.
            if (columnSpec.Behavior != FieldBehavior.Relation || columnSpec.RelationSpecification == null || column == null)
                return;

            // Try get the object set. If not found, do nothing.
            var tableSet = ApplicationState.Instance.CurrentDataSet.FirstOrDefault(o => o.Specification.Guid == columnSpec.RelationSpecification.SourceTable);
            if (tableSet == null)
                return;

            // Get the assigned value and display column indexes.
            var lookupColumn = tableSet.Content.Columns.FindIndex(c => c.Guid == columnSpec.RelationSpecification.LookupColumn);
            var displayColumn = tableSet.Content.Columns.FindIndex(c => c.Guid == columnSpec.RelationSpecification.DisplayColumn);

            bool hasErrors = false;

            // Check if the value can be found. If not, show the original ID without any source.
            if (lookupColumn == null)
            {
                hasErrors = true;
                var uniqueIds = new HashSet<object>();
                foreach (var cell in dataGridView.FindCellsForColumn(column.Index).Where(c => !c.OwningRow.IsNewRow))
                    uniqueIds.Add(cell.Value);
                column.Items.Clear();
                uniqueIds.Select(r => new ComboBoxElement(r, r)).ForEach(r => column.Items.Add(r));
            }
            // Check if the display can be found. If not, show the value column.
            else if (displayColumn == null)
            {
                hasErrors = true;
                displayColumn = lookupColumn;
            }

            // Show some markup if the column has errors
            if (hasErrors)
            {
                column.DefaultCellStyle = CellStyles.ErrorStyle;
                column.HeaderText = column.Name + " (BINDING ERROR)";
            }
            else
            {
                column.DefaultCellStyle = null;
                column.HeaderText = column.Name;

                // Add additional brackets if the column is not exported
                if (columnSpec.NoExport)
                    column.HeaderText = "[" + column.HeaderText + "]";

            }

            // Add the items to the drop down list if it has a proper data source.
            if (lookupColumn != null)
            {
                column.Items.Clear();
                tableSet.Content.Rows.Select(r => new ComboBoxElement(r[lookupColumn.Value], r[displayColumn.Value]))
                    .ForEach(r => column.Items.Add(r));
            }
        }

        private void AfterColumnChangeProcessing(ColumnSpec columnSpec, DataGridViewColumn column)
        {
            // Load the relation if possible
            RefreshGridDependencies(columnSpec);

            // Validate the new cells
            foreach (var cell in dataGridView.FindCellsForColumn(column.Index))
            {
                cell.ErrorText = null;

                if (cell.OwningRow.IsNewRow) continue;
                ValidateCell(cell, columnSpec);
            }
            ValidateUniquenessForColumn(column, columnSpec);
        }


        private void ValidateCell(DataGridViewCell cell, ColumnSpec columnSpec = null)
        {
            ColumnSpec spec = columnSpec;
            if (columnSpec == null && !_columnMapping.TryGetValue(cell.OwningColumn, out spec))
                return;

            var value = cell.Value?.ToString();
            var validator = DataValidatorFactory.Create(spec.Type);

            if (!spec.AllowNull && spec.Behavior != FieldBehavior.Generated && value == null)
                cell.ErrorText = "The value cannot be NULL.";
            else if (validator != null && spec.Behavior == FieldBehavior.None && !validator.Validate(value))
                cell.ErrorText = "The value is not in the correct format.";
        }

        private void ValidateUniquenessForColumn(DataGridViewColumn column, ColumnSpec columnSpec = null)
        {
            ColumnSpec spec = columnSpec;
            if (columnSpec == null && !_columnMapping.TryGetValue(column, out spec) || !spec.MustBeUnique || spec.Behavior == FieldBehavior.Generated)
                return;

            var lookup = new Dictionary<string, List<DataGridViewCell>>();
            foreach (var cell in dataGridView.FindCellsForColumn(column.Index))
            {
                var key = cell.Value?.ToString() ?? string.Empty;

                List<DataGridViewCell> result;
                if (!lookup.TryGetValue(key, out result))
                    lookup.Add(key, result = new List<DataGridViewCell>());
                result.Add(cell);
            }
            foreach (var cell in lookup.Values.Where(l => l.Count > 1).SelectMany(i => i))
                cell.ErrorText = "The value is not unique in this field";
        }

        private async Task GenerateDefaultDataForCell(DataGridViewCell cell, ColumnSpec columnSpec = null)
        {
            // Apply the new value only once, otherwise it keeps refreshing when the selection is on the new row.
            if (cell.Value != null) return;

            ColumnSpec spec = columnSpec;
            if (columnSpec == null && !_columnMapping.TryGetValue(cell.OwningColumn, out spec))
                return;

            if (spec.DefaultDataProvider != null)
                cell.Value = await spec.DefaultDataProvider.GenerateAsync();
        }

        private DataGridViewColumn CreateColumn(ColumnSpec columnInfo, int insertAtIndex)
        {
            DataGridViewColumn gridColumn;

            // Pick proper column type
            switch (columnInfo.Behavior)
            {
                case FieldBehavior.Relation:
                    gridColumn = new DataGridViewComboBoxColumn
                    {
                        DisplayStyleForCurrentCellOnly = true,
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                        DisplayMember = "Display",
                        ValueMember = "Value",
                        Sorted = true
                    };
                    break;
                case FieldBehavior.RazorTemplate:
                    gridColumn = new DataGridViewTypedVariableColumn();
                    gridColumn.ReadOnly = true;
                    gridColumn.CellTemplate.Style = CellStyles.TemplateStyle;
                    break;
                case FieldBehavior.Generated:
                    gridColumn = new DataGridViewTextBoxColumn();
                    gridColumn.ReadOnly = true;
                    gridColumn.Width = gridColumn.Width / 2;
                    break;
                default:
                    gridColumn = new DataGridViewTextBoxColumn();
                    break;
            };

            if (columnInfo.Type == FieldType.Raw && columnInfo.Behavior == FieldBehavior.None)
                gridColumn.CellTemplate.Style = CellStyles.RawStyle;

            gridColumn.Name = columnInfo.Name;
            gridColumn.HeaderText = columnInfo.Name;
            gridColumn.DisplayIndex = insertAtIndex;
            gridColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

            // Add additional brackets if the column is not exported
            if (columnInfo.NoExport)
                gridColumn.HeaderText = "[" + gridColumn.HeaderText + "]";
            return gridColumn;
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var addColumn = dataGridView.Columns[0];
            if (e.ColumnIndex == addColumn.Index)
            {
                OpenAddNewColumn();
            }
            else if (e.Button == MouseButtons.Right)
            {
                _contentMenuOpenedFor = dataGridView.Columns[e.ColumnIndex];
                cmenuColumns.Show(Control.MousePosition);
            }
        }

        private void cmenuItemEdit_Click(object sender, EventArgs e)
        {
            var columnSpec = _columnMapping[_contentMenuOpenedFor];
            OpenEditColumn(columnSpec);
        }

        private void cmenuItemDelete_Click(object sender, EventArgs e)
        {
            var columnSpec = _columnMapping[_contentMenuOpenedFor];

            if (MessageBox.Show("Are you sure to remove the " + columnSpec.Name + " column?\r\n\r\nThis action cannot be undone!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _columnMapping.Remove(_contentMenuOpenedFor);
            dataGridView.Columns.Remove(_contentMenuOpenedFor);
        }

        private async void cmenuItemRegenerate_Click(object sender, EventArgs e)
        {
            var columnSpec = _columnMapping[_contentMenuOpenedFor];

            if (MessageBox.Show("Are you sure want to generate all data in the " + columnSpec.Name + " column?\r\nAll containing data is truncated.\r\n\r\nThis action cannot be undone!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (var cell in dataGridView.FindCellsForColumn(_contentMenuOpenedFor.Index))
                await GenerateDefaultDataForCell(cell, columnSpec);
        }

        private async void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewCell cell in e.Row.Cells)
                await GenerateDefaultDataForCell(cell);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var spec = _columnMapping[dataGridView.Columns[e.ColumnIndex]];

            object value = cell.Value;
            // If error in dropdown, show the error message
            if (cell is DataGridViewComboBoxCell)
            {
                var comboCell = cell as DataGridViewComboBoxCell;
                var errorElement = comboCell.Items.OfType<ComboBoxErrorElement>().FirstOrDefault(item => item.Value == value);
                if (errorElement != null)
                    cell.ErrorText = errorElement.ErrorMessage;
            }

            // Check if the input is " ". Is so, use an empty string as value.
            if (spec.AllowNull && cell.Value?.ToString() == " ")
                value = string.Empty;
            // Check if the input is "NULL". Is so, use a null value is allowed.
            else if (spec.AllowNull && cell.Value?.ToString() == "NULL")
                value = null;

            if (dataGridView.SelectedCells.Count != 1 || (dataGridView.SelectedCells[0].RowIndex == e.RowIndex && dataGridView.SelectedCells[0].ColumnIndex == e.ColumnIndex))
            {
                foreach (DataGridViewCell selectedCell in dataGridView.SelectedCells)
                {
                    // Only in the current column, because of the possible type difference.
                    if (selectedCell.ColumnIndex != e.ColumnIndex) continue;

                    SetCellValue(selectedCell, value);
                }
            }

            // Validate the cell for validity.
            ValidateUniquenessForColumn(dataGridView.Columns[e.ColumnIndex]);
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Do not change the style if the value is not NULL, not for the ADD column and not if the cell is in edit mode.
            if (e.Value != null || e.ColumnIndex == AddField.Index || dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                return;

            e.CellStyle.ForeColor = Color.Gray;
            e.CellStyle.Font = _italicFont ?? (_italicFont = new Font(e.CellStyle.Font, FontStyle.Italic));

            var behavior = _columnMapping[dataGridView.Columns[e.ColumnIndex]].Behavior;

            // Apply value for generated data
            if (behavior == FieldBehavior.Generated)
                e.CellStyle.NullValue = "GENERATED";
            else
                e.CellStyle.NullValue = "NULL";
        }

        private void cmenuColumns_Opening(object sender, CancelEventArgs e)
        {
            var spec = _columnMapping[_contentMenuOpenedFor];
            cmenuItemRegenerate.Enabled = spec.DefaultDataProvider != null;
        }

        private void SetCellValue(DataGridViewCell cell, object value)
        {
            this.dataGridView.SetCellValue(cell, value);
            ValidateCell(cell);
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Prevent a double click on the row header.
            if (e.ColumnIndex < 0) return;

            // Open the settings of the razor template.
            var columnSpec = _columnMapping[dataGridView.Columns[e.ColumnIndex]];
            if (columnSpec.Behavior == FieldBehavior.RazorTemplate && (columnSpec.TemplateSpecification?.DefaultVariables?.Count ?? 0) > 0)
            {
                var currentCell = dataGridView.CurrentCell;
                var cellList = currentCell.Value as IList<TypedVariable>;
                var all = TypedVariableHelper.Merge(columnSpec.TemplateSpecification.DefaultVariables, cellList);

                var form = new RazorLocalParamsForm();
                form.ReadOnlyName = true;
                form.LoadData(all);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentCell.Value = form.CurrentVariables;
                }
            }
        }
    }
}
