using System;
using System.Windows.Forms;

namespace youtubedown2
{
    public partial class LopForm : Form
    {
        public LopForm(String error_log)
        {
            InitializeComponent();

            richTextBox1.Text = error_log;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Width = this.Width;
            this.Height = this.Height;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
