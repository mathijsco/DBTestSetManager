namespace DatabaseTestSetManager.Win.UI.Controls
{
    partial class DefaultValueConfiguration
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
            this.panelDefaultValuePlaceholder = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDefaultValueSource = new System.Windows.Forms.ComboBox();
            this.groupOuter = new System.Windows.Forms.GroupBox();
            this.chkEnableValue = new System.Windows.Forms.CheckBox();
            this.groupOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDefaultValuePlaceholder
            // 
            this.panelDefaultValuePlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDefaultValuePlaceholder.Location = new System.Drawing.Point(6, 46);
            this.panelDefaultValuePlaceholder.Name = "panelDefaultValuePlaceholder";
            this.panelDefaultValuePlaceholder.Size = new System.Drawing.Size(432, 115);
            this.panelDefaultValuePlaceholder.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Value source";
            // 
            // cmbDefaultValueSource
            // 
            this.cmbDefaultValueSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultValueSource.FormattingEnabled = true;
            this.cmbDefaultValueSource.Location = new System.Drawing.Point(125, 19);
            this.cmbDefaultValueSource.Name = "cmbDefaultValueSource";
            this.cmbDefaultValueSource.Size = new System.Drawing.Size(150, 21);
            this.cmbDefaultValueSource.TabIndex = 3;
            this.cmbDefaultValueSource.SelectedIndexChanged += new System.EventHandler(this.cmbDefaultValueSource_SelectedIndexChanged);
            // 
            // groupOuter
            // 
            this.groupOuter.Controls.Add(this.cmbDefaultValueSource);
            this.groupOuter.Controls.Add(this.panelDefaultValuePlaceholder);
            this.groupOuter.Controls.Add(this.label3);
            this.groupOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOuter.Location = new System.Drawing.Point(0, 0);
            this.groupOuter.Name = "groupOuter";
            this.groupOuter.Size = new System.Drawing.Size(444, 167);
            this.groupOuter.TabIndex = 6;
            this.groupOuter.TabStop = false;
            // 
            // chkEnableValue
            // 
            this.chkEnableValue.AutoSize = true;
            this.chkEnableValue.Location = new System.Drawing.Point(9, 0);
            this.chkEnableValue.Name = "chkEnableValue";
            this.chkEnableValue.Size = new System.Drawing.Size(109, 17);
            this.chkEnableValue.TabIndex = 6;
            this.chkEnableValue.Text = "Has default value";
            this.chkEnableValue.UseVisualStyleBackColor = true;
            this.chkEnableValue.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DefaultValueConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkEnableValue);
            this.Controls.Add(this.groupOuter);
            this.Name = "DefaultValueConfiguration";
            this.Size = new System.Drawing.Size(444, 167);
            this.groupOuter.ResumeLayout(false);
            this.groupOuter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDefaultValuePlaceholder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDefaultValueSource;
        private System.Windows.Forms.GroupBox groupOuter;
        private System.Windows.Forms.CheckBox chkEnableValue;
    }
}
