namespace youtubedown2
{
    partial class DougaConverterApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.atosentaku = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.motosentaku = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.henkan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "元動画";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.atosentaku);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.motosentaku);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 175);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "名前";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(56, 129);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(391, 25);
            this.textBox3.TabIndex = 6;
            // 
            // atosentaku
            // 
            this.atosentaku.Location = new System.Drawing.Point(361, 86);
            this.atosentaku.Name = "atosentaku";
            this.atosentaku.Size = new System.Drawing.Size(86, 23);
            this.atosentaku.TabIndex = 5;
            this.atosentaku.Text = "選択";
            this.atosentaku.UseVisualStyleBackColor = true;
            this.atosentaku.Click += new System.EventHandler(this.atosentaku_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(299, 25);
            this.textBox2.TabIndex = 4;
            // 
            // motosentaku
            // 
            this.motosentaku.Location = new System.Drawing.Point(361, 40);
            this.motosentaku.Name = "motosentaku";
            this.motosentaku.Size = new System.Drawing.Size(86, 23);
            this.motosentaku.TabIndex = 3;
            this.motosentaku.Text = "選択";
            this.motosentaku.UseVisualStyleBackColor = true;
            this.motosentaku.Click += new System.EventHandler(this.motosentaku_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(299, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "変換後";
            // 
            // henkan
            // 
            this.henkan.Location = new System.Drawing.Point(12, 193);
            this.henkan.Name = "henkan";
            this.henkan.Size = new System.Drawing.Size(453, 29);
            this.henkan.TabIndex = 2;
            this.henkan.Text = "変換";
            this.henkan.UseVisualStyleBackColor = true;
            this.henkan.Click += new System.EventHandler(this.henkan_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 239);
            this.Controls.Add(this.henkan);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "超絶どうが変換機β1.0  ※試験段階です";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button atosentaku;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button motosentaku;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button henkan;
    }
}