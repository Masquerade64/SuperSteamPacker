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
            this.ClearQueueBtn = new System.Windows.Forms.Button();
            this.MoveUpBtn = new System.Windows.Forms.Button();
            this.MoveDownBtn = new System.Windows.Forms.Button();
            this.csrinbtn = new System.Windows.Forms.Button();
            this.ExportQueueButton = new System.Windows.Forms.Button();
            this.ImportQueueButton = new System.Windows.Forms.Button();
            this.GithubBtn = new System.Windows.Forms.Button();
            this.QueueManageGrp = new System.Windows.Forms.GroupBox();
            this.GameManageGrp = new System.Windows.Forms.GroupBox();
            this.BranchGrp = new System.Windows.Forms.GroupBox();
            this.BranchPasswordTxtBox = new System.Windows.Forms.TextBox();
            this.BranchLabel = new System.Windows.Forms.Label();
            this.BranchNameTxtBox = new System.Windows.Forms.TextBox();
            this.BranchPasswordCB = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.QueueManageGrp.SuspendLayout();
            this.GameManageGrp.SuspendLayout();
            this.BranchGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OSBox
            // 
            this.OSBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.OSBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OSBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSBox.FormattingEnabled = true;
            this.OSBox.Items.AddRange(new object[] {
            "Linux x86",
            "Linux x64",
            "Mac",
            "Windows x86",
            "Windows x64"});
            this.OSBox.Location = new System.Drawing.Point(52, 53);
            this.OSBox.Name = "OSBox";
            this.OSBox.Size = new System.Drawing.Size(151, 21);
            this.OSBox.TabIndex = 5;
            // 
            // QueueBox
            // 
            this.QueueBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.QueueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueueBox.ForeColor = System.Drawing.Color.White;
            this.QueueBox.FormattingEnabled = true;
            this.QueueBox.Location = new System.Drawing.Point(12, 30);
            this.QueueBox.Name = "QueueBox";
            this.QueueBox.Size = new System.Drawing.Size(442, 210);
            this.QueueBox.TabIndex = 1;
            this.QueueBox.SelectedIndexChanged += new System.EventHandler(this.QueueBox_SelectedIndexChanged);
            // 
            // QueueLabel
            // 
            this.QueueLabel.AutoSize = true;
            this.QueueLabel.BackColor = System.Drawing.Color.Transparent;
            this.QueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueLabel.ForeColor = System.Drawing.Color.White;
            this.QueueLabel.Location = new System.Drawing.Point(9, 7);
            this.QueueLabel.Name = "QueueLabel";
            this.QueueLabel.Size = new System.Drawing.Size(87, 18);
            this.QueueLabel.TabIndex = 2;
            this.QueueLabel.Text = "QueueLabel";
            // 
            // AppIDTxtBox
            // 
            this.AppIDTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AppIDTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AppIDTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDTxtBox.Location = new System.Drawing.Point(52, 27);
            this.AppIDTxtBox.Name = "AppIDTxtBox";
            this.AppIDTxtBox.Size = new System.Drawing.Size(151, 20);
            this.AppIDTxtBox.TabIndex = 3;
            this.AppIDTxtBox.WordWrap = false;
            this.AppIDTxtBox.TextChanged += new System.EventHandler(this.AppIDTxtBox_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(6, 23);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(140, 36);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "AddBtn";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // AppIDLabel
            // 
            this.AppIDLabel.AutoSize = true;
            this.AppIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDLabel.Location = new System.Drawing.Point(6, 31);
            this.AppIDLabel.Name = "AppIDLabel";
            this.AppIDLabel.Size = new System.Drawing.Size(40, 13);
            this.AppIDLabel.TabIndex = 5;
            this.AppIDLabel.Text = "AppID:";
            // 
            // AppIDExplain
            // 
            this.AppIDExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AppIDExplain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AppIDExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppIDExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDExplain.Location = new System.Drawing.Point(209, 27);
            this.AppIDExplain.Name = "AppIDExplain";
            this.AppIDExplain.Size = new System.Drawing.Size(21, 21);
            this.AppIDExplain.TabIndex = 4;
            this.AppIDExplain.Text = "?";
            this.AppIDExplain.UseVisualStyleBackColor = false;
            this.AppIDExplain.Click += new System.EventHandler(this.AppIDExplain_Click);
            // 
            // OSLabel
            // 
            this.OSLabel.AutoSize = true;
            this.OSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSLabel.Location = new System.Drawing.Point(6, 58);
            this.OSLabel.Name = "OSLabel";
            this.OSLabel.Size = new System.Drawing.Size(25, 13);
            this.OSLabel.TabIndex = 7;
            this.OSLabel.Text = "OS:";
            // 
            // OSExplain
            // 
            this.OSExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.OSExplain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OSExplain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OSExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSExplain.Location = new System.Drawing.Point(209, 53);
            this.OSExplain.Name = "OSExplain";
            this.OSExplain.Size = new System.Drawing.Size(21, 21);
            this.OSExplain.TabIndex = 6;
            this.OSExplain.Text = "?";
            this.OSExplain.UseVisualStyleBackColor = false;
            this.OSExplain.Click += new System.EventHandler(this.OSExplain_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.DelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelBtn.Location = new System.Drawing.Point(152, 23);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(140, 36);
            this.DelBtn.TabIndex = 8;
            this.DelBtn.Text = "DelBtn";
            this.DelBtn.UseVisualStyleBackColor = false;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.StartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.ForeColor = System.Drawing.Color.White;
            this.StartBtn.Location = new System.Drawing.Point(464, 339);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(204, 58);
            this.StartBtn.TabIndex = 14;
            this.StartBtn.Text = "StartBtn";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // TmpLstBx
            // 
            this.TmpLstBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.TmpLstBx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TmpLstBx.ForeColor = System.Drawing.Color.White;
            this.TmpLstBx.FormattingEnabled = true;
            this.TmpLstBx.Location = new System.Drawing.Point(379, 30);
            this.TmpLstBx.Name = "TmpLstBx";
            this.TmpLstBx.Size = new System.Drawing.Size(75, 67);
            this.TmpLstBx.TabIndex = 11;
            this.TmpLstBx.Visible = false;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameTextBox.Location = new System.Drawing.Point(464, 119);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(204, 20);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.WordWrap = false;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // MoreSettingsBtn
            // 
            this.MoreSettingsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MoreSettingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoreSettingsBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MoreSettingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoreSettingsBtn.ForeColor = System.Drawing.Color.White;
            this.MoreSettingsBtn.Location = new System.Drawing.Point(464, 221);
            this.MoreSettingsBtn.Name = "MoreSettingsBtn";
            this.MoreSettingsBtn.Size = new System.Drawing.Size(204, 25);
            this.MoreSettingsBtn.TabIndex = 13;
            this.MoreSettingsBtn.Text = "MoreSettingsBtn";
            this.MoreSettingsBtn.UseVisualStyleBackColor = false;
            this.MoreSettingsBtn.Click += new System.EventHandler(this.MoreSettingsBtn_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Location = new System.Drawing.Point(464, 164);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(204, 20);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.WordWrap = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(465, 146);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(79, 13);
            this.PasswordLabel.TabIndex = 15;
            this.PasswordLabel.Text = "PasswordLabel";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(465, 102);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(81, 13);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "UsernameLabel";
            // 
            // SaveLoginBtn
            // 
            this.SaveLoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SaveLoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveLoginBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SaveLoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveLoginBtn.ForeColor = System.Drawing.Color.White;
            this.SaveLoginBtn.Location = new System.Drawing.Point(464, 190);
            this.SaveLoginBtn.Name = "SaveLoginBtn";
            this.SaveLoginBtn.Size = new System.Drawing.Size(204, 25);
            this.SaveLoginBtn.TabIndex = 17;
            this.SaveLoginBtn.Text = "SaveLoginBtn";
            this.SaveLoginBtn.UseVisualStyleBackColor = false;
            this.SaveLoginBtn.Click += new System.EventHandler(this.SaveLoginBtn_Click);
            // 
            // ClearQueueBtn
            // 
            this.ClearQueueBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClearQueueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearQueueBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ClearQueueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearQueueBtn.Location = new System.Drawing.Point(298, 23);
            this.ClearQueueBtn.Name = "ClearQueueBtn";
            this.ClearQueueBtn.Size = new System.Drawing.Size(140, 36);
            this.ClearQueueBtn.TabIndex = 9;
            this.ClearQueueBtn.Text = "ClearQueueBtn";
            this.ClearQueueBtn.UseVisualStyleBackColor = false;
            this.ClearQueueBtn.Click += new System.EventHandler(this.ClearQueueBtn_Click);
            // 
            // MoveUpBtn
            // 
            this.MoveUpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MoveUpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveUpBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MoveUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpBtn.Location = new System.Drawing.Point(6, 64);
            this.MoveUpBtn.Name = "MoveUpBtn";
            this.MoveUpBtn.Size = new System.Drawing.Size(215, 25);
            this.MoveUpBtn.TabIndex = 10;
            this.MoveUpBtn.Text = "MoveUpBtn";
            this.MoveUpBtn.UseVisualStyleBackColor = false;
            this.MoveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
            // 
            // MoveDownBtn
            // 
            this.MoveDownBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MoveDownBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveDownBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.MoveDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownBtn.Location = new System.Drawing.Point(222, 64);
            this.MoveDownBtn.Name = "MoveDownBtn";
            this.MoveDownBtn.Size = new System.Drawing.Size(215, 25);
            this.MoveDownBtn.TabIndex = 11;
            this.MoveDownBtn.Text = "MoveDownBtn";
            this.MoveDownBtn.UseVisualStyleBackColor = false;
            this.MoveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
            // 
            // csrinbtn
            // 
            this.csrinbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.csrinbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.csrinbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.csrinbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csrinbtn.ForeColor = System.Drawing.Color.White;
            this.csrinbtn.Location = new System.Drawing.Point(464, 403);
            this.csrinbtn.Name = "csrinbtn";
            this.csrinbtn.Size = new System.Drawing.Size(204, 25);
            this.csrinbtn.TabIndex = 15;
            this.csrinbtn.Text = "CS.RIN.RU";
            this.csrinbtn.UseVisualStyleBackColor = false;
            this.csrinbtn.Click += new System.EventHandler(this.csrinbtn_Click);
            // 
            // ExportQueueButton
            // 
            this.ExportQueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ExportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportQueueButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ExportQueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportQueueButton.Location = new System.Drawing.Point(6, 92);
            this.ExportQueueButton.Name = "ExportQueueButton";
            this.ExportQueueButton.Size = new System.Drawing.Size(215, 25);
            this.ExportQueueButton.TabIndex = 12;
            this.ExportQueueButton.Text = "ExportQueueButton";
            this.ExportQueueButton.UseVisualStyleBackColor = false;
            this.ExportQueueButton.Click += new System.EventHandler(this.ExportQueueButton_Click);
            // 
            // ImportQueueButton
            // 
            this.ImportQueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ImportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportQueueButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ImportQueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportQueueButton.Location = new System.Drawing.Point(222, 92);
            this.ImportQueueButton.Name = "ImportQueueButton";
            this.ImportQueueButton.Size = new System.Drawing.Size(215, 25);
            this.ImportQueueButton.TabIndex = 13;
            this.ImportQueueButton.Text = "ImportQueueButton";
            this.ImportQueueButton.UseVisualStyleBackColor = false;
            this.ImportQueueButton.Click += new System.EventHandler(this.ImportQueueButton_Click);
            // 
            // GithubBtn
            // 
            this.GithubBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.GithubBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GithubBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GithubBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GithubBtn.ForeColor = System.Drawing.Color.White;
            this.GithubBtn.Location = new System.Drawing.Point(464, 434);
            this.GithubBtn.Name = "GithubBtn";
            this.GithubBtn.Size = new System.Drawing.Size(204, 25);
            this.GithubBtn.TabIndex = 16;
            this.GithubBtn.Text = "Masquerade\'s Github";
            this.GithubBtn.UseVisualStyleBackColor = false;
            this.GithubBtn.Click += new System.EventHandler(this.GithubBtn_Click);
            // 
            // QueueManageGrp
            // 
            this.QueueManageGrp.BackColor = System.Drawing.Color.Transparent;
            this.QueueManageGrp.Controls.Add(this.MoveUpBtn);
            this.QueueManageGrp.Controls.Add(this.MoveDownBtn);
            this.QueueManageGrp.Controls.Add(this.ExportQueueButton);
            this.QueueManageGrp.Controls.Add(this.ImportQueueButton);
            this.QueueManageGrp.Controls.Add(this.ClearQueueBtn);
            this.QueueManageGrp.Controls.Add(this.AddBtn);
            this.QueueManageGrp.Controls.Add(this.DelBtn);
            this.QueueManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueManageGrp.ForeColor = System.Drawing.Color.White;
            this.QueueManageGrp.Location = new System.Drawing.Point(12, 339);
            this.QueueManageGrp.Name = "QueueManageGrp";
            this.QueueManageGrp.Size = new System.Drawing.Size(446, 122);
            this.QueueManageGrp.TabIndex = 20;
            this.QueueManageGrp.TabStop = false;
            this.QueueManageGrp.Text = "QueueManageGrp";
            // 
            // GameManageGrp
            // 
            this.GameManageGrp.BackColor = System.Drawing.Color.Transparent;
            this.GameManageGrp.Controls.Add(this.AppIDLabel);
            this.GameManageGrp.Controls.Add(this.OSBox);
            this.GameManageGrp.Controls.Add(this.AppIDTxtBox);
            this.GameManageGrp.Controls.Add(this.AppIDExplain);
            this.GameManageGrp.Controls.Add(this.OSLabel);
            this.GameManageGrp.Controls.Add(this.OSExplain);
            this.GameManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameManageGrp.ForeColor = System.Drawing.Color.White;
            this.GameManageGrp.Location = new System.Drawing.Point(12, 249);
            this.GameManageGrp.Name = "GameManageGrp";
            this.GameManageGrp.Size = new System.Drawing.Size(242, 84);
            this.GameManageGrp.TabIndex = 21;
            this.GameManageGrp.TabStop = false;
            this.GameManageGrp.Text = "GameManageGrp";
            // 
            // BranchGrp
            // 
            this.BranchGrp.BackColor = System.Drawing.Color.Transparent;
            this.BranchGrp.Controls.Add(this.BranchPasswordTxtBox);
            this.BranchGrp.Controls.Add(this.BranchLabel);
            this.BranchGrp.Controls.Add(this.BranchNameTxtBox);
            this.BranchGrp.Controls.Add(this.BranchPasswordCB);
            this.BranchGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchGrp.ForeColor = System.Drawing.Color.White;
            this.BranchGrp.Location = new System.Drawing.Point(260, 249);
            this.BranchGrp.Name = "BranchGrp";
            this.BranchGrp.Size = new System.Drawing.Size(408, 84);
            this.BranchGrp.TabIndex = 8;
            this.BranchGrp.TabStop = false;
            this.BranchGrp.Text = "BranchGrp";
            // 
            // BranchPasswordTxtBox
            // 
            this.BranchPasswordTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BranchPasswordTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BranchPasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchPasswordTxtBox.Location = new System.Drawing.Point(203, 47);
            this.BranchPasswordTxtBox.Name = "BranchPasswordTxtBox";
            this.BranchPasswordTxtBox.Size = new System.Drawing.Size(200, 20);
            this.BranchPasswordTxtBox.TabIndex = 3;
            // 
            // BranchLabel
            // 
            this.BranchLabel.AutoSize = true;
            this.BranchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchLabel.Location = new System.Drawing.Point(6, 26);
            this.BranchLabel.Name = "BranchLabel";
            this.BranchLabel.Size = new System.Drawing.Size(67, 13);
            this.BranchLabel.TabIndex = 2;
            this.BranchLabel.Text = "BranchLabel";
            // 
            // BranchNameTxtBox
            // 
            this.BranchNameTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BranchNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BranchNameTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchNameTxtBox.Location = new System.Drawing.Point(6, 47);
            this.BranchNameTxtBox.Name = "BranchNameTxtBox";
            this.BranchNameTxtBox.Size = new System.Drawing.Size(192, 20);
            this.BranchNameTxtBox.TabIndex = 1;
            this.BranchNameTxtBox.TextChanged += new System.EventHandler(this.BranchNameTxtBox_TextChanged);
            // 
            // BranchPasswordCB
            // 
            this.BranchPasswordCB.AutoSize = true;
            this.BranchPasswordCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BranchPasswordCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchPasswordCB.Location = new System.Drawing.Point(204, 23);
            this.BranchPasswordCB.Name = "BranchPasswordCB";
            this.BranchPasswordCB.Size = new System.Drawing.Size(117, 17);
            this.BranchPasswordCB.TabIndex = 0;
            this.BranchPasswordCB.Text = "BranchPasswordCB";
            this.BranchPasswordCB.UseVisualStyleBackColor = true;
            this.BranchPasswordCB.CheckedChanged += new System.EventHandler(this.BranchPasswordCB_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SuperSteamPacker.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(468, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(678, 466);
            this.Controls.Add(this.BranchGrp);
            this.Controls.Add(this.GameManageGrp);
            this.Controls.Add(this.QueueManageGrp);
            this.Controls.Add(this.GithubBtn);
            this.Controls.Add(this.csrinbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SaveLoginBtn);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.MoreSettingsBtn);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.TmpLstBx);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.QueueLabel);
            this.Controls.Add(this.QueueBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Steam Packer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.QueueManageGrp.ResumeLayout(false);
            this.GameManageGrp.ResumeLayout(false);
            this.GameManageGrp.PerformLayout();
            this.BranchGrp.ResumeLayout(false);
            this.BranchGrp.PerformLayout();
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
        private System.Windows.Forms.GroupBox QueueManageGrp;
        private System.Windows.Forms.GroupBox GameManageGrp;
        private System.Windows.Forms.GroupBox BranchGrp;
        private System.Windows.Forms.CheckBox BranchPasswordCB;
        private System.Windows.Forms.TextBox BranchNameTxtBox;
        private System.Windows.Forms.Label BranchLabel;
        private System.Windows.Forms.TextBox BranchPasswordTxtBox;
    }
}

