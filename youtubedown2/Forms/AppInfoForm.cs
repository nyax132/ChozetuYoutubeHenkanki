using System;
using System.IO;
using System.Windows.Forms;

namespace youtubedown2
{
    public partial class AppInfoForm : Form
    {
        public AppInfoForm()
        {
            InitializeComponent();

            if (File.Exists(YouTubeApp.SettingFolderPath + "Setup.txt")) //Setup
            {
                string readText = File.ReadAllText(YouTubeApp.SettingFolderPath + "Setup.txt");

                if (readText.Equals("true")) YouTubeApp.SetupLabel = "○";
                if (readText.Equals("false")) YouTubeApp.SetupLabel = "×";
                if (!readText.Equals("true") && !readText.Equals("false")) YouTubeApp.SetupLabel = "-";
            }
            else
            {
                File.WriteAllText(YouTubeApp.SettingFolderPath + "Setup.txt", "false");
            }
        }

        private void AppInfoForm_Load(object sender, EventArgs e)
        {
            this.Width = this.Width;
            this.Height = this.Height;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Setup.Text = YouTubeApp.SetupLabel;


            string readText = File.ReadAllText(YouTubeApp.SettingFolderPath + "Setup.txt");

            if (readText.Equals("true")) 
            {
                button1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YouTubeApp.FirstSetup();
        }
    }
}
