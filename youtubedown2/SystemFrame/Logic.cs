using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using youtubedown2.SystemFrame;

namespace youtubedown2
{
    public class Logic
    {
        /// <summary>
        /// システムファイルの適合性確認、削除
        /// </summary>
        public void SystemFileCheck()
        {
            Console.WriteLine("-SysFileCheck-");

            //Youtube-dl確認
            if (!File.Exists(YouTubeApp.SystemFolderPath + "youtube-dl.exe"))
            {
                Console.WriteLine("Youtube-dl not");
                MessageBox.Show("Youtube-dl.exe が見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
                return;
            }

            //無駄なファイル削除
            try
            {
                foreach (var path in Directory.EnumerateFiles(YouTubeApp.SystemFolderPath)
                    .Where(x => !(Path.GetFileName(x) == "ffmpeg.exe" || Path.GetFileName(x) == "ffprobe.exe" || Path.GetFileName(x) == "youtube-dl.exe")))
                {
                    File.Delete(path);
                    Console.WriteLine("削除: " + path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// ファイルの作成(初期化)
        /// </summary>
        public void FileSetup()
        {
            Console.WriteLine("-FileSetup-");

            //FileList
            string Filesavepath = YouTubeApp.SettingFolderPath + "Filesavepath.txt";
            string Setuppath = YouTubeApp.SettingFolderPath + "Setup.txt";

            //ログ削除
            File.WriteAllText(YouTubeApp.SettingFolderPath + "log.txt", "");
            Console.WriteLine("LOG TXT file UPDATE");


            if (File.Exists(Filesavepath))
            {
                Console.WriteLine("Filesave TXT file OK");
            }
            else
            {
                File.WriteAllText(YouTubeApp.SettingFolderPath + "Filesavepath.txt", "");
                Console.WriteLine("Filesave TXT file CREATE");
            }

            if (File.Exists(Setuppath))
            {
                Console.WriteLine("Setup TXT file OK");
            }
            else
            {
                File.WriteAllText(YouTubeApp.SettingFolderPath + "Setup.txt", "false");
                Console.WriteLine("Setup TXT file CREATE");
            }
        }

        /// <summary>
        /// Youtube-dlのバージョンアップ
        /// </summary>
        public async void DLupdate()
        {
            YouTubeApp.Taskbar(true);
            YouTubeApp.is_executing = true;

            await Task.Run(() =>
            {
                try
                {
                    var url = "https://youtube-dl.org/downloads/latest/youtube-dl.exe";
                    var baseDir = YouTubeApp.SystemFolderPath;

                    // WebRequest(+拡張メソッド)でファイルを保存します。
                    var request = WebRequest.Create(url);
                    request.DownloadFileTo(baseDir + "youtube-dl.exe");

                    YouTubeApp.Taskbar(false);

                    string ver = DLversion();

                    MessageBox.Show("更新完了 - " + ver, "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    YouTubeApp.is_executing = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show("更新に失敗しました。" + Environment.NewLine + e, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    YouTubeApp.Taskbar(false);
                    YouTubeApp.is_executing = false;
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("--DLupdate End--");
                }
            });
        }

        /// <summary>
        /// Youtube-dlバージョン情報を取得し、表示。
        /// </summary>
        public void DLcheck()
        {
            string output;
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = @"/c youtube-dl --version";
            proc.StartInfo.WorkingDirectory = YouTubeApp.SystemFolderPath;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;

            proc.StartInfo.RedirectStandardOutput = true;

            proc.Start();

            output = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();

            Console.WriteLine("ログ: " + output);

            proc.Close();
            proc.Dispose();

            MessageBox.Show("現在のバージョンは" + output + "です。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Y-DLバージョン情報を返す(String)
        /// </summary>
        public string DLversion()
        {
            string output;
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = @"/c youtube-dl --version";
            proc.StartInfo.WorkingDirectory = YouTubeApp.SystemFolderPath;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;

            proc.StartInfo.RedirectStandardOutput = true;

            proc.Start();

            output = proc.StandardOutput.ReadToEnd();

            proc.WaitForExit();

            Console.WriteLine("ログ: " + output);

            proc.Close();
            proc.Dispose();

            return output;
        }

        public string GetAppPath()
        {
            string path = System.Windows.Forms.Application.StartupPath;
            return path;
        }

        /// <summary>
        /// コマンドプロンプトをSystemFolderPathのディレクトリで起動
        /// </summary>
        public void Cmd()
        {
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.WorkingDirectory = YouTubeApp.SystemFolderPath;
                p.StartInfo.CreateNoWindow = false;

                p.Start();
            }
        }
    }
}
