namespace otomasyon
{
    partial class SınıfForm
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
            this.txtad = new System.Windows.Forms.TextBox();
            this.txtkapasite = new System.Windows.Forms.TextBox();
            this.txtaciklama = new System.Windows.Forms.TextBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsekleg = new System.Windows.Forms.Button();
            this.btnssil = new System.Windows.Forms.Button();
            this.btnsguncel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtad
            // 
            this.txtad.Location = new System.Drawing.Point(88, 15);
            this.txtad.Name = "txtad";
            this.txtad.Size = new System.Drawing.Size(311, 20);
            this.txtad.TabIndex = 0;
            // 
            // txtkapasite
            // 
            this.txtkapasite.Location = new System.Drawing.Point(88, 53);
            this.txtkapasite.Name = "txtkapasite";
            this.txtkapasite.Size = new System.Drawing.Size(311, 20);
            this.txtkapasite.TabIndex = 1;
            // 
            // txtaciklama
            // 
            this.txtaciklama.Location = new System.Drawing.Point(88, 127);
            this.txtaciklama.Multiline = true;
            this.txtaciklama.Name = "txtaciklama";
            this.txtaciklama.Size = new System.Drawing.Size(311, 62);
            this.txtaciklama.TabIndex = 2;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(88, 89);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(311, 20);
            this.dtp.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sınıf Adi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Kapasite";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tarih";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Açıklama";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(559, 212);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnsekleg
            // 
            this.btnsekleg.Location = new System.Drawing.Point(424, 13);
            this.btnsekleg.Name = "btnsekleg";
            this.btnsekleg.Size = new System.Drawing.Size(147, 55);
            this.btnsekleg.TabIndex = 9;
            this.btnsekleg.Text = "Sınıf Ekle";
            this.btnsekleg.UseVisualStyleBackColor = true;
            this.btnsekleg.Click += new System.EventHandler(this.btnsekleg_Click);
            // 
            // btnssil
            // 
            this.btnssil.Location = new System.Drawing.Point(424, 134);
            this.btnssil.Name = "btnssil";
            this.btnssil.Size = new System.Drawing.Size(147, 55);
            this.btnssil.TabIndex = 10;
            this.btnssil.Text = "Sınıf Sil";
            this.btnssil.UseVisualStyleBackColor = true;
            this.btnssil.Click += new System.EventHandler(this.btnssil_Click);
            // 
            // btnsguncel
            // 
            this.btnsguncel.Location = new System.Drawing.Point(424, 74);
            this.btnsguncel.Name = "btnsguncel";
            this.btnsguncel.Size = new System.Drawing.Size(147, 54);
            this.btnsguncel.TabIndex = 11;
            this.btnsguncel.Text = "Sınıf Güncelle";
            this.btnsguncel.UseVisualStyleBackColor = true;
            this.btnsguncel.Click += new System.EventHandler(this.btnsguncel_Click);
            // 
            // SınıfForm
            // 
            this.AcceptButton = this.btnsekleg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 436);
            this.Controls.Add(this.btnsguncel);
            this.Controls.Add(this.btnssil);
            this.Controls.Add(this.btnsekleg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.txtaciklama);
            this.Controls.Add(this.txtkapasite);
            this.Controls.Add(this.txtad);
            this.Name = "SınıfForm";
            this.Text = "SınıfForm";
            this.Load += new System.EventHandler(this.SınıfForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtad;
        private System.Windows.Forms.TextBox txtkapasite;
        private System.Windows.Forms.TextBox txtaciklama;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsekleg;
        private System.Windows.Forms.Button btnssil;
        private System.Windows.Forms.Button btnsguncel;
    }
}