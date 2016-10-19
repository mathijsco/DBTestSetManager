using DatabaseTestSetManager.Win.UI.DataGridModules;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DatabaseTestSetManager.Win.UI.Controls.Modules.DataGridModules
{
    public class CopyPastModule : IControlModule<ExtensibleDataGridView>
    {
        public ExtensibleDataGridView Control { get; set; }

        public void Register()
        {
            this.Control.KeyDown += Grid_KeyDown;
        }

        public void Unregister()
        {
            this.Control.KeyDown -= Grid_KeyDown;
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled) return;

            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V && Clipboard.ContainsText())
            {
                e.Handled = TryPaste();
            }
        }

        private bool TryPaste()
        {
            try
            {
                var text = Clipboard.GetText(TextDataFormat.Text);

                int minX = int.MaxValue,
                    minY = int.MaxValue,
                    maxX = 0,
                    maxY = 0;

                // Get the minimum and maximum positions of the selection.
                this.Control.SelectedCells.Cast<DataGridViewCell>().ForEach(c =>
                {
                    minX = Math.Min(minX, c.ColumnIndex);
                    minY = Math.Min(minY, c.RowIndex);
                    maxX = Math.Max(maxX, c.ColumnIndex);
                    maxY = Math.Max(maxY, c.RowIndex);
                });

                var selectionColumnCount = maxX - minX + 1;
                var selectionRowCount = maxY - minY + 1;

                // Past the raw text to the current cell
                if (selectionColumnCount == 1 && selectionRowCount == 1)
                {
                    this.Control.SetCellValue(this.Control.CurrentCell, text);
                }
                else
                {
                    // Process the content of the clipboard by splitten on ENTER and TAB.
                    var lines = Regex.Split(text.TrimEnd('\r', '\n'), @"\r?\n");
                    var allBlocks = new string[lines.Length][];
                    lines.ForEach((line, i) => allBlocks[i] = line.Split('\t'));

                    var clipboardRowCount = lines.Length;
                    var clipboardColumnCount = allBlocks[0].Length;

                    // Check if the selection is correct.
                    if ((clipboardColumnCount != 1 && selectionColumnCount != clipboardColumnCount)
                        || (clipboardRowCount != 1 && selectionRowCount != clipboardRowCount))
                    {
                        MessageBox.Show("The selection does not match the column count of the matrix on the clipboard.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    // Apply the ranges to the cells
                    foreach (DataGridViewCell cell in this.Control.SelectedCells)
                    {
                        var x = (cell.ColumnIndex - minX) % clipboardColumnCount;
                        var y = (cell.RowIndex - minY) % clipboardRowCount;
                        this.Control.SetCellValue(cell, allBlocks[y][x]);
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Trace.TraceError(ex.ToString());
                MessageBox.Show("Cannot paste the content of the clipboard.\r\nThe data is not a proper matrix.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return true;
        }

    }
}
