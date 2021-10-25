
namespace Trowel.BspEditor.Environment.Xonotic
{
    partial class XonoticEnvironmentEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGameExe = new System.Windows.Forms.ComboBox();
            this.lblGameExe = new System.Windows.Forms.Label();
            this.lblGameDir = new System.Windows.Forms.Label();
            this.btnGameDirBrowse = new System.Windows.Forms.Button();
            this.txtGameDir = new System.Windows.Forms.TextBox();
            this.grpFgds = new System.Windows.Forms.GroupBox();
            this.lstFgds = new System.Windows.Forms.ListView();
            this.colFgdName = new System.Windows.Forms.ColumnHeader();
            this.colFgdPath = new System.Windows.Forms.ColumnHeader();
            this.cmbDefaultPointEntity = new System.Windows.Forms.ComboBox();
            this.cmbDefaultBrushEntity = new System.Windows.Forms.ComboBox();
            this.chkIncludeFgdDirectories = new System.Windows.Forms.CheckBox();
            this.cmbMapSizeOverrideHigh = new System.Windows.Forms.ComboBox();
            this.lblDefaultPointEntity = new System.Windows.Forms.Label();
            this.lblMapSizeOverrideHigh = new System.Windows.Forms.Label();
            this.btnRemoveFgd = new System.Windows.Forms.Button();
            this.cmbMapSizeOverrideLow = new System.Windows.Forms.ComboBox();
            this.lblDefaultBrushEntity = new System.Windows.Forms.Label();
            this.chkOverrideMapSize = new System.Windows.Forms.CheckBox();
            this.btnAddFgd = new System.Windows.Forms.Button();
            this.lblMapSizeOverrideLow = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpFgds.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbGameExe);
            this.groupBox1.Controls.Add(this.lblGameExe);
            this.groupBox1.Controls.Add(this.lblGameDir);
            this.groupBox1.Controls.Add(this.btnGameDirBrowse);
            this.groupBox1.Controls.Add(this.txtGameDir);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directories";
            // 
            // cmbGameExe
            // 
            this.cmbGameExe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameExe.FormattingEnabled = true;
            this.cmbGameExe.Items.AddRange(new object[] {
            "Valve"});
            this.cmbGameExe.Location = new System.Drawing.Point(245, 48);
            this.cmbGameExe.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbGameExe.Name = "cmbGameExe";
            this.cmbGameExe.Size = new System.Drawing.Size(178, 23);
            this.cmbGameExe.TabIndex = 20;
            // 
            // lblGameExe
            // 
            this.lblGameExe.Location = new System.Drawing.Point(18, 47);
            this.lblGameExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameExe.Name = "lblGameExe";
            this.lblGameExe.Size = new System.Drawing.Size(219, 23);
            this.lblGameExe.TabIndex = 19;
            this.lblGameExe.Text = "Game Executable (e.g. \'xonotic.exe\')";
            this.lblGameExe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGameDir
            // 
            this.lblGameDir.Location = new System.Drawing.Point(7, 19);
            this.lblGameDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGameDir.Name = "lblGameDir";
            this.lblGameDir.Size = new System.Drawing.Size(111, 23);
            this.lblGameDir.TabIndex = 17;
            this.lblGameDir.Text = "Game Dir";
            this.lblGameDir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnGameDirBrowse
            // 
            this.btnGameDirBrowse.Location = new System.Drawing.Point(430, 19);
            this.btnGameDirBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGameDirBrowse.Name = "btnGameDirBrowse";
            this.btnGameDirBrowse.Size = new System.Drawing.Size(86, 23);
            this.btnGameDirBrowse.TabIndex = 18;
            this.btnGameDirBrowse.Text = "Browse...";
            this.btnGameDirBrowse.UseVisualStyleBackColor = true;
            this.btnGameDirBrowse.Click += new System.EventHandler(this.BrowseGameDirectory);
            // 
            // txtGameDir
            // 
            this.txtGameDir.Location = new System.Drawing.Point(125, 19);
            this.txtGameDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtGameDir.Name = "txtGameDir";
            this.txtGameDir.Size = new System.Drawing.Size(298, 23);
            this.txtGameDir.TabIndex = 16;
            this.txtGameDir.Text = "example: C:\\Sierra\\Half-Life";
            this.txtGameDir.TextChanged += new System.EventHandler(this.GameDirectoryTextChanged);
            // 
            // grpFgds
            // 
            this.grpFgds.Controls.Add(this.lstFgds);
            this.grpFgds.Controls.Add(this.cmbDefaultPointEntity);
            this.grpFgds.Controls.Add(this.cmbDefaultBrushEntity);
            this.grpFgds.Controls.Add(this.chkIncludeFgdDirectories);
            this.grpFgds.Controls.Add(this.cmbMapSizeOverrideHigh);
            this.grpFgds.Controls.Add(this.lblDefaultPointEntity);
            this.grpFgds.Controls.Add(this.lblMapSizeOverrideHigh);
            this.grpFgds.Controls.Add(this.btnRemoveFgd);
            this.grpFgds.Controls.Add(this.cmbMapSizeOverrideLow);
            this.grpFgds.Controls.Add(this.lblDefaultBrushEntity);
            this.grpFgds.Controls.Add(this.chkOverrideMapSize);
            this.grpFgds.Controls.Add(this.btnAddFgd);
            this.grpFgds.Controls.Add(this.lblMapSizeOverrideLow);
            this.grpFgds.Location = new System.Drawing.Point(4, 93);
            this.grpFgds.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpFgds.Name = "grpFgds";
            this.grpFgds.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpFgds.Size = new System.Drawing.Size(536, 351);
            this.grpFgds.TabIndex = 48;
            this.grpFgds.TabStop = false;
            this.grpFgds.Text = "Game Data Files";
            // 
            // lstFgds
            // 
            this.lstFgds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFgdName,
            this.colFgdPath});
            this.lstFgds.FullRowSelect = true;
            this.lstFgds.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFgds.HideSelection = false;
            this.lstFgds.Location = new System.Drawing.Point(7, 22);
            this.lstFgds.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstFgds.Name = "lstFgds";
            this.lstFgds.ShowItemToolTips = true;
            this.lstFgds.Size = new System.Drawing.Size(416, 132);
            this.lstFgds.TabIndex = 34;
            this.lstFgds.UseCompatibleStateImageBehavior = false;
            this.lstFgds.View = System.Windows.Forms.View.Details;
            // 
            // colFgdName
            // 
            this.colFgdName.Text = "Name";
            // 
            // colFgdPath
            // 
            this.colFgdPath.Text = "Path";
            // 
            // cmbDefaultPointEntity
            // 
            this.cmbDefaultPointEntity.DropDownHeight = 300;
            this.cmbDefaultPointEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultPointEntity.FormattingEnabled = true;
            this.cmbDefaultPointEntity.IntegralHeight = false;
            this.cmbDefaultPointEntity.Items.AddRange(new object[] {
            "Valve"});
            this.cmbDefaultPointEntity.Location = new System.Drawing.Point(191, 162);
            this.cmbDefaultPointEntity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDefaultPointEntity.Name = "cmbDefaultPointEntity";
            this.cmbDefaultPointEntity.Size = new System.Drawing.Size(231, 23);
            this.cmbDefaultPointEntity.TabIndex = 33;
            // 
            // cmbDefaultBrushEntity
            // 
            this.cmbDefaultBrushEntity.DropDownHeight = 300;
            this.cmbDefaultBrushEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultBrushEntity.FormattingEnabled = true;
            this.cmbDefaultBrushEntity.IntegralHeight = false;
            this.cmbDefaultBrushEntity.Items.AddRange(new object[] {
            "Valve"});
            this.cmbDefaultBrushEntity.Location = new System.Drawing.Point(191, 193);
            this.cmbDefaultBrushEntity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDefaultBrushEntity.Name = "cmbDefaultBrushEntity";
            this.cmbDefaultBrushEntity.Size = new System.Drawing.Size(231, 23);
            this.cmbDefaultBrushEntity.TabIndex = 32;
            // 
            // chkIncludeFgdDirectories
            // 
            this.chkIncludeFgdDirectories.Checked = true;
            this.chkIncludeFgdDirectories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeFgdDirectories.Location = new System.Drawing.Point(7, 224);
            this.chkIncludeFgdDirectories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkIncludeFgdDirectories.Name = "chkIncludeFgdDirectories";
            this.chkIncludeFgdDirectories.Size = new System.Drawing.Size(416, 28);
            this.chkIncludeFgdDirectories.TabIndex = 39;
            this.chkIncludeFgdDirectories.Text = "Load sprites and models from FGD directories";
            this.chkIncludeFgdDirectories.UseVisualStyleBackColor = true;
            // 
            // cmbMapSizeOverrideHigh
            // 
            this.cmbMapSizeOverrideHigh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapSizeOverrideHigh.FormattingEnabled = true;
            this.cmbMapSizeOverrideHigh.Items.AddRange(new object[] {
            "4096",
            "8192",
            "16384",
            "32768",
            "65536",
            "131072"});
            this.cmbMapSizeOverrideHigh.Location = new System.Drawing.Point(88, 317);
            this.cmbMapSizeOverrideHigh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMapSizeOverrideHigh.Name = "cmbMapSizeOverrideHigh";
            this.cmbMapSizeOverrideHigh.Size = new System.Drawing.Size(66, 23);
            this.cmbMapSizeOverrideHigh.TabIndex = 44;
            // 
            // lblDefaultPointEntity
            // 
            this.lblDefaultPointEntity.Location = new System.Drawing.Point(8, 163);
            this.lblDefaultPointEntity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultPointEntity.Name = "lblDefaultPointEntity";
            this.lblDefaultPointEntity.Size = new System.Drawing.Size(176, 23);
            this.lblDefaultPointEntity.TabIndex = 31;
            this.lblDefaultPointEntity.Text = "Default Point Entity";
            this.lblDefaultPointEntity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMapSizeOverrideHigh
            // 
            this.lblMapSizeOverrideHigh.Location = new System.Drawing.Point(6, 316);
            this.lblMapSizeOverrideHigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapSizeOverrideHigh.Name = "lblMapSizeOverrideHigh";
            this.lblMapSizeOverrideHigh.Size = new System.Drawing.Size(75, 23);
            this.lblMapSizeOverrideHigh.TabIndex = 43;
            this.lblMapSizeOverrideHigh.Text = "High";
            this.lblMapSizeOverrideHigh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRemoveFgd
            // 
            this.btnRemoveFgd.Location = new System.Drawing.Point(430, 55);
            this.btnRemoveFgd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveFgd.Name = "btnRemoveFgd";
            this.btnRemoveFgd.Size = new System.Drawing.Size(86, 27);
            this.btnRemoveFgd.TabIndex = 28;
            this.btnRemoveFgd.Text = "Remove";
            this.btnRemoveFgd.UseVisualStyleBackColor = true;
            // 
            // cmbMapSizeOverrideLow
            // 
            this.cmbMapSizeOverrideLow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapSizeOverrideLow.FormattingEnabled = true;
            this.cmbMapSizeOverrideLow.Items.AddRange(new object[] {
            "-4096",
            "-8192",
            "-16384",
            "-32768",
            "-65536",
            "-131072"});
            this.cmbMapSizeOverrideLow.Location = new System.Drawing.Point(88, 286);
            this.cmbMapSizeOverrideLow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbMapSizeOverrideLow.Name = "cmbMapSizeOverrideLow";
            this.cmbMapSizeOverrideLow.Size = new System.Drawing.Size(66, 23);
            this.cmbMapSizeOverrideLow.TabIndex = 42;
            // 
            // lblDefaultBrushEntity
            // 
            this.lblDefaultBrushEntity.Location = new System.Drawing.Point(8, 194);
            this.lblDefaultBrushEntity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefaultBrushEntity.Name = "lblDefaultBrushEntity";
            this.lblDefaultBrushEntity.Size = new System.Drawing.Size(176, 23);
            this.lblDefaultBrushEntity.TabIndex = 30;
            this.lblDefaultBrushEntity.Text = "Default Brush Entity";
            this.lblDefaultBrushEntity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkOverrideMapSize
            // 
            this.chkOverrideMapSize.Checked = true;
            this.chkOverrideMapSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverrideMapSize.Location = new System.Drawing.Point(7, 255);
            this.chkOverrideMapSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkOverrideMapSize.Name = "chkOverrideMapSize";
            this.chkOverrideMapSize.Size = new System.Drawing.Size(229, 28);
            this.chkOverrideMapSize.TabIndex = 41;
            this.chkOverrideMapSize.Text = "Override FGD map size";
            this.chkOverrideMapSize.UseVisualStyleBackColor = true;
            // 
            // btnAddFgd
            // 
            this.btnAddFgd.Location = new System.Drawing.Point(430, 22);
            this.btnAddFgd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddFgd.Name = "btnAddFgd";
            this.btnAddFgd.Size = new System.Drawing.Size(86, 27);
            this.btnAddFgd.TabIndex = 27;
            this.btnAddFgd.Text = "Add...";
            this.btnAddFgd.UseVisualStyleBackColor = true;
            // 
            // lblMapSizeOverrideLow
            // 
            this.lblMapSizeOverrideLow.Location = new System.Drawing.Point(7, 287);
            this.lblMapSizeOverrideLow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapSizeOverrideLow.Name = "lblMapSizeOverrideLow";
            this.lblMapSizeOverrideLow.Size = new System.Drawing.Size(74, 23);
            this.lblMapSizeOverrideLow.TabIndex = 40;
            this.lblMapSizeOverrideLow.Text = "Low";
            this.lblMapSizeOverrideLow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // XonoticEnvironmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFgds);
            this.Controls.Add(this.groupBox1);
            this.Name = "XonoticEnvironmentEditor";
            this.Size = new System.Drawing.Size(551, 1387);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpFgds.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGameDir;
        private System.Windows.Forms.Button btnGameDirBrowse;
        private System.Windows.Forms.TextBox txtGameDir;
        private System.Windows.Forms.GroupBox grpFgds;
        private System.Windows.Forms.ListView lstFgds;
        private System.Windows.Forms.ColumnHeader colFgdName;
        private System.Windows.Forms.ColumnHeader colFgdPath;
        private System.Windows.Forms.ComboBox cmbDefaultPointEntity;
        private System.Windows.Forms.ComboBox cmbDefaultBrushEntity;
        private System.Windows.Forms.CheckBox chkIncludeFgdDirectories;
        private System.Windows.Forms.ComboBox cmbMapSizeOverrideHigh;
        private System.Windows.Forms.Label lblDefaultPointEntity;
        private System.Windows.Forms.Label lblMapSizeOverrideHigh;
        private System.Windows.Forms.Button btnRemoveFgd;
        private System.Windows.Forms.ComboBox cmbMapSizeOverrideLow;
        private System.Windows.Forms.Label lblDefaultBrushEntity;
        private System.Windows.Forms.CheckBox chkOverrideMapSize;
        private System.Windows.Forms.Button btnAddFgd;
        private System.Windows.Forms.Label lblMapSizeOverrideLow;
        private System.Windows.Forms.ComboBox cmbGameExe;
        private System.Windows.Forms.Label lblGameExe;
    }
}
