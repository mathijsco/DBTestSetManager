namespace DatabaseTestSetManager.Win.UI.Controls
{
    partial class TableManagementTabs
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
            this.tabObjects = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.cmenuTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabObjects.SuspendLayout();
            this.cmenuTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabObjects
            // 
            this.tabObjects.Controls.Add(this.tabAdd);
            this.tabObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabObjects.Location = new System.Drawing.Point(0, 0);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.SelectedIndex = 0;
            this.tabObjects.Size = new System.Drawing.Size(547, 413);
            this.tabObjects.TabIndex = 1;
            this.tabObjects.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabObjects_Selecting);
            this.tabObjects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabObjects_MouseClick);
            // 
            // tabAdd
            // 
            this.tabAdd.Location = new System.Drawing.Point(4, 22);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(539, 387);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "+";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // cmenuTabs
            // 
            this.cmenuTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuItemEdit,
            this.cmenuItemDelete});
            this.cmenuTabs.Name = "cmenuTabs";
            this.cmenuTabs.Size = new System.Drawing.Size(117, 48);
            // 
            // cmenuItemEdit
            // 
            this.cmenuItemEdit.Name = "cmenuItemEdit";
            this.cmenuItemEdit.Size = new System.Drawing.Size(116, 22);
            this.cmenuItemEdit.Text = "Edit...";
            this.cmenuItemEdit.Click += new System.EventHandler(this.cmenuItemEdit_Click);
            // 
            // cmenuItemDelete
            // 
            this.cmenuItemDelete.Name = "cmenuItemDelete";
            this.cmenuItemDelete.Size = new System.Drawing.Size(116, 22);
            this.cmenuItemDelete.Text = "Delete...";
            this.cmenuItemDelete.Click += new System.EventHandler(this.cmenuItemDelete_Click);
            // 
            // ObjectManagementTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabObjects);
            this.Name = "ObjectManagementTabs";
            this.Size = new System.Drawing.Size(547, 413);
            this.tabObjects.ResumeLayout(false);
            this.cmenuTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabObjects;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.ContextMenuStrip cmenuTabs;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem cmenuItemDelete;
    }
}
