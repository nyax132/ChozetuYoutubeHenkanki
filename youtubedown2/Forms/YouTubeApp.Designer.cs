namespace youtubedown2
{
    partial class YouTubeApp
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YouTubeApp));
            this.urlinput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parcetext = new System.Windows.Forms.Label();
            this.IDdelete = new System.Windows.Forms.CheckBox();
            this.text_converting_activation = new System.Windows.Forms.CheckBox();
            this.playlist_download_checkbox = new System.Windows.Forms.CheckBox();
            this.syousaicheckbox = new System.Windows.Forms.CheckBox();
            this.mp3 = new System.Windows.Forms.RadioButton();
            this.mp4 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.filepath = new System.Windows.Forms.TextBox();
            this.fileselect = new System.Windows.Forms.Button();
            this.henkan = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.syousaigb = new System.Windows.Forms.GroupBox();
            this.cmdbutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Musicfilekakutyou = new System.Windows.Forms.TextBox();
            this.Moviefile = new System.Windows.Forms.RadioButton();
            this.Musicfile = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubedlVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubedl更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.syousaigb.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlinput
            // 
            this.urlinput.AllowDrop = true;
            this.urlinput.Location = new System.Drawing.Point(44, 42);
            this.urlinput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.urlinput.Name = "urlinput";
            this.urlinput.Size = new System.Drawing.Size(561, 25);
            this.urlinput.TabIndex = 0;
            this.urlinput.TextChanged += new System.EventHandler(this.urlinput_TextChanged);
            this.urlinput.DragDrop += new System.Windows.Forms.DragEventHandler(this.urlinput_DragDrop);
            this.urlinput.DragEnter += new System.Windows.Forms.DragEventHandler(this.urlinput_DragEnter);
            this.urlinput.DragLeave += new System.EventHandler(this.urlinput_DragLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parcetext);
            this.groupBox1.Controls.Add(this.IDdelete);
            this.groupBox1.Controls.Add(this.text_converting_activation);
            this.groupBox1.Controls.Add(this.playlist_download_checkbox);
            this.groupBox1.Controls.Add(this.syousaicheckbox);
            this.groupBox1.Controls.Add(this.mp3);
            this.groupBox1.Controls.Add(this.mp4);
            this.groupBox1.Location = new System.Drawing.Point(17, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 86);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // parcetext
            // 
            this.parcetext.AutoSize = true;
            this.parcetext.Location = new System.Drawing.Point(15, 57);
            this.parcetext.Name = "parcetext";
            this.parcetext.Size = new System.Drawing.Size(0, 18);
            this.parcetext.TabIndex = 8;
            // 
            // IDdelete
            // 
            this.IDdelete.AutoSize = true;
            this.IDdelete.BackColor = System.Drawing.Color.LightCoral;
            this.IDdelete.Location = new System.Drawing.Point(247, 25);
            this.IDdelete.Name = "IDdelete";
            this.IDdelete.Size = new System.Drawing.Size(77, 22);
            this.IDdelete.TabIndex = 5;
            this.IDdelete.Text = "IDを消す";
            this.IDdelete.UseVisualStyleBackColor = false;
            this.IDdelete.Visible = false;
            // 
            // text_converting_activation
            // 
            this.text_converting_activation.AutoSize = true;
            this.text_converting_activation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.text_converting_activation.Location = new System.Drawing.Point(127, 25);
            this.text_converting_activation.Name = "text_converting_activation";
            this.text_converting_activation.Size = new System.Drawing.Size(111, 22);
            this.text_converting_activation.TabIndex = 7;
            this.text_converting_activation.Text = "テキストで変換";
            this.text_converting_activation.UseVisualStyleBackColor = false;
            this.text_converting_activation.CheckedChanged += new System.EventHandler(this.text_converting_activation_CheckedChanged);
            // 
            // playlist_download_checkbox
            // 
            this.playlist_download_checkbox.AutoSize = true;
            this.playlist_download_checkbox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.playlist_download_checkbox.Location = new System.Drawing.Point(247, 57);
            this.playlist_download_checkbox.Name = "playlist_download_checkbox";
            this.playlist_download_checkbox.Size = new System.Drawing.Size(171, 22);
            this.playlist_download_checkbox.TabIndex = 6;
            this.playlist_download_checkbox.Text = "プレイリストダウンロード";
            this.playlist_download_checkbox.UseVisualStyleBackColor = false;
            this.playlist_download_checkbox.Visible = false;
            // 
            // syousaicheckbox
            // 
            this.syousaicheckbox.AutoSize = true;
            this.syousaicheckbox.Location = new System.Drawing.Point(333, 25);
            this.syousaicheckbox.Name = "syousaicheckbox";
            this.syousaicheckbox.Size = new System.Drawing.Size(135, 22);
            this.syousaicheckbox.TabIndex = 4;
            this.syousaicheckbox.Text = "詳細設定を使用する";
            this.syousaicheckbox.UseVisualStyleBackColor = true;
            this.syousaicheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // mp3
            // 
            this.mp3.AutoSize = true;
            this.mp3.Checked = true;
            this.mp3.Location = new System.Drawing.Point(74, 24);
            this.mp3.Name = "mp3";
            this.mp3.Size = new System.Drawing.Size(50, 22);
            this.mp3.TabIndex = 1;
            this.mp3.TabStop = true;
            this.mp3.Text = "MP3";
            this.mp3.UseVisualStyleBackColor = true;
            // 
            // mp4
            // 
            this.mp4.AutoSize = true;
            this.mp4.Location = new System.Drawing.Point(18, 24);
            this.mp4.Name = "mp4";
            this.mp4.Size = new System.Drawing.Size(50, 22);
            this.mp4.TabIndex = 0;
            this.mp4.Text = "MP4";
            this.mp4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.filepath);
            this.groupBox2.Controls.Add(this.fileselect);
            this.groupBox2.Location = new System.Drawing.Point(17, 166);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 108);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存先";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(395, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(6, 68);
            this.filepath.Name = "filepath";
            this.filepath.ReadOnly = true;
            this.filepath.Size = new System.Drawing.Size(456, 25);
            this.filepath.TabIndex = 1;
            // 
            // fileselect
            // 
            this.fileselect.Location = new System.Drawing.Point(6, 24);
            this.fileselect.Name = "fileselect";
            this.fileselect.Size = new System.Drawing.Size(383, 28);
            this.fileselect.TabIndex = 0;
            this.fileselect.Text = "選択";
            this.fileselect.UseVisualStyleBackColor = true;
            this.fileselect.Click += new System.EventHandler(this.fileselect_Click);
            // 
            // henkan
            // 
            this.henkan.Location = new System.Drawing.Point(497, 74);
            this.henkan.Name = "henkan";
            this.henkan.Size = new System.Drawing.Size(114, 200);
            this.henkan.TabIndex = 4;
            this.henkan.Text = "変換";
            this.henkan.UseVisualStyleBackColor = true;
            this.henkan.Click += new System.EventHandler(this.henkan_Click);
            // 
            // syousaigb
            // 
            this.syousaigb.Controls.Add(this.cmdbutton);
            this.syousaigb.Controls.Add(this.label5);
            this.syousaigb.Controls.Add(this.label4);
            this.syousaigb.Controls.Add(this.tate);
            this.syousaigb.Controls.Add(this.label3);
            this.syousaigb.Controls.Add(this.Musicfilekakutyou);
            this.syousaigb.Controls.Add(this.Moviefile);
            this.syousaigb.Controls.Add(this.Musicfile);
            this.syousaigb.Location = new System.Drawing.Point(17, 280);
            this.syousaigb.Name = "syousaigb";
            this.syousaigb.Size = new System.Drawing.Size(594, 84);
            this.syousaigb.TabIndex = 5;
            this.syousaigb.TabStop = false;
            this.syousaigb.Text = "詳細設定";
            // 
            // cmdbutton
            // 
            this.cmdbutton.Location = new System.Drawing.Point(318, 51);
            this.cmdbutton.Name = "cmdbutton";
            this.cmdbutton.Size = new System.Drawing.Size(126, 27);
            this.cmdbutton.TabIndex = 7;
            this.cmdbutton.Text = "コマンドプロンプト";
            this.cmdbutton.UseVisualStyleBackColor = true;
            this.cmdbutton.Click += new System.EventHandler(this.cmdbutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "❙";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "手動で入力";
            // 
            // tate
            // 
            this.tate.AutoSize = true;
            this.tate.Location = new System.Drawing.Point(226, 26);
            this.tate.Name = "tate";
            this.tate.Size = new System.Drawing.Size(12, 18);
            this.tate.TabIndex = 4;
            this.tate.Text = "❙";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "拡張子";
            // 
            // Musicfilekakutyou
            // 
            this.Musicfilekakutyou.Location = new System.Drawing.Point(294, 21);
            this.Musicfilekakutyou.Name = "Musicfilekakutyou";
            this.Musicfilekakutyou.Size = new System.Drawing.Size(78, 25);
            this.Musicfilekakutyou.TabIndex = 2;
            // 
            // Moviefile
            // 
            this.Moviefile.AutoSize = true;
            this.Moviefile.Location = new System.Drawing.Point(122, 24);
            this.Moviefile.Name = "Moviefile";
            this.Moviefile.Size = new System.Drawing.Size(98, 22);
            this.Moviefile.TabIndex = 1;
            this.Moviefile.TabStop = true;
            this.Moviefile.Text = "動画ファイル";
            this.Moviefile.UseVisualStyleBackColor = true;
            // 
            // Musicfile
            // 
            this.Musicfile.AutoSize = true;
            this.Musicfile.Location = new System.Drawing.Point(18, 24);
            this.Musicfile.Name = "Musicfile";
            this.Musicfile.Size = new System.Drawing.Size(98, 22);
            this.Musicfile.TabIndex = 0;
            this.Musicfile.TabStop = true;
            this.Musicfile.Text = "音声ファイル";
            this.Musicfile.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dToolStripMenuItem,
            this.uToolStripMenuItem,
            this.iToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dToolStripMenuItem
            // 
            this.dToolStripMenuItem.AutoToolTip = true;
            this.dToolStripMenuItem.Image = global::youtubedown2.Properties.Resources.MovieIcon;
            this.dToolStripMenuItem.Name = "dToolStripMenuItem";
            this.dToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.dToolStripMenuItem.ToolTipText = "ローカルの動画を変換する";
            this.dToolStripMenuItem.Click += new System.EventHandler(this.dToolStripMenuItem_Click);
            // 
            // uToolStripMenuItem
            // 
            this.uToolStripMenuItem.AutoToolTip = true;
            this.uToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youTubedlVersionToolStripMenuItem,
            this.youTubedl更新ToolStripMenuItem});
            this.uToolStripMenuItem.Image = global::youtubedown2.Properties.Resources.downloadIcon;
            this.uToolStripMenuItem.Name = "uToolStripMenuItem";
            this.uToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.uToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.uToolStripMenuItem.ToolTipText = "YouTube-dl";
            // 
            // youTubedlVersionToolStripMenuItem
            // 
            this.youTubedlVersionToolStripMenuItem.Name = "youTubedlVersionToolStripMenuItem";
            this.youTubedlVersionToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.youTubedlVersionToolStripMenuItem.Text = "YouTube-dl バージョン確認";
            this.youTubedlVersionToolStripMenuItem.Click += new System.EventHandler(this.youTubedlバージョン確認ToolStripMenuItem_Click);
            // 
            // youTubedl更新ToolStripMenuItem
            // 
            this.youTubedl更新ToolStripMenuItem.Name = "youTubedl更新ToolStripMenuItem";
            this.youTubedl更新ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.youTubedl更新ToolStripMenuItem.Text = "YouTube-dl 更新";
            this.youTubedl更新ToolStripMenuItem.Click += new System.EventHandler(this.youTubedl更新ToolStripMenuItem_Click);
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.AutoToolTip = true;
            this.iToolStripMenuItem.Image = global::youtubedown2.Properties.Resources.InfoIcon;
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.iToolStripMenuItem.ToolTipText = "このソフトの情報";
            this.iToolStripMenuItem.Click += new System.EventHandler(this.iToolStripMenuItem_Click);
            // 
            // YouTubeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 376);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.syousaigb);
            this.Controls.Add(this.henkan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlinput);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "YouTubeApp";
            this.Text = "超絶ようつべ変換機4.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.syousaigb.ResumeLayout(false);
            this.syousaigb.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlinput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton mp3;
        private System.Windows.Forms.RadioButton mp4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Button fileselect;
        private System.Windows.Forms.Button henkan;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox syousaigb;
        private System.Windows.Forms.CheckBox syousaicheckbox;
        private System.Windows.Forms.RadioButton Moviefile;
        private System.Windows.Forms.RadioButton Musicfile;
        private System.Windows.Forms.TextBox Musicfilekakutyou;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox IDdelete;
        private System.Windows.Forms.CheckBox playlist_download_checkbox;
        private System.Windows.Forms.CheckBox text_converting_activation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youTubedlVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youTubedl更新ToolStripMenuItem;
        public System.Windows.Forms.Label parcetext;
        private System.Windows.Forms.Button cmdbutton;
    }
}

