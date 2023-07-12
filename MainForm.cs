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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var globalini = new Ini("Language\\Global.ini");

            string readlanguage = settingsini.Read("language", "SSP");

            if (String.IsNullOrEmpty(readlanguage) || !File.Exists("Language\\" + readlanguage + ".ini"))
            {
                readlanguage = "English";
                settingsini.Write("language", readlanguage, "SSP");
            }

            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            Text = globalini.Read("Title", "SSP") + " " + globalini.Read("Version", "SSP") + " " + languageini.Read("by", "SSP") + " " + globalini.Read("Author", "SSP");

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
                UsernameTextBox.Text = userdata.Read("username", "userdata");
                PasswordTextBox.Text = userdata.Read("password", "userdata");
                UsernameTextBox.Enabled = false;
                PasswordTextBox.Enabled = false;
            }

            BranchPasswordTxtBox.Enabled = false;
            BranchPasswordCB.Enabled     = false;
            BranchNameTxtBox.Enabled     = false;
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
            if (!File.Exists("settings.ini") || !Directory.Exists("Language"))
            {
                MessageBox.Show("Important Data is missing! Please redownload this program.", "Super Steam Packer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }

            if (File.Exists("userdata.ini"))
            {
                var userdataini = new Ini("userdata.ini");
                UsernameTextBox.Text=userdataini.Read("username", "userdata");
                PasswordTextBox.Text=userdataini.Read("password", "userdata");
                SaveLoginBtn.Enabled = false;
            }
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
                    if (OSBox.SelectedItem.ToString() == "Mac")
                    {
                        QueueBox.Items.Add("AppID: " + AppIDTxtBox.Text + "\t" + "Branch: " + BranchNameTxtBox.Text + "\t\t" + "OS: " + OSBox.SelectedItem.ToString() + "\t\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }
                    else
                    {
                        QueueBox.Items.Add("AppID: " + AppIDTxtBox.Text + "\t" + "Branch: " + BranchNameTxtBox.Text + "\t" + "OS: " + OSBox.SelectedItem.ToString() + "\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }
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
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            if (!String.IsNullOrEmpty(UsernameTextBox.Text))
            {
                if (settingsini.Read("loginwarningaccepted", "SSP") == "true")
                {
                    File.WriteAllText("userdata.ini", "[userdata]\nusername=\npassword=");
                    var userini = new Ini("userdata.ini");
                    userini.Write("username", UsernameTextBox.Text, "userdata");
                    userini.Write("password", PasswordTextBox.Text, "userdata");
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
                        userini.Write("username", UsernameTextBox.Text, "userdata");
                        userini.Write("password", PasswordTextBox.Text, "userdata");
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
                Directory.CreateDirectory("Jobs");
                for (int i = 0; i < TmpLstBx.Items.Count; i++)
                {
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
                            File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] +" validate\nquit");
                        }
                        else
                        {
                            File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] +" validate\nquit");
                        }
                    }
                    else //Non public branch code.
                    {
                        if (String.IsNullOrEmpty(workarray[3])) //non password protected branch
                        {
                            if (i == 0)
                            {
                                File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " validate\nquit");
                            }
                            else
                            {
                                File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " validate\nquit");
                            }
                        }
                        else //password protected branch
                        {
                            if (i == 0)
                            {
                                File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + " " + PasswordTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " -betapassword " + workarray[3] + " validate\nquit");
                            }
                            else
                            {
                                File.WriteAllText("Jobs\\" + i + "_" + workarray[1] + "_" + workarray[0] + ".JOB", "login " + UsernameTextBox.Text + os + "\napp_update " + workarray[1] + " -beta " + workarray[2] + " -betapassword " + workarray[3] + " validate\nquit");
                            }
                        }
                        
                    }
                }

                string[] files = Directory.GetFiles("Jobs", "*.JOB");

                foreach (string file in files)
                {
                    TmpLstBx.SelectedIndex = int.Parse(file.Substring(5, 1));
                    string[] workarray = TmpLstBx.SelectedItem.ToString().Split('|');
                    string AppID = workarray[1];
                    string Branch = workarray[2];
                    if (Branch == "Public")
                    {
                        Branch = Branch.ToLower();
                    }
                    QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("GETINFO", "SSP"));
                    var steamGameData = await GetSteamGameDataAsync(AppID);
                    string GameNameEarly = "";
                    string OS = "";
                    string BuildNoEarly = "";
                    string BuildTime = "";
                    string[] parts = file.Split('_');
                    if (parts.Length > 2)
                    {
                        switch (parts[2].Substring(0, Math.Min(5, parts[2].Length)))
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
                    }
                    if (steamGameData != null)
                    {
                        JToken buildid   = steamGameData["data"][AppID]["depots"]["branches"][Branch]["buildid"];
                        JToken buildtime = steamGameData["data"][AppID]["depots"]["branches"][Branch]["timeupdated"];
                        JToken gamename  = steamGameData["data"][AppID]["common"]["name"];

                        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(buildtime.Value<long>());
                        BuildTime = dateTime.ToString("MMMM d, yyyy - HH:mm:ss UTC");

                        GameNameEarly = steamGameData["data"][AppID]["common"]["name"].Value<string>();
                        GameNameEarly = GameNameEarly.Replace(" ", "_");
                        BuildNoEarly  = buildid.Value<string>();
                    }
                    else
                    {
                        QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("UNABLETOREACH", "SSP"));
                        continue;
                    }
                    try
                    {
                        string[] filesearly = Directory.GetFiles("Completed\\", GameNameEarly+".Build."+BuildNoEarly+"."+OS + ".*");

                        if (filesearly.Length != 0)
                        {
                            QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("SKIPPED", "SSP"));
                            continue;
                        }
                    }
                    catch 
                    {
                    }

                    QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("GETINFO", "SSP"), languageini.Read("DOWNLOADING", "SSP")); 
                    Directory.SetCurrentDirectory("SteamCMD");
                    if (Directory.Exists("Logs"))
                    {
                        Directory.Delete("Logs", true);
                    }
                    Process SteamCMD = new Process();
                    SteamCMD.StartInfo.FileName = "steamcmd.exe";
                    SteamCMD.StartInfo.Arguments = "+runscript" + " ..\\" + file;
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
                        if(File.ReadAllText("Logs\\connection_log.txt").Contains("Rate Limit Exceeded"))
                        {
                            ratelimited = true;
                            MessageBox.Show("RL");
                        }
                        if (File.ReadAllText("Logs\\connection_log.txt").Contains("Invalid Password"))
                        {
                            invalidpassword = true;
                            MessageBox.Show("IP");
                        }
                    }
                    if (!File.Exists("Logs\\sitelicense_steamcmd.txt") && !File.Exists("Logs\\compat_log.txt"))
                    {
                        steamguardcodefail = true;
                        MessageBox.Show("SGCF");
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
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                continue;
                            }
                            else
                            {
                                for (int ratelimititems = int.Parse(file.Substring(5, 1)); ratelimititems < QueueBox.Items.Count; ratelimititems++)
                                {
                                    QueueBox.Items[ratelimititems] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("RATELIMITED", "SSP"));
                                    QueueBox.Items[ratelimititems] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("READY", "SSP"), languageini.Read("RATELIMITED", "SSP"));
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
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("BADLOGIN", "SSP"));
                            }
                            else
                            {
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("FAIL", "SSP"));
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

                                DepotManifestList.Add(depotid + " - DepotName [Manifest " + manifest + "]");
                            }
                        }
                    }

                    QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("DOWNLOADING", "SSP"), languageini.Read("COMPRESSING", "SSP"));

                    Process Compress = new Process();
                    if (settingsini.Read("compressor", "SSP") == "7z")
                    {
                        Compress.StartInfo.FileName = "..\\Compressor\\7z.exe";
                        if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                        {
                            if (File.Exists("..\\Completed\\"+GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z") || File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001"))
                            {
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                Directory.Delete("Temp", true);
                                continue;
                            }
                            else
                            {
                                Compress.StartInfo.Arguments = "a -mx9 -sdel -pcs.rin.ru -v5g ..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z *";
                            }
                            
                        }
                        else
                        {
                            if (File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z") || File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001"))
                            {
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                Directory.Delete("Temp", true);
                                continue;
                            }
                            else
                            {
                                Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z *";
                            }
                        }
                    }
                    else
                    {
                        Compress.StartInfo.FileName = "..\\Compressor\\rar.exe";
                        if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                        {
                            if (File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".rar") || File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".part1.rar"))
                            {
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                Directory.Delete("Temp", true);
                                continue;
                            }
                            else
                            {
                                Compress.StartInfo.Arguments = "a -df -hpcs.rin.ru -htc -v5000000k -r ..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".rar *";
                            }
                        }
                        else
                        {
                            if (File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".rar") || File.Exists("..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".part1.rar"))
                            {
                                QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("SKIPPED", "SSP"));
                                Directory.SetCurrentDirectory("..");
                                Directory.Delete("Temp", true);
                                continue;
                            }
                            else
                            {
                                Compress.StartInfo.Arguments = "a " + settingsini.Read("customcompressoption", "SSP") + " ..\\Completed\\" + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".rar *";
                            }
                        }
                    }
                    Compress.Start();
                    Compress.WaitForExit();

                    if (Compress.ExitCode!=0)
                    {
                        QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("FAIL", "SSP"));
                        Directory.SetCurrentDirectory("..");
                        DirectoryInfo directoryInfo = new DirectoryInfo("Completed");
                        foreach (FileInfo fileToDelete in directoryInfo.GetFiles(GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".*"))
                        {
                            fileToDelete.Delete();
                        }
                        continue;
                    }

                    if (!File.Exists("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.002") && settingsini.Read("compressor", "SSP") == "7z")
                    {
                        if (File.Exists("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001"))
                        {
                            File.Move("..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z.001", "..\\Completed\\"+ GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".7z");
                        }
                        
                    }
                    Directory.SetCurrentDirectory("..");
                    Directory.Delete("Temp", true);
                    QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("COMPRESSING", "SSP"), languageini.Read("WRITINGINFO", "SSP"));

                    using (StreamWriter RINfo = new StreamWriter("Completed\\[CS.RIN.RU Info] " + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".txt"))
                    {
                        GameName = GameName.Replace("_", " ");
                        GameName = GameName.Replace(".", " ");
                        RINfo.WriteLine("[url=][color=white][b]" + GameName + " [Branch: " + workarray[2] + "] (Clean Steam Files)[/b][/color][/url]");
                        RINfo.WriteLine("[size=85][color=white][b]Version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color][/size]");
                        RINfo.WriteLine();
                        RINfo.WriteLine("[spoiler=\"[color=white]Depots & Manifests[/color]\"][code=text]");
                        foreach (string item in DepotManifestList)
                        {
                            RINfo.WriteLine(item);
                        }
                        RINfo.WriteLine("[/code][/spoiler][color=white][b]Uploaded version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color]");
                    }

                    if (settingsini.Read("uploadcrewmode", "SSP") == "1")
                    {
                        using (StreamWriter UCInfo = new StreamWriter("Completed\\[Upload Crew Info] " + GameName+".Build."+BuildNo+"."+OS+"."+workarray[2]+".txt"))
                        {
                            GameName = GameName.Replace("_", " ");
                            GameName = GameName.Replace(".", " ");
                            UCInfo.WriteLine("[color=red][b]" + GameName + "[/b][/color]");
                            UCInfo.WriteLine("[list][color=yellow][b]Mirror 1[/b][/color]");
                            UCInfo.WriteLine("[url=][color=cyan]" + GameName + "[/color] | [color=#FF8000]#UploadDate#[/color][/url] (#Filehost#) [i]< uploaded by #YourUsernameHere# / pw: cs.rin.ru >[/i][/list]");
                            UCInfo.WriteLine();
                            UCInfo.WriteLine();
                            UCInfo.WriteLine();
                            UCInfo.WriteLine("[color=red][b]" + GameName + "[/b][/color]");
                            UCInfo.WriteLine("[spoiler=\"[color=white]Depots & Manifests[/color]\"][code=text]");
                            foreach (string item in DepotManifestList)
                            {
                                UCInfo.WriteLine(item);
                            }
                            UCInfo.WriteLine("[/code][/spoiler][color=white][b]Uploaded version:[/b] [i]" + BuildTime + " [Build " + BuildNo + "][/i][/color]");
                        }
                    }

                    QueueBox.Items[int.Parse(file.Substring(5, 1))] = QueueBox.Items[int.Parse(file.Substring(5, 1))].ToString().Replace(languageini.Read("WRITINGINFO", "SSP"), languageini.Read("COMPLETE", "SSP"));
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
                    if (os == "Mac")
                    {
                        QueueBox.Items.Add("AppID: " + workarray[1] + "\t" + "Branch: " + workarray[2] + "\t\t" + "OS: " + os + "\t\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }
                    else
                    {
                        QueueBox.Items.Add("AppID: " + workarray[1] + "\t" + "Branch: " + workarray[2] + "\t" + "OS: " + os + "\t" + languageini.Read("Status", "SSP") + ":" + " " + languageini.Read("READY", "SSP"));
                    }

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
    }
}