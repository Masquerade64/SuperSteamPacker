namespace SuperSteamPacker
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.OSBox = new System.Windows.Forms.ComboBox();
            this.QueueBox = new System.Windows.Forms.ListBox();
            this.QueueLabel = new System.Windows.Forms.Label();
            this.AppIDTxtBox = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.AppIDLabel = new System.Windows.Forms.Label();
            this.AppIDExplain = new System.Windows.Forms.Button();
            this.OSLabel = new System.Windows.Forms.Label();
            this.OSExplain = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.TmpLstBx = new System.Windows.Forms.ListBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.MoreSettingsBtn = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SaveLoginBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClearQueueBtn = new System.Windows.Forms.Button();
            this.MoveUpBtn = new System.Windows.Forms.Button();
            this.MoveDownBtn = new System.Windows.Forms.Button();
            this.csrinbtn = new System.Windows.Forms.Button();
            this.ExportQueueButton = new System.Windows.Forms.Button();
            this.ImportQueueButton = new System.Windows.Forms.Button();
            this.GithubBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OSBox
            // 
            this.OSBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OSBox.FormattingEnabled = true;
            this.OSBox.Items.AddRange(new object[] {
            "Linux",
            "Mac",
            "Windows x86",
            "Windows x64"});
            this.OSBox.Location = new System.Drawing.Point(148, 274);
            this.OSBox.Name = "OSBox";
            this.OSBox.Size = new System.Drawing.Size(120, 21);
            this.OSBox.TabIndex = 0;
            // 
            // QueueBox
            // 
            this.QueueBox.FormattingEnabled = true;
            this.QueueBox.Location = new System.Drawing.Point(12, 30);
            this.QueueBox.Name = "QueueBox";
            this.QueueBox.Size = new System.Drawing.Size(431, 212);
            this.QueueBox.TabIndex = 1;
            this.QueueBox.SelectedIndexChanged += new System.EventHandler(this.QueueBox_SelectedIndexChanged);
            // 
            // QueueLabel
            // 
            this.QueueLabel.AutoSize = true;
            this.QueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueLabel.Location = new System.Drawing.Point(9, 7);
            this.QueueLabel.Name = "QueueLabel";
            this.QueueLabel.Size = new System.Drawing.Size(87, 18);
            this.QueueLabel.TabIndex = 2;
            this.QueueLabel.Text = "QueueLabel";
            // 
            // AppIDTxtBox
            // 
            this.AppIDTxtBox.Location = new System.Drawing.Point(12, 274);
            this.AppIDTxtBox.Name = "AppIDTxtBox";
            this.AppIDTxtBox.Size = new System.Drawing.Size(130, 20);
            this.AppIDTxtBox.TabIndex = 3;
            this.AppIDTxtBox.WordWrap = false;
            this.AppIDTxtBox.TextChanged += new System.EventHandler(this.AppIDTxtBox_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(274, 245);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(84, 51);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "AddBtn";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AppIDLabel
            // 
            this.AppIDLabel.AutoSize = true;
            this.AppIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDLabel.Location = new System.Drawing.Point(12, 250);
            this.AppIDLabel.Name = "AppIDLabel";
            this.AppIDLabel.Size = new System.Drawing.Size(51, 18);
            this.AppIDLabel.TabIndex = 5;
            this.AppIDLabel.Text = "AppID:";
            // 
            // AppIDExplain
            // 
            this.AppIDExplain.Location = new System.Drawing.Point(119, 245);
            this.AppIDExplain.Name = "AppIDExplain";
            this.AppIDExplain.Size = new System.Drawing.Size(23, 23);
            this.AppIDExplain.TabIndex = 6;
            this.AppIDExplain.Text = "?";
            this.AppIDExplain.UseVisualStyleBackColor = true;
            this.AppIDExplain.Click += new System.EventHandler(this.AppIDExplain_Click);
            // 
            // OSLabel
            // 
            this.OSLabel.AutoSize = true;
            this.OSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSLabel.Location = new System.Drawing.Point(148, 249);
            this.OSLabel.Name = "OSLabel";
            this.OSLabel.Size = new System.Drawing.Size(34, 18);
            this.OSLabel.TabIndex = 7;
            this.OSLabel.Text = "OS:";
            // 
            // OSExplain
            // 
            this.OSExplain.Location = new System.Drawing.Point(246, 245);
            this.OSExplain.Name = "OSExplain";
            this.OSExplain.Size = new System.Drawing.Size(23, 23);
            this.OSExplain.TabIndex = 8;
            this.OSExplain.Text = "?";
            this.OSExplain.UseVisualStyleBackColor = true;
            this.OSExplain.Click += new System.EventHandler(this.OSExplain_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(359, 245);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(84, 51);
            this.DelBtn.TabIndex = 9;
            this.DelBtn.Text = "DelBtn";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(534, 245);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(118, 51);
            this.StartBtn.TabIndex = 10;
            this.StartBtn.Text = "StartBtn";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // TmpLstBx
            // 
            this.TmpLstBx.FormattingEnabled = true;
            this.TmpLstBx.Location = new System.Drawing.Point(366, 30);
            this.TmpLstBx.Name = "TmpLstBx";
            this.TmpLstBx.Size = new System.Drawing.Size(77, 69);
            this.TmpLstBx.TabIndex = 11;
            this.TmpLstBx.Visible = false;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(450, 114);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(202, 20);
            this.UsernameTextBox.TabIndex = 12;
            this.UsernameTextBox.WordWrap = false;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // MoreSettingsBtn
            // 
            this.MoreSettingsBtn.Location = new System.Drawing.Point(450, 214);
            this.MoreSettingsBtn.Name = "MoreSettingsBtn";
            this.MoreSettingsBtn.Size = new System.Drawing.Size(202, 23);
            this.MoreSettingsBtn.TabIndex = 13;
            this.MoreSettingsBtn.Text = "MoreSettingsBtn";
            this.MoreSettingsBtn.UseVisualStyleBackColor = true;
            this.MoreSettingsBtn.Click += new System.EventHandler(this.MoreSettingsBtn_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(450, 159);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(202, 20);
            this.PasswordTextBox.TabIndex = 14;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.WordWrap = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(449, 141);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(79, 13);
            this.PasswordLabel.TabIndex = 15;
            this.PasswordLabel.Text = "PasswordLabel";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(449, 97);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(81, 13);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "UsernameLabel";
            // 
            // SaveLoginBtn
            // 
            this.SaveLoginBtn.Location = new System.Drawing.Point(449, 185);
            this.SaveLoginBtn.Name = "SaveLoginBtn";
            this.SaveLoginBtn.Size = new System.Drawing.Size(203, 23);
            this.SaveLoginBtn.TabIndex = 17;
            this.SaveLoginBtn.Text = "SaveLoginBtn";
            this.SaveLoginBtn.UseVisualStyleBackColor = true;
            this.SaveLoginBtn.Click += new System.EventHandler(this.SaveLoginBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SuperSteamPacker.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(452, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // ClearQueueBtn
            // 
            this.ClearQueueBtn.Location = new System.Drawing.Point(444, 245);
            this.ClearQueueBtn.Name = "ClearQueueBtn";
            this.ClearQueueBtn.Size = new System.Drawing.Size(84, 51);
            this.ClearQueueBtn.TabIndex = 19;
            this.ClearQueueBtn.Text = "ClearQueueBtn";
            this.ClearQueueBtn.UseVisualStyleBackColor = true;
            this.ClearQueueBtn.Click += new System.EventHandler(this.ClearQueueBtn_Click);
            // 
            // MoveUpBtn
            // 
            this.MoveUpBtn.Location = new System.Drawing.Point(12, 300);
            this.MoveUpBtn.Name = "MoveUpBtn";
            this.MoveUpBtn.Size = new System.Drawing.Size(215, 25);
            this.MoveUpBtn.TabIndex = 20;
            this.MoveUpBtn.Text = "MoveUpBtn";
            this.MoveUpBtn.UseVisualStyleBackColor = true;
            this.MoveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
            // 
            // MoveDownBtn
            // 
            this.MoveDownBtn.Location = new System.Drawing.Point(228, 300);
            this.MoveDownBtn.Name = "MoveDownBtn";
            this.MoveDownBtn.Size = new System.Drawing.Size(215, 25);
            this.MoveDownBtn.TabIndex = 21;
            this.MoveDownBtn.Text = "MoveDownBtn";
            this.MoveDownBtn.UseVisualStyleBackColor = true;
            this.MoveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
            // 
            // csrinbtn
            // 
            this.csrinbtn.Location = new System.Drawing.Point(444, 300);
            this.csrinbtn.Name = "csrinbtn";
            this.csrinbtn.Size = new System.Drawing.Size(208, 25);
            this.csrinbtn.TabIndex = 22;
            this.csrinbtn.Text = "CS.RIN.RU";
            this.csrinbtn.UseVisualStyleBackColor = true;
            this.csrinbtn.Click += new System.EventHandler(this.csrinbtn_Click);
            // 
            // ExportQueueButton
            // 
            this.ExportQueueButton.Location = new System.Drawing.Point(12, 328);
            this.ExportQueueButton.Name = "ExportQueueButton";
            this.ExportQueueButton.Size = new System.Drawing.Size(215, 25);
            this.ExportQueueButton.TabIndex = 23;
            this.ExportQueueButton.Text = "ExportQueueButton";
            this.ExportQueueButton.UseVisualStyleBackColor = true;
            this.ExportQueueButton.Click += new System.EventHandler(this.ExportQueueButton_Click);
            // 
            // ImportQueueButton
            // 
            this.ImportQueueButton.Location = new System.Drawing.Point(228, 328);
            this.ImportQueueButton.Name = "ImportQueueButton";
            this.ImportQueueButton.Size = new System.Drawing.Size(215, 25);
            this.ImportQueueButton.TabIndex = 24;
            this.ImportQueueButton.Text = "ImportQueueButton";
            this.ImportQueueButton.UseVisualStyleBackColor = true;
            this.ImportQueueButton.Click += new System.EventHandler(this.ImportQueueButton_Click);
            // 
            // GithubBtn
            // 
            this.GithubBtn.Location = new System.Drawing.Point(444, 328);
            this.GithubBtn.Name = "GithubBtn";
            this.GithubBtn.Size = new System.Drawing.Size(208, 25);
            this.GithubBtn.TabIndex = 25;
            this.GithubBtn.Text = "Masquerade\'s Github";
            this.GithubBtn.UseVisualStyleBackColor = true;
            this.GithubBtn.Click += new System.EventHandler(this.GithubBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(657, 361);
            this.Controls.Add(this.GithubBtn);
            this.Controls.Add(this.ImportQueueButton);
            this.Controls.Add(this.ExportQueueButton);
            this.Controls.Add(this.csrinbtn);
            this.Controls.Add(this.MoveDownBtn);
            this.Controls.Add(this.MoveUpBtn);
            this.Controls.Add(this.ClearQueueBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SaveLoginBtn);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.MoreSettingsBtn);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.TmpLstBx);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.OSExplain);
            this.Controls.Add(this.OSLabel);
            this.Controls.Add(this.AppIDExplain);
            this.Controls.Add(this.AppIDLabel);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.AppIDTxtBox);
            this.Controls.Add(this.QueueLabel);
            this.Controls.Add(this.QueueBox);
            this.Controls.Add(this.OSBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Steam Packer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OSBox;
        private System.Windows.Forms.ListBox QueueBox;
        private System.Windows.Forms.Label QueueLabel;
        private System.Windows.Forms.TextBox AppIDTxtBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label AppIDLabel;
        private System.Windows.Forms.Button AppIDExplain;
        private System.Windows.Forms.Label OSLabel;
        private System.Windows.Forms.Button OSExplain;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.ListBox TmpLstBx;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.Button MoreSettingsBtn;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button SaveLoginBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ClearQueueBtn;
        private System.Windows.Forms.Button MoveUpBtn;
        private System.Windows.Forms.Button MoveDownBtn;
        private System.Windows.Forms.Button csrinbtn;
        private System.Windows.Forms.Button ExportQueueButton;
        private System.Windows.Forms.Button ImportQueueButton;
        private System.Windows.Forms.Button GithubBtn;
    }
}

