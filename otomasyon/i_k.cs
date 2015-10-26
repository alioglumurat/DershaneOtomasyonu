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
using System.Collections;

namespace otomasyon
{
    public partial class i_k : Form
    {
        public i_k()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 3;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.Columns[0].Name = "Ders";
            dataGridView1.Columns[1].Name = "İstenen saat";
            dataGridView1.Columns[2].Name = "Fiyat";
        }

        public static int ogID = 0;

        DB db = new DB();    
        ArrayList ar = new ArrayList();
        ArrayList secilenSaatArray = new ArrayList();

        
        
        private void insan_kaynaklari_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void insan_kaynaklari_Load(object sender, EventArgs e)
        {
           
            DB db = new DB();
            SqlDataReader getir = db.dersGetir();
            while (getir.Read())
            {
               listBox1.Items.Add(getir["dersAdi"].ToString());
            }
            db.kapat();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int sonuc = 0;
            int saat = 0;
            int birimUcret = 0;
            ar.Clear();            
            lbl_dersSaati.Text = " ";
            int idDegeri = 0;

            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                deger dgg = new deger();
                String deger = listBox1.Items[listBox1.SelectedIndices[i]].ToString();
                SqlCommand isle = db.dersSaatiGetir(deger);
                birimUcret = db.saatUcreti(deger);        
                saat = Convert.ToInt32(isle.ExecuteScalar());
                idDegeri = db.idGetir(listBox1.Items[listBox1.SelectedIndices[i]].ToString());
                dgg.dersId = idDegeri;
                dgg.gSaat = saat;
                dgg.gdersAdi = deger;
                dgg.ucret = birimUcret;
                ar.Add(dgg);

                sonuc += saat;
                db.kapat();
            }
            
        
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
           
            for (int i = 0; i < ar.Count; i++)
            {
                dataGridView1.Rows.Add();
                deger dgr = (deger)ar[i];
                lbl_dersSaati.Text += "" + dgr.gdersAdi + "Dersi -" + dgr.gSaat + " Saat \n\n";
                dataGridView1.Rows[i].Cells[0].Value = dgr.gdersAdi;

            }
         
