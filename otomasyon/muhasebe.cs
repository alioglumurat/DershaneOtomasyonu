using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace otomasyon
{
    public partial class muhasebe : Form
    {
        DB db = new DB();
        fnc fnc = new fnc();

        public muhasebe()
        {
            InitializeComponent();
        }

        private void muhasebe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fnc.giderTipiListele();
            dataGrid1Styles();
            db.kapat();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabGiderTipleri"])
            {
                dataGridView1.DataSource = fnc.giderTipiListele();
                dataGrid1Styles();
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabGiderler"])
            {
                cbGiderAdi.Items.Clear();
                dataGridView2.DataSource = fnc.giderListele();
                dataGrid2Styles();

                try
                {
                    SqlDataReader durum = fnc.cmbVeriYukle("giderAdiCombo");
                    while (durum.Read())
                    {
                        cbGiderAdi.Items.Add(durum["adi"]);
                        cbGiderAdi.Text = "";
                    }
                    durum.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            db.kapat();
        }

        // Gider Tipleri Sekmesi - Ekle Butonu
        private void btnEkle_Click(object sender, EventArgs e)
        {
            int durum = 0;
            try
            {
                if (txtGiderAdi.Text.Equals(""))
                    MessageBox.Show("HATA : 'Gider Adı' alanı boş bırakılamaz !");
                else
                {
                    durum = fnc.giderTipiEkle(txtGiderAdi.Text);

                    if (durum > 0)
                    {
                        MessageBox.Show("Gider adı başarıyla eklenmiştir.");
                        txtGiderAdi.Clear();

                        dataGridView1.DataSource = fnc.giderTipiListele();
                    }
                    else
                    {
                        MessageBox.Show("HATA : Gider adı eklenirken bir hata oluştu !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.kapat();
        }

        // Gider Tipleri Sekmesi - Güncelle Butonu
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int durum = 0;
            try
            {
                if (txtGiderAdi.Text.Equals(""))
                    MessageBox.Show("HATA : Lütfen tablodan değiştirmek istediğiniz alanı tıklayınız !");
                else
                {
                    durum = fnc.giderTipiGuncelle(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()), txtGiderAdi.Text);

                    if (durum > 0)
                    {
                        MessageBox.Show("Gider adı başarıyla güncellenmiştir.");
                        txtGiderAdi.Clear();

                        dataGridView1.DataSource = fnc.giderTipiListele();
                    }
                    else
                    {
                        MessageBox.Show("HATA : Gider adı güncellenirken bir hata oluştu !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.kapat();
        }

        // Gider Tipleri Sekmesi - Güncelleme Olayı
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtGiderAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            db.kapat();
        }

        // Giderler Sekmesi - Kaydet Butonu
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int durum = 0;
            try
            {
                if (cbGiderAdi.Text.Equals("") || txtTutar.Text.Equals("") || txtAciklama.Text.Equals("") || txtDosyaEkle.Text.Equals(""))
                    MessageBox.Show("HATA : Alanlar boş bırakılamaz !");
                else
                {
                    durum = fnc.giderEkle(cbGiderAdi.Text, float.Parse(txtTutar.Text), txtAciklama.Text, txtDosyaEkle.Text);

                    if (durum > 0)
                    {
                        MessageBox.Show("Gider bilgileri başarıyla eklenmiştir.");
                        cbGiderAdi.Text = "";
                        txtTutar.Clear();
                        txtAciklama.Clear();
                        txtDosyaEkle.Clear();

                        dataGridView2.DataSource = fnc.giderListele();
                    }
                    else
                    {
                        MessageBox.Show("HATA : Gider bilgileri eklenirken bir hata oluştu !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.kapat();
        }

        // Giderler Sekmesi - Güncelle Butonu
        private void btnGuncelle2_Click(object sender, EventArgs e)
        {
            int durum = 0;
            try
            {
                if (cbGiderAdi.Text.Equals("") || txtTutar.Text.Equals("") || txtAciklama.Text.Equals("") || txtDosyaEkle.Text.Equals(""))
                    MessageBox.Show("HATA : Lütfen tablodan değiştirmek istediğiniz alanı tıklayınız !");
                else
                {
                    durum = fnc.giderGuncelle(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), cbGiderAdi.SelectedItem.ToString(), Convert.ToDouble(txtTutar.Text), txtAciklama.Text, txtDosyaEkle.Text);

                    if (durum > 0)
                    {
                        MessageBox.Show("Gider bilgileri başarıyla güncellenmiştir.");
                        cbGiderAdi.Text = "";
                        txtTutar.Clear();
                        txtAciklama.Clear();
                        txtDosyaEkle.Clear();

                        dataGridView2.DataSource = fnc.giderListele();
                    }
                    else
                    {
                        MessageBox.Show("HATA : Gider bilgileri güncellenirken bir hata oluştu !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.kapat();
        }

        // Giderler Sekmesi - Güncelleme Olayı
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbGiderAdi.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtAciklama.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtTutar.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            txtDosyaEkle.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();

            db.kapat();
        }

        // Giderler Sekmesi - Sil Butonu
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int sayi = fnc.giderSil(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value));
                MessageBox.Show("Kayıt Silme İşlemi Başarılı !");

                dataGridView2.DataSource = fnc.giderListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            db.kapat();
        }

        // Giderler Sekmesi - Arama Butonu
        private void btnArama_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGiderAra.Text.Equals(""))
                {
                    dataGridView2.DataSource = fnc.giderListele();
                }
                else
                {
                    String bol = "";
                    String or = "";
                    String[] dizi = txtGiderAra.Text.Split(' ');
                
                    for (int i = 0; i < dizi.Length; i++)
			        {
			            if (i == dizi.Length - 1)
	                    {
		                    or = "";
	                    }
                        else
	                    {
                            or = " or ";
	                    }

                        bol += dizi[i] + or;
                    }
                    String bol1="" + bol + "";

                    DataTable dt = new DataTable();
                    SqlDataReader rd =   fnc.giderAra(bol1);
                
                    dt.Load(rd);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();
        }

        // Giderler Sekmesi - Gözat Butonu
        private void btnGozat_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Dosya Seçiniz";
                openFileDialog1.InitialDirectory = "C:\\";
                openFileDialog1.ShowDialog();
                txtDosyaEkle.Text = openFileDialog1.FileName;
            }
            catch (Exception)
            {
                MessageBox.Show(openFileDialog1.FileName + " Bu dosya açılamadı !!!");
            }
            db.kapat();
        }

        // Giderler Sekmesi - Tutar Alanı - 1
        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        // Giderler Sekmesi - Tutar Alanı - 2
        private void txtTutar_Leave(object sender, EventArgs e)
        {
            float tutar;
            tutar = float.Parse(txtTutar.Text);
            txtTutar.Text = tutar.ToString("N");
        }

        // Gider Tipleri Sekmesi - Tablo Özellikleri
        public void dataGrid1Styles()
        {
            DataGridViewCellStyle columnHeaderStyle1 = new DataGridViewCellStyle();
            columnHeaderStyle1.BackColor = Color.Purple;
            columnHeaderStyle1.Font = new Font("Calibri", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle1;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderCell.Value = "No";
            dataGridView1.Columns[0].Width = 35;

            dataGridView1.Columns[1].HeaderCell.Value = "Gider Adı";

            dataGridView1.Columns[2].HeaderCell.Value = "Eklenme Tarihi";
            dataGridView1.Columns[2].Width = 150;
        }

        // Giderler Sekmesi - Tablo Özellikleri
        public void dataGrid2Styles()
        {
            DataGridViewCellStyle columnHeaderStyle2 = new DataGridViewCellStyle();
            columnHeaderStyle2.BackColor = Color.Purple;
            columnHeaderStyle2.Font = new Font("Calibri", 10, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle2;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].HeaderCell.Value = "No";
            dataGridView2.Columns[0].Width = 35;

            dataGridView2.Columns[1].HeaderCell.Value = "Gider Adı";
            dataGridView2.Columns[2].HeaderCell.Value = "Açıklama";

            dataGridView2.Columns[3].HeaderCell.Value = "Tutar";
            dataGridView2.Columns[3].Width = 80;

            dataGridView2.Columns[4].HeaderCell.Value = "Dosya URL";
            dataGridView2.Columns[4].Width = 120;

            dataGridView2.Columns[5].HeaderCell.Value = "Eklenme Tarihi";
            dataGridView2.Columns[5].Width = 120;
        }

        // Giderler Sekmesi - ComboBox Özelliği
        private void cbGiderAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Giderler Sekmesi - dataGridView2
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}