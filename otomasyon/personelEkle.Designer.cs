namespace otomasyon
{
    partial class personelEkle
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
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.adres_txt = new System.Windows.Forms.TextBox();
            this.mail_txt = new System.Windows.Forms.TextBox();
            this.tel_txt = new System.Windows.Forms.TextBox();
            this.soyad_txt = new System.Windows.Forms.TextBox();
            this.ad_txt = new System.Windows.Forms.TextBox();
            this.tc_text = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Soyadı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Adres:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "TC Kimlik No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "E-Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Telefon:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Adı:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // adres_txt
            // 
            this.adres_txt.Location = new System.Drawing.Point(248, 234);
            this.adres_txt.Multiline = true;
            this.adres_txt.Name = "adres_txt";
            this.adres_txt.Size = new System.Drawing.Size(196, 56);
            this.adres_txt.TabIndex = 16;
            // 
            // mail_txt
            // 
            this.mail_txt.Location = new System.Drawing.Point(248, 154);
            this.mail_txt.Name = "mail_txt";
            this.mail_txt.Size = new System.Drawing.Size(196, 20);
            this.mail_txt.TabIndex = 18;
            // 
            // tel_txt
            // 
            this.tel_txt.Location = new System.Drawing.Point(248, 112);
            this.tel_txt.Name = "tel_txt";
            this.tel_txt.Size = new System.Drawing.Size(196, 20);
            this.tel_txt.TabIndex = 19;
            // 
            // soyad_txt
            // 
            this.soyad_txt.Location = new System.Drawing.Point(248, 69);
            this.soyad_txt.Name = "soyad_txt";
            this.soyad_txt.Size = new System.Drawing.Size(196, 20);
            this.soyad_txt.TabIndex = 20;
            // 
            // ad_txt
            // 
            this.ad_txt.Location = new System.Drawing.Point(248, 27);
            this.ad_txt.Name = "ad_txt";
            this.ad_txt.Size = new System.Drawing.Size(196, 20);
            this.ad_txt.TabIndex = 21;
            // 
            // tc_text
            // 
            this.tc_text.Location = new System.Drawing.Point(248, 195);
            this.tc_text.Mask = "00000000000";
            this.tc_text.Name = "tc_text";
            this.tc_text.Size = new System.Drawing.Size(196, 20);
            this.tc_text.TabIndex = 29;
            // 
            // personelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 356);
            this.Controls.Add(this.tc_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adres_txt);
            this.Controls.Add(this.mail_txt);
            this.Controls.Add(this.tel_txt);
            this.Controls.Add(this.soyad_txt);
            this.Controls.Add(this.ad_txt);
            this.Name = "personelEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "personelEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox adres_txt;
        private System.Windows.Forms.TextBox mail_txt;
        private System.Windows.Forms.TextBox tel_txt;
        private System.Windows.Forms.TextBox soyad_txt;
        private System.Windows.Forms.TextBox ad_txt;
        private System.Windows.Forms.MaskedTextBox tc_text;


    }
}