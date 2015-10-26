namespace otomasyon
{
    partial class i_k
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_toplamFiyat = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lbl_sonFiyat = new System.Windows.Forms.Label();
            this.txt_indirim_sebebi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.txt_gorusme_aciklama = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmb_gorusme_durum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_toplamSaat = new System.Windows.Forms.Label();
            this.lbl_dersSaati = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, -3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 421);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Öğrenci Bilgileri";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_toplamFiyat);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.lbl_sonFiyat);
            this.tabPage2.Controls.Add(this.txt_indirim_sebebi);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.btn_kaydet);
            this.tabPage2.Controls.Add(this.txt_gorusme_aciklama);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.cmb_gorusme_durum);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lbl_toplamSaat);
            this.tabPage2.Controls.Add(this.lbl_dersSaati);
            this.tabPage2.Controls.Add(this.label);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(705, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Görüşme Bilgileri";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_toplamFiyat
            // 
            this.lbl_toplamFiyat.AutoSize = true;
            this.lbl_toplamFiyat.Location = new System.Drawing.Point(177, 331);
            this.lbl_toplamFiyat.Name = "lbl_toplamFiyat";
            this.lbl_toplamFiyat.Size = new System.Drawing.Size(0, 13);
            this.lbl_toplamFiyat.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Toplam Fiyat";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 107);
            this.button1.TabIndex = 20;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(335, 111);
            this.dataGridView1.TabIndex = 19;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.numericUpDown2.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(501, 21);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(67, 20);
            this.numericUpDown2.TabIndex = 18;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // lbl_sonFiyat
            // 
            this.lbl_sonFiyat.AutoSize = true;
            this.lbl_sonFiyat.Location = new System.Drawing.Point(177, 358);
            this.lbl_sonFiyat.Name = "lbl_sonFiyat";
            this.lbl_sonFiyat.Size = new System.Drawing.Size(0, 13);
            this.lbl_sonFiyat.TabIndex = 17;
            // 
            // txt_indirim_sebebi
            // 
            this.txt_indirim_sebebi.Location = new System.Drawing.Point(500, 57);
            this.txt_indirim_sebebi.Multiline = true;
            this.txt_indirim_sebebi.Name = "txt_indirim_sebebi";
            this.txt_indirim_sebebi.Size = new System.Drawing.Size(174, 65);
            this.txt_indirim_sebebi.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "İndirim Sebebi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "İndirim";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(180, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(142, 69);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 10;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Location = new System.Drawing.Point(306, 363);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(108, 29);
            this.btn_kaydet.TabIndex = 9;
            this.btn_kaydet.Text = "KAYDET";
            this.btn_kaydet.UseVisualStyleBackColor = true;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // txt_gorusme_aciklama
            // 
            this.txt_gorusme_aciklama.Location = new System.Drawing.Point(500, 210);
            this.txt_gorusme_aciklama.Multiline = true;
            this.txt_gorusme_aciklama.Name = "txt_gorusme_aciklama";
            this.txt_gorusme_aciklama.Size = new System.Drawing.Size(190, 87);
            this.txt_gorusme_aciklama.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(500, 178);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Visible = false;
            // 
            // cmb_gorusme_durum
            // 
            this.cmb_gorusme_durum.FormattingEnabled = true;
            this.cmb_gorusme_durum.Items.AddRange(new object[] {
            "Kayıt olacak",
            "Kayıt olmayacak",
            "Daha sonra"});
            this.cmb_gorusme_durum.Location = new System.Drawing.Point(500, 142);
            this.cmb_gorusme_durum.Name = "cmb_gorusme_durum";
            this.cmb_gorusme_durum.Size = new System.Drawing.Size(121, 21);
            this.cmb_gorusme_durum.TabIndex = 4;
            this.cmb_gorusme_durum.SelectedIndexChanged += new System.EventHandler(this.cmb_gorusme_durum_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Açıklama";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Süre";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Sonuç";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Son Fiyat";
            // 
            // lbl_toplamSaat
            // 
            this.lbl_toplamSaat.AutoSize = true;
            this.lbl_toplamSaat.Location = new System.Drawing.Point(180, 176);
            this.lbl_toplamSaat.Name = "lbl_toplamSaat";
            this.lbl_toplamSaat.Size = new System.Drawing.Size(0, 13);
            this.lbl_toplamSaat.TabIndex = 3;
            // 
            // lbl_dersSaati
            // 
            this.lbl_dersSaati.AutoSize = true;
            this.lbl_dersSaati.Location = new System.Drawing.Point(177, 106);
            this.lbl_dersSaati.Name = "lbl_dersSaati";
            this.lbl_dersSaati.Size = new System.Drawing.Size(0, 13);
            this.lbl_dersSaati.TabIndex = 3;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(27, 174);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(94, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Toplam Ders Saati";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ders Saatleri";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ders Türü";
            // 
            // i_k
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 428);
            this.Controls.Add(this.tabControl1);
            this.Name = "i_k";
            this.Text = "insan_kaynaklari";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.insan_kaynaklari_FormClosed);
            this.Load += new System.EventHandler(this.insan_kaynaklari_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.TextBox txt_gorusme_aciklama;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmb_gorusme_durum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_dersSaati;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txt_indirim_sebebi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_toplamSaat;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbl_sonFiyat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_toplamFiyat;
        private System.Windows.Forms.Label label4;
    }
}