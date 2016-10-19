namespace DatabaseTestSetManager.Win.UI.Controls
{
    partial class ContentSetGrid
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new DatabaseTestSetManager.Win.UI.DataGridModules.ExtensibleDataGridView();
            this.AddField = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmenuColumns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmenuItemRegenerate = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.cmenuColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddField});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(486, 306);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            this.dataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_DefaultValuesNeeded);
            // 
            // AddField
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.AddField.DefaultCellStyle = dataGridViewCellStyle1;
            this.AddField.HeaderText = "+";
            this.AddField.Name = "AddField";
            this.AddField.ReadOnly = true;
            this.AddField.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AddField.Width = 30;
            // 
            // cmenuColumns
            // 
            this.cmenuColumns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuItemEdit,
            this.cmenuItemDelete,
            this.toolStripMenuItem1,
            this.cmenuItemRegenerate});
            this.cmenuColumns.Name = "cmenuColumns";
            this.cmenuColumns.Size = new System.Drawing.Size(175, 76);
            this.cmenuColumns.Opening += new System.ComponentModel.CancelEventHandler(this.cmenuColumns_Opening);
            // 
            // cmenuItemEdit
            // 
            this.cmenuItemEdit.Name = "cmenuItemEdit";
            this.cmenuItemEdit.Size = new System.Drawing.Size(174, 22);
            this.cmenuItemEdit.Text = "Edit...";
            this.cmenuItemEdit.Click += new System.EventHandler(this.cmenuItemEdit_Click);
            // 
            // cmenuItemDelete
            // 
            this.cmenuItemDelete.Name = "cmenuItemDelete";
            this.cmenuItemDelete.Size = new System.Drawing.Size(174, 22);
            this.cmenuItemDelete.Text = "Delete...";
            this.cmenuItemDelete.Click += new System.EventHandler(this.cmenuItemDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // cmenuItemRegenerate
            // 
            this.cmenuItemRegenerate.Name = "cmenuItemRegenerate";
            this.cmenuItemRegenerate.Size = new System.Drawing.Size(174, 22);
            this.cmenuItemRegenerate.Text = "Regenerate all data";
            this.cmenuItemRegenerate.Click += new System.EventHandler(this.cmenuItemRegenerate_Click);
            // 
            // ContentSetGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Name = "ContentSetGrid";
            this.Size = new System.Drawing.Size(486, 306);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.cmenuColumns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DatabaseTestSetManager.Win.UI.DataGridModules.ExtensibleDataGridView dataGridView;
        private System.Windows.Forms.ContextMenuStrip cmenuColumns;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemEdit;
        private System.Windows.Forms.DataGridViewLinkColumn AddField;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemRegenerate;
    }
}
