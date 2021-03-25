using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using youtubedown2.SystemFrame;

namespace youtubedown2
{
    public partial class YouTubeApp : Form
    {
        //変数
        String par = "";

        static String selectfilepath;
        public static bool is_executing = false;
        bool selectcheck;
        public bool error = false;
        static bool IDdeletecheck = false;
        static bool playlist_download_activation = false;

        //FolderPath
        public static String SystemFolderPath;
        public static String SettingFolderPath;

        //Setup
        public static String SetupLabel = "-";
        static bool setup = true;

        //List
        static readonly List<string> list = new List<string>();//(text変換のときに使うやつ)


        public delegate string ReadLine();
        public YouTubeApp() // form 初期動作
        {
            InitializeComponent();

            syousaigb.Visible = false;
            this.Width = 641;
            this.Height = 319;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void Form1_Load(object sender, EventArgs e) //初期起動設定
        {
            //ファイルチェック、無駄なファイル削除
            Logic logic = new Logic();

            string path = logic.GetAppPath();

            SystemFolderPath = path + "/System/";
            SettingFolderPath = path + "/Setting/";

            logic.FileSetup();
            logic.SystemFileCheck();

            filepath.Text = "[ファイルを選択してください]";
            selectcheck = false;
            text_converting_activation.Visible = false;

            //出力ファイルパス
            if (File.Exists(SettingFolderPath + "Filesavepath.txt"))
            {
                string readText = File.ReadAllText(SettingFolderPath + "Filesavepath.txt");

                if (readText.Length == 0)
                {
                    filepath.Text = "[ファイルを選択してください]";
                    selectcheck = false;
                }
                else
                {
                    filepath.Text = readText;
                    selectfilepath = readText;
                    selectcheck = true;
                }
            }
            else
            {
                File.WriteAllText(SettingFolderPath + "Filesavepath.txt", "");
            }

            //初期セットアップ確認
            if (File.Exists(SettingFolderPath + "Setup.txt")) //Setup
            {
                string readText = File.ReadAllText(SettingFolderPath + "Setup.txt");

                if (readText.Equals("false"))
                {
                    henkan.Text = "*初期設定*";
                    setup = false;
                }
            }
            else
            {
                File.WriteAllText(SettingFolderPath + "Setup.txt", "false");
                henkan.Text = "*初期設定*";
                setup = false;
            }
        }
        private void henkan_Click(object sender, EventArgs e) //変換ボタンで実行
        {
            if (setup == false)
            {
                FirstSetup();

                henkan.Text = "変換";
                return;
            }

            if (IDdelete.Checked)
            {
                IDdeletecheck = true;
            }
            else
            {
                IDdeletecheck = false;
            }

            if (is_executing == true)
            {
                MessageBox.Show("実行中です", "情報", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (error == true)
            {
                MessageBox.Show("直下ファイルに動画や音声が検出されています。エラーが発生する可能性があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (selectcheck == false)
            {
                MessageBox.Show("保存先を選択してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (urlinput.TextLength == 0)
            {
                MessageBox.Show("URLを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (playlist_download_checkbox.Checked == false && playlist_download_activation == true)
            {
                MessageBox.Show("プレイリストダウンロードを有効にしてください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (playlist_download_checkbox.Checked == true && playlist_download_activation == false)
            {
                MessageBox.Show("プレイリストでないと、プレイリストチェックボックスは表示されません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (mp4.Checked) // MP4選択時、Videodownを実行
            {
                File.WriteAllText(SettingFolderPath + "log.txt", "");

                if (playlist_download_checkbox.Checked == true) { VideoPlayListdown(urlinput.Text); return; } //プレイリストの時

                if (text_converting_activation.Checked == true) { VideoTextdown(); return; } //テキスト変換の時

                Videodown(urlinput.Text);
            }

            if (mp3.Checked) // MP3選択時、Musicdownを実行
            {
                File.WriteAllText(SettingFolderPath + "log.txt", "");

                if (playlist_download_checkbox.Checked == true) { MusicPlayListdown(urlinput.Text); return; } //プレイリストの時

                if (text_converting_activation.Checked == true) { MusicTextdown(); return; } //テキスト変換の時

                Musicdown(urlinput.Text);
            }

            //---
            //詳細設定
            //---

            if (syousaicheckbox.Checked)
            {
                if (Musicfile.Checked) // 詳細設定の音声ファイル選択時、CustomMusicdownを実行
                {
                    if (Musicfilekakutyou.TextLength == 0)
                    {
                        MessageBox.Show("出力する拡張子を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    File.WriteAllText(SettingFolderPath + "log.txt", "");

                    if (playlist_download_checkbox.Checked == true) { CustomMusicPlayListdown(urlinput.Text, Musicfilekakutyou.Text); return; } //プレイリスト（カスタム

                    if (text_converting_activation.Checked == true) { CustomMusicTextdown(Musicfilekakutyou.Text); return; } //テキスト変換の時

                    CustomMusicdown(urlinput.Text, Musicfilekakutyou.Text);
                    Musicfilekakutyou.Text = "";
                }

                if (Moviefile.Checked)
                {
                    if (Musicfilekakutyou.TextLength == 0)
                    {
                        MessageBox.Show("出力する拡張子を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    File.WriteAllText(SettingFolderPath + "log.txt", "");

                    if (playlist_download_checkbox.Checked == true) { CustomVideoPlayListdown(urlinput.Text, Musicfilekakutyou.Text); return; } //プレイリスト（カスタム

                    if (text_converting_activation.Checked == true) { CustomVideoTextdown(Musicfilekakutyou.Text); return; } //テキスト変換の時

                    CustomVideodown(urlinput.Text, Musicfilekakutyou.Text);
                    Musicfilekakutyou.Text = "";

                }
            }
            urlinput.Text = "";
        }
        //通常
        public async void Videodown(String videourl)//動画ダウンロード
        {
            Console.WriteLine("Videodown");
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @"/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best --newline " + videourl;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    Filemovement(Yid, "*.mp4");

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }
        public async void Musicdown(String videourl)//音楽ダウンロード
        {
            Console.WriteLine("Musicdown");
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @"/c youtube-dl -x --audio-format mp3 --yes-playlist --newline " + videourl;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    Filemovement(Yid, "*.mp3");

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");

                is_executing = false;
            });
        }
        public async void CustomVideodown(String videourl, String encode)
        {
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    String arg = "/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output " + encode + " --newline " + videourl;
                    Console.WriteLine("arg: " + arg);
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @arg;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    Filemovement(Yid, "*." + encode);

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }//カスタムビデオ
        public async void CustomMusicdown(String videourl, String encode)
        {
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @"/c youtube-dl -x --audio-format " + encode + "  --newline " + videourl;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    Filemovement(Yid, "*." + encode);

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }//カスタムミュージック

        //プレイリストの時
        public async void VideoPlayListdown(String videourl)
        {
            Console.WriteLine("VideoPlayListdown");
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @"/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best --playlist-start 1 --ignore-errors " + videourl;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    FilemovementPlayList(12, "*.mp4", ".mp4");

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }
        public async void MusicPlayListdown(String videourl)
        {
            Console.WriteLine("MusicPlayListdown");
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @"/c youtube-dl -x --audio-format mp3 --playlist-start 1 --ignore-errors --newline " + videourl;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    FilemovementPlayList(12, "*.mp3", ".mp3");

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }
        public async void CustomVideoPlayListdown(String videourl, String encode)
        {
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    String arg = "/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output " + encode + " --newline --playlist-start 1 --ignore-errors " + videourl;
                    Console.WriteLine("arg: " + arg);
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @arg;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;

                    proc.StartInfo.RedirectStandardOutput = true;

                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    FilemovementPlayList(12, "*." + encode, "." + encode);

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }
        public async void CustomMusicPlayListdown(String videourl, String encode)
        {
            is_executing = true;
            Taskbar(true);
            await Task.Run(() =>
            {
                using (Process proc = new Process())
                {
                    string pat = @"\?v=([^&]+)";
                    string YouTubeid = videourl;
                    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                    Match m = r.Match(YouTubeid);
                    String Yid = m.Groups[1].ToString();

                    Console.WriteLine(Yid);

                    String arg = "/c youtube-dl -x --audio-format " + encode + " --newline --playlist-start 1 --ignore-errors " + videourl;
                    Console.WriteLine("arg: " + arg);
                    proc.StartInfo.FileName = "cmd.exe";
                    proc.StartInfo.Arguments = @arg;
                    proc.StartInfo.WorkingDirectory = SystemFolderPath;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;

                    proc.StartInfo.RedirectStandardOutput = true;

                    proc.StartInfo.RedirectStandardError = true;

                    proc.Start();

                    //通常ログ
                    for (; ; )
                    {
                        ReadLine readln = proc.StandardOutput.ReadLine;
                        IAsyncResult ar = readln.BeginInvoke(null, null);
                        ar.AsyncWaitHandle.WaitOne();
                        string line = readln.EndInvoke(ar);
                        if (line == null)
                        {
                            break;
                        }

                        //%取得
                        par = Percent.Parcent(line);

                        //Invokeメソッドを使用
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(this.UpdateText));
                        }
                        else
                        {
                            this.parcetext.Text = par;
                        }

                        Console.WriteLine(par);

                        File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                        Console.WriteLine(line + " :log");
                    }

                    //エラーログ
                    String errorln = proc.StandardError.ReadToEnd();
                    if (!errorln.Equals(""))
                    {
                        File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                        Console.WriteLine(errorln + " :Error");
                    }

                    FilemovementPlayList(12, "*." + encode, "." + encode);

                    proc.Close();
                    proc.Dispose();
                }

                Console.WriteLine();

                Console.WriteLine("Complete");
                is_executing = false;
            });
        }

        //テキスト変換の時
        public async void VideoTextdown()
        {
            is_executing = true;
            Taskbar(true);
            Console.WriteLine("VideoTextdown");
            int itemcount = list.Count;

            foreach (var item in list)
            {

                await Task.Run(() =>
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = "cmd.exe";
                        proc.StartInfo.Arguments = @"/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a]/best[ext=mp4]/best --ignore-errors " + item;
                        proc.StartInfo.WorkingDirectory = SystemFolderPath;
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.RedirectStandardError = true;

                        proc.Start();

                        //通常ログ
                        for (; ; )
                        {
                            ReadLine readln = proc.StandardOutput.ReadLine;
                            IAsyncResult ar = readln.BeginInvoke(null, null);
                            ar.AsyncWaitHandle.WaitOne();
                            string line = readln.EndInvoke(ar);
                            if (line == null)
                            {
                                break;
                            }

                            //%取得
                            par = Percent.Parcent(line);

                            //Invokeメソッドを使用
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(this.UpdateText));
                            }
                            else
                            {
                                this.parcetext.Text = par;
                            }

                            Console.WriteLine(par);

                            File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                            Console.WriteLine(line + " :log");
                        }

                        //エラーログ
                        String errorln = proc.StandardError.ReadToEnd();
                        if (!errorln.Equals(""))
                        {
                            File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                            Console.WriteLine(errorln + " :Error");
                        }

                        if (item.Contains("youtube.com")) // YouTubeがどうか
                        {
                            FilemovementTextMode(12, "*.mp4", ".mp4", true);
                        }
                        else
                        {
                            FilemovementTextMode(12, "*.mp4", ".mp4", false);
                        }

                        proc.Close();
                        proc.Dispose();
                    }
                });
            }

            Console.WriteLine("Complete");

            Taskbar(false);
            MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();

            is_executing = false;
        }
        public async void MusicTextdown()
        {
            is_executing = true;
            Taskbar(true);
            Console.WriteLine("MusicTextdown");
            int itemcount = list.Count;

            foreach (var item in list)
            {

                await Task.Run(() =>
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = "cmd.exe";
                        proc.StartInfo.Arguments = @"/c youtube-dl -x --audio-format mp3 --yes-playlist --newline --ignore-errors " + item;
                        proc.StartInfo.WorkingDirectory = SystemFolderPath;
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.RedirectStandardError = true;

                        proc.Start();

                        //通常ログ
                        for (; ; )
                        {
                            ReadLine readln = proc.StandardOutput.ReadLine;
                            IAsyncResult ar = readln.BeginInvoke(null, null);
                            ar.AsyncWaitHandle.WaitOne();
                            string line = readln.EndInvoke(ar);
                            if (line == null)
                            {
                                break;
                            }

                            //%取得
                            par = Percent.Parcent(line);

                            //Invokeメソッドを使用
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(this.UpdateText));
                            }
                            else
                            {
                                this.parcetext.Text = par;
                            }

                            Console.WriteLine(par);

                            File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                            Console.WriteLine(line + " :log");
                        }

                        //エラーログ
                        String errorln = proc.StandardError.ReadToEnd();
                        if (!errorln.Equals(""))
                        {
                            File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                            Console.WriteLine(errorln + " :Error");
                        }

                        if (item.Contains("youtube.com")) // YouTubeがどうか
                        {
                            FilemovementTextMode(12, "*.mp3", ".mp3", true);
                        }
                        else
                        {
                            FilemovementTextMode(12, "*.mp3", ".mp3", false);
                        }

                        proc.Close();
                        proc.Dispose();
                    }
                });
            }

            Console.WriteLine("Complete");

            Taskbar(false);
            MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();

            is_executing = false;
        }
        public async void CustomVideoTextdown(String encode)
        {
            is_executing = true;
            Taskbar(true);
            Console.WriteLine("VideoCustomdown");
            int itemcount = list.Count;

            foreach (var item in list)
            {

                await Task.Run(() =>
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = "cmd.exe";
                        proc.StartInfo.Arguments = @"/c youtube-dl -f bestvideo[ext=mp4]+bestaudio[ext=m4a] --merge-output " + encode + " --newline --ignore-errors " + item;
                        proc.StartInfo.WorkingDirectory = SystemFolderPath;
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.RedirectStandardError = true;

                        proc.Start();

                        //通常ログ
                        for (; ; )
                        {
                            ReadLine readln = proc.StandardOutput.ReadLine;
                            IAsyncResult ar = readln.BeginInvoke(null, null);
                            ar.AsyncWaitHandle.WaitOne();
                            string line = readln.EndInvoke(ar);
                            if (line == null)
                            {
                                break;
                            }

                            //%取得
                            par = Percent.Parcent(line);

                            //Invokeメソッドを使用
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(this.UpdateText));
                            }
                            else
                            {
                                this.parcetext.Text = par;
                            }

                            Console.WriteLine(par);

                            File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                            Console.WriteLine(line + " :log");
                        }

                        //エラーログ
                        String errorln = proc.StandardError.ReadToEnd();
                        if (!errorln.Equals(""))
                        {
                            File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                            Console.WriteLine(errorln + " :Error");
                        }

                        if (item.Contains("youtube.com")) // YouTubeがどうか
                        {
                            FilemovementTextMode(12, "*." + encode, "." + encode, true);
                        }
                        else
                        {
                            FilemovementTextMode(12, "*." + encode, "." + encode, false);
                        }

                        proc.Close();
                        proc.Dispose();
                    }
                });
            }

            Console.WriteLine("Complete");

            Taskbar(false);
            MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();

            is_executing = false;
        }
        public async void CustomMusicTextdown(String encode)
        {
            is_executing = true;
            Taskbar(true);
            Console.WriteLine("MusicCustomdown");
            int itemcount = list.Count;

            foreach (var item in list)
            {

                await Task.Run(() =>
                {
                    using (Process proc = new Process())
                    {
                        proc.StartInfo.FileName = "cmd.exe";
                        proc.StartInfo.Arguments = @"/c youtube-dl -x --audio-format " + encode + " --ignore-errors --newline " + item;
                        proc.StartInfo.WorkingDirectory = SystemFolderPath;
                        proc.StartInfo.CreateNoWindow = true;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.RedirectStandardError = true;

                        proc.Start();

                        //通常ログ
                        for (; ; )
                        {
                            ReadLine readln = proc.StandardOutput.ReadLine;
                            IAsyncResult ar = readln.BeginInvoke(null, null);
                            ar.AsyncWaitHandle.WaitOne();
                            string line = readln.EndInvoke(ar);
                            if (line == null)
                            {
                                break;
                            }

                            //%取得
                            par = Percent.Parcent(line);

                            //Invokeメソッドを使用
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(this.UpdateText));
                            }
                            else
                            {
                                this.parcetext.Text = par;
                            }

                            Console.WriteLine(par);

                            File.AppendAllText(SettingFolderPath + "log.txt", line + Environment.NewLine);
                            Console.WriteLine(line + " :log");
                        }

                        //エラーログ
                        String errorln = proc.StandardError.ReadToEnd();
                        if (!errorln.Equals(""))
                        {
                            File.AppendAllText(SettingFolderPath + "log.txt", errorln + Environment.NewLine);
                            Console.WriteLine(errorln + " :Error");
                        }

                        if (item.Contains("youtube.com")) // YouTubeがどうか
                        {
                            FilemovementTextMode(12, "*." + encode, "." + encode, true);
                        }
                        else
                        {
                            FilemovementTextMode(12, "*." + encode, "." + encode, false);
                        }

                        proc.Close();
                        proc.Dispose();
                    }
                });
            }

