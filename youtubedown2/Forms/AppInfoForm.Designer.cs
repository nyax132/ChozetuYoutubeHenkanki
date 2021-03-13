namespace youtubedown2
{
    partial class AppInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Setup = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "ICOON MONO　様のアイコンを使用させて頂いています\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "初回設定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "このソフトは、";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "YouTube DL を使用しています。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-23, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(437, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            // 
            // Setup
            // 
            this.Setup.AutoSize = true;
            this.Setup.Location = new System.Drawing.Point(75, 21);
            this.Setup.Name = "Setup";
            this.Setup.Size = new System.Drawing.Size(12, 12);
            this.Setup.TabIndex = 6;
            this.Setup.Text = "S";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 19);
            this.button1.TabIndex = 7;
            this.button1.Text = "初回設定を実行する";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AppInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 184);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Setup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AppInfoForm";
            this.Text = "AppInfoForm";
            this.Load += new System.EventHandler(this.AppInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Setup;
        private System.Windows.Forms.Button button1;
    }
}