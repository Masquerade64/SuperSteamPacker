using System;
using System.IO;
using System.Windows.Forms;

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

            string readlanguage = settingsini.Read("language", "SSP");
            var languageini = new Ini("Language\\" + readlanguage + ".ini");

            this.Text = languageini.Read("MoreSettings", "SSP");
            LangLabel.Text = languageini.Read("Language","SSP") + ":";
            CompressorLabel.Text = languageini.Read("Compressor", "SSP") + ":";
            CustomCompressorOptionsCheckBox.Text = languageini.Read("customcompressoroptions", "SSP");
            DelSavedLoginBtn.Text = languageini.Read("DeleteSavedLogin", "SSP");
        }

        private void DelSavedLoginBtn_Click(object sender, EventArgs e)
        {
            File.Delete("userdata.ini");
            DelSavedLoginBtn.Enabled = false;
        }

        private void MoreSettingsForm_Load(object sender, EventArgs e)
        {
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
    }
}
