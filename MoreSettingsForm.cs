using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Net;

namespace SuperSteamPacker
{
    public partial class MoreSettingsForm : Form
    {
        public MoreSettingsForm()
        {
            InitializeComponent();

            var settingsini = new Ini("Settings.ini");

            string[] langfiles = Directory.GetFiles("Language", "*.ini");
            foreach (string langfile in langfiles)
            {
                if (langfile.Substring(9, langfile.Length-(9+4)).ToLower() != "global")
                {
                    LangChoiceBox.Items.Add(langfile.Substring(9, langfile.Length-(9+4)));
                }
            }
            LangChoiceBox.SelectedItem = settingsini.Read("language", "SSP");

            switch (settingsini.Read("compressor", "SSP"))
            {
                case "7z":
                    CompressorChoiceBox.SelectedIndex = 0;
                    break;
                case "RAR":
                    CompressorChoiceBox.SelectedIndex = 1;
                    break;
            }

            if (!File.Exists("userdata.ini"))
            {
                DelSavedLoginBtn.Enabled = false;
            }

            if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
            {
                CustomCompressorOptionsTextBox.Enabled = false;
                CustomCompressorOptionsCheckBox.Checked = false;
            }
            else
            {
                CustomCompressorOptionsTextBox.Text = settingsini.Read("customcompressoption", "SSP");
                CustomCompressorOptionsCheckBox.Checked = true;
            }

            rinruUsernameTextbox.Enabled = false;
            filehostTextbox.Enabled      = false;

            if (settingsini.Read("uploadcrewmode", "SSP") == "1")
            {
                UploadCrewModeCB.Checked = true;
                rinruUsernameTextbox.Enabled = true;
                rinruUsernameTextbox.Text = settingsini.Read("rinruusername", "SSP");
                filehostTextbox.Enabled = true;
                filehostTextbox.Text = settingsini.Read("filehost", "SSP");
            }

            if (settingsini.Read("darkmode", "SSP") == "1")
            {
                DarkModeCB.Checked = true;
            }

            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            Text = languageini.Read("MoreSettings", "SSP");
            LangLabel.Text = languageini.Read("Language","SSP") + ":";
            CompressorLabel.Text = languageini.Read("Compressor", "SSP") + ":";
            CustomCompressorOptionsCheckBox.Text = languageini.Read("customcompressoroptions", "SSP");
            DelSavedLoginBtn.Text = languageini.Read("DeleteSavedLogin", "SSP");
            UploadCrewModeCB.Text = languageini.Read("UploadCrewMode", "SSP");
            DarkModeCB.Text = languageini.Read("DarkMode", "SSP");
            DepotSyncBtn.Text = languageini.Read("SyncDepots", "SSP");
            rinruUsernameLabel.Text = languageini.Read("rinruUsername", "SSP");
            filehostLabel.Text = languageini.Read("filehost", "SSP");
            SkipCompressionCheckBox.Text = languageini.Read("skipcompression", "SSP");

            if (settingsini.Read("darkmode", "SSP") == "1")
            {
                LangLabel.ForeColor                        = Color.White;
                CompressorLabel.ForeColor                  = Color.White;
                CompressorLabel.ForeColor                  = Color.White;
                CustomCompressorOptionsCheckBox.ForeColor  = Color.White;
                UploadCrewModeCB.ForeColor                 = Color.White;
                DarkModeCB.ForeColor                       = Color.White;
                BackColor                                  = Color.FromArgb(35,35,40);
                DelSavedLoginBtn.BackColor                 = Color.FromArgb(60,60,69);
                DelSavedLoginBtn.ForeColor                 = Color.White;
                DelSavedLoginBtn.FlatStyle                 = FlatStyle.Flat;
                CustomCompressorOptionsTextBox.ForeColor   = Color.White;
                CustomCompressorOptionsTextBox.BackColor   = Color.FromArgb(60, 60, 69);
                CustomCompressorOptionsTextBox.BorderStyle = BorderStyle.FixedSingle;
                DepotSyncBtn.BackColor                     = Color.FromArgb(60, 60, 69);
                DepotSyncBtn.ForeColor                     = Color.White;
                DepotSyncBtn.FlatStyle                     = FlatStyle.Flat;
                rinruUsernameLabel.ForeColor               = Color.White;
                rinruUsernameTextbox.ForeColor             = Color.White;
                rinruUsernameTextbox.BackColor             = Color.FromArgb(60, 60, 69);
                rinruUsernameTextbox.BorderStyle           = BorderStyle.FixedSingle;
                filehostLabel.ForeColor                    = Color.White;
                filehostTextbox.ForeColor                  = Color.White;
                filehostTextbox.BackColor                  = Color.FromArgb(60, 60, 69);
                filehostTextbox.BorderStyle                = BorderStyle.FixedSingle;
                SkipCompressionCheckBox.ForeColor          = Color.White;    
            }
        }

