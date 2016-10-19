namespace DatabaseTestSetManager.Win.UI
{
    partial class ColumnProperties
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
            DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders.StaticDataProvider staticDataProvider1 = new DatabaseTestSetManager.Lib.DataHandlers.DefaultDataProviders.StaticDataProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkMustBeUnique = new System.Windows.Forms.CheckBox();
            this.chkAllowNull = new System.Windows.Forms.CheckBox();
            this.panelAdditionalOptions = new System.Windows.Forms.Panel();
            this.defaultValueConfiguration = new DatabaseTestSetManager.Win.UI.Controls.DefaultValueConfiguration();
            this.templateConfiguration = new DatabaseTestSetManager.Win.UI.Controls.TemplateConfiguration();
            this.relationConfiguration = new DatabaseTestSetManager.Win.UI.Controls.RelationConfiguration();
            this.sharedTemplateConfiguration = new DatabaseTestSetManager.Win.UI.Controls.SharedTemplateConfiguration();
            this.chkExcludeFromExport = new System.Windows.Forms.CheckBox();
            this.cmbBehavior = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customBehaviorConfiguration = new DatabaseTestSetManager.Win.UI.Controls.CustomBehaviorConfiguration();
            this.panelAdditionalOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Column name";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(316, 346);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(397, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(105, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(105, 38);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(150, 21);
            this.cmbType.TabIndex = 3;
            // 
            // chkMustBeUnique
            // 
            this.chkMustBeUnique.AutoSize = true;
            this.chkMustBeUnique.Location = new System.Drawing.Point(289, 37);
            this.chkMustBeUnique.Name = "chkMustBeUnique";
            this.chkMustBeUnique.Size = new System.Drawing.Size(155, 17);
            this.chkMustBeUnique.TabIndex = 7;
            this.chkMustBeUnique.Text = "Only unique values allowed";
            this.chkMustBeUnique.UseVisualStyleBackColor = true;
            this.chkMustBeUnique.CheckedChanged += new System.EventHandler(this.chkMustBeUnique_CheckedChanged);
            // 
            // chkAllowNull
            // 
            this.chkAllowNull.AutoSize = true;
            this.chkAllowNull.Checked = true;
            this.chkAllowNull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllowNull.Location = new System.Drawing.Point(289, 14);
            this.chkAllowNull.Name = "chkAllowNull";
            this.chkAllowNull.Size = new System.Drawing.Size(82, 17);
            this.chkAllowNull.TabIndex = 6;
            this.chkAllowNull.Text = "Allow NULL";
            this.chkAllowNull.UseVisualStyleBackColor = true;
            // 
            // panelAdditionalOptions
            // 
            this.panelAdditionalOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAdditionalOptions.Controls.Add(this.defaultValueConfiguration);
            this.panelAdditionalOptions.Controls.Add(this.templateConfiguration);
            this.panelAdditionalOptions.Controls.Add(this.relationConfiguration);
            this.panelAdditionalOptions.Controls.Add(this.sharedTemplateConfiguration);
            this.panelAdditionalOptions.Controls.Add(this.customBehaviorConfiguration);
            this.panelAdditionalOptions.Location = new System.Drawing.Point(12, 92);
            this.panelAdditionalOptions.Name = "panelAdditionalOptions";
            this.panelAdditionalOptions.Size = new System.Drawing.Size(460, 252);
            this.panelAdditionalOptions.TabIndex = 7;
            // 
            // defaultValueConfiguration
            // 
            this.defaultValueConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultValueConfiguration.HasDefaultValue = false;
            this.defaultValueConfiguration.Location = new System.Drawing.Point(0, 0);
            this.defaultValueConfiguration.Name = "defaultValueConfiguration";
            this.defaultValueConfiguration.SelectedDataType = DatabaseTestSetManager.Lib.Models.DefaultDataType.Static;
            this.defaultValueConfiguration.Size = new System.Drawing.Size(460, 252);
            this.defaultValueConfiguration.SupportDefaultValue = true;
            this.defaultValueConfiguration.TabIndex = 0;
            staticDataProvider1.Value = "";
            this.defaultValueConfiguration.Value = staticDataProvider1;
            // 
            // templateConfiguration
            // 
            this.templateConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateConfiguration.Location = new System.Drawing.Point(0, 0);
            this.templateConfiguration.Name = "templateConfiguration";
            this.templateConfiguration.Size = new System.Drawing.Size(460, 252);
            this.templateConfiguration.TabIndex = 1;
            // 
            // relationConfiguration
            // 
            this.relationConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relationConfiguration.Location = new System.Drawing.Point(0, 0);
            this.relationConfiguration.Name = "relationConfiguration";
            this.relationConfiguration.Size = new System.Drawing.Size(460, 252);
            this.relationConfiguration.TabIndex = 0;
            // 
            // sharedTemplateConfiguration
            // 
            this.sharedTemplateConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharedTemplateConfiguration.Location = new System.Drawing.Point(0, 0);
            this.sharedTemplateConfiguration.Name = "sharedTemplateConfiguration";
            this.sharedTemplateConfiguration.Size = new System.Drawing.Size(460, 252);
            this.sharedTemplateConfiguration.TabIndex = 2;
            // 
            // chkExcludeFromExport
            // 
            this.chkExcludeFromExport.AutoSize = true;
            this.chkExcludeFromExport.Location = new System.Drawing.Point(289, 60);
            this.chkExcludeFromExport.Name = "chkExcludeFromExport";
            this.chkExcludeFromExport.Size = new System.Drawing.Size(119, 17);
            this.chkExcludeFromExport.TabIndex = 8;
            this.chkExcludeFromExport.Text = "Exclude from export";
            this.chkExcludeFromExport.UseVisualStyleBackColor = true;
            // 
            // cmbBehavior
            // 
            this.cmbBehavior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBehavior.FormattingEnabled = true;
            this.cmbBehavior.Location = new System.Drawing.Point(105, 65);
            this.cmbBehavior.Name = "cmbBehavior";
            this.cmbBehavior.Size = new System.Drawing.Size(150, 21);
            this.cmbBehavior.TabIndex = 5;
            this.cmbBehavior.SelectedIndexChanged += new System.EventHandler(this.cmbBehavior_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Behavior";
            // 
            // customBehaviorConfiguration
            // 
            this.customBehaviorConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customBehaviorConfiguration.Location = new System.Drawing.Point(0, 0);
            this.customBehaviorConfiguration.Name = "customBehaviorConfiguration";
            this.customBehaviorConfiguration.Size = new System.Drawing.Size(460, 252);
            this.customBehaviorConfiguration.TabIndex = 3;
            // 
            // ColumnProperties
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 381);
            this.Controls.Add(this.cmbBehavior);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkExcludeFromExport);
            this.Controls.Add(this.panelAdditionalOptions);
            this.Controls.Add(this.chkAllowNull);
            this.Controls.Add(this.chkMustBeUnique);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "ColumnProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new column";
            this.panelAdditionalOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkMustBeUnique;
        private System.Windows.Forms.CheckBox chkAllowNull;
        private Controls.RelationConfiguration relationConfiguration;
        private Controls.DefaultValueConfiguration defaultValueConfiguration;
        private System.Windows.Forms.Panel panelAdditionalOptions;
        private Controls.TemplateConfiguration templateConfiguration;
        private System.Windows.Forms.CheckBox chkExcludeFromExport;
        private System.Windows.Forms.ComboBox cmbBehavior;
        private System.Windows.Forms.Label label3;
        private Controls.SharedTemplateConfiguration sharedTemplateConfiguration;
        private Controls.CustomBehaviorConfiguration customBehaviorConfiguration;
    }
}