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
            this.TabManager = new System.Windows.Forms.TabControl();
            this.GamePage = new System.Windows.Forms.TabPage();
            this.SSPLogoPicBox = new System.Windows.Forms.PictureBox();
            this.WorkshopPage = new System.Windows.Forms.TabPage();
            this.MODTmpLstBx = new System.Windows.Forms.ListBox();
            this.MODManageGrp = new System.Windows.Forms.GroupBox();
            this.MODWorkshopItemID = new System.Windows.Forms.Label();
            this.MODWorkshopItemIDBx = new System.Windows.Forms.TextBox();
            this.MODAppIDTxtBx = new System.Windows.Forms.TextBox();
            this.MODAppIDLabel = new System.Windows.Forms.Label();
            this.MODQueueBox = new System.Windows.Forms.ListBox();
            this.MODQueueLabel = new System.Windows.Forms.Label();
            this.MODStartBtn = new System.Windows.Forms.Button();
            this.MODQueueManageGrp = new System.Windows.Forms.GroupBox();
            this.MODMoveUpBtn = new System.Windows.Forms.Button();
            this.MODMoveDownBtn = new System.Windows.Forms.Button();
            this.MODExportQueueButton = new System.Windows.Forms.Button();
            this.MODImportQueueButton = new System.Windows.Forms.Button();
            this.MODClearQueueBtn = new System.Windows.Forms.Button();
            this.MODAddBtn = new System.Windows.Forms.Button();
            this.MODDelBtn = new System.Windows.Forms.Button();
            this.MODGithubBtn = new System.Windows.Forms.Button();
            this.MODcsrinbtn = new System.Windows.Forms.Button();
            this.DepotsPage = new System.Windows.Forms.TabPage();
            this.Placeholder2 = new System.Windows.Forms.Label();
            this.AchievementsPage = new System.Windows.Forms.TabPage();
            this.Placeholder3 = new System.Windows.Forms.Label();
            this.PostTemplatePage = new System.Windows.Forms.TabPage();
            this.Placeholder4 = new System.Windows.Forms.Label();
            this.QueueManageGrp.SuspendLayout();
            this.GameManageGrp.SuspendLayout();
            this.BranchGrp.SuspendLayout();
            this.TabManager.SuspendLayout();
            this.GamePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPLogoPicBox)).BeginInit();
            this.WorkshopPage.SuspendLayout();
            this.MODManageGrp.SuspendLayout();
            this.MODQueueManageGrp.SuspendLayout();
            this.DepotsPage.SuspendLayout();
            this.AchievementsPage.SuspendLayout();
            this.PostTemplatePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // OSBox
            // 
            this.OSBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OSBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSBox.FormattingEnabled = true;
            this.OSBox.Items.AddRange(new object[] {
            "Linux x86",
            "Linux x64",
            "Mac",
            "Windows x86",
            "Windows x64"});
            this.OSBox.Location = new System.Drawing.Point(52, 55);
            this.OSBox.Name = "OSBox";
            this.OSBox.Size = new System.Drawing.Size(177, 21);
            this.OSBox.TabIndex = 5;
            // 
            // QueueBox
            // 
            this.QueueBox.FormattingEnabled = true;
            this.QueueBox.Location = new System.Drawing.Point(6, 26);
            this.QueueBox.Name = "QueueBox";
            this.QueueBox.Size = new System.Drawing.Size(468, 212);
            this.QueueBox.TabIndex = 1;
            this.QueueBox.SelectedIndexChanged += new System.EventHandler(this.QueueBox_SelectedIndexChanged);
            // 
            // QueueLabel
            // 
            this.QueueLabel.AutoSize = true;
            this.QueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueLabel.Location = new System.Drawing.Point(3, 3);
            this.QueueLabel.Name = "QueueLabel";
            this.QueueLabel.Size = new System.Drawing.Size(87, 18);
            this.QueueLabel.TabIndex = 2;
            this.QueueLabel.Text = "QueueLabel";
            // 
            // AppIDTxtBox
            // 
            this.AppIDTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDTxtBox.Location = new System.Drawing.Point(52, 27);
            this.AppIDTxtBox.Name = "AppIDTxtBox";
            this.AppIDTxtBox.Size = new System.Drawing.Size(179, 20);
            this.AppIDTxtBox.TabIndex = 3;
            this.AppIDTxtBox.WordWrap = false;
            this.AppIDTxtBox.TextChanged += new System.EventHandler(this.AppIDTxtBox_TextChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBtn.Location = new System.Drawing.Point(6, 24);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(150, 35);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "AddBtn";
            this.AddBtn.UseVisualStyleBackColor = true;
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
            this.AppIDExplain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AppIDExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppIDExplain.Location = new System.Drawing.Point(236, 26);
            this.AppIDExplain.Name = "AppIDExplain";
            this.AppIDExplain.Size = new System.Drawing.Size(22, 22);
            this.AppIDExplain.TabIndex = 4;
            this.AppIDExplain.Text = "?";
            this.AppIDExplain.UseVisualStyleBackColor = true;
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
            this.OSExplain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OSExplain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSExplain.Location = new System.Drawing.Point(235, 55);
            this.OSExplain.Name = "OSExplain";
            this.OSExplain.Size = new System.Drawing.Size(23, 23);
            this.OSExplain.TabIndex = 6;
            this.OSExplain.Text = "?";
            this.OSExplain.UseVisualStyleBackColor = true;
            this.OSExplain.Click += new System.EventHandler(this.OSExplain_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelBtn.Location = new System.Drawing.Point(159, 23);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(150, 36);
            this.DelBtn.TabIndex = 8;
            this.DelBtn.Text = "DelBtn";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBtn.Location = new System.Drawing.Point(480, 335);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(204, 59);
            this.StartBtn.TabIndex = 14;
            this.StartBtn.Text = "StartBtn";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // TmpLstBx
            // 
            this.TmpLstBx.FormattingEnabled = true;
            this.TmpLstBx.Location = new System.Drawing.Point(374, 26);
            this.TmpLstBx.Name = "TmpLstBx";
            this.TmpLstBx.Size = new System.Drawing.Size(100, 95);
            this.TmpLstBx.TabIndex = 11;
            this.TmpLstBx.Visible = false;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(480, 115);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(204, 20);
            this.UsernameTextBox.TabIndex = 1;
            this.UsernameTextBox.WordWrap = false;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // MoreSettingsBtn
            // 
            this.MoreSettingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoreSettingsBtn.Location = new System.Drawing.Point(480, 217);
            this.MoreSettingsBtn.Name = "MoreSettingsBtn";
            this.MoreSettingsBtn.Size = new System.Drawing.Size(204, 25);
            this.MoreSettingsBtn.TabIndex = 13;
            this.MoreSettingsBtn.Text = "MoreSettingsBtn";
            this.MoreSettingsBtn.UseVisualStyleBackColor = true;
            this.MoreSettingsBtn.Click += new System.EventHandler(this.MoreSettingsBtn_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(480, 160);
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
            this.PasswordLabel.Location = new System.Drawing.Point(481, 142);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(79, 13);
            this.PasswordLabel.TabIndex = 15;
            this.PasswordLabel.Text = "PasswordLabel";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(481, 98);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(81, 13);
            this.UsernameLabel.TabIndex = 16;
            this.UsernameLabel.Text = "UsernameLabel";
            // 
            // SaveLoginBtn
            // 
            this.SaveLoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveLoginBtn.Location = new System.Drawing.Point(480, 186);
            this.SaveLoginBtn.Name = "SaveLoginBtn";
            this.SaveLoginBtn.Size = new System.Drawing.Size(204, 25);
            this.SaveLoginBtn.TabIndex = 17;
            this.SaveLoginBtn.Text = "SaveLoginBtn";
            this.SaveLoginBtn.UseVisualStyleBackColor = true;
            this.SaveLoginBtn.Click += new System.EventHandler(this.SaveLoginBtn_Click);
            // 
            // ClearQueueBtn
            // 
            this.ClearQueueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearQueueBtn.Location = new System.Drawing.Point(312, 23);
            this.ClearQueueBtn.Name = "ClearQueueBtn";
            this.ClearQueueBtn.Size = new System.Drawing.Size(150, 36);
            this.ClearQueueBtn.TabIndex = 9;
            this.ClearQueueBtn.Text = "ClearQueueBtn";
            this.ClearQueueBtn.UseVisualStyleBackColor = true;
            this.ClearQueueBtn.Click += new System.EventHandler(this.ClearQueueBtn_Click);
            // 
            // MoveUpBtn
            // 
            this.MoveUpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUpBtn.Location = new System.Drawing.Point(6, 64);
            this.MoveUpBtn.Name = "MoveUpBtn";
            this.MoveUpBtn.Size = new System.Drawing.Size(225, 25);
            this.MoveUpBtn.TabIndex = 10;
            this.MoveUpBtn.Text = "MoveUpBtn";
            this.MoveUpBtn.UseVisualStyleBackColor = true;
            this.MoveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
            // 
            // MoveDownBtn
            // 
            this.MoveDownBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveDownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveDownBtn.Location = new System.Drawing.Point(237, 64);
            this.MoveDownBtn.Name = "MoveDownBtn";
            this.MoveDownBtn.Size = new System.Drawing.Size(225, 25);
            this.MoveDownBtn.TabIndex = 11;
            this.MoveDownBtn.Text = "MoveDownBtn";
            this.MoveDownBtn.UseVisualStyleBackColor = true;
            this.MoveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
            // 
            // csrinbtn
            // 
            this.csrinbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.csrinbtn.Location = new System.Drawing.Point(480, 400);
            this.csrinbtn.Name = "csrinbtn";
            this.csrinbtn.Size = new System.Drawing.Size(204, 25);
            this.csrinbtn.TabIndex = 15;
            this.csrinbtn.Text = "CS.RIN.RU";
            this.csrinbtn.UseVisualStyleBackColor = true;
            this.csrinbtn.Click += new System.EventHandler(this.csrinbtn_Click);
            // 
            // ExportQueueButton
            // 
            this.ExportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportQueueButton.Location = new System.Drawing.Point(6, 92);
            this.ExportQueueButton.Name = "ExportQueueButton";
            this.ExportQueueButton.Size = new System.Drawing.Size(225, 25);
            this.ExportQueueButton.TabIndex = 12;
            this.ExportQueueButton.Text = "ExportQueueButton";
            this.ExportQueueButton.UseVisualStyleBackColor = true;
            this.ExportQueueButton.Click += new System.EventHandler(this.ExportQueueButton_Click);
            // 
            // ImportQueueButton
            // 
            this.ImportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportQueueButton.Location = new System.Drawing.Point(237, 92);
            this.ImportQueueButton.Name = "ImportQueueButton";
            this.ImportQueueButton.Size = new System.Drawing.Size(225, 25);
            this.ImportQueueButton.TabIndex = 13;
            this.ImportQueueButton.Text = "ImportQueueButton";
            this.ImportQueueButton.UseVisualStyleBackColor = true;
            this.ImportQueueButton.Click += new System.EventHandler(this.ImportQueueButton_Click);
            // 
            // GithubBtn
            // 
            this.GithubBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GithubBtn.Location = new System.Drawing.Point(480, 431);
            this.GithubBtn.Name = "GithubBtn";
            this.GithubBtn.Size = new System.Drawing.Size(204, 25);
            this.GithubBtn.TabIndex = 16;
            this.GithubBtn.Text = "Masquerade\'s Github";
            this.GithubBtn.UseVisualStyleBackColor = true;
            this.GithubBtn.Click += new System.EventHandler(this.GithubBtn_Click);
            // 
            // QueueManageGrp
            // 
            this.QueueManageGrp.Controls.Add(this.MoveUpBtn);
            this.QueueManageGrp.Controls.Add(this.MoveDownBtn);
            this.QueueManageGrp.Controls.Add(this.ExportQueueButton);
            this.QueueManageGrp.Controls.Add(this.ImportQueueButton);
            this.QueueManageGrp.Controls.Add(this.ClearQueueBtn);
            this.QueueManageGrp.Controls.Add(this.AddBtn);
            this.QueueManageGrp.Controls.Add(this.DelBtn);
            this.QueueManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueueManageGrp.Location = new System.Drawing.Point(6, 335);
            this.QueueManageGrp.Name = "QueueManageGrp";
            this.QueueManageGrp.Size = new System.Drawing.Size(468, 122);
            this.QueueManageGrp.TabIndex = 20;
            this.QueueManageGrp.TabStop = false;
            this.QueueManageGrp.Text = "QueueManageGrp";
            // 
            // GameManageGrp
            // 
            this.GameManageGrp.Controls.Add(this.AppIDLabel);
            this.GameManageGrp.Controls.Add(this.OSBox);
            this.GameManageGrp.Controls.Add(this.AppIDTxtBox);
            this.GameManageGrp.Controls.Add(this.AppIDExplain);
            this.GameManageGrp.Controls.Add(this.OSLabel);
            this.GameManageGrp.Controls.Add(this.OSExplain);
            this.GameManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameManageGrp.Location = new System.Drawing.Point(6, 245);
            this.GameManageGrp.Name = "GameManageGrp";
            this.GameManageGrp.Size = new System.Drawing.Size(264, 84);
            this.GameManageGrp.TabIndex = 21;
            this.GameManageGrp.TabStop = false;
            this.GameManageGrp.Text = "GameManageGrp";
            // 
            // BranchGrp
            // 
            this.BranchGrp.Controls.Add(this.BranchPasswordTxtBox);
            this.BranchGrp.Controls.Add(this.BranchLabel);
            this.BranchGrp.Controls.Add(this.BranchNameTxtBox);
            this.BranchGrp.Controls.Add(this.BranchPasswordCB);
            this.BranchGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchGrp.Location = new System.Drawing.Point(276, 245);
            this.BranchGrp.Name = "BranchGrp";
            this.BranchGrp.Size = new System.Drawing.Size(408, 84);
            this.BranchGrp.TabIndex = 8;
            this.BranchGrp.TabStop = false;
            this.BranchGrp.Text = "BranchGrp";
            // 
            // BranchPasswordTxtBox
            // 
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
            this.BranchPasswordCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchPasswordCB.Location = new System.Drawing.Point(203, 24);
            this.BranchPasswordCB.Name = "BranchPasswordCB";
            this.BranchPasswordCB.Size = new System.Drawing.Size(120, 17);
            this.BranchPasswordCB.TabIndex = 0;
            this.BranchPasswordCB.Text = "BranchPasswordCB";
            this.BranchPasswordCB.UseVisualStyleBackColor = true;
            this.BranchPasswordCB.CheckedChanged += new System.EventHandler(this.BranchPasswordCB_CheckedChanged);
            // 
            // TabManager
            // 
            this.TabManager.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabManager.Controls.Add(this.GamePage);
            this.TabManager.Controls.Add(this.WorkshopPage);
            this.TabManager.Controls.Add(this.DepotsPage);
            this.TabManager.Controls.Add(this.AchievementsPage);
            this.TabManager.Controls.Add(this.PostTemplatePage);
            this.TabManager.HotTrack = true;
            this.TabManager.Location = new System.Drawing.Point(0, 0);
            this.TabManager.Name = "TabManager";
            this.TabManager.SelectedIndex = 0;
            this.TabManager.Size = new System.Drawing.Size(698, 490);
            this.TabManager.TabIndex = 22;
            // 
            // GamePage
            // 
            this.GamePage.BackColor = System.Drawing.Color.White;
            this.GamePage.Controls.Add(this.TmpLstBx);
            this.GamePage.Controls.Add(this.QueueLabel);
            this.GamePage.Controls.Add(this.BranchGrp);
            this.GamePage.Controls.Add(this.QueueBox);
            this.GamePage.Controls.Add(this.GameManageGrp);
            this.GamePage.Controls.Add(this.StartBtn);
            this.GamePage.Controls.Add(this.QueueManageGrp);
            this.GamePage.Controls.Add(this.GithubBtn);
            this.GamePage.Controls.Add(this.UsernameTextBox);
            this.GamePage.Controls.Add(this.csrinbtn);
            this.GamePage.Controls.Add(this.MoreSettingsBtn);
            this.GamePage.Controls.Add(this.SSPLogoPicBox);
            this.GamePage.Controls.Add(this.PasswordTextBox);
            this.GamePage.Controls.Add(this.SaveLoginBtn);
            this.GamePage.Controls.Add(this.PasswordLabel);
            this.GamePage.Controls.Add(this.UsernameLabel);
            this.GamePage.Location = new System.Drawing.Point(4, 25);
            this.GamePage.Name = "GamePage";
            this.GamePage.Padding = new System.Windows.Forms.Padding(3);
            this.GamePage.Size = new System.Drawing.Size(690, 461);
            this.GamePage.TabIndex = 0;
            this.GamePage.Text = "Steam Games";
            // 
            // SSPLogoPicBox
            // 
            this.SSPLogoPicBox.Image = global::SuperSteamPacker.Properties.Resources.logo;
            this.SSPLogoPicBox.Location = new System.Drawing.Point(484, 8);
            this.SSPLogoPicBox.Name = "SSPLogoPicBox";
            this.SSPLogoPicBox.Size = new System.Drawing.Size(193, 78);
            this.SSPLogoPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SSPLogoPicBox.TabIndex = 18;
            this.SSPLogoPicBox.TabStop = false;
            // 
            // WorkshopPage
            // 
            this.WorkshopPage.BackColor = System.Drawing.Color.White;
            this.WorkshopPage.Controls.Add(this.MODTmpLstBx);
            this.WorkshopPage.Controls.Add(this.MODManageGrp);
            this.WorkshopPage.Controls.Add(this.MODQueueBox);
            this.WorkshopPage.Controls.Add(this.MODQueueLabel);
            this.WorkshopPage.Controls.Add(this.MODStartBtn);
            this.WorkshopPage.Controls.Add(this.MODQueueManageGrp);
            this.WorkshopPage.Controls.Add(this.MODGithubBtn);
            this.WorkshopPage.Controls.Add(this.MODcsrinbtn);
            this.WorkshopPage.Location = new System.Drawing.Point(4, 25);
            this.WorkshopPage.Name = "WorkshopPage";
            this.WorkshopPage.Padding = new System.Windows.Forms.Padding(3);
            this.WorkshopPage.Size = new System.Drawing.Size(690, 461);
            this.WorkshopPage.TabIndex = 1;
            this.WorkshopPage.Text = "Steam Workshop";
            // 
            // MODTmpLstBx
            // 
            this.MODTmpLstBx.FormattingEnabled = true;
            this.MODTmpLstBx.Location = new System.Drawing.Point(535, 26);
            this.MODTmpLstBx.Name = "MODTmpLstBx";
            this.MODTmpLstBx.Size = new System.Drawing.Size(147, 147);
            this.MODTmpLstBx.TabIndex = 29;
            this.MODTmpLstBx.Visible = false;
            // 
            // MODManageGrp
            // 
            this.MODManageGrp.Controls.Add(this.MODWorkshopItemID);
            this.MODManageGrp.Controls.Add(this.MODWorkshopItemIDBx);
            this.MODManageGrp.Controls.Add(this.MODAppIDTxtBx);
            this.MODManageGrp.Controls.Add(this.MODAppIDLabel);
            this.MODManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.MODManageGrp.Location = new System.Drawing.Point(6, 280);
            this.MODManageGrp.Name = "MODManageGrp";
            this.MODManageGrp.Size = new System.Drawing.Size(676, 52);
            this.MODManageGrp.TabIndex = 28;
            this.MODManageGrp.TabStop = false;
            this.MODManageGrp.Text = "MODManageGrp";
            // 
            // MODWorkshopItemID
            // 
            this.MODWorkshopItemID.AutoSize = true;
            this.MODWorkshopItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MODWorkshopItemID.Location = new System.Drawing.Point(219, 23);
            this.MODWorkshopItemID.Name = "MODWorkshopItemID";
            this.MODWorkshopItemID.Size = new System.Drawing.Size(96, 13);
            this.MODWorkshopItemID.TabIndex = 3;
            this.MODWorkshopItemID.Text = "Workshop Item ID:";
            // 
            // MODWorkshopItemIDBx
            // 
            this.MODWorkshopItemIDBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MODWorkshopItemIDBx.Location = new System.Drawing.Point(321, 19);
            this.MODWorkshopItemIDBx.Name = "MODWorkshopItemIDBx";
            this.MODWorkshopItemIDBx.Size = new System.Drawing.Size(349, 20);
            this.MODWorkshopItemIDBx.TabIndex = 2;
            this.MODWorkshopItemIDBx.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MODAppIDTxtBx
            // 
            this.MODAppIDTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MODAppIDTxtBx.Location = new System.Drawing.Point(52, 20);
            this.MODAppIDTxtBx.Name = "MODAppIDTxtBx";
            this.MODAppIDTxtBx.Size = new System.Drawing.Size(161, 20);
            this.MODAppIDTxtBx.TabIndex = 1;
            this.MODAppIDTxtBx.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MODAppIDLabel
            // 
            this.MODAppIDLabel.AutoSize = true;
            this.MODAppIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MODAppIDLabel.Location = new System.Drawing.Point(6, 23);
            this.MODAppIDLabel.Name = "MODAppIDLabel";
            this.MODAppIDLabel.Size = new System.Drawing.Size(40, 13);
            this.MODAppIDLabel.TabIndex = 0;
            this.MODAppIDLabel.Text = "AppID:";
            // 
            // MODQueueBox
            // 
            this.MODQueueBox.FormattingEnabled = true;
            this.MODQueueBox.Location = new System.Drawing.Point(6, 26);
            this.MODQueueBox.Name = "MODQueueBox";
            this.MODQueueBox.Size = new System.Drawing.Size(676, 251);
            this.MODQueueBox.TabIndex = 27;
            this.MODQueueBox.SelectedIndexChanged += new System.EventHandler(this.MODQueueBox_SelectedIndexChanged);
            // 
            // MODQueueLabel
            // 
            this.MODQueueLabel.AutoSize = true;
            this.MODQueueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODQueueLabel.Location = new System.Drawing.Point(3, 3);
            this.MODQueueLabel.Name = "MODQueueLabel";
            this.MODQueueLabel.Size = new System.Drawing.Size(123, 18);
            this.MODQueueLabel.TabIndex = 25;
            this.MODQueueLabel.Text = "MODQueueLabel";
            // 
            // MODStartBtn
            // 
            this.MODStartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODStartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODStartBtn.Location = new System.Drawing.Point(480, 335);
            this.MODStartBtn.Name = "MODStartBtn";
            this.MODStartBtn.Size = new System.Drawing.Size(204, 59);
            this.MODStartBtn.TabIndex = 21;
            this.MODStartBtn.Text = "MODStartBtn";
            this.MODStartBtn.UseVisualStyleBackColor = true;
            this.MODStartBtn.Click += new System.EventHandler(this.MODStartBtn_Click);
            // 
            // MODQueueManageGrp
            // 
            this.MODQueueManageGrp.Controls.Add(this.MODMoveUpBtn);
            this.MODQueueManageGrp.Controls.Add(this.MODMoveDownBtn);
            this.MODQueueManageGrp.Controls.Add(this.MODExportQueueButton);
            this.MODQueueManageGrp.Controls.Add(this.MODImportQueueButton);
            this.MODQueueManageGrp.Controls.Add(this.MODClearQueueBtn);
            this.MODQueueManageGrp.Controls.Add(this.MODAddBtn);
            this.MODQueueManageGrp.Controls.Add(this.MODDelBtn);
            this.MODQueueManageGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODQueueManageGrp.Location = new System.Drawing.Point(6, 335);
            this.MODQueueManageGrp.Name = "MODQueueManageGrp";
            this.MODQueueManageGrp.Size = new System.Drawing.Size(468, 122);
            this.MODQueueManageGrp.TabIndex = 24;
            this.MODQueueManageGrp.TabStop = false;
            this.MODQueueManageGrp.Text = "MODQueueManageGrp";
            // 
            // MODMoveUpBtn
            // 
            this.MODMoveUpBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODMoveUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODMoveUpBtn.Location = new System.Drawing.Point(6, 64);
            this.MODMoveUpBtn.Name = "MODMoveUpBtn";
            this.MODMoveUpBtn.Size = new System.Drawing.Size(225, 25);
            this.MODMoveUpBtn.TabIndex = 10;
            this.MODMoveUpBtn.Text = "MODMoveUpBtn";
            this.MODMoveUpBtn.UseVisualStyleBackColor = true;
            // 
            // MODMoveDownBtn
            // 
            this.MODMoveDownBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODMoveDownBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODMoveDownBtn.Location = new System.Drawing.Point(237, 64);
            this.MODMoveDownBtn.Name = "MODMoveDownBtn";
            this.MODMoveDownBtn.Size = new System.Drawing.Size(225, 25);
            this.MODMoveDownBtn.TabIndex = 11;
            this.MODMoveDownBtn.Text = "MODMoveDownBtn";
            this.MODMoveDownBtn.UseVisualStyleBackColor = true;
            // 
            // MODExportQueueButton
            // 
            this.MODExportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODExportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODExportQueueButton.Location = new System.Drawing.Point(6, 92);
            this.MODExportQueueButton.Name = "MODExportQueueButton";
            this.MODExportQueueButton.Size = new System.Drawing.Size(225, 25);
            this.MODExportQueueButton.TabIndex = 12;
            this.MODExportQueueButton.Text = "MODExportQueueButton";
            this.MODExportQueueButton.UseVisualStyleBackColor = true;
            this.MODExportQueueButton.Click += new System.EventHandler(this.MODExportQueueButton_Click);
            // 
            // MODImportQueueButton
            // 
            this.MODImportQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODImportQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODImportQueueButton.Location = new System.Drawing.Point(237, 92);
            this.MODImportQueueButton.Name = "MODImportQueueButton";
            this.MODImportQueueButton.Size = new System.Drawing.Size(225, 25);
            this.MODImportQueueButton.TabIndex = 13;
            this.MODImportQueueButton.Text = "MODImportQueueButton";
            this.MODImportQueueButton.UseVisualStyleBackColor = true;
            this.MODImportQueueButton.Click += new System.EventHandler(this.MODImportQueueButton_Click);
            // 
            // MODClearQueueBtn
            // 
            this.MODClearQueueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODClearQueueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODClearQueueBtn.Location = new System.Drawing.Point(312, 23);
            this.MODClearQueueBtn.Name = "MODClearQueueBtn";
            this.MODClearQueueBtn.Size = new System.Drawing.Size(150, 36);
            this.MODClearQueueBtn.TabIndex = 9;
            this.MODClearQueueBtn.Text = "MODClearBtn";
            this.MODClearQueueBtn.UseVisualStyleBackColor = true;
            this.MODClearQueueBtn.Click += new System.EventHandler(this.MODClearQueueBtn_Click);
            // 
            // MODAddBtn
            // 
            this.MODAddBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODAddBtn.Location = new System.Drawing.Point(6, 24);
            this.MODAddBtn.Name = "MODAddBtn";
            this.MODAddBtn.Size = new System.Drawing.Size(150, 35);
            this.MODAddBtn.TabIndex = 7;
            this.MODAddBtn.Text = "MODAddBtn";
            this.MODAddBtn.UseVisualStyleBackColor = true;
            this.MODAddBtn.Click += new System.EventHandler(this.MODAddBtn_Click);
            // 
            // MODDelBtn
            // 
            this.MODDelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODDelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MODDelBtn.Location = new System.Drawing.Point(159, 23);
            this.MODDelBtn.Name = "MODDelBtn";
            this.MODDelBtn.Size = new System.Drawing.Size(150, 36);
            this.MODDelBtn.TabIndex = 8;
            this.MODDelBtn.Text = "MODDelBtn";
            this.MODDelBtn.UseVisualStyleBackColor = true;
            this.MODDelBtn.Click += new System.EventHandler(this.MODDelBtn_Click);
            // 
            // MODGithubBtn
            // 
            this.MODGithubBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODGithubBtn.Location = new System.Drawing.Point(480, 431);
            this.MODGithubBtn.Name = "MODGithubBtn";
            this.MODGithubBtn.Size = new System.Drawing.Size(204, 25);
            this.MODGithubBtn.TabIndex = 23;
            this.MODGithubBtn.Text = "Masquerade\'s Github";
            this.MODGithubBtn.UseVisualStyleBackColor = true;
            this.MODGithubBtn.Click += new System.EventHandler(this.GithubBtn_Click);
            // 
            // MODcsrinbtn
            // 
            this.MODcsrinbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MODcsrinbtn.Location = new System.Drawing.Point(480, 400);
            this.MODcsrinbtn.Name = "MODcsrinbtn";
            this.MODcsrinbtn.Size = new System.Drawing.Size(204, 25);
            this.MODcsrinbtn.TabIndex = 22;
            this.MODcsrinbtn.Text = "CS.RIN.RU Forum";
            this.MODcsrinbtn.UseVisualStyleBackColor = true;
            this.MODcsrinbtn.Click += new System.EventHandler(this.csrinbtn_Click);
            // 
            // DepotsPage
            // 
            this.DepotsPage.BackColor = System.Drawing.Color.White;
            this.DepotsPage.Controls.Add(this.Placeholder2);
            this.DepotsPage.Location = new System.Drawing.Point(4, 25);
            this.DepotsPage.Name = "DepotsPage";
            this.DepotsPage.Padding = new System.Windows.Forms.Padding(3);
            this.DepotsPage.Size = new System.Drawing.Size(690, 461);
            this.DepotsPage.TabIndex = 2;
            this.DepotsPage.Text = "Steam Depots";
            // 
            // Placeholder2
            // 
            this.Placeholder2.AutoSize = true;
            this.Placeholder2.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Placeholder2.Location = new System.Drawing.Point(3, 3);
            this.Placeholder2.Name = "Placeholder2";
            this.Placeholder2.Size = new System.Drawing.Size(234, 39);
            this.Placeholder2.TabIndex = 1;
            this.Placeholder2.Text = "Coming soon.";
            // 
            // AchievementsPage
            // 
            this.AchievementsPage.BackColor = System.Drawing.Color.White;
            this.AchievementsPage.Controls.Add(this.Placeholder3);
            this.AchievementsPage.Location = new System.Drawing.Point(4, 25);
            this.AchievementsPage.Name = "AchievementsPage";
            this.AchievementsPage.Padding = new System.Windows.Forms.Padding(3);
            this.AchievementsPage.Size = new System.Drawing.Size(690, 461);
            this.AchievementsPage.TabIndex = 3;
            this.AchievementsPage.Text = "Achievements";
            // 
            // Placeholder3
            // 
            this.Placeholder3.AutoSize = true;
            this.Placeholder3.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Placeholder3.Location = new System.Drawing.Point(3, 3);
            this.Placeholder3.Name = "Placeholder3";
            this.Placeholder3.Size = new System.Drawing.Size(234, 39);
            this.Placeholder3.TabIndex = 2;
            this.Placeholder3.Text = "Coming soon.";
            // 
            // PostTemplatePage
            // 
            this.PostTemplatePage.BackColor = System.Drawing.Color.White;
            this.PostTemplatePage.Controls.Add(this.Placeholder4);
            this.PostTemplatePage.Location = new System.Drawing.Point(4, 25);
            this.PostTemplatePage.Name = "PostTemplatePage";
            this.PostTemplatePage.Padding = new System.Windows.Forms.Padding(3);
            this.PostTemplatePage.Size = new System.Drawing.Size(690, 461);
            this.PostTemplatePage.TabIndex = 4;
            this.PostTemplatePage.Text = "Post Template";
            // 
            // Placeholder4
            // 
            this.Placeholder4.AutoSize = true;
            this.Placeholder4.Font = new System.Drawing.Font("Lucida Sans Unicode", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Placeholder4.Location = new System.Drawing.Point(3, 3);
            this.Placeholder4.Name = "Placeholder4";
            this.Placeholder4.Size = new System.Drawing.Size(234, 39);
            this.Placeholder4.TabIndex = 2;
            this.Placeholder4.Text = "Coming soon.";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(698, 490);
            this.Controls.Add(this.TabManager);
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
            this.TabManager.ResumeLayout(false);
            this.GamePage.ResumeLayout(false);
            this.GamePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPLogoPicBox)).EndInit();
            this.WorkshopPage.ResumeLayout(false);
            this.WorkshopPage.PerformLayout();
            this.MODManageGrp.ResumeLayout(false);
            this.MODManageGrp.PerformLayout();
            this.MODQueueManageGrp.ResumeLayout(false);
            this.DepotsPage.ResumeLayout(false);
            this.DepotsPage.PerformLayout();
            this.AchievementsPage.ResumeLayout(false);
            this.AchievementsPage.PerformLayout();
            this.PostTemplatePage.ResumeLayout(false);
            this.PostTemplatePage.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.PictureBox SSPLogoPicBox;
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
        private System.Windows.Forms.TabControl TabManager;
        private System.Windows.Forms.TabPage GamePage;
        private System.Windows.Forms.TabPage WorkshopPage;
        private System.Windows.Forms.TabPage DepotsPage;
        private System.Windows.Forms.Label Placeholder2;
        private System.Windows.Forms.TabPage AchievementsPage;
        private System.Windows.Forms.Button MODStartBtn;
        private System.Windows.Forms.GroupBox MODQueueManageGrp;
        private System.Windows.Forms.Button MODMoveUpBtn;
        private System.Windows.Forms.Button MODMoveDownBtn;
        private System.Windows.Forms.Button MODExportQueueButton;
        private System.Windows.Forms.Button MODImportQueueButton;
        private System.Windows.Forms.Button MODClearQueueBtn;
        private System.Windows.Forms.Button MODAddBtn;
        private System.Windows.Forms.Button MODDelBtn;
        private System.Windows.Forms.Button MODGithubBtn;
        private System.Windows.Forms.Button MODcsrinbtn;
        private System.Windows.Forms.Label MODQueueLabel;
        private System.Windows.Forms.ListBox MODQueueBox;
        private System.Windows.Forms.GroupBox MODManageGrp;
        private System.Windows.Forms.Label MODAppIDLabel;
        private System.Windows.Forms.TextBox MODAppIDTxtBx;
        private System.Windows.Forms.Label MODWorkshopItemID;
        private System.Windows.Forms.TextBox MODWorkshopItemIDBx;
        private System.Windows.Forms.ListBox MODTmpLstBx;
        private System.Windows.Forms.TabPage PostTemplatePage;
        private System.Windows.Forms.Label Placeholder3;
        private System.Windows.Forms.Label Placeholder4;
    }
}

