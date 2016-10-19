namespace DatabaseTestSetManager.Win.UI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.menuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProject = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuWhiteboard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSharedTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbtnAddField = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtbAddObject = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnGenerateRows = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnAddNewTable = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddNewColumn = new System.Windows.Forms.ToolStripButton();
            this.tbtnAddNewRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnGenerate = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbtnGenerateSql = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnGenerateCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnGenerateJson = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSelectedCells = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.objectManagementTabs = new DatabaseTestSetManager.Win.UI.Controls.TableManagementTabs();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.toolStripLogs = new System.Windows.Forms.ToolStrip();
            this.tbtnCloseLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnClearLog = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuProject,
            this.toolStripSeparator5,
            this.tbtnOpen,
            this.tbtnSave,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.tbtnGenerateRows,
            this.toolStripSeparator2,
            this.tbtnAddNewTable,
            this.tbtnAddNewColumn,
            this.tbtnAddNewRow,
            this.toolStripSeparator3,
            this.tbtnGenerate});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip.Size = new System.Drawing.Size(805, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // menuFile
            // 
            this.menuFile.AutoToolTip = false;
            this.menuFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.menuSave,
            this.menuSaveAs,
            this.toolStripMenuItem2,
            this.menuExit});
            this.menuFile.Image = ((System.Drawing.Image)(resources.GetObject("menuFile.Image")));
            this.menuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFile.Name = "menuFile";
            this.menuFile.ShowDropDownArrow = false;
            this.menuFile.Size = new System.Drawing.Size(29, 22);
            this.menuFile.Text = "&File";
            // 
            // menuNew
            // 
            this.menuNew.Name = "menuNew";
            this.menuNew.Size = new System.Drawing.Size(155, 22);
            this.menuNew.Text = "New";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(155, 22);
            this.menuOpen.Text = "Open...";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuSave
            // 
            this.menuSave.Image = global::DatabaseTestSetManager.Win.Properties.Resources.Save;
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(155, 22);
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(155, 22);
            this.menuSaveAs.Text = "Save as...";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(155, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuProject
            // 
            this.menuProject.AutoToolTip = false;
            this.menuProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWhiteboard,
            this.menuSharedTemplates});
            this.menuProject.Image = ((System.Drawing.Image)(resources.GetObject("menuProject.Image")));
            this.menuProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuProject.Name = "menuProject";
            this.menuProject.ShowDropDownArrow = false;
            this.menuProject.Size = new System.Drawing.Size(48, 22);
            this.menuProject.Text = "&Project";
            // 
            // menuWhiteboard
            // 
            this.menuWhiteboard.Image = global::DatabaseTestSetManager.Win.Properties.Resources.VariablesWindow;
            this.menuWhiteboard.Name = "menuWhiteboard";
            this.menuWhiteboard.Size = new System.Drawing.Size(219, 22);
            this.menuWhiteboard.Text = "Manage whiteboard...";
            this.menuWhiteboard.Click += new System.EventHandler(this.menuWhiteboard_Click);
            // 
            // menuSharedTemplates
            // 
            this.menuSharedTemplates.Name = "menuSharedTemplates";
            this.menuSharedTemplates.Size = new System.Drawing.Size(219, 22);
            this.menuSharedTemplates.Text = "Manage shared templates...";
            this.menuSharedTemplates.Click += new System.EventHandler(this.menuSharedTemplates_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpen.Image = global::DatabaseTestSetManager.Win.Properties.Resources.Open;
            this.tbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tbtnOpen.Text = "Open";
            this.tbtnOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // tbtnSave
            // 
            this.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSave.Image = global::DatabaseTestSetManager.Win.Properties.Resources.Save;
            this.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tbtnSave.Text = "Save";
            this.tbtnSave.ToolTipText = "Save (CTRL+S)";
            this.tbtnSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnAddField,
            this.tbtbAddObject});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(63, 22);
            this.toolStripDropDownButton1.Text = "Hotkeys";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // tbtnAddField
            // 
            this.tbtnAddField.Name = "tbtnAddField";
            this.tbtnAddField.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tbtnAddField.Size = new System.Drawing.Size(172, 22);
            this.tbtnAddField.Text = "AddField";
            this.tbtnAddField.Click += new System.EventHandler(this.tbtnAddNewField_Click);
            // 
            // tbtbAddObject
            // 
            this.tbtbAddObject.Name = "tbtbAddObject";
            this.tbtbAddObject.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.tbtbAddObject.Size = new System.Drawing.Size(172, 22);
            this.tbtbAddObject.Text = "AddObject";
            this.tbtbAddObject.Click += new System.EventHandler(this.tbtnAddNewObject_Click);
            // 
            // tbtnGenerateRows
            // 
            this.tbtnGenerateRows.Image = global::DatabaseTestSetManager.Win.Properties.Resources.GenerateRows;
            this.tbtnGenerateRows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnGenerateRows.Name = "tbtnGenerateRows";
            this.tbtnGenerateRows.Size = new System.Drawing.Size(111, 22);
            this.tbtnGenerateRows.Text = "Generate 5 rows";
            this.tbtnGenerateRows.Click += new System.EventHandler(this.tbtnGenerateRows_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnAddNewTable
            // 
            this.tbtnAddNewTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddNewTable.Image = global::DatabaseTestSetManager.Win.Properties.Resources.AddTable;
            this.tbtnAddNewTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddNewTable.Name = "tbtnAddNewTable";
            this.tbtnAddNewTable.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddNewTable.Text = "New table";
            this.tbtnAddNewTable.ToolTipText = "New table (CTRL+T)";
            this.tbtnAddNewTable.Click += new System.EventHandler(this.tbtnAddNewObject_Click);
            // 
            // tbtnAddNewColumn
            // 
            this.tbtnAddNewColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddNewColumn.Image = global::DatabaseTestSetManager.Win.Properties.Resources.AddColumn;
            this.tbtnAddNewColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddNewColumn.Name = "tbtnAddNewColumn";
            this.tbtnAddNewColumn.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddNewColumn.Text = "New column";
            this.tbtnAddNewColumn.ToolTipText = "New column (CTRL+F)";
            this.tbtnAddNewColumn.Click += new System.EventHandler(this.tbtnAddNewField_Click);
            // 
            // tbtnAddNewRow
            // 
            this.tbtnAddNewRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnAddNewRow.Image = global::DatabaseTestSetManager.Win.Properties.Resources.AddRow;
            this.tbtnAddNewRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnAddNewRow.Name = "tbtnAddNewRow";
            this.tbtnAddNewRow.Size = new System.Drawing.Size(23, 22);
            this.tbtnAddNewRow.Text = "New row";
            this.tbtnAddNewRow.Click += new System.EventHandler(this.tbtnAddNewRow_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnGenerate
            // 
            this.tbtnGenerate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnGenerateSql,
            this.tbtnGenerateCsv,
            this.tbtnGenerateJson});
            this.tbtnGenerate.Image = global::DatabaseTestSetManager.Win.Properties.Resources.GenerateSQL;
            this.tbtnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnGenerate.Name = "tbtnGenerate";
            this.tbtnGenerate.Size = new System.Drawing.Size(115, 22);
            this.tbtnGenerate.Text = "Generate script";
            // 
            // tbtnGenerateSql
            // 
            this.tbtnGenerateSql.Name = "tbtnGenerateSql";
            this.tbtnGenerateSql.Size = new System.Drawing.Size(184, 22);
            this.tbtnGenerateSql.Text = "Microsoft SQL Server";
            this.tbtnGenerateSql.Click += new System.EventHandler(this.tbtnGenerateSql_Click);
            // 
            // tbtnGenerateCsv
            // 
            this.tbtnGenerateCsv.Name = "tbtnGenerateCsv";
            this.tbtnGenerateCsv.Size = new System.Drawing.Size(184, 22);
            this.tbtnGenerateCsv.Text = "CSV";
            this.tbtnGenerateCsv.Click += new System.EventHandler(this.tbtnGenerateCsv_Click);
            // 
            // tbtnGenerateJson
            // 
            this.tbtnGenerateJson.Enabled = false;
            this.tbtnGenerateJson.Name = "tbtnGenerateJson";
            this.tbtnGenerateJson.Size = new System.Drawing.Size(184, 22);
            this.tbtnGenerateJson.Text = "JSON";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.statusSelectedCells});
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(805, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(666, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // statusSelectedCells
            // 
            this.statusSelectedCells.Name = "statusSelectedCells";
            this.statusSelectedCells.Size = new System.Drawing.Size(85, 17);
            this.statusSelectedCells.Text = "0 cells selected";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.testset";
            this.openFileDialog.Filter = "Test set files (*.testset)|*.testset";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "*.testset";
            this.saveFileDialog.Filter = "Test set files (*.testset)|*.testset";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.objectManagementTabs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLogs);
            this.splitContainer1.Panel2.Controls.Add(this.toolStripLogs);
            this.splitContainer1.Size = new System.Drawing.Size(805, 515);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 4;
            // 
            // objectManagementTabs
            // 
            this.objectManagementTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectManagementTabs.Location = new System.Drawing.Point(0, 0);
            this.objectManagementTabs.Name = "objectManagementTabs";
            this.objectManagementTabs.Size = new System.Drawing.Size(805, 380);
            this.objectManagementTabs.TabIndex = 3;
            this.objectManagementTabs.SelectedCellsChanged += new System.EventHandler<DatabaseTestSetManager.Win.UI.EventArguments.SelectedCellsChangedEventArgs>(this.objectManagementTabs_SelectedCellsChanged);
            // 
            // txtLogs
            // 
            this.txtLogs.BackColor = System.Drawing.SystemColors.Window;
            this.txtLogs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogs.Location = new System.Drawing.Point(0, 0);
            this.txtLogs.MaxLength = 10485760;
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(781, 131);
            this.txtLogs.TabIndex = 0;
            this.txtLogs.TabStop = false;
            // 
            // toolStripLogs
            // 
            this.toolStripLogs.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStripLogs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnCloseLog,
            this.toolStripSeparator4,
            this.tbtnClearLog});
            this.toolStripLogs.Location = new System.Drawing.Point(781, 0);
            this.toolStripLogs.Name = "toolStripLogs";
            this.toolStripLogs.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripLogs.Size = new System.Drawing.Size(24, 131);
            this.toolStripLogs.TabIndex = 1;
            this.toolStripLogs.Text = "toolStrip1";
            this.toolStripLogs.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // tbtnCloseLog
            // 
            this.tbtnCloseLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnCloseLog.Image = global::DatabaseTestSetManager.Win.Properties.Resources.Close;
            this.tbtnCloseLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnCloseLog.Name = "tbtnCloseLog";
            this.tbtnCloseLog.Size = new System.Drawing.Size(21, 20);
            this.tbtnCloseLog.Text = "Close";
            this.tbtnCloseLog.Click += new System.EventHandler(this.tbtnCloseLog_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(21, 6);
            this.toolStripSeparator4.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // tbtnClearLog
            // 
            this.tbtnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnClearLog.Image = global::DatabaseTestSetManager.Win.Properties.Resources.ClearText;
            this.tbtnClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnClearLog.Name = "tbtnClearLog";
            this.tbtnClearLog.Size = new System.Drawing.Size(21, 20);
            this.tbtnClearLog.Text = "Clear output";
            this.tbtnClearLog.Click += new System.EventHandler(this.tbtnClearLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test set manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripLogs.ResumeLayout(false);
            this.toolStripLogs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private Controls.TableManagementTabs objectManagementTabs;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tbtnAddField;
        private System.Windows.Forms.ToolStripMenuItem tbtbAddObject;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnGenerateRows;
        private System.Windows.Forms.ToolStripButton tbtnAddNewTable;
        private System.Windows.Forms.ToolStripButton tbtnAddNewColumn;
        private System.Windows.Forms.ToolStripButton tbtnAddNewRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tbtnGenerate;
        private System.Windows.Forms.ToolStripMenuItem tbtnGenerateSql;
        private System.Windows.Forms.ToolStripMenuItem tbtnGenerateCsv;
        private System.Windows.Forms.ToolStripMenuItem tbtnGenerateJson;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.ToolStrip toolStripLogs;
        private System.Windows.Forms.ToolStripButton tbtnCloseLog;
        private System.Windows.Forms.ToolStripButton tbtnClearLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusSelectedCells;
        private System.Windows.Forms.ToolStripDropDownButton menuFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripDropDownButton menuProject;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuWhiteboard;
        private System.Windows.Forms.ToolStripMenuItem menuSharedTemplates;
    }
}

