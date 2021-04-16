using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtubedown2
{
    public partial class DougaConverterApp : Form
    {
        String atoselect;
        String motoselect;
        String name;
        bool zikkou = false;

        public DougaConverterApp()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void henkan_Click(object sender, EventArgs e) // 変換
        {
            if (zikkou == true)
            {
                MessageBox.Show("実行中です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            name = textBox3.Text;
            Henkan();
        }

        public async void Henkan()
        {
            zikkou = true;
            await Task.Run(() =>
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = @"/c ffmpeg -i "+ motoselect +" "+ atoselect+@"\"+name;
                proc.StartInfo.WorkingDirectory = YouTubeApp.SystemFolderPath;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;

                proc.Start();
                Console.WriteLine("c ffmpeg - i "+ motoselect +" "+ atoselect +@"\"+ name);


                proc.WaitForExit();
                Console.WriteLine("END");
                zikkou = false;
                MessageBox.Show("完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void atosentaku_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog
            {

                // ダイアログの説明文を指定する
                Description = "変換後のファイルを出力する場所を指定してください",

                // デフォルトのフォルダを指定する
                SelectedPath = @"C:",

                // 「新しいフォルダーの作成する」ボタンを表示する
                ShowNewFolderButton = true
            };

            //フォルダを選択するダイアログを表示する
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(fbDialog.SelectedPath);
                atoselect = fbDialog.SelectedPath;
                textBox2.Text = atoselect;
            }

            else
            {
                Console.WriteLine("キャンセルされました");
            }

            // オブジェクトを破棄する
            fbDialog.Dispose();

        }

        private void motosentaku_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog
            {

                // デフォルトのフォルダを指定する
                InitialDirectory = @"C:Desktop",

                //ダイアログのタイトルを指定する
                Title = "変換前のファイルを選択してください。"
            };

            //ダイアログを表示する
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(ofDialog.FileName);
                motoselect = ofDialog.FileName;
                textBox1.Text = motoselect;
            }
            else
            {
                Console.WriteLine("キャンセルされました");
            }

            // オブジェクトを破棄する
            ofDialog.Dispose();
        }
    }
}