            Console.WriteLine("Complete");

            Taskbar(false);
            MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GC.Collect();

            is_executing = false;
        }
        public void UpdateText()//％更新
        {
            this.parcetext.Text = "<進行状況>" + par;
        }

        /// <summary>
        /// プレイリストモードでのファイル移動システム
        /// </summary>
        /// <param name="Amo">YoutubeURLIDの文字数</param>
        /// <param name="kakutyou">検索に使う拡張子</param>
        /// <param name="kakutyouNormal">変換後の拡張子</param>
        public static void FilemovementPlayList(int Amo, String kakutyou, String kakutyouNormal)
        {
            string[] files = Directory.GetFiles(SystemFolderPath, kakutyou);
            int count = 0;

            try
            {
                foreach (string str in files)
                {
                    count++;
                    string filename = Path.GetFileNameWithoutExtension(str);

                    Console.WriteLine(count + "個目です。");

                    if (IDdeletecheck == true) //IDを消す
                    {
                        int fileLen = filename.Length;
                        int fileLenEnd = fileLen - Amo;
                        String fileLenName = filename.Substring(0, fileLenEnd);
                        System.IO.File.Move(str, selectfilepath + @"\" + fileLenName + kakutyouNormal);
                        Console.WriteLine(str + " を移動します。 ファイル名は " + filename.Substring(0, fileLenEnd) + kakutyouNormal + " です。");
                    }

                    if (IDdeletecheck == false) //IDを消さない
                    {
                        System.IO.File.Move(str, selectfilepath + @"\" + filename + kakutyouNormal);
                        Console.WriteLine(str + " を移動します。 ファイル名は " + filename + " です。");
                    }
                }
                Taskbar(false);
                MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();

            }
            catch (System.IndexOutOfRangeException)
            {
                Taskbar(false);
                MessageBox.Show("動画のダウンロードに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                StreamReader sr = new StreamReader(SettingFolderPath + "log.txt");
                string str = sr.ReadToEnd();
                sr.Close();

                Form fm3 = new LopForm(str);
                fm3.ShowDialog();
                fm3.Dispose();
            }
            catch (System.IO.IOException)
            {
                Taskbar(false);
                MessageBox.Show("ファイル移動に失敗しました。保存先に同じファイルがあるか確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 通常時のファイル移動システム
        /// </summary>
        /// <param name="youtubeid">YoutubeURLID</param>
        /// <param name="kakutyou">移動させたい拡張子</param>
        public static void Filemovement(String youtubeid, String kakutyou)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(SystemFolderPath);
            System.IO.FileInfo[] files = di.GetFiles(kakutyou, System.IO.SearchOption.TopDirectoryOnly);

            //Console.WriteLine(files[0]);

            try
            {
                String filenameR;
                String filename = files[0].ToString(); // 出力ファイル名

                if (0 <= filename.IndexOf(youtubeid)) //Yidがファイル名に含まれているかどうかを確認
                {
                    Console.WriteLine("selectFilePath :" + selectfilepath);
                    Console.WriteLine("filename :" + filename);

                    if (IDdeletecheck == true)
                    {
                        filenameR = filename.Replace("-" + youtubeid, "");
                        Console.WriteLine("filenameR :" + filenameR);

                        System.IO.File.Move(SystemFolderPath + filename, selectfilepath + @"\" + filenameR); // 移動 （IDなし
                    }

                    if (IDdeletecheck == false)
                    {
                        System.IO.File.Move(SystemFolderPath + filename, selectfilepath + @"\" + filename); // 移動 （IDあり
                    }

                    Taskbar(false);
                    MessageBox.Show("処理が完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GC.Collect();

                }
                else
                {
                    Taskbar(false);
                    MessageBox.Show("ファイルが見つかりませんでした", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (System.IndexOutOfRangeException)
            {
                Taskbar(false);
                MessageBox.Show("動画のダウンロードに失敗しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

                StreamReader sr = new StreamReader(SettingFolderPath + "log.txt");
                string str = sr.ReadToEnd();
                sr.Close();

                Form fm3 = new LopForm(str);
                fm3.ShowDialog();
                fm3.Dispose();
            }
            catch (System.IO.IOException)
            {
                Taskbar(false);
                MessageBox.Show("ファイル移動に失敗しました。保存先に同じファイルがあるか確認してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// テキストモードでのファイル移動システム
        /// </summary>
        /// <param name="Amo">YoutubeURLIDの文字数</param>
        /// <param name="kakutyou">検索に使う拡張子</param>
        /// <param name="kakutyouNormal">変換後の拡張子</param>
        /// <param name="youtube">URLがYoutubeかどうか</param>
        public static void FilemovementTextMode(int Amo, String kakutyou, String kakutyouNormal, bool youtube)
        {
            string[] files = Directory.GetFiles(SystemFolderPath, kakutyou);

            if (files.Length == 0)
            {
                return;
            }

            foreach (string str in files)
            {
                string filename = Path.GetFileNameWithoutExtension(str);

                if (IDdeletecheck == true && youtube == true) //IDを消す
                {
                    int fileLen = filename.Length;
                    int fileLenEnd = fileLen - Amo;
                    String fileLenName = filename.Substring(0, fileLenEnd);
                    System.IO.File.Move(str, selectfilepath + @"\" + fileLenName + kakutyouNormal);
                    Console.WriteLine(str + " を移動します。 ファイル名は " + filename.Substring(0, fileLenEnd) + kakutyouNormal + " です。");
                }
                else
                {
                    System.IO.File.Move(str, selectfilepath + @"\" + filename + kakutyouNormal);
                    Console.WriteLine(str + " を移動します。 ファイル名は " + filename + " です。");
                }

                if (IDdeletecheck == false && youtube == false) //IDを消さない
                {
                    System.IO.File.Move(str, selectfilepath + @"\" + filename + kakutyouNormal);
                    Console.WriteLine(str + " を移動します。 ファイル名は " + filename + " です。");
                }
            }
        }

        private void fileselect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.FileName = "Folder Selection";
                openFileDialog1.Filter = "フォルダー|.";
                openFileDialog1.ValidateNames = false;
                openFileDialog1.CheckFileExists = false;
                openFileDialog1.CheckPathExists = true;

                using (OpenFileDialog openFileDialog2 = openFileDialog1)
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        filepath.Text = Path.GetDirectoryName(openFileDialog2.FileName);
                        selectfilepath = Path.GetDirectoryName(openFileDialog2.FileName);
                    }
                }
            }

            selectcheck = true;

        }//FileSelect

        /// <summary>
        /// 初期設定を実行
        /// </summary>
        public static async void FirstSetup() //初期設定
        {
            var a = MessageBox.Show("YouTube-dlを使用するために初期設定を行います" + Environment.NewLine
                  + "こちらを必ず実行してください。", "初期設定 1/3", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (a == DialogResult.Yes)
            {
                MessageBox.Show("コマンドプロンプトが開きます。コマンドを貼り付けて実行してください。" + Environment.NewLine + "-コマンドはクリップボードにコピーされます", "2/3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetData(DataFormats.Text, "youtube-dl -x --audio-format mp3 https://www.youtube.com/watch?v=9Rfykh-YzCc");

                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.WorkingDirectory = SystemFolderPath;
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();

                //監視スタート

                Boolean checkloop = true;

                await Task.Run(() =>
                {

                    while (checkloop)
                    {

                        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(SystemFolderPath);
                        System.IO.FileInfo[] files = di.GetFiles("*.mp3", System.IO.SearchOption.TopDirectoryOnly);
                        if (files.Length != 0)
                        {

                            String filename = files[0].ToString(); // 出力ファイル名

                            Console.WriteLine(filename);
                            checkloop = false;

                            Thread.Sleep(2000);

                            MessageBox.Show("実行を検知しました。初期設定を終了します。", "3/3", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            File.WriteAllText(SettingFolderPath + "Setup.txt", "true");
                            setup = true;

                            Thread.Sleep(1000);
                            System.IO.File.Delete(SystemFolderPath + filename);
                            MessageBox.Show("コマンドプロンプトを閉じてください", "終了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Console.WriteLine("-END-");
                        }
                    }
                });
            }
            else
            {
                MessageBox.Show("初期設定をしない場合、正常に動作しない可能性があります", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)//保存先保存ボタン
        {
            if (selectcheck == false)
            {
                MessageBox.Show("保存するには保存先を選択をしてください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String paths = selectfilepath;
            File.WriteAllText(SettingFolderPath + "Filesavepath.txt", paths);
            MessageBox.Show("保存しました[次回起動時もこのファイルパスが使われます]", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //詳細設定Form拡張
        {
            if (!syousaicheckbox.Checked)
            {
                syousaigb.Visible = false;
                this.Size = new Size(641, 319);
                mp4.Enabled = true;
                mp3.Enabled = true;
                mp4.Checked = false;
                mp3.Checked = true;
            }
            else
            {
                syousaigb.Visible = true;
                this.Size = new Size(641, 415);
                mp4.Enabled = false;
                mp3.Enabled = false;
                mp4.Checked = false;
                mp3.Checked = false;

                Musicfile.Checked = true;
            }
        }

        private void urlinput_TextChanged(object sender, EventArgs e)
        {
            String inputtest = urlinput.Text;

            if (inputtest.Contains("youtube.com") == true)
            {
                IDdelete.Visible = true;
            }
            else
            {
                IDdelete.Checked = false;
                IDdelete.Visible = false;
            }

            if (inputtest.Contains("youtube.com") && inputtest.Contains("playlist"))
            {
                playlist_download_checkbox.Visible = true;
                playlist_download_activation = true;
            }
            else
            {
                playlist_download_checkbox.Checked = false;
                playlist_download_checkbox.Visible = false;
                playlist_download_activation = false;
            }
        }

        private void urlinput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
                urlinput.ForeColor = Color.Gray;
                urlinput.Text = "<ファイル読み込み>";
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void urlinput_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length > 1)
            {
                Console.WriteLine("複数のファイルが入力されたのでスルーします。");
                MessageBox.Show("入力できるファイルはテキストファイルで１つまでしか選択できません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                urlinput.Text = "";
                urlinput.ForeColor = Color.Black;
            }
            else
            {
                if (Path.GetExtension(files[0]) == ".txt")
                {
                    Console.WriteLine("実行");


                    //テキストモード
                    playlist_download_checkbox.Visible = true;

                    urlinput.ReadOnly = true;
                    text_converting_activation.Visible = true;
                    text_converting_activation.Checked = true;

                    //テキストの色、ReadOnly
                    urlinput.ForeColor = Color.Black;
                    urlinput.Text = files[0];

                    groupBox1.SendToBack();
                    IDdelete.BringToFront();
                    IDdelete.Visible = true;
                    IDdelete.Checked = false;

                    using (System.IO.StreamReader file = new System.IO.StreamReader(files[0]))
                    {
                        string line = "";

                        // 1行ずつ読み込んでいき、何もない行までwhile文で繰り返す
                        while ((line = file.ReadLine()) != null)
                        {
                            list.Add(line);
                        }

                        // foreachで回す
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("入力できるファイルはテキストファイルで１つまでしか選択できません。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    urlinput.Text = "";
                    urlinput.ForeColor = Color.Black;
                }
            }
        }

        private void urlinput_DragLeave(object sender, EventArgs e) // ドラッグ（マウス）がテキストボックスを離れた時
        {
            urlinput.Text = "";
            urlinput.ForeColor = Color.Black;
        }

        private void text_converting_activation_CheckedChanged(object sender, EventArgs e) //テキストで変換チェック外した時
        {
            if (text_converting_activation.Checked)
            {

            }
            else
            {
                //テキストモード
                urlinput.ReadOnly = false;
                text_converting_activation.Checked = false;
                text_converting_activation.Visible = false;

                //テキストの色、ReadOnly
                urlinput.ForeColor = Color.Black;
                urlinput.Text = "";

                groupBox1.SendToBack();
                IDdelete.BringToFront();
                IDdelete.Visible = false;
                IDdelete.Checked = false;

            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("動画変換モード");
            DougaConverterApp form2 = new DougaConverterApp();
            form2.Show();
        }

        private void youTubedlバージョン確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            logic.DLcheck();
        }

        private void youTubedl更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();
            logic.DLupdate();
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form appform = new AppInfoForm();
            appform.ShowDialog();
        }

        /// <summary>
        /// タスクバーの処理
        /// </summary>
        /// <param name="l">On(true)かOff(false)</param>
        public static void Taskbar(bool l)
        {
            if (l == true)
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            }
            else
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
            }
        }
        private void cmdbutton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("コマンドプロンプト起動");

            Logic logic = new Logic();
            logic.Cmd();
        }
    }
}
