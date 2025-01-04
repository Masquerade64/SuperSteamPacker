using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamKit2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using static SteamKit2.Internal.CContentBuilder_CommitAppBuild_Request;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace SuperSteamPacker
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Directory.Exists("Jobs"))
            {
                Directory.Delete("Jobs", true);
            }
            if (Directory.Exists("Temp"))
            {
                Directory.Delete("Temp", true);
            }
            if (!File.Exists("settings.ini"))
            {
                File.WriteAllBytes("settings.ini", Properties.Resources.Settings);
            }
            if (!Directory.Exists("Language"))
            {
                Directory.CreateDirectory("Language");
            }
            if (!File.Exists("Compressor\\7z.exe"))
            {
                if (!Directory.Exists("Compressor"))
                {
                    Directory.CreateDirectory("Compressor");
                }
                File.WriteAllBytes("Compressor\\7z.exe", Properties.Resources._7z);
            }
            if (!File.Exists("Compressor\\rar.exe"))
            {
                if (!Directory.Exists("Compressor"))
                {
                    Directory.CreateDirectory("Compressor");
                }
                File.WriteAllBytes("Compressor\\rar.exe", Properties.Resources.rar);
                File.WriteAllBytes("Compressor\\rarreg.key", Properties.Resources.rarreg);
            }

            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);

            foreach (DictionaryEntry resource in resourceSet)
            {
                string resourcename = resource.Key.ToString();
                if (resourcename.StartsWith("LANGDATA_"))
                {
                    byte[] resourceBytes = (byte[])resource.Value;
                    File.WriteAllBytes("Language\\" + resourcename.Substring(9) + ".ini", resourceBytes);
                }
            }

            var settingsini = new Ini("Settings.ini");

            string compressorcheck = settingsini.Read("compressor", "SSP");

            if (compressorcheck != "7z" && compressorcheck != "RAR")
            {
                settingsini.Write("compressor", "7z", "SSP");
            }

            if (settingsini.Read("key", "SSP").Length == 0)
            {
                if (File.Exists("userdata.ini"))
                {
                    File.Delete("userdata.ini");
                }
                settingsini.Write("key", GenerateKey(32), "SSP");
            }

            var globalini = new Ini("Language\\Global.ini");

            string readlanguage = settingsini.Read("language", "SSP");

            if (String.IsNullOrEmpty(readlanguage) || !File.Exists("Language\\" + readlanguage + ".ini"))
            {
                readlanguage = "English";
                settingsini.Write("language", readlanguage, "SSP");
            }

            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            Text = globalini.Read("Title", "SSP") + " " + globalini.Read("Version", "SSP") + " " + languageini.Read("by", "SSP") + " " + globalini.Read("Author", "SSP");

            MODAddBtn.Text               = languageini.Read("add", "SSP");
            MODDelBtn.Text               = languageini.Read("del", "SSP");
            MODStartBtn.Text             = languageini.Read("start", "SSP");
            MODClearQueueBtn.Text        = languageini.Read("ClearQueue", "SSP");
            MODExportQueueButton.Text    = languageini.Read("Export", "SSP");
            MODImportQueueButton.Text    = languageini.Read("Import", "SSP");
            MODQueueLabel.Text           = languageini.Read("queue", "SSP") + ":";
            MODMoveUpBtn.Text            = languageini.Read("MoveUp", "SSP");
            MODMoveDownBtn.Text          = languageini.Read("MoveDown", "SSP");
            MODQueueManageGrp.Text       = languageini.Read("QueueManageGroup", "SSP");
            MODManageGrp.Text            = languageini.Read("MODManager", "SSP");
            MODDelBtn.Enabled            = false;
            MODStartBtn.Enabled          = false;
            MODClearQueueBtn.Enabled     = false;
            MODMoveUpBtn.Enabled         = false;
            MODMoveDownBtn.Enabled       = false;
            MODAddBtn.Enabled            = false;
            MODExportQueueButton.Enabled = false;

            QueueLabel.Text           = languageini.Read("queue", "SSP") + ":";
            AddBtn.Text               = languageini.Read("add", "SSP");
            DelBtn.Text               = languageini.Read("del", "SSP");
            SaveLoginBtn.Text         = languageini.Read("SaveLogin", "SSP");
            StartBtn.Text             = languageini.Read("Start", "SSP");
            UsernameLabel.Text        = languageini.Read("Username", "SSP");
            PasswordLabel.Text        = languageini.Read("Password", "SSP");
            MoreSettingsBtn.Text      = languageini.Read("MoreSettings", "SSP");
            ClearQueueBtn.Text        = languageini.Read("ClearQueue", "SSP");
            csrinbtn.Text             = globalini.Read("Forum", "SSP") + " " + languageini.Read("Forum", "SSP");
            GithubBtn.Text            = globalini.Read("Github", "SSP");
            MoveUpBtn.Text            = languageini.Read("MoveUp", "SSP");
            MoveDownBtn.Text          = languageini.Read("MoveDown", "SSP");
            DelBtn.Enabled            = false;
            StartBtn.Enabled          = false;
            ClearQueueBtn.Enabled     = false;
            MoveUpBtn.Enabled         = false;
            MoveDownBtn.Enabled       = false;
            AddBtn.Enabled            = false;
            OSBox.Enabled             = false;
            ExportQueueButton.Enabled = false;
            ExportQueueButton.Text    = languageini.Read("Export", "SSP");
            ImportQueueButton.Text    = languageini.Read("Import", "SSP");
            OSBox.SelectedIndex       = 4;
            QueueManageGrp.Text       = languageini.Read("QueueManageGroup", "SSP");
            GameManageGrp.Text        = languageini.Read("GameManageGroup", "SSP");
            BranchGrp.Text            = languageini.Read("BranchManagerGroup", "SSP");
            BranchLabel.Text          = languageini.Read("BranchLabel", "SSP");
            BranchPasswordCB.Text     = languageini.Read("BranchPassword", "SSP");

            if (File.Exists("userdata.ini"))
            {
                var userdata = new Ini("userdata.ini");
                UsernameTextBox.Text = DecryptString(userdata.Read("username", "userdata"), settingsini.Read("key", "SSP"));
                PasswordTextBox.Text = DecryptString(userdata.Read("password", "userdata"), settingsini.Read("key", "SSP"));
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
            }

            BranchPasswordTxtBox.Enabled = false;
            BranchPasswordCB.Enabled     = false;
            BranchNameTxtBox.Enabled     = false;

            if (settingsini.Read("darkmode", "SSP") == "1")
            {
                BackColor = Color.FromArgb(35, 35, 40);
                GamePage.BackColor = Color.FromArgb(35, 35, 40);
                QueueLabel.ForeColor = Color.White;
                UsernameLabel.ForeColor = Color.White;
                PasswordLabel.ForeColor = Color.White;
                GameManageGrp.ForeColor = Color.White;
                BranchGrp.ForeColor = Color.White;
                QueueManageGrp.ForeColor = Color.White;
                AppIDExplain.BackColor = Color.FromArgb(60, 60, 69);
                AppIDExplain.FlatStyle = FlatStyle.Flat;
                OSExplain.BackColor = Color.FromArgb(60, 60, 69);
                OSExplain.FlatStyle = FlatStyle.Flat;
                SaveLoginBtn.BackColor = Color.FromArgb(60, 60, 69);
                SaveLoginBtn.FlatStyle = FlatStyle.Flat;
                SaveLoginBtn.ForeColor = Color.White;
                MoreSettingsBtn.BackColor = Color.FromArgb(60, 60, 69);
                MoreSettingsBtn.FlatStyle = FlatStyle.Flat;
                MoreSettingsBtn.ForeColor = Color.White;
                QueueBox.BackColor = Color.FromArgb(35,32,35);
                QueueBox.ForeColor = Color.FromArgb(58, 128, 250);
                AddBtn.BackColor = Color.FromArgb(60, 60, 69);
                AddBtn.FlatStyle = FlatStyle.Flat;
                AddBtn.ForeColor = Color.White;
                DelBtn.BackColor = Color.FromArgb(60, 60, 69);
                DelBtn.FlatStyle = FlatStyle.Flat;
                DelBtn.ForeColor = Color.White;
                ClearQueueBtn.BackColor = Color.FromArgb(60, 60, 69);
                ClearQueueBtn.FlatStyle = FlatStyle.Flat;
                ClearQueueBtn.ForeColor = Color.White;
                MoveUpBtn.BackColor = Color.FromArgb(60, 60, 69);
                MoveUpBtn.FlatStyle = FlatStyle.Flat;
                MoveUpBtn.ForeColor = Color.White;
                MoveDownBtn.BackColor = Color.FromArgb(60, 60, 69);
                MoveDownBtn.FlatStyle = FlatStyle.Flat;
                MoveDownBtn.ForeColor = Color.White;
                ExportQueueButton.BackColor = Color.FromArgb(60, 60, 69);
                ExportQueueButton.FlatStyle = FlatStyle.Flat;
                ExportQueueButton.ForeColor = Color.White;
                ImportQueueButton.BackColor = Color.FromArgb(60, 60, 69);
                ImportQueueButton.FlatStyle = FlatStyle.Flat;
                ImportQueueButton.ForeColor = Color.White;
                BranchPasswordCB.ForeColor = Color.White;
                StartBtn.BackColor = Color.FromArgb(60, 60, 69);
                StartBtn.FlatStyle = FlatStyle.Flat;
                StartBtn.ForeColor = Color.White;
                csrinbtn.BackColor = Color.FromArgb(60, 60, 69);
                csrinbtn.FlatStyle = FlatStyle.Flat;
                csrinbtn.ForeColor = Color.White;
                GithubBtn.BackColor = Color.FromArgb(60, 60, 69);
                GithubBtn.FlatStyle = FlatStyle.Flat;
                GithubBtn.ForeColor = Color.White;
                SSPLogoPicBox.Image = Properties.Resources.logo_dark;
                AppIDTxtBox.ForeColor = Color.White;
                AppIDTxtBox.BackColor = Color.FromArgb(60, 60, 69);
                AppIDTxtBox.BorderStyle = BorderStyle.FixedSingle;
                UsernameTextBox.ForeColor = Color.White;
                UsernameTextBox.BackColor = Color.FromArgb(60, 60, 69);
                UsernameTextBox.BorderStyle = BorderStyle.FixedSingle;
                PasswordTextBox.ForeColor = Color.White;
                PasswordTextBox.BackColor = Color.FromArgb(60, 60, 69);
                PasswordTextBox.BorderStyle = BorderStyle.FixedSingle;
                BranchNameTxtBox.ForeColor = Color.White;
                BranchNameTxtBox.BackColor = Color.FromArgb(60, 60, 69);
                BranchNameTxtBox.BorderStyle = BorderStyle.FixedSingle;
                BranchPasswordTxtBox.ForeColor = Color.White;
                BranchPasswordTxtBox.BackColor = Color.FromArgb(60, 60, 69);
                BranchPasswordTxtBox.BorderStyle = BorderStyle.FixedSingle;
                AchievementsPage.BackColor = Color.FromArgb(35, 35, 40);
                WorkshopPage.BackColor = Color.FromArgb(35, 35, 40);
                DepotsPage.BackColor = Color.FromArgb(35, 35, 40);
                PostTemplatePage.BackColor = Color.FromArgb(35, 35, 40);
                Placeholder2.ForeColor = Color.White;
                Placeholder3.ForeColor = Color.White;
                Placeholder4.ForeColor = Color.White;
                MODQueueLabel.ForeColor = Color.White;
                MODManageGrp.ForeColor = Color.White;
                MODAppIDTxtBx.ForeColor = Color.White;
                MODAppIDTxtBx.BackColor = Color.FromArgb(60, 60, 69);
                MODAppIDTxtBx.BorderStyle = BorderStyle.FixedSingle;
                MODWorkshopItemIDBx.ForeColor = Color.White;
                MODWorkshopItemIDBx.BackColor = Color.FromArgb(60, 60, 69);
                MODWorkshopItemIDBx.BorderStyle = BorderStyle.FixedSingle;
                MODQueueManageGrp.ForeColor = Color.White;
                MODAddBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODAddBtn.FlatStyle = FlatStyle.Flat;
                MODAddBtn.ForeColor = Color.White;
                MODDelBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODDelBtn.FlatStyle = FlatStyle.Flat;
                MODDelBtn.ForeColor = Color.White;
                MODClearQueueBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODClearQueueBtn.FlatStyle = FlatStyle.Flat;
                MODClearQueueBtn.ForeColor = Color.White;
                MODMoveUpBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODMoveUpBtn.FlatStyle = FlatStyle.Flat;
                MODMoveUpBtn.ForeColor = Color.White;
                MODMoveDownBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODMoveDownBtn.FlatStyle = FlatStyle.Flat;
                MODMoveDownBtn.ForeColor = Color.White;
                MODImportQueueButton.BackColor = Color.FromArgb(60, 60, 69);
                MODImportQueueButton.FlatStyle = FlatStyle.Flat;
                MODImportQueueButton.ForeColor = Color.White;
                MODExportQueueButton.BackColor = Color.FromArgb(60, 60, 69);
                MODExportQueueButton.FlatStyle = FlatStyle.Flat;
                MODExportQueueButton.ForeColor = Color.White;
                MODcsrinbtn.BackColor = Color.FromArgb(60, 60, 69);
                MODcsrinbtn.FlatStyle = FlatStyle.Flat;
                MODcsrinbtn.ForeColor = Color.White;
                MODGithubBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODGithubBtn.FlatStyle = FlatStyle.Flat;
                MODGithubBtn.ForeColor = Color.White;
                MODStartBtn.BackColor = Color.FromArgb(60, 60, 69);
                MODStartBtn.FlatStyle = FlatStyle.Flat;
                MODStartBtn.ForeColor = Color.White;
                MODQueueBox.BackColor = Color.FromArgb(35, 32, 35);
                MODQueueBox.ForeColor = Color.FromArgb(58, 128, 250);
            }
        }


        public static void EditVDF(string filePath, string keyToModify, string newValue)
        {
            string fileContents = File.ReadAllText(filePath);
            Regex regex = new Regex("\"" + keyToModify + "\"\\s+\"([^\"]*)\"");
            Match match = regex.Match(fileContents);

            if (match.Success)
            {
                string oldValue = match.Groups[1].Value;
                fileContents = fileContents.Replace("\"" + oldValue + "\"", "\"" + newValue + "\"");
                File.WriteAllText(filePath, fileContents);
            }
        }

        public static string ReadVDF(string filePath, string keyToRead)
        {
            string fileContents = File.ReadAllText(filePath);
            Regex regex = new Regex("\"" + keyToRead + "\"\\s+\"([^\"]*)\"");
            Match match = regex.Match(fileContents);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "0";
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        private void AppIDExplain_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            MessageBox.Show(languageini.Read("AppIDInfoMsg1", "SSP") + "\n" + "\n" + languageini.Read("AppIDInfoMsg2", "SSP") + "\n" + "\n" + "https://store.steampowered.com/app/<APPID>/", "AppID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OSExplain_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            MessageBox.Show(languageini.Read("OSMsg1", "SSP") + "\n \n" + languageini.Read("OSMsg2", "SSP"), "OS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            string appcheck = "";

            switch (OSBox.SelectedItem.ToString())
            {
                case ("Windows x64"):
                    appcheck = "win64" + "|" + AppIDTxtBox.Text + "|" + BranchNameTxtBox.Text + "|" + BranchPasswordTxtBox.Text;
                    break;
                case ("Windows x86"):
                    appcheck = "win32" + "|" + AppIDTxtBox.Text + "|" + BranchNameTxtBox.Text + "|" + BranchPasswordTxtBox.Text;
                    break;
                case ("Linux x86"):
                    appcheck = "lin32" + "|" + AppIDTxtBox.Text + "|" + BranchNameTxtBox.Text + "|" + BranchPasswordTxtBox.Text;
                    break;
                case ("Linux x64"):
                    appcheck = "lin64" + "|" + AppIDTxtBox.Text + "|" + BranchNameTxtBox.Text + "|" + BranchPasswordTxtBox.Text;
                    break;
                case ("Mac"):
                    appcheck = "macos" + "|" + AppIDTxtBox.Text + "|" + BranchNameTxtBox.Text + "|" + BranchPasswordTxtBox.Text;
                    break;
            }
            if (!TmpLstBx.Items.Contains(appcheck))
            {
                ClearQueueBtn.Enabled = true;
                ExportQueueButton.Enabled = true;

                int parsedValue;
                bool validappidcheck = int.TryParse(AppIDTxtBox.Text, out parsedValue);

                if (!String.IsNullOrEmpty(AppIDTxtBox.Text) && validappidcheck == true)
                {
                    QueueBox.Items.Add("AppID: " + AppIDTxtBox.Text + "\t" + "Branch: " + BranchNameTxtBox.Text + "\t" + "OS: " + OSBox.SelectedItem.ToString() + "\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    TmpLstBx.Items.Add(appcheck);
                    AppIDTxtBox.Text="";
                    StartBtn.Enabled = true;
                }
                else
                {
                    MessageBox.Show(languageini.Read("AppIDWarning", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AppIDTxtBox.Clear();
                }
            }
            else
            {
                MessageBox.Show(languageini.Read("AlreadyAdded", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            BranchNameTxtBox.Enabled=false;
            BranchNameTxtBox.Text="";
            BranchPasswordCB.Checked=false;
            BranchPasswordCB.Enabled=false;
            BranchPasswordTxtBox.Text="";
            BranchPasswordTxtBox.Enabled=false;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            if (QueueBox.SelectedItem != null)
            {
                int selectedindex = QueueBox.SelectedIndex;
                TmpLstBx.SelectedIndex = QueueBox.SelectedIndex;
                QueueBox.Items.Remove(QueueBox.SelectedItem);
                TmpLstBx.Items.Remove(TmpLstBx.SelectedItem);

                if (QueueBox.Items.Count == 0)
                {
                    MoveUpBtn.Enabled = false;
                    MoveDownBtn.Enabled = false;    
                    DelBtn.Enabled = false;
                    StartBtn.Enabled = false;
                    ClearQueueBtn.Enabled = false;
                    ExportQueueButton.Enabled = false;
                }
                else
                {
                    try
                    {
                        QueueBox.SelectedIndex = selectedindex;
                    }
                    catch
                    {
                        QueueBox.SelectedIndex = selectedindex-1;
                    }
                }
            }
            else
            {
                MessageBox.Show(languageini.Read("pleaseselectwarning", "SSP"), languageini.Read("information", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveLoginBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            if (!String.IsNullOrEmpty(UsernameTextBox.Text))
            {
                if (settingsini.Read("loginwarningaccepted", "SSP") == "true")
                {
                    File.WriteAllText("userdata.ini", "[userdata]\nusername=\npassword=");
                    var userini = new Ini("userdata.ini");
                    userini.Write("username", EncryptString(UsernameTextBox.Text, settingsini.Read("key", "SSP")), "userdata");
                    userini.Write("password", EncryptString(PasswordTextBox.Text, settingsini.Read("key", "SSP")), "userdata");
                    SaveLoginBtn.Enabled = false;
                    UsernameTextBox.Enabled = false;
                    PasswordTextBox.Enabled = false;
                    settingsini.Write("loginwarningaccepted", "true", "SSP");
                }
                else
                {
                    DialogResult result = MessageBox.Show(languageini.Read("LoginSaveWarning1", "SSP") + "\n\n" + languageini.Read("LoginSaveWarning2", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        File.WriteAllText("userdata.ini", "[userdata]\nusername=\npassword=");
                        var userini = new Ini("userdata.ini");
                        userini.Write("username", EncryptString(UsernameTextBox.Text, settingsini.Read("key", "SSP")), "userdata");
                        userini.Write("password", EncryptString(PasswordTextBox.Text, settingsini.Read("key", "SSP")), "userdata");
                        SaveLoginBtn.Enabled = false;
                        UsernameTextBox.Enabled = false;
                        PasswordTextBox.Enabled = false;
                        settingsini.Write("loginwarningaccepted", "true", "SSP");
                        settingsini.Write("userdatasaved", "true", "SSP");
                    }
                }
            }
            else
            {
                MessageBox.Show(languageini.Read("loginwarning", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            var depotsini = new Ini("depots.ini");
            StartBtn.Enabled = false;
            AppIDTxtBox.Enabled = false;
            OSBox.Enabled = false;
            if (Directory.Exists("Jobs"))
            {
                Directory.Delete("Jobs", true);
            }
            if (Directory.Exists("Temp"))
            {
                Directory.Delete("Temp", true);
            }
            if (Directory.Exists("SteamCMD\\steamapps"))
            {
                Directory.Delete("SteamCMD\\steamapps", true);
            }
            if (Directory.Exists("SteamCMD\\depotcache"))
            {
                Directory.Delete("SteamCMD\\depotcache", true);
            }
            if (Directory.Exists("SteamCMD\\logs"))
            {
                Directory.Delete("SteamCMD\\logs", true);
            }
            if (File.Exists("CurrentJob.JOB"))
            {
                File.Delete("CurrentJob.JOB");
            }

            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            bool anonymousloginconfirmation = false;

            if (String.IsNullOrEmpty(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "anonymous";
            }
            if (UsernameTextBox.Text == "anonymous")
            {
                DialogResult result = MessageBox.Show(languageini.Read("anonymousconfirmation", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    anonymousloginconfirmation = true;
                }
            }
            if (!File.Exists("depots.ini"))
            {
                try
                {
                    var client = new WebClient();
                    client.DownloadFile("https://raw.githubusercontent.com/Masquerade64/SteamDepotNames/main/depots.ini", "depots.ini");
                }
                catch
                {
                }
            }
            if ((!String.IsNullOrEmpty(UsernameTextBox.Text) && !String.IsNullOrEmpty(PasswordTextBox.Text)) || anonymousloginconfirmation == true)
            {
                if (!File.Exists("SteamCMD\\steamcmd.exe"))
                {
                    var client = new WebClient();
                    client.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", "download.tmp");
                    ZipFile.ExtractToDirectory("download.tmp", "SteamCMD");
                    File.Delete("download.tmp");

                    Process loadsteam1 = new Process();
                    loadsteam1.StartInfo.FileName = "SteamCMD\\steamcmd.exe";
                    loadsteam1.StartInfo.Arguments = "+quit";
                    loadsteam1.Start();
                    loadsteam1.WaitForExit();
                }
                for (int i = 0; i < TmpLstBx.Items.Count; i++)
                {
                    if (File.Exists("CurrentJob.JOB"))
                    {
                        File.Delete("CurrentJob.JOB");
                    }
                    TmpLstBx.SelectedIndex = i;
                    string os = "";
                    string[] workarray = TmpLstBx.SelectedItem.ToString().Split('|');
                    switch (workarray[0])
                    {
                        case "win64":
                            os = "\n@sSteamCmdForcePlatformType windows\n@sSteamCmdForcePlatformBitness 64";
                            break;
                        case "win32":
                            os = "\n@sSteamCmdForcePlatformType windows\n@sSteamCmdForcePlatformBitness 32";
                            break;
                        case "macos":
                            os = "\n@sSteamCmdForcePlatformType " + workarray[0];
                            break;
                        case "lin32":
                            os = "\n@sSteamCmdForcePlatformType linux\n@sSteamCmdForcePlatformBitness 32";
                            break;
                        case "lin64":
                            os = "\n@sSteamCmdForcePlatformType linux\n@sSteamCmdForcePlatformBitness 64";
                            break;
                    }
                    if (workarray[2].ToLower() == "public")
                    {
                        if (i == 0)
                        {
                            File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] +" validate\nquit");
                        }
                        else
                        {
                            File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] +" validate\nquit");
                        }
                    }
                    else //Non public branch code.
                    {
                        if (String.IsNullOrEmpty(workarray[3])) //non password protected branch
                        {
                            if (i == 0)
                            {
                                File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " validate\nquit");
                            }
                            else
                            {
                                File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " validate\nquit");
                            }
                        }
                        else //password protected branch
                        {
                            if (i == 0)
                            {
                                File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " -betapassword " + workarray[3] + " validate\nquit");
                            }
                            else
                            {
                                File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " -betapassword " + workarray[3] + " validate\nquit");
                            }
                        }

                    }

                    TmpLstBx.SelectedIndex = i;
                    string AppID = workarray[1];
                    string Branch = workarray[2];
                    if (Branch == "Public")
                    {
                        Branch = Branch.ToLower();
                    }
                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("GETINFO", "SSP"));
                    var steamGameData = await GetSteamGameDataAsync(AppID);
                    string GameNameEarly = "";
                    string OS = "";
                    string BuildNoEarly = "";
                    string BuildTime = "";
                    switch (workarray[0])
                    {
                        case "win64":
                            OS = "Win64";
                            break;
                        case "win32":
                            OS = "Win32";
                            break;
                        case "macos":
                            OS = "Mac";
                            break;
                        case "lin64":
                            OS = "Linux64";
                            break;
                        case "lin32":
                            OS = "Linux32";
                            break;
                    }
                    if (steamGameData != null)
                    {
                        if (steamGameData["status"].ToString() != "failed")
                        {
                            try
                            {
                                JToken buildid = steamGameData["data"][AppID]["depots"]["branches"][Branch]["buildid"];
                                BuildNoEarly = buildid.Value<string>();
                            }
                            catch
                            {
                                BuildNoEarly = "Unknown";
                            }
                            JToken gamename  = steamGameData["data"][AppID]["common"]["name"];
                            try
                            {
                                JToken buildtime = steamGameData["data"][AppID]["depots"]["branches"][Branch]["timeupdated"];
                                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(buildtime.Value<long>());
                                BuildTime = dateTime.ToString("MMMM d, yyyy - HH:mm:ss UTC", System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch
                            {
                                BuildTime = "";
                            }
                            GameNameEarly = steamGameData["data"][AppID]["common"]["name"].Value<string>();
                            GameNameEarly = GameNameEarly.Replace(" ", "_");
                        }
                        else
                        {
                            BuildNoEarly = "Unknown";
                            BuildTime    = "";
                            GameNameEarly= "";
                        }
                    }
                    else
                    {
                        //BuildNoEarly = "Unknown";
                        //BuildTime    = "";
                        //GameNameEarly= "";
                        QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("UNABLETOREACH", "SSP"));
                        continue;
                    }
                    try
                    {
                        string[] filesearly = Directory.GetFiles("Completed\\", GameNameEarly+".Build."+BuildNoEarly+"."+OS + ".*");

                        if (filesearly.Length != 0)
                        {
                            QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("SKIPPED", "SSP"));
                            continue;
                        }
                    }
                    catch 
                    {
                    }

                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("DOWNLOADING", "SSP")); 
                    Directory.SetCurrentDirectory("SteamCMD");
                    if (Directory.Exists("Logs"))
                    {
                        Directory.Delete("Logs", true);
                    }
                    Process SteamCMD = new Process();
                    SteamCMD.StartInfo.FileName = "steamcmd.exe";
                    SteamCMD.StartInfo.Arguments = "+runscript" + " ..\\" + "CurrentJob.JOB";
                    SteamCMD.Start();
                    SteamCMD.WaitForExit();

                    bool failedsubscription = false;
                    bool ratelimited        = false;
                    bool invalidpassword    = false;
                    bool steamguardcodefail = false;


                    if (File.Exists("Logs\\content_log.txt"))
                    {
                        if (File.ReadAllText("Logs\\content_log.txt").Contains("No subscription"))
                        {
                            failedsubscription = true;
                        }
                    }
                    if (File.Exists("Logs\\connection_log.txt"))
                    {
                        if (File.ReadAllText("Logs\\connection_log.txt").Contains("Rate Limit Exceeded"))
                        {
                            ratelimited = true;
                            //MessageBox.Show("RL");
                        }
                        if (File.ReadAllText("Logs\\connection_log.txt").Contains("Invalid Password"))
                        {
                            invalidpassword = true;
                            //MessageBox.Show("IP");
                        }
                    }
                    if (!File.Exists("Logs\\sitelicense_steamcmd.txt") && !File.Exists("Logs\\compat_log.txt"))
                    {
                        steamguardcodefail = true;
                        //MessageBox.Show("SGCF");
                    }

                    if (SteamCMD.ExitCode != 0 || ratelimited || failedsubscription || steamguardcodefail || invalidpassword)
                    {
                        if (Directory.Exists("steamapps"))
                        {
                            Directory.Delete("steamapps", true);
                        }
                        if (Directory.Exists("depotcache"))
                        {
                            Directory.Delete("depotcache", true);
                        }

                        if (ratelimited && !failedsubscription)
                        {
                            DialogResult ratelimitask = MessageBox.Show(languageini.Read("RateLimitWarn", "SSP"), languageini.Read("WARNING", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (ratelimitask == DialogResult.OK)
                            {
                                QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                continue;
                            }
                            else
                            {
                                for (int ratelimititems = i; ratelimititems < QueueBox.Items.Count; ratelimititems++)
                                {
                                    QueueBox.Items[ratelimititems] = QueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                    QueueBox.Items[ratelimititems] = QueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                }
                                if (Directory.Exists("steamapps"))
                                {
                                    Directory.Delete("steamapps", true);
                                }
                                if (Directory.Exists("depotcache"))
                                {
                                    Directory.Delete("depotcache", true);
                                }
                                if (Directory.Exists("logs"))
                                {
                                    Directory.Delete("logs", true);
                                }
                                Directory.SetCurrentDirectory("..");
                                if (Directory.Exists("Temp"))
                                {
                                    Directory.Delete("Temp", true);
                                }
                                if (Directory.Exists("Jobs"))
                                {
                                    Directory.Delete("Jobs", true);
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (steamguardcodefail || invalidpassword)
                            {
                                QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("BADLOGIN", "SSP"));
                            }
                            else
                            {
                                QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("FAIL", "SSP"));
                            }
                            Directory.SetCurrentDirectory("..");
                            continue;
                        }
                    }

                    Directory.SetCurrentDirectory("..");
                    if (!Directory.Exists("Temp"))
                    {
                        Directory.CreateDirectory("Temp");
                    }
                    DirectoryInfo depotcachedir = new DirectoryInfo("SteamCMD\\depotcache");
                    depotcachedir.MoveTo("Temp\\depotcache");
                    DirectoryInfo steamappsdir = new DirectoryInfo("SteamCMD\\steamapps");
                    steamappsdir.MoveTo("Temp\\steamapps");
                    if (File.Exists("Temp\\steamapps\\libraryfolders.vdf"))
                    {
                        File.Delete("Temp\\steamapps\\libraryfolders.vdf");
                    }
                    if (Directory.Exists("Temp\\steamapps\\downloading"))
                    {
                        Directory.Delete("Temp\\steamapps\\downloading", true);
                    }
                    if (Directory.Exists("Temp\\steamapps\\temp"))
                    {
                        Directory.Delete("Temp\\steamapps\\temp", true);
                    }
                    string[] acffiles = Directory.GetFiles("Temp\\steamapps", "*.acf");
                    foreach (string acffile in acffiles)
                    {
                        EditVDF(acffile, "LastOwner", "0");
                        EditVDF(acffile, "LauncherPath", "0");
                    }


                    string GameName = ReadVDF("Temp\\steamapps\\appmanifest_" + AppID + ".acf", "name");
                    GameName = GameName.Replace(" ", ".");
                    char[] forbiddenchars = Path.GetInvalidFileNameChars();
                    GameName = Regex.Replace(GameName, "[" + Regex.Escape(new string(forbiddenchars)) + "]", "");
                    string BuildNo = ReadVDF("Temp\\steamapps\\appmanifest_" + AppID + ".acf", "buildid");
                    if (!Directory.Exists("Completed"))
                    {
                        Directory.CreateDirectory("Completed");
                    }
                    Directory.SetCurrentDirectory("Temp");
                    if (Directory.Exists("steamapps\\workshop"))
                    {
                        Directory.Delete("steamapps\\workshop", true);
                    }

                    List<string> DepotManifestList = new List<string>();

                    foreach (string ACFPath in Directory.GetFiles("steamapps", "*.acf"))
                    {
                        JObject json = JObject.Parse(JsonConvert.SerializeObject(KeyValue.LoadFromString(Regex.Replace(File.ReadAllText(ACFPath), "//.*\n", "\n"))));
                        JObject installedDepots = (JObject)json["Children"].FirstOrDefault(c => c["Name"].Value<string>() == "InstalledDepots");

                        if (installedDepots != null)
                        {
                            JArray depots = (JArray)installedDepots["Children"];
                            foreach (JObject depot in depots)
                            {
                                string depotid = depot["Name"].Value<string>();
                                string manifest = depot["Children"].FirstOrDefault(c => c["Name"].Value<string>() == "manifest")?["Value"].Value<string>();
                                string depotname = depotsini.Read(depotid, "depots");
                                if (string.IsNullOrEmpty(depotname))
                                {
                                    DepotManifestList.Add(depotid + " - DepotName [Manifest " + manifest + "]");
                                }
                                else
                                {
                                    DepotManifestList.Add(depotid + " - " + depotname + " [Manifest " + manifest + "]");
                                }
                            }
                        }
                    }

                    if (settingsini.Read("skipcompression", "SSP") == "1")
                    {
                        Directory.SetCurrentDirectory("..");
                        Directory.Move("Temp", "Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2]);
                    }
                    else
                    {
                        QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("COMPRESSING", "SSP"));

                        Process Compress = new Process();
                        if (settingsini.Read("compressor", "SSP") == "7z")
                        {
                            Compress.StartInfo.FileName = "..\\Compressor\\7z.exe";
                            if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                            {
                                if (File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z") || File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z.001"))
                                {
                                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a -mx9 -sdel -pcs.rin.ru -mhe=on -v5g ..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z *";
                                }

                            }
                            else
                            {
                                if (File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z") || File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z.001"))
                                {
                                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".7z *";
                                }
                            }
                        }
                        else
                        {
                            Compress.StartInfo.FileName = "..\\Compressor\\rar.exe";
                            if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                            {
                                if (File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".rar") || File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".part1.rar"))
                                {
                                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a -df -hpcs.rin.ru -htc -v5000000k -r ..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".rar *";
                                }
                            }
                            else
                            {
                                if (File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".rar") || File.Exists("..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".part1.rar"))
                                {
                                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\" + GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".rar *";
                                }
                            }
                        }
                        Compress.Start();
                        Compress.WaitForExit();

                        if (Compress.ExitCode != 0)
                        {
                            QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("FAIL", "SSP"));
                            Directory.SetCurrentDirectory("..");
                            DirectoryInfo directoryInfo = new DirectoryInfo("Completed");
                            foreach (FileInfo fileToDelete in directoryInfo.GetFiles(GameName + ".Build." + BuildNo + "." + OS + "." + workarray[2] + ".*"))
                            {
                                fileToDelete.Delete();
                            }
                            continue;
                        }
                    }

                    if (!File.Exists("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.002") && settingsini.Read("compressor", "SSP") == "7z")
                    {
                        if (File.Exists("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001"))
                        {
                            File.Move("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001", "..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z");
                        }
                        
                    }
                    if (settingsini.Read("skipcompression", "SSP") == "0")
                    {
                        Directory.SetCurrentDirectory("..");
                        Directory.Delete("Temp", true);
                    }
                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("WRITINGINFO", "SSP"));
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    using (StreamWriter RINfo = new StreamWriter("Completed\\[CS.RIN.RU Info] " + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".txt"))
                    {
                        GameName = GameName.Replace("_", " ");
                        GameName = GameName.Replace(".", " ");
                        RINfo.Write("[url=][color=white][b]" + GameName + " [" + OS + "] [Branch: " + workarray[2] + "] (Clean Steam Files)[/b][/color][/url]\n"+"[size=85][color=white][b]Version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color][/size]\n\n"+"[spoiler=\"[color=white]Depots & Manifests[/color]\"][code=text]");
                        foreach (string item in DepotManifestList)
                        {
                            if (item != DepotManifestList.Last())
                            {
                                RINfo.Write(item + "\n");
                            }
                            else
                            {
                                RINfo.Write(item);
                            }
                        }
                        RINfo.Write("[/code][/spoiler][color=white][b]Uploaded version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color]");
                    }

                    if (settingsini.Read("uploadcrewmode", "SSP") == "1")
                    {
                        var storedata = await GetSteamStoreDataAsync(AppID);
                        string GameDescription = "A description could not be found for this game. Please add this manually.";
                        string BonusWebsite = null;

                        try
                        {
                            JToken ShortDescription = storedata[AppID]["data"]["short_description"];
                            GameDescription = ShortDescription.Value<string>();
                        }
                        catch
                        {
                        }
                        try
                        {
                            JToken Website = storedata[AppID]["data"]["website"];
                            BonusWebsite = Website.Value<string>();
                            BonusWebsite = BonusWebsite.Replace("http", "https");
                        }
                        catch
                        {
                        }

                        using (StreamWriter UCInfo = new StreamWriter("Completed\\[Upload Crew Info] " + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".txt"))
                        {
                            GameName = GameName.Replace("_", " ");
                            GameName = GameName.Replace(".", " ");

                            string username = settingsini.Read("rinruusername", "SSP");
                            string filehost = settingsini.Read("filehost", "SSP");

                            if (!(BonusWebsite == null))
                            {
                                UCInfo.Write("[img]https://steamcdn-a.akamaihd.net/steam/apps/"+AppID+"/header.jpg[/img]\n\n\n[color=red][b]About This Game:[/b][/color]\r\n[img]https://steamstore-a.akamaihd.net/public/images/v6/maincol_gradient_rule.png[/img]\n" + GameDescription + "\n\n[color=red][b]Official Site:[/b][/color]\r\n[url]https://store.steampowered.com/app/"+AppID+"/[/url]\r\n[url]" + BonusWebsite + "[/url]\n\n[color=red][b]Download Links:[/b][/color]\n[list][color=yellow][b]Mirror 1[/b][/color]\n[url=][color=cyan]" + GameName + "[/color] | [color=#FF8000]#UploadDate#[/color][/url] (" + filehost + ") [i]< uploaded by " + username +" / pw: cs.rin.ru >[/i][/list]\n\n\n[color=red][b]" + GameName + "[/b][/color]\n[spoiler=\"[color=white]Depots & Manifests[/color]\"][code=text]");
                            }
                            else
                            {
                                UCInfo.Write("[img]https://steamcdn-a.akamaihd.net/steam/apps/"+AppID+"/header.jpg[/img]\n\n\n[color=red][b]About This Game:[/b][/color]\r\n[img]https://steamstore-a.akamaihd.net/public/images/v6/maincol_gradient_rule.png[/img]\n" + GameDescription + "\n\n[color=red][b]Official Site:[/b][/color]\r\n[url]https://store.steampowered.com/app/"+AppID+"/[/url]\n\n[color=red][b]Download Links:[/b][/color]\n[list][color=yellow][b]Mirror 1[/b][/color]\n[url=][color=cyan]" + GameName + "[/color] | [color=#FF8000]#UploadDate#[/color][/url] (" + filehost + ") [i]< uploaded by " + username +" / pw: cs.rin.ru >[/i][/list]\n\n\n[color=red][b]" + GameName + "[/b][/color]\n[spoiler=\"[color=white]Depots & Manifests[/color]\"][code=text]");
                            }
                            
                            foreach (string item in DepotManifestList)
                            {
                                if (item != DepotManifestList.Last())
                                {
                                    UCInfo.Write(item + "\n");
                                }
                                else
                                {
                                    UCInfo.Write(item);
                                }
                            }
                            UCInfo.Write("[/code][/spoiler][color=white][b]Uploaded version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color]");
                        }
                    }

                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("WRITINGINFO", "SSP"), languageini.Read("COMPLETE", "SSP"));
                    if (File.Exists("Currentjob.JOB"))
                    {
                        File.Delete("Currentjob.JOB");
                    }

                    try
                    {
                        int gamesshared = int.Parse(settingsini.Read("gamesshared", "SSP"));
                        gamesshared++;
                        settingsini.Write("gamesshared", gamesshared.ToString(), "SSP");
                    }
                    catch
                    {
                        settingsini.Write("gamesshared", "0", "SSP");
                    }
                }
                if (Directory.Exists("Jobs"))
                {
                    Directory.Delete("Jobs", true);
                }
                MessageBox.Show(languageini.Read("jobscomplete", "SSP") + "\n\n" + languageini.Read("jobscomplete2", "SSP"), languageini.Read("information", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartBtn.Enabled=false;
                AddBtn.Enabled=false;
                DelBtn.Enabled=false;
                ClearQueueBtn.PerformClick();
            }
            else
            {
                MessageBox.Show(languageini.Read("loginwarning", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Enabled = true;
                UsernameTextBox.Enabled = true;
            }
            StartBtn.Enabled = true;
        }

        private void MoreSettingsBtn_Click(object sender, EventArgs e)
        {
            MoreSettingsForm settingsMenu = new MoreSettingsForm();
            settingsMenu.ShowDialog();
            this.Refresh();
            if (!File.Exists("userdata.ini"))
            {
                SaveLoginBtn.Enabled=true;
                UsernameTextBox.Enabled=true;
                PasswordTextBox.Enabled=true;
            }
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "anonymous")
            {
                PasswordTextBox.Enabled = false;
            }
            else
            {
                PasswordTextBox.Enabled = true;
            }
        }

        private void ClearQueueBtn_Click(object sender, EventArgs e)
        {
            MoveUpBtn.Enabled = false;
            MoveDownBtn.Enabled = false;
            ClearQueueBtn.Enabled = false;
            StartBtn.Enabled = false;
            DelBtn.Enabled = false;
            ExportQueueButton.Enabled = false;
            TmpLstBx.Items.Clear();
            QueueBox.Items.Clear();
            AppIDTxtBox.Enabled = true;
            OSBox.Enabled = true;
            BranchNameTxtBox.Enabled=false;
            BranchPasswordCB.Enabled=false;
            BranchPasswordTxtBox.Enabled=false;
        }

        private void csrinbtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://cs.rin.ru/forum");
        }

        private void GithubBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Masquerade64");
        }

        private void QueueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DelBtn.Enabled=true;
            if (QueueBox.Items.Count != 1)
            {
                if (QueueBox.SelectedIndex == 0)
                {
                    MoveUpBtn.Enabled = false;
                }
                else
                {
                    MoveUpBtn.Enabled = true;
                }
                if (QueueBox.SelectedIndex == QueueBox.Items.Count-1)
                {
                    MoveDownBtn.Enabled = false;
                }
                else
                {
                    MoveDownBtn.Enabled = true;
                }
            }
        }

        private void MoveUpBtn_Click(object sender, EventArgs e)
        {
            object selecteditem = QueueBox.SelectedItem;
            int newindex = QueueBox.SelectedIndex - 1;

            QueueBox.Items.Remove(selecteditem);
            TmpLstBx.Items.Remove(selecteditem);
            QueueBox.Items.Insert(newindex, selecteditem);
            TmpLstBx.Items.Insert(newindex, selecteditem);
            QueueBox.SetSelected(newindex, true);
        }

        private void MoveDownBtn_Click(object sender, EventArgs e)
        {
            object selecteditem = QueueBox.SelectedItem;
            int newindex = QueueBox.SelectedIndex + 1;

            QueueBox.Items.Remove(selecteditem);
            TmpLstBx.Items.Remove(selecteditem);
            QueueBox.Items.Insert(newindex, selecteditem);
            TmpLstBx.Items.Insert(newindex, selecteditem);
            QueueBox.SetSelected(newindex, true);
        }

        private void ExportQueueButton_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            SaveFileDialog savequeue = new SaveFileDialog();
            savequeue.Title = languageini.Read("Export", "SSP");
            savequeue.Filter = "SSP Queue Files (*.SSPQ)|*.SSPQ";
            DialogResult result = savequeue.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = savequeue.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in TmpLstBx.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
        }

        private void ImportQueueButton_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            OpenFileDialog openqueue = new OpenFileDialog();
            openqueue.Title = languageini.Read("Import", "SSP");
            openqueue.Filter = "SSP Queue Files (*.SSPQ)|*.SSPQ";
            DialogResult result = openqueue.ShowDialog();
            if (result == DialogResult.OK)
            {
                QueueBox.Items.Clear();
                TmpLstBx.Items.Clear();

                string[] lines = File.ReadAllLines(openqueue.FileName);

                foreach (string line in lines)
                {
                    TmpLstBx.Items.Add(line);
                    string[] workarray = line.Split('|');
                    string os = workarray[0];
                    switch (os)
                    {
                        case "win64":
                            os = "Windows x64";
                            break;
                        case "win32":
                            os = "Windows x86";
                            break;
                        case "macos":
                            os = "Mac";
                            break;
                        case "lin32":
                            os = "Linux x86";
                            break;
                        case "lin64":
                            os = "Linux x64";
                            break;
                    }
                    QueueBox.Items.Add("AppID: " + workarray[1] + "\t" + "Branch: " + workarray[2] + "\t" + "OS: " + os + "\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    DelBtn.Enabled = true;
                    ClearQueueBtn.Enabled = true;
                    StartBtn.Enabled = true;
                    ExportQueueButton.Enabled = true;
                }
            }
        }

        private void AppIDTxtBox_TextChanged(object sender, EventArgs e)
        {
            AddBtn.Enabled = true;
            OSBox.Enabled  = true;
            BranchNameTxtBox.Enabled = true;
            BranchNameTxtBox.Text = "Public";
        }

        static async Task<JObject> GetSteamGameDataAsync(string appId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://api.steamcmd.net/v1/info/{appId}";
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(jsonString);
                }
            }
            catch
            {
                return null;
            }
        }

        static async Task<JObject> GetSteamStoreDataAsync(string appId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://store.steampowered.com/api/appdetails?appids={appId}";
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(jsonString);
                }
            }
            catch
            {
                return null;
            }
        }

        private void BranchPasswordCB_CheckedChanged(object sender, EventArgs e)
        {
            if (BranchPasswordCB.Checked)
            {
                BranchPasswordTxtBox.Enabled = true;
            }
            else
            {
                BranchPasswordTxtBox.Enabled = false;
            }
        }

        private void BranchNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!(BranchNameTxtBox.Text.ToLower() == "public"))
            {
                BranchPasswordCB.Enabled = true;
            }
            else
            {
                BranchPasswordTxtBox.Enabled = false;
                BranchPasswordCB.Enabled = false;
                BranchPasswordTxtBox.Text = "";
                BranchPasswordCB.Checked = false;
            }
        }

        static string EncryptString(string plainText, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    string completed = Convert.ToBase64String(aesAlg.IV) + ":" + Convert.ToBase64String(msEncrypt.ToArray());
                    byte[] textbytes = Encoding.UTF8.GetBytes(completed);
                    byte[] keybytes = Encoding.UTF8.GetBytes(key);
                    byte[] xorbytes = new byte[textbytes.Length];
                    for (int i = 0; i < textbytes.Length; i++)
                    {
                        xorbytes[i] = (byte)(textbytes[i] ^ keybytes[i % keybytes.Length]);
                    }
                    return Convert.ToBase64String(xorbytes);
                }
            }
        }

        static string DecryptString(string cipherText, string key)
        {
            byte[] xorbytes = Convert.FromBase64String(cipherText);
            byte[] keybytes = Encoding.UTF8.GetBytes(key);

            byte[] decryptedBytes = new byte[xorbytes.Length];
            for (int i = 0; i < xorbytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(xorbytes[i] ^ keybytes[i % keybytes.Length]);
            }

            string[] parts = Encoding.UTF8.GetString(decryptedBytes).Split(':');
            byte[] iv = Convert.FromBase64String(parts[0]);
            byte[] cipherBytes = Convert.FromBase64String(parts[1]);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        static string GenerateKey(int length)
        {
            string asciiCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+[]{}|,.<>?";
            StringBuilder sb = new StringBuilder(length);
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(asciiCharacters.Length);
                char randomChar = asciiCharacters[index];
                sb.Append(randomChar);
            }
            return sb.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MODAppIDTxtBx.Text) && !string.IsNullOrEmpty(MODWorkshopItemIDBx.Text))
            {
                MODAddBtn.Enabled = true;
            }
            else
            {
                MODAddBtn.Enabled = false;
            }
        }


        private void MODAddBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            int appidvalue;
            long workshopitemvalue;
            bool validappid       = int.TryParse(MODAppIDTxtBx.Text, out appidvalue);
            bool validworkshopid  = long.TryParse(MODWorkshopItemIDBx.Text, out workshopitemvalue);
            if (validappid == true && validworkshopid == true)
            {
                bool itemexistsinlist = false;
                string newentry = MODAppIDTxtBx.Text + "|" + MODWorkshopItemIDBx.Text;
                foreach (string item in MODTmpLstBx.Items)
                {
                    if (newentry == item)
                    {
                        itemexistsinlist = true;
                        break;
                    }
                }
                if (!itemexistsinlist) // item is NOT in list.
                {
                    MODTmpLstBx.Items.Add(newentry);
                    MODQueueBox.Items.Add("AppID: " + MODAppIDTxtBx.Text + "\t\t Workshop Item ID: " + MODWorkshopItemIDBx.Text + "\t\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    MODClearQueueBtn.Enabled     = true;
                    MODExportQueueButton.Enabled = true;
                    MODWorkshopItemIDBx.Text     = "";
                    MODAppIDTxtBx.Text           = "";
                }
                else
                {
                    //Item is in the list.
                }
                MODStartBtn.Enabled = true;
            }
            else
            {
                //Item is NOT valid. Something failed the integer check.
                MessageBox.Show(languageini.Read("MODWarning1", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MODQueueBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MODDelBtn.Enabled=true;
            if (MODQueueBox.Items.Count != 1)
            {
                if (MODQueueBox.SelectedIndex == 0)
                {
                    MODMoveUpBtn.Enabled = false;
                }
                else
                {
                    MODMoveUpBtn.Enabled = true;
                }
                if (MODQueueBox.SelectedIndex == MODQueueBox.Items.Count-1)
                {
                    MODMoveDownBtn.Enabled = false;
                }
                else
                {
                    MODMoveDownBtn.Enabled = true;
                }
            }
        }

        private void MODDelBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            if (MODQueueBox.SelectedItem != null)
            {
                int selectedindex = MODQueueBox.SelectedIndex;
                MODTmpLstBx.SelectedIndex = MODQueueBox.SelectedIndex;
                MODQueueBox.Items.Remove(MODQueueBox.SelectedItem);
                MODTmpLstBx.Items.Remove(MODTmpLstBx.SelectedItem);

                if (MODQueueBox.Items.Count == 0)
                {
                    MODMoveUpBtn.Enabled = false;
                    MODMoveDownBtn.Enabled = false;
                    MODDelBtn.Enabled = false;
                    MODStartBtn.Enabled = false;
                    MODClearQueueBtn.Enabled = false;
                    MODExportQueueButton.Enabled = false;
                }
                else
                {
                    try
                    {
                        MODQueueBox.SelectedIndex = selectedindex;
                    }
                    catch
                    {
                        MODQueueBox.SelectedIndex = selectedindex-1;
                    }
                }
            }
            else
            {
                MessageBox.Show(languageini.Read("pleaseselectwarning", "SSP"), languageini.Read("information", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MODClearQueueBtn_Click(object sender, EventArgs e)
        {
            MODMoveUpBtn.Enabled = false;
            MODMoveDownBtn.Enabled = false;
            MODClearQueueBtn.Enabled = false;
            MODStartBtn.Enabled = false;
            MODDelBtn.Enabled = false;
            MODExportQueueButton.Enabled = false;
            MODTmpLstBx.Items.Clear();
            MODQueueBox.Items.Clear();
        }

        private void MODExportQueueButton_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            SaveFileDialog savequeue = new SaveFileDialog();
            savequeue.Title = languageini.Read("Export", "SSP");
            savequeue.Filter = "SSP Workshop Queue Files (*.SSWQ)|*.SSWQ";
            DialogResult result = savequeue.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filePath = savequeue.FileName;
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in MODTmpLstBx.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
        }

        private void MODImportQueueButton_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            OpenFileDialog openqueue = new OpenFileDialog();
            openqueue.Title = languageini.Read("Import", "SSP");
            openqueue.Filter = "SSP Workshop Queue Files (*.SSWQ)|*.SSWQ|Text Files (*.txt)|*.TXT";
            DialogResult result = openqueue.ShowDialog();
            if (result == DialogResult.OK)
            {
                MODQueueBox.Items.Clear();
                MODTmpLstBx.Items.Clear();

                string[] lines = File.ReadAllLines(openqueue.FileName);

                foreach (string line in lines)
                {
                    

                    if (line.Contains("|"))
                    {
                        string[] workarray = line.Split('|');
                        MODTmpLstBx.Items.Add(line);
                        MODQueueBox.Items.Add("AppID: " + workarray[0] + "\t\t Workshop Item ID: " + workarray[1] + "\t\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }
                    else if (line.Contains("workshop_download_item"))
                    {
                        string[] workarray = line.Split(' ');
                        MODTmpLstBx.Items.Add(workarray[1]+"|"+workarray[2]);
                        MODQueueBox.Items.Add("AppID: " + workarray[1] + "\t\t Workshop Item ID: " + workarray[2] + "\t\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }
                    MODDelBtn.Enabled = true;
                    MODClearQueueBtn.Enabled = true;
                    MODStartBtn.Enabled = true;
                    MODExportQueueButton.Enabled = true;
                }
            }
        }

        private void MODStartBtn_Click(object sender, EventArgs e)
        {
            MODStartBtn.Enabled = false;
            if (Directory.Exists("Jobs"))
            {
                Directory.Delete("Jobs", true);
            }
            if (Directory.Exists("Temp"))
            {
                Directory.Delete("Temp", true);
            }
            if (Directory.Exists("SteamCMD\\steamapps"))
            {
                Directory.Delete("SteamCMD\\steamapps", true);
            }
            if (Directory.Exists("SteamCMD\\depotcache"))
            {
                Directory.Delete("SteamCMD\\depotcache", true);
            }
            if (Directory.Exists("SteamCMD\\logs"))
            {
                Directory.Delete("SteamCMD\\logs", true);
            }
            if (File.Exists("CurrentJob.JOB"))
            {
                File.Delete("CurrentJob.JOB");
            }
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            bool anonymousloginconfirmation = false;

            if (String.IsNullOrEmpty(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "anonymous";
            }
            if (UsernameTextBox.Text == "anonymous")
            {
                DialogResult result = MessageBox.Show(languageini.Read("anonymousconfirmation", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    anonymousloginconfirmation = true;
                }
            }
            if ((!String.IsNullOrEmpty(UsernameTextBox.Text) && !String.IsNullOrEmpty(PasswordTextBox.Text)) || anonymousloginconfirmation == true)
            {
                if (!File.Exists("SteamCMD\\steamcmd.exe"))
                {
                    var client = new WebClient();
                    client.DownloadFile("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip", "download.tmp");
                    ZipFile.ExtractToDirectory("download.tmp", "SteamCMD");
                    File.Delete("download.tmp");

                    Process loadsteam1 = new Process();
                    loadsteam1.StartInfo.FileName = "SteamCMD\\steamcmd.exe";
                    loadsteam1.StartInfo.Arguments = "+quit";
                    loadsteam1.Start();
                    loadsteam1.WaitForExit();
                }
                for (int i = 0; i < MODTmpLstBx.Items.Count; i++)
                {
                    if (File.Exists("CurrentJob.JOB"))
                    {
                        File.Delete("CurrentJob.JOB");
                    }
                    MODTmpLstBx.SelectedIndex = i;
                    string[] workarray = MODTmpLstBx.SelectedItem.ToString().Split('|');
                    string AppID = workarray[0];
                    string WorkshopID = workarray[1];

                    if (File.Exists("Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z") || File.Exists("Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.001"))
                    {
                        MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("SKIPPED", "SSP"));
                        continue;
                    }
                    if (File.Exists("Completed\\Workshop_" + AppID + "_" + WorkshopID + ".rar") || File.Exists("Completed\\Workshop_" + AppID + "_" + WorkshopID + ".part1.rar"))
                    {
                        MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("SKIPPED", "SSP"));
                        continue;
                    }

                    if (i == 0)
                    {
                        File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + "\nworkshop_download_item " + workarray[0] + " " + workarray[1] + " validate\nquit");
                    }
                    else
                    {
                        File.WriteAllText("Currentjob.JOB", "login " + UsernameTextBox.Text + "\nworkshop_download_item " + workarray[0] + " " + workarray[1] + " validate\nquit");
                    }
                    MODTmpLstBx.SelectedIndex = i;
                    try
                    {
                        string[] filesearly = Directory.GetFiles("Completed\\Workshop_", AppID + "_" + WorkshopID + ".*");

                        if (filesearly.Length != 0)
                        {
                            MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("SKIPPED", "SSP"));
                            continue;
                        }
                    }
                    catch
                    {
                    }
                    MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("DOWNLOADING", "SSP"));
                    if (Directory.Exists("Logs"))
                    {
                        Directory.Delete("Logs", true);
                    }
                    Directory.SetCurrentDirectory("SteamCMD");
                    Process SteamCMD = new Process();
                    SteamCMD.StartInfo.FileName = "steamcmd.exe";
                    SteamCMD.StartInfo.Arguments = "+runscript" + " ..\\" + "CurrentJob.JOB";
                    SteamCMD.Start();
                    SteamCMD.WaitForExit();

                    bool failedsubscription = false;
                    bool ratelimited = false;
                    bool invalidpassword = false;
                    bool steamguardcodefail = false;

                    if (File.Exists("Logs\\content_log.txt"))
                    {
                        if (File.ReadAllText("Logs\\content_log.txt").Contains("No subscription"))
                        {
                            failedsubscription = true;
                        }
                    }
                    if (File.Exists("Logs\\connection_log.txt"))
                    {
                        if (File.ReadAllText("Logs\\connection_log.txt").Contains("Rate Limit Exceeded"))
                        {
                            ratelimited = true;
                            //MessageBox.Show("RL");
                        }
                        if (File.ReadAllText("Logs\\connection_log.txt").Contains("Invalid Password"))
                        {
                            invalidpassword = true;
                            //MessageBox.Show("IP");
                        }
                    }
                    if (!File.Exists("Logs\\sitelicense_steamcmd.txt") && !File.Exists("Logs\\compat_log.txt"))
                    {
                        steamguardcodefail = true;
                        //MessageBox.Show("SGCF");
                    }

                    if (SteamCMD.ExitCode != 0 || ratelimited || failedsubscription || steamguardcodefail || invalidpassword)
                    {
                        if (Directory.Exists("steamapps"))
                        {
                            Directory.Delete("steamapps", true);
                        }
                        if (Directory.Exists("depotcache"))
                        {
                            Directory.Delete("depotcache", true);
                        }

                        if (ratelimited && !failedsubscription)
                        {
                            DialogResult ratelimitask = MessageBox.Show(languageini.Read("RateLimitWarn", "SSP"), languageini.Read("WARNING", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            if (ratelimitask == DialogResult.OK)
                            {
                                MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                continue;
                            }
                            else
                            {
                                for (int ratelimititems = i; ratelimititems < MODQueueBox.Items.Count; ratelimititems++)
                                {
                                    MODQueueBox.Items[ratelimititems] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                    MODQueueBox.Items[ratelimititems] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                }
                                if (Directory.Exists("steamapps"))
                                {
                                    Directory.Delete("steamapps", true);
                                }
                                if (Directory.Exists("depotcache"))
                                {
                                    Directory.Delete("depotcache", true);
                                }
                                if (Directory.Exists("logs"))
                                {
                                    Directory.Delete("logs", true);
                                }
                                Directory.SetCurrentDirectory("..");
                                if (Directory.Exists("Temp"))
                                {
                                    Directory.Delete("Temp", true);
                                }
                                if (Directory.Exists("Jobs"))
                                {
                                    Directory.Delete("Jobs", true);
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (steamguardcodefail || invalidpassword)
                            {
                                MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("BADLOGIN", "SSP"));
                            }
                            else
                            {
                                MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("FAIL", "SSP"));
                            }
                            Directory.SetCurrentDirectory("..");
                            continue;
                        }
                    }
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    if (!Directory.Exists("Temp"))
                    {
                        Directory.CreateDirectory("Temp");
                    }
                    DirectoryInfo depotcachedir = new DirectoryInfo("SteamCMD\\depotcache");
                    try
                    {
                        depotcachedir.MoveTo("Temp\\depotcache");
                    }
                    catch

                    {
                        MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("FAIL", "SSP"));
                        continue;
                    }
                    DirectoryInfo steamappsdir = new DirectoryInfo("SteamCMD\\steamapps");
                    steamappsdir.MoveTo("Temp\\steamapps");
                    if (File.Exists("Temp\\steamapps\\libraryfolders.vdf"))
                    {
                        File.Delete("Temp\\steamapps\\libraryfolders.vdf");
                    }
                    if (Directory.Exists("Temp\\steamapps\\downloading"))
                    {
                        Directory.Delete("Temp\\steamapps\\downloading", true);
                    }
                    if (Directory.Exists("Temp\\steamapps\\temp"))
                    {
                        Directory.Delete("Temp\\steamapps\\temp", true);
                    }
                    if (Directory.Exists("Temp\\steamapps\\workshop\\downloads"))
                    {
                        Directory.Delete("Temp\\steamapps\\workshop\\downloads", true);
                    }
                    if (Directory.Exists("Temp\\steamapps\\workshop\\temp"))
                    {
                        Directory.Delete("Temp\\steamapps\\workshop\\temp", true);
                    }
                    if (!Directory.Exists("Completed"))
                    {
                        Directory.CreateDirectory("Completed");
                    }

                    if (settingsini.Read("skipcompression", "SSP") == "1")
                    {
                        Directory.Move("Temp", "Completed\\Workshop_" + AppID + "_" + WorkshopID);
                    }
                    else
                    {
                        Directory.SetCurrentDirectory("Temp");
                        MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("COMPRESSING", "SSP"));

                        Process Compress = new Process();
                        if (settingsini.Read("compressor", "SSP") == "7z")
                        {
                            Compress.StartInfo.FileName = "..\\Compressor\\7z.exe";
                            if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                            {
                                if (File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z") || File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.001"))
                                {
                                    MODQueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a -mx9 -sdel -pcs.rin.ru -mhe=on -v5g ..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z *";
                                }

                            }
                            else
                            {
                                if (File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z") || File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.001"))
                                {
                                    MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z *";
                                }
                            }
                        }
                        else
                        {
                            Compress.StartInfo.FileName = "..\\Compressor\\rar.exe";
                            if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                            {
                                if (File.Exists("..\\Completed\\" + AppID + "_" + WorkshopID + ".rar") || File.Exists("..\\Completed\\" + AppID + "_" + WorkshopID + ".part1.rar"))
                                {
                                    MODQueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a -df -hpcs.rin.ru -htc -v5000000k -r ..\\Completed\\" + AppID + "_" + WorkshopID + ".rar *";
                                }
                            }
                            else
                            {
                                if (File.Exists("..\\Completed\\" + AppID + "_" + WorkshopID + ".rar") || File.Exists("..\\Completed\\" + AppID + "_" + WorkshopID + ".part1.rar"))
                                {
                                    QueueBox.Items[i] = QueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                    Directory.SetCurrentDirectory("..");
                                    Directory.Delete("Temp", true);
                                    continue;
                                }
                                else
                                {
                                    Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\" + AppID + "_" + WorkshopID + ".rar *";
                                }
                            }
                        }
                        Compress.Start();
                        Compress.WaitForExit();
                        if (Compress.ExitCode != 0)
                        {
                            MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("FAIL", "SSP"));
                            Directory.SetCurrentDirectory("..");
                            DirectoryInfo directoryInfo = new DirectoryInfo("Completed");
                            foreach (FileInfo fileToDelete in directoryInfo.GetFiles("Workshop_" + AppID + "_" + WorkshopID + ".*"))
                            {
                                fileToDelete.Delete();
                            }
                            continue;
                        }
                        if (!File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.002") && settingsini.Read("compressor", "SSP") == "7z")
                        {
                            if (File.Exists("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.001"))
                            {
                                File.Move("..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.001", "..\\Completed\\Workshop_" + AppID + "_" + WorkshopID + ".7z.");
                            }
                        }
                        Directory.SetCurrentDirectory("..");
                        Directory.Delete("Temp", true);
                    }
                    MODQueueBox.Items[i] = MODQueueBox.Items[i].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("COMPLETE", "SSP"));
                    if (File.Exists("Currentjob.JOB"))
                    {
                        File.Delete("Currentjob.JOB");
                    }
                }
                if (Directory.Exists("Jobs"))
                {
                    Directory.Delete("Jobs", true);
                }
                MessageBox.Show(languageini.Read("jobscomplete", "SSP") + "\n\n" + languageini.Read("jobscomplete2", "SSP"), languageini.Read("information", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                MODStartBtn.Enabled = false;
                MODAddBtn.Enabled = false;
                MODDelBtn.Enabled = false;
                MODClearQueueBtn.PerformClick();
            }
            else
            {
                MessageBox.Show(languageini.Read("loginwarning", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Enabled = true;
                UsernameTextBox.Enabled = true;
            }
            MODStartBtn.Enabled = true;
        }
    }
}