namespace DatabaseTestSetManager.Win.UI.Controls
{
    partial class TemplateConfiguration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControls = new System.Windows.Forms.TabControl();
            this.tabCompose = new System.Windows.Forms.TabPage();
            this.splitContainerOuter = new System.Windows.Forms.SplitContainer();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.treeModelExplorer = new System.Windows.Forms.TreeView();
            this.imageListNodes = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnWordWrap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnManageVariables = new System.Windows.Forms.ToolStripButton();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.chkTrimWhitespaces = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControls.SuspendLayout();
            this.tabCompose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOuter)).BeginInit();
            this.splitContainerOuter.Panel1.SuspendLayout();
            this.splitContainerOuter.Panel2.SuspendLayout();
            this.splitContainerOuter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControls);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template specification";
            // 
            // tabControls
            // 
            this.tabControls.Controls.Add(this.tabCompose);
            this.tabControls.Controls.Add(this.tabOutput);
            this.tabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControls.Location = new System.Drawing.Point(3, 16);
            this.tabControls.Name = "tabControls";
            this.tabControls.SelectedIndex = 0;
            this.tabControls.Size = new System.Drawing.Size(494, 223);
            this.tabControls.TabIndex = 3;
            this.tabControls.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControls_Selected);
            // 
            // tabCompose
            // 
            this.tabCompose.Controls.Add(this.splitContainerOuter);
            this.tabCompose.Controls.Add(this.toolStrip1);
            this.tabCompose.Location = new System.Drawing.Point(4, 22);
            this.tabCompose.Name = "tabCompose";
            this.tabCompose.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompose.Size = new System.Drawing.Size(486, 197);
            this.tabCompose.TabIndex = 0;
            this.tabCompose.Text = "Compose";
            this.tabCompose.UseVisualStyleBackColor = true;
            // 
            // splitContainerOuter
            // 
            this.splitContainerOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOuter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerOuter.Location = new System.Drawing.Point(3, 28);
            this.splitContainerOuter.Name = "splitContainerOuter";
            // 
            // splitContainerOuter.Panel1
            // 
            this.splitContainerOuter.Panel1.Controls.Add(this.txtTemplate);
            // 
            // splitContainerOuter.Panel2
            // 
            this.splitContainerOuter.Panel2.Controls.Add(this.treeModelExplorer);
            this.splitContainerOuter.Panel2.Controls.Add(this.chkTrimWhitespaces);
            this.splitContainerOuter.Size = new System.Drawing.Size(480, 166);
            this.splitContainerOuter.SplitterDistance = 290;
            this.splitContainerOuter.TabIndex = 2;
            // 
            // txtTemplate
            // 
            this.txtTemplate.AcceptsReturn = true;
            this.txtTemplate.AcceptsTab = true;
            this.txtTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTemplate.HideSelection = false;
            this.txtTemplate.Location = new System.Drawing.Point(0, 0);
            this.txtTemplate.MaxLength = 1048576;
            this.txtTemplate.Multiline = true;
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTemplate.Size = new System.Drawing.Size(290, 166);
            this.txtTemplate.TabIndex = 0;
            this.txtTemplate.WordWrap = false;
            // 
            // treeModelExplorer
            // 
            this.treeModelExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeModelExplorer.ImageIndex = 0;
            this.treeModelExplorer.ImageList = this.imageListNodes;
            this.treeModelExplorer.Location = new System.Drawing.Point(0, 0);
            this.treeModelExplorer.Name = "treeModelExplorer";
            this.treeModelExplorer.PathSeparator = ".";
            this.treeModelExplorer.SelectedImageIndex = 0;
            this.treeModelExplorer.Size = new System.Drawing.Size(186, 126);
            this.treeModelExplorer.TabIndex = 1;
            this.treeModelExplorer.DoubleClick += new System.EventHandler(this.treeModelExplorer_DoubleClick);
            // 
            // imageListNodes
            // 
            this.imageListNodes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListNodes.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListNodes.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnWordWrap,
            this.toolStripSeparator1,
            this.tbtnManageVariables});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(480, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnWordWrap
            // 
            this.tbtnWordWrap.Image = global::DatabaseTestSetManager.Win.Properties.Resources.WordWrap;
            this.tbtnWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnWordWrap.Name = "tbtnWordWrap";
            this.tbtnWordWrap.Size = new System.Drawing.Size(85, 22);
            this.tbtnWordWrap.Text = "Word wrap";
            this.tbtnWordWrap.Click += new System.EventHandler(this.tbtnWordWrap_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnManageVariables
            // 
            this.tbtnManageVariables.Image = global::DatabaseTestSetManager.Win.Properties.Resources.VariablesWindow;
            this.tbtnManageVariables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnManageVariables.Name = "tbtnManageVariables";
            this.tbtnManageVariables.Size = new System.Drawing.Size(160, 22);
            this.tbtnManageVariables.Text = "Manage local parameters";
            this.tbtnManageVariables.Click += new System.EventHandler(this.tbtnManageVariables_Click);
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.txtOutput);
            this.tabOutput.Location = new System.Drawing.Point(4, 22);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabOutput.Size = new System.Drawing.Size(486, 197);
            this.tabOutput.TabIndex = 1;
            this.tabOutput.Text = "Output";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.MaxLength = 10485760;
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(480, 191);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // chkTrimWhitespaces
            // 
            this.chkTrimWhitespaces.Checked = true;
            this.chkTrimWhitespaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrimWhitespaces.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chkTrimWhitespaces.Location = new System.Drawing.Point(0, 126);
            this.chkTrimWhitespaces.Name = "chkTrimWhitespaces";
            this.chkTrimWhitespaces.Size = new System.Drawing.Size(186, 40);
            this.chkTrimWhitespaces.TabIndex = 2;
            this.chkTrimWhitespaces.Text = "Trim leading and trailing whitespaces and line breaks.";
            this.chkTrimWhitespaces.UseVisualStyleBackColor = true;
            // 
            // TemplateConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TemplateConfiguration";
            this.Size = new System.Drawing.Size(500, 242);
            this.groupBox1.ResumeLayout(false);
            this.tabControls.ResumeLayout(false);
            this.tabCompose.ResumeLayout(false);
            this.tabCompose.PerformLayout();
            this.splitContainerOuter.Panel1.ResumeLayout(false);
            this.splitContainerOuter.Panel1.PerformLayout();
            this.splitContainerOuter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOuter)).EndInit();
            this.splitContainerOuter.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabOutput.ResumeLayout(false);
            this.tabOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.TreeView treeModelExplorer;
        private System.Windows.Forms.ImageList imageListNodes;
        private System.Windows.Forms.SplitContainer splitContainerOuter;
        private System.Windows.Forms.TabControl tabControls;
        private System.Windows.Forms.TabPage tabCompose;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnWordWrap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbtnManageVariables;
        private System.Windows.Forms.CheckBox chkTrimWhitespaces;
    }
}
