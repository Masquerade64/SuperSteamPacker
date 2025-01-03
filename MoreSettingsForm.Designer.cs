namespace SuperSteamPacker
{
    partial class MoreSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreSettingsForm));
            this.DelSavedLoginBtn = new System.Windows.Forms.Button();
            this.CompressorLabel = new System.Windows.Forms.Label();
            this.LangLabel = new System.Windows.Forms.Label();
            this.LangChoiceBox = new System.Windows.Forms.ComboBox();
            this.CompressorChoiceBox = new System.Windows.Forms.ComboBox();
            this.CustomCompressorOptionsCheckBox = new System.Windows.Forms.CheckBox();
            this.CustomCompressorOptionsTextBox = new System.Windows.Forms.TextBox();
            this.UploadCrewModeCB = new System.Windows.Forms.CheckBox();
            this.DarkModeCB = new System.Windows.Forms.CheckBox();
            this.DepotSyncBtn = new System.Windows.Forms.Button();
            this.rinruUsernameTextbox = new System.Windows.Forms.TextBox();
            this.rinruUsernameLabel = new System.Windows.Forms.Label();
            this.filehostLabel = new System.Windows.Forms.Label();
            this.filehostTextbox = new System.Windows.Forms.TextBox();
            this.SkipCompressionCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DelSavedLoginBtn
            // 
            this.DelSavedLoginBtn.Location = new System.Drawing.Point(12, 326);
            this.DelSavedLoginBtn.Name = "DelSavedLoginBtn";
            this.DelSavedLoginBtn.Size = new System.Drawing.Size(280, 23);
            this.DelSavedLoginBtn.TabIndex = 0;
            this.DelSavedLoginBtn.Text = "DelSavedLoginBtn";
            this.DelSavedLoginBtn.UseVisualStyleBackColor = true;
            this.DelSavedLoginBtn.Click += new System.EventHandler(this.DelSavedLoginBtn_Click);
            // 
            // CompressorLabel
            // 
            this.CompressorLabel.AutoSize = true;
            this.CompressorLabel.Location = new System.Drawing.Point(9, 59);
            this.CompressorLabel.Name = "CompressorLabel";
            this.CompressorLabel.Size = new System.Drawing.Size(88, 13);
            this.CompressorLabel.TabIndex = 1;
            this.CompressorLabel.Text = "CompressorLabel";
            // 
            // LangLabel
            // 
            this.LangLabel.AutoSize = true;
            this.LangLabel.Location = new System.Drawing.Point(9, 9);
            this.LangLabel.Name = "LangLabel";
            this.LangLabel.Size = new System.Drawing.Size(57, 13);
            this.LangLabel.TabIndex = 2;
            this.LangLabel.Text = "LangLabel";
            // 
            // LangChoiceBox
            // 
            this.LangChoiceBox.BackColor = System.Drawing.SystemColors.Window;
            this.LangChoiceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LangChoiceBox.FormattingEnabled = true;
            this.LangChoiceBox.Location = new System.Drawing.Point(13, 30);
            this.LangChoiceBox.Name = "LangChoiceBox";
            this.LangChoiceBox.Size = new System.Drawing.Size(280, 21);
            this.LangChoiceBox.TabIndex = 3;
            this.LangChoiceBox.SelectedIndexChanged += new System.EventHandler(this.LangChoiceBox_SelectedIndexChanged);
            // 
            // CompressorChoiceBox
            // 
            this.CompressorChoiceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompressorChoiceBox.FormattingEnabled = true;
            this.CompressorChoiceBox.Items.AddRange(new object[] {
            "7-Zip",
            "WinRAR"});
            this.CompressorChoiceBox.Location = new System.Drawing.Point(12, 79);
            this.CompressorChoiceBox.Name = "CompressorChoiceBox";
            this.CompressorChoiceBox.Size = new System.Drawing.Size(280, 21);
            this.CompressorChoiceBox.TabIndex = 4;
            this.CompressorChoiceBox.SelectedIndexChanged += new System.EventHandler(this.CompressorChoiceBox_SelectedIndexChanged);
            // 
            // CustomCompressorOptionsCheckBox
            // 
            this.CustomCompressorOptionsCheckBox.AutoSize = true;
            this.CustomCompressorOptionsCheckBox.Location = new System.Drawing.Point(12, 107);
            this.CustomCompressorOptionsCheckBox.Name = "CustomCompressorOptionsCheckBox";
            this.CustomCompressorOptionsCheckBox.Size = new System.Drawing.Size(201, 17);
            this.CustomCompressorOptionsCheckBox.TabIndex = 5;
            this.CustomCompressorOptionsCheckBox.Text = "CustomCompressorOptionsCheckBox";
            this.CustomCompressorOptionsCheckBox.UseVisualStyleBackColor = true;
            this.CustomCompressorOptionsCheckBox.CheckedChanged += new System.EventHandler(this.CustomCompressorOptionsCheckBox_CheckedChanged);
            // 
            // CustomCompressorOptionsTextBox
            // 
            this.CustomCompressorOptionsTextBox.Location = new System.Drawing.Point(12, 131);
            this.CustomCompressorOptionsTextBox.Name = "CustomCompressorOptionsTextBox";
            this.CustomCompressorOptionsTextBox.Size = new System.Drawing.Size(280, 20);
            this.CustomCompressorOptionsTextBox.TabIndex = 6;
            this.CustomCompressorOptionsTextBox.WordWrap = false;
            this.CustomCompressorOptionsTextBox.TextChanged += new System.EventHandler(this.CustomCompressorOptionsTextBox_TextChanged);
            // 
            // UploadCrewModeCB
            // 
            this.UploadCrewModeCB.AutoSize = true;
            this.UploadCrewModeCB.Location = new System.Drawing.Point(12, 187);
            this.UploadCrewModeCB.Name = "UploadCrewModeCB";
            this.UploadCrewModeCB.Size = new System.Drawing.Size(160, 17);
            this.UploadCrewModeCB.TabIndex = 7;
            this.UploadCrewModeCB.Text = "UploadCrewModeCheckBox";
            this.UploadCrewModeCB.UseVisualStyleBackColor = true;
            this.UploadCrewModeCB.CheckedChanged += new System.EventHandler(this.UploadCrewModeCB_CheckedChanged);
            // 
            // DarkModeCB
            // 
            this.DarkModeCB.AutoSize = true;
            this.DarkModeCB.Location = new System.Drawing.Point(12, 304);
            this.DarkModeCB.Name = "DarkModeCB";
            this.DarkModeCB.Size = new System.Drawing.Size(125, 17);
            this.DarkModeCB.TabIndex = 8;
            this.DarkModeCB.Text = "DarkModeCheckBox";
            this.DarkModeCB.UseVisualStyleBackColor = true;
            this.DarkModeCB.CheckedChanged += new System.EventHandler(this.DarkModeCB_CheckedChanged);
            // 
            // DepotSyncBtn
            // 
            this.DepotSyncBtn.Location = new System.Drawing.Point(12, 356);
            this.DepotSyncBtn.Name = "DepotSyncBtn";
            this.DepotSyncBtn.Size = new System.Drawing.Size(280, 23);
            this.DepotSyncBtn.TabIndex = 9;
            this.DepotSyncBtn.Text = "DepotSyncBtn";
            this.DepotSyncBtn.UseVisualStyleBackColor = true;
            this.DepotSyncBtn.Click += new System.EventHandler(this.DepotSyncBtn_Click);
            // 
            // rinruUsernameTextbox
            // 
            this.rinruUsernameTextbox.Location = new System.Drawing.Point(12, 229);
            this.rinruUsernameTextbox.Name = "rinruUsernameTextbox";
            this.rinruUsernameTextbox.Size = new System.Drawing.Size(280, 20);
            this.rinruUsernameTextbox.TabIndex = 10;
            this.rinruUsernameTextbox.TextChanged += new System.EventHandler(this.rinruUsernameTextbox_TextChanged);
            // 
            // rinruUsernameLabel
            // 
            this.rinruUsernameLabel.AutoSize = true;
            this.rinruUsernameLabel.Location = new System.Drawing.Point(12, 211);
            this.rinruUsernameLabel.Name = "rinruUsernameLabel";
            this.rinruUsernameLabel.Size = new System.Drawing.Size(101, 13);
            this.rinruUsernameLabel.TabIndex = 11;
            this.rinruUsernameLabel.Text = "rinruUsernameLabel";
            // 
            // filehostLabel
            // 
            this.filehostLabel.AutoSize = true;
            this.filehostLabel.Location = new System.Drawing.Point(12, 256);
            this.filehostLabel.Name = "filehostLabel";
            this.filehostLabel.Size = new System.Drawing.Size(66, 13);
            this.filehostLabel.TabIndex = 12;
            this.filehostLabel.Text = "filehostLabel";
            // 
            // filehostTextbox
            // 
            this.filehostTextbox.Location = new System.Drawing.Point(12, 274);
            this.filehostTextbox.Name = "filehostTextbox";
            this.filehostTextbox.Size = new System.Drawing.Size(281, 20);
            this.filehostTextbox.TabIndex = 13;
            this.filehostTextbox.TextChanged += new System.EventHandler(this.filehostTextbox_TextChanged);
            // 
            // SkipCompressionCheckBox
            // 
            this.SkipCompressionCheckBox.AutoSize = true;
            this.SkipCompressionCheckBox.Location = new System.Drawing.Point(12, 161);
            this.SkipCompressionCheckBox.Name = "SkipCompressionCheckBox";
            this.SkipCompressionCheckBox.Size = new System.Drawing.Size(104, 17);
            this.SkipCompressionCheckBox.TabIndex = 14;
            this.SkipCompressionCheckBox.Text = "skipcompression";
            this.SkipCompressionCheckBox.UseVisualStyleBackColor = true;
            this.SkipCompressionCheckBox.CheckedChanged += new System.EventHandler(this.SkipCompressionCheckBox_CheckedChanged);
            // 
            // MoreSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(303, 389);
            this.Controls.Add(this.SkipCompressionCheckBox);
            this.Controls.Add(this.filehostTextbox);
            this.Controls.Add(this.filehostLabel);
            this.Controls.Add(this.rinruUsernameLabel);
            this.Controls.Add(this.rinruUsernameTextbox);
            this.Controls.Add(this.DepotSyncBtn);
            this.Controls.Add(this.DarkModeCB);
            this.Controls.Add(this.UploadCrewModeCB);
            this.Controls.Add(this.CustomCompressorOptionsTextBox);
            this.Controls.Add(this.CustomCompressorOptionsCheckBox);
            this.Controls.Add(this.CompressorChoiceBox);
            this.Controls.Add(this.LangChoiceBox);
            this.Controls.Add(this.LangLabel);
            this.Controls.Add(this.CompressorLabel);
            this.Controls.Add(this.DelSavedLoginBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoreSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MoreSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DelSavedLoginBtn;
        private System.Windows.Forms.Label CompressorLabel;
        private System.Windows.Forms.Label LangLabel;
        private System.Windows.Forms.ComboBox LangChoiceBox;
        private System.Windows.Forms.ComboBox CompressorChoiceBox;
        private System.Windows.Forms.CheckBox CustomCompressorOptionsCheckBox;
        private System.Windows.Forms.TextBox CustomCompressorOptionsTextBox;
        private System.Windows.Forms.CheckBox UploadCrewModeCB;
        private System.Windows.Forms.CheckBox DarkModeCB;
        private System.Windows.Forms.Button DepotSyncBtn;
        private System.Windows.Forms.TextBox rinruUsernameTextbox;
        private System.Windows.Forms.Label rinruUsernameLabel;
        private System.Windows.Forms.Label filehostLabel;
        private System.Windows.Forms.TextBox filehostTextbox;
        private System.Windows.Forms.CheckBox SkipCompressionCheckBox;
    }
}