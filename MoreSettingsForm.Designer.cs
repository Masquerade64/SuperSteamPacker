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
            this.SuspendLayout();
            // 
            // DelSavedLoginBtn
            // 
            this.DelSavedLoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.DelSavedLoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelSavedLoginBtn.ForeColor = System.Drawing.Color.White;
            this.DelSavedLoginBtn.Location = new System.Drawing.Point(12, 184);
            this.DelSavedLoginBtn.Name = "DelSavedLoginBtn";
            this.DelSavedLoginBtn.Size = new System.Drawing.Size(280, 23);
            this.DelSavedLoginBtn.TabIndex = 0;
            this.DelSavedLoginBtn.Text = "DelSavedLoginBtn";
            this.DelSavedLoginBtn.UseVisualStyleBackColor = false;
            this.DelSavedLoginBtn.Click += new System.EventHandler(this.DelSavedLoginBtn_Click);
            // 
            // CompressorLabel
            // 
            this.CompressorLabel.AutoSize = true;
            this.CompressorLabel.BackColor = System.Drawing.Color.Transparent;
            this.CompressorLabel.ForeColor = System.Drawing.Color.White;
            this.CompressorLabel.Location = new System.Drawing.Point(9, 59);
            this.CompressorLabel.Name = "CompressorLabel";
            this.CompressorLabel.Size = new System.Drawing.Size(88, 13);
            this.CompressorLabel.TabIndex = 1;
            this.CompressorLabel.Text = "CompressorLabel";
            // 
            // LangLabel
            // 
            this.LangLabel.AutoSize = true;
            this.LangLabel.BackColor = System.Drawing.Color.Transparent;
            this.LangLabel.ForeColor = System.Drawing.Color.White;
            this.LangLabel.Location = new System.Drawing.Point(9, 9);
            this.LangLabel.Name = "LangLabel";
            this.LangLabel.Size = new System.Drawing.Size(57, 13);
            this.LangLabel.TabIndex = 2;
            this.LangLabel.Text = "LangLabel";
            // 
            // LangChoiceBox
            // 
            this.LangChoiceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.LangChoiceBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LangChoiceBox.ForeColor = System.Drawing.Color.White;
            this.LangChoiceBox.FormattingEnabled = true;
            this.LangChoiceBox.Location = new System.Drawing.Point(12, 30);
            this.LangChoiceBox.Name = "LangChoiceBox";
            this.LangChoiceBox.Size = new System.Drawing.Size(280, 21);
            this.LangChoiceBox.TabIndex = 3;
            this.LangChoiceBox.SelectedIndexChanged += new System.EventHandler(this.LangChoiceBox_SelectedIndexChanged);
            // 
            // CompressorChoiceBox
            // 
            this.CompressorChoiceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CompressorChoiceBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompressorChoiceBox.ForeColor = System.Drawing.Color.White;
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
            this.CustomCompressorOptionsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.CustomCompressorOptionsCheckBox.ForeColor = System.Drawing.Color.White;
            this.CustomCompressorOptionsCheckBox.Location = new System.Drawing.Point(12, 107);
            this.CustomCompressorOptionsCheckBox.Name = "CustomCompressorOptionsCheckBox";
            this.CustomCompressorOptionsCheckBox.Size = new System.Drawing.Size(201, 17);
            this.CustomCompressorOptionsCheckBox.TabIndex = 5;
            this.CustomCompressorOptionsCheckBox.Text = "CustomCompressorOptionsCheckBox";
            this.CustomCompressorOptionsCheckBox.UseVisualStyleBackColor = false;
            this.CustomCompressorOptionsCheckBox.CheckedChanged += new System.EventHandler(this.CustomCompressorOptionsCheckBox_CheckedChanged);
            // 
            // CustomCompressorOptionsTextBox
            // 
            this.CustomCompressorOptionsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CustomCompressorOptionsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CustomCompressorOptionsTextBox.ForeColor = System.Drawing.Color.White;
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
            this.UploadCrewModeCB.BackColor = System.Drawing.Color.Transparent;
            this.UploadCrewModeCB.ForeColor = System.Drawing.Color.White;
            this.UploadCrewModeCB.Location = new System.Drawing.Point(12, 159);
            this.UploadCrewModeCB.Name = "UploadCrewModeCB";
            this.UploadCrewModeCB.Size = new System.Drawing.Size(160, 17);
            this.UploadCrewModeCB.TabIndex = 7;
            this.UploadCrewModeCB.Text = "UploadCrewModeCheckBox";
            this.UploadCrewModeCB.UseVisualStyleBackColor = false;
            this.UploadCrewModeCB.CheckedChanged += new System.EventHandler(this.UploadCrewModeCB_CheckedChanged);
            // 
            // MoreSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(303, 217);
            this.Controls.Add(this.UploadCrewModeCB);
            this.Controls.Add(this.CustomCompressorOptionsTextBox);
            this.Controls.Add(this.CustomCompressorOptionsCheckBox);
            this.Controls.Add(this.CompressorChoiceBox);
            this.Controls.Add(this.LangChoiceBox);
            this.Controls.Add(this.LangLabel);
            this.Controls.Add(this.CompressorLabel);
            this.Controls.Add(this.DelSavedLoginBtn);
            this.ForeColor = System.Drawing.Color.White;
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
    }
}