            lbl_toplamSaat.Text = sonuc.ToString();

        }
        int Sonucdeger = -1;
        private void cmb_gorusme_durum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_gorusme_durum.Text == "Kayıt olacak")
            {
                Sonucdeger = 0;
                dateTimePicker1.Visible = false;
                label9.Visible = false;
            }
            if (cmb_gorusme_durum.Text == "Kayıt olmayacak")
            {
                Sonucdeger = 1;
                dateTimePicker1.Visible = false;
                label9.Visible = false;
            }
                if (cmb_gorusme_durum.Text == "Daha sonra")
            {
                dateTimePicker1.Visible = true;
                label9.Visible = true;
                Sonucdeger = 2;
            }
        }

        int indDeger = 0;

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            indDeger = Convert.ToInt32(numericUpDown2.Value);
            lbl_sonFiyat.Text = (Convert.ToInt32(lbl_toplamFiyat.Text) - indDeger).ToString();
        }


        
        private void button1_Click(object sender, EventArgs e)
        {
            int saat = 0;
            int tfiyat = 0;

            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < ar.Count; j++)
                {
                    deger dr = (deger)ar[j];
                    if (i!=dataGridView1.Rows.Count-1)
                    {
                        if (dr.gdersAdi == dataGridView1.Rows[i].Cells[0].Value.ToString())
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value)>dr.gSaat)
                            {
                                MessageBox.Show(dataGridView1.Rows[i].Cells[0].Value+" için istenen saat sistemde tanımlı saatten büyük olamaz");
                            }
                            else
                            {
                                saat = dr.ucret;
                                dataGridView1.Rows[i].Cells[2].Value = saat * Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                                tfiyat += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                            }                            
                        }
                    }              
                }
                secilenSaatArray.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                            
            }
            lbl_toplamFiyat.Text = tfiyat.ToString();
            lbl_sonFiyat.Text = tfiyat.ToString();
        }
        int sayi;
        public void omer()
        {
            SqlCommand islem = new SqlCommand("SELECT dbo.perID(@username)", db.baglan());
            SqlParameter axx = new SqlParameter("@username", SqlDbType.VarChar, 50);
            axx.Direction = ParameterDirection.Input;
            axx.Value = Form1.degisken;
            islem.Parameters.Add(axx);
            sayi = Convert.ToInt32(islem.ExecuteScalar());
         
            db.kapat();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            bool durum = true;
            try
            {
               
                if (lbl_toplamSaat.Text.Equals(""))
                {
                    MessageBox.Show("Lütfen ders seçimi yapınız.");
                    durum = false;
                }

                if (lbl_sonFiyat.Text.Equals(""))
                {
                    MessageBox.Show("Lütfen ders saatlerini hesaplayınız.");
                    durum = false;
                }
                else
                {
                    if ((Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(lbl_sonFiyat.Text) > 0))
                    {
                        MessageBox.Show("Yapılan indirim anlaşılan fiyattan fazla olamaz. ");
                    }
                }
               
                if (numericUpDown2.Value != 0)
                {
                   
                    if (txt_indirim_sebebi.Text.Equals(""))
                    {
                        durum = false;
                        MessageBox.Show("Lütfen indirim sebebini giriniz");
                    }
                }

                if (cmb_gorusme_durum.Text.Equals(""))
                {
                    durum = false;
                    MessageBox.Show("Lütfen bir görüşme sonucu seçiniz");
                }
                if (cmb_gorusme_durum.Text.Equals("Daha sonra"))
                {
                    if (txt_gorusme_aciklama.Text.Equals("")) {

                        durum = false;
                        MessageBox.Show("Lütfen bir açıklama giriniz");
                    
                    }
                }
              
                if (durum)
                {
                    omer();
                    SqlCommand yap = new SqlCommand("gorusmeKaydet", db.baglan());
                    yap.CommandType = CommandType.StoredProcedure;

                    SqlParameter ax = new SqlParameter("@a", SqlDbType.Int);
                    SqlParameter bx = new SqlParameter("@b", SqlDbType.Int);
                    SqlParameter cx = new SqlParameter("@c", SqlDbType.VarChar, 50);
                    SqlParameter dx = new SqlParameter("@d", SqlDbType.VarChar, 50);
                    SqlParameter ex = new SqlParameter("@e", SqlDbType.Int);
                    SqlParameter fx = new SqlParameter("@f", SqlDbType.Int);
                    SqlParameter gx = new SqlParameter("@g", SqlDbType.VarChar, 500);
                    SqlParameter hx = new SqlParameter("@h", SqlDbType.Int);
                    SqlParameter jx = new SqlParameter("@j", SqlDbType.DateTime);
                    SqlParameter kx = new SqlParameter("@k", SqlDbType.VarChar, 500);

                    ax.Direction = ParameterDirection.Input;
                    bx.Direction = ParameterDirection.Input;
                    cx.Direction = ParameterDirection.Input;
                    dx.Direction = ParameterDirection.Input;
                    ex.Direction = ParameterDirection.Input;
                    fx.Direction = ParameterDirection.Input;
                    gx.Direction = ParameterDirection.Input;
                    hx.Direction = ParameterDirection.Input;
                    jx.Direction = ParameterDirection.Input;
                    kx.Direction = ParameterDirection.Input;

                    String kelime = "";
                    String saatKelime = "";
                    String vir = ",";
                    for (int i = 0; i < ar.Count; i++)
                    {
                        deger dh = (deger)ar[i];
                        if (i == ar.Count - 1)
                        {
                            vir = " ";
                        }
                        kelime += dh.dersId + vir;
                    }


                    vir = ",";
                    for (int i = 0; i < secilenSaatArray.Count; i++)
                    {

                        if (i == secilenSaatArray.Count - 1)
                        {
                            vir = " ";
                        }
                        saatKelime += secilenSaatArray[i] + vir;
                    }





                    ax.Value = sayi;
                    bx.Value = ogID;
                    cx.Value = kelime;
                    dx.Value = saatKelime;
                    ex.Value = Convert.ToDecimal(lbl_toplamFiyat.Text);
                    fx.Value = Convert.ToDecimal(lbl_sonFiyat.Text);
                    gx.Value = txt_indirim_sebebi.Text;
                    hx.Value = Sonucdeger;
                    jx.Value = dateTimePicker1.Value;
                    kx.Value = txt_gorusme_aciklama.Text;

                    yap.Parameters.Add(ax);
                    yap.Parameters.Add(bx);
                    yap.Parameters.Add(cx);
                    yap.Parameters.Add(dx);
                    yap.Parameters.Add(ex);
                    yap.Parameters.Add(fx);
                    yap.Parameters.Add(gx);
                    yap.Parameters.Add(hx);
                    yap.Parameters.Add(jx);
                    yap.Parameters.Add(kx);
                    int sx = 0;
                    sx = yap.ExecuteNonQuery();
                    if (sx == 1)
                    {
                        MessageBox.Show("Başarıyla kaydedildi");
                    }

                    txt_indirim_sebebi.Text = " ";
                    txt_gorusme_aciklama.Text = " ";
                    cmb_gorusme_durum.Text = " ";

                    listBox1.ClearSelected();
                    numericUpDown2.Value = 0;
                    //dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    lbl_dersSaati.Text = " ";
                    lbl_sonFiyat.Text = " ";
                    lbl_toplamFiyat.Text = " ";
                    lbl_toplamSaat.Text = " ";
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Görüşme kaydetme hatası"+ex);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