        private void DelSavedLoginBtn_Click(object sender, EventArgs e)
        {
            File.Delete("userdata.ini");
            DelSavedLoginBtn.Enabled = false;
        }

        private void LangChoiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            settingsini.Write("language", LangChoiceBox.SelectedItem.ToString(), "SSP");
        }

        private void CustomCompressorOptionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            if (CustomCompressorOptionsCheckBox.Checked == true)
            {
                if (String.IsNullOrEmpty(settingsini.Read("customcompressoption", "SSP")))
                {
                    DialogResult result = MessageBox.Show(languageini.Read("compressionwarning1", "SSP") + "\n\n" + languageini.Read("compressionwarning2", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        CustomCompressorOptionsTextBox.Enabled = true;
                    }
                    else
                    {
                        CustomCompressorOptionsTextBox.Enabled  = false;
                        CustomCompressorOptionsCheckBox.Checked = false;
                    }
                }
            }
            else
            {
                settingsini.Write("customcompressoption", null, "SSP");
                CustomCompressorOptionsTextBox.Enabled = false;
                CustomCompressorOptionsTextBox.Text = null;
            }
        }

        private void CustomCompressorOptionsTextBox_TextChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            settingsini.Write("customcompressoption", CustomCompressorOptionsTextBox.Text, "SSP");
        }

        private void CompressorChoiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            switch (CompressorChoiceBox.SelectedIndex)
            {
                case 0:
                    settingsini.Write("compressor", "7z", "SSP");
                    break;
                case 1:
                    settingsini.Write("compressor", "RAR", "SSP");
                    break;
            }
            
        }

        private void UploadCrewModeCB_CheckedChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            switch (UploadCrewModeCB.Checked)
            {
                case true:
                    settingsini.Write("uploadcrewmode", "1", "SSP");
                    rinruUsernameTextbox.Enabled = true;
                    filehostTextbox.Enabled = true; 
                    break;
                case false:
                    settingsini.Write("uploadcrewmode", "0", "SSP");
                    rinruUsernameTextbox.Enabled = false;
                    rinruUsernameTextbox.Text = null;
                    filehostTextbox.Enabled = false;
                    filehostTextbox.Text = null;
                    break;
            }
        }

        private void DarkModeCB_CheckedChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            switch (DarkModeCB.Checked)
            {
                case true:
                    settingsini.Write("darkmode", "1", "SSP");
                    break;
                case false:
                    settingsini.Write("darkmode", "0", "SSP");
                    break;
            }
        }

        private void DepotSyncBtn_Click(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            var globalini = new Ini("Language\\Global.ini");
            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");
            try
            {
                var client = new WebClient();
                client.DownloadFile("https://raw.githubusercontent.com/Masquerade64/SteamDepotNames/main/depots.ini", "depots.ini");
                MessageBox.Show(languageini.Read("depotsyncsuccess", "SSP"), languageini.Read("Information", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                DepotSyncBtn.Enabled = false;
            }
            catch
            {
                MessageBox.Show(languageini.Read("unabletoaccessgithub", "SSP"), languageini.Read("Warning", "SSP"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rinruUsernameTextbox_TextChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            settingsini.Write("rinruusername", rinruUsernameTextbox.Text, "SSP");
        }

        private void filehostTextbox_TextChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            settingsini.Write("filehost", filehostTextbox.Text, "SSP");
        }

        private void SkipCompressionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var settingsini = new Ini("Settings.ini");
            switch (SkipCompressionCheckBox.Checked)
            {
                case true:
                    settingsini.Write("skipcompression", "1", "SSP");
                    break;
                case false:
                    settingsini.Write("skipcompression", "0", "SSP");
                    break;
            }
        }
    }
}
