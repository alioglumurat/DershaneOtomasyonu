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

    public partial class demirbas : Form
    {


        public demirbas()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        DB db = new DB();
        private void demirbas_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Load(db.ozdatagetir("demirbasdatagetir"));
            dataGridView1.DataSource = dt;

        }

        private void demirbas_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            muhasebe mhs = new muhasebe();
            mhs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Demirbaş adını giriniz!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Demirbaş adetini giriniz!");

            }

            else if (textBox3.Text == "")
            {
                MessageBox.Show("Demirbaş fiyatını giriniz!");

            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Personel id'sini  giriniz!");

            }

            else if (textBox5.Text == "")
            {
                MessageBox.Show("Lokasyon giriniz!");

            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Açıklama giriniz!");

            }



            else
            {
                try
                {
                    //int sayi = db.ozdataekle(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text, textBox6.Text);
                    int sayi = db.ozdataekle(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                    if (sayi > 0)
                    {
                        MessageBox.Show("kayıt islemi gerceklesti");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();

                        SqlCommand cm = new SqlCommand("select p.adi,p.soyadi,p.id as personelID,d.adi as demirbasadi,d.adet,d.id,d.fiyat,d.lokasyon,d.aciklama,d.tarih from personelProfil as p left join demirbas as d on d.personelId=p.id", db.baglan());
                        SqlDataReader oku = cm.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(oku);
                        dataGridView1.DataSource = dt;
                        db.kapat();

                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız");
                    }
                }

                catch (Exception ex)
                {

                    int bak;
                    if (!int.TryParse(textBox2.Text, out bak))

                    {
                        MessageBox.Show("Lütfen Demirbaş adeti için sayısal değerler giriniz");
                    }

                    else if (!int.TryParse(textBox3.Text, out bak))

                    {
                        MessageBox.Show("Lütfen personel id için sayısal değer giriniz");
                    }

                    else if (!int.TryParse(textBox4.Text, out bak))

                    {
                        MessageBox.Show("Lütfen fiyat için sayısal değerler giriniz");
                    }
                    else
                    {
                        MessageBox.Show("Kayıt hekleme hatası" + ex);
                    }




                }
                db.kapat();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Demirbaş adını giriniz!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Demirbaş adetini giriniz!");

            }

            else if (textBox3.Text == "")
            {
                MessageBox.Show("Demirbaş fiyatını giriniz!");

            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Personel id'sini  giriniz!");

            }

            else if (textBox5.Text == "")
            {
                MessageBox.Show("Lokasyon giriniz!");

            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Açıklama giriniz!");

            }
            else {

                int sayi1 = 0;
                try
                {

                    SqlCommand cm = new SqlCommand("demirbasdataguncelle", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;

                    SqlParameter a = new SqlParameter("id", SqlDbType.Int);
                    a.Direction = ParameterDirection.Input;
                    a.Value = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    cm.Parameters.Add(a);


                    SqlParameter b = new SqlParameter("adi", SqlDbType.VarChar, 500);
                    b.Direction = ParameterDirection.Input;
                    b.Value = textBox1.Text;
                    cm.Parameters.Add(b);


                    SqlParameter c = new SqlParameter("adet", SqlDbType.TinyInt);
                    c.Direction = ParameterDirection.Input;
                    c.Value = textBox2.Text;
                    cm.Parameters.Add(c);


                    SqlParameter d = new SqlParameter("personelid", SqlDbType.Int);
                    d.Direction = ParameterDirection.Input;
                    d.Value = textBox3.Text;
                    cm.Parameters.Add(d);


                    SqlParameter f = new SqlParameter("fiyat", SqlDbType.Money);
                    f.Direction = ParameterDirection.Input;
                    f.Value = textBox4.Text;
                    cm.Parameters.Add(f);


                    SqlParameter g = new SqlParameter("lokasyon", SqlDbType.VarChar, 500);
                    g.Direction = ParameterDirection.Input;
                    g.Value = textBox5.Text;
                    cm.Parameters.Add(g);


                    SqlParameter h = new SqlParameter("aciklama", SqlDbType.VarChar, 500);
                    h.Direction = ParameterDirection.Input;
                    h.Value = textBox6.Text;
                    cm.Parameters.Add(h);

                    sayi1 = cm.ExecuteNonQuery();

                    if (sayi1 > 0)
                    {
                        MessageBox.Show("Data güncelleme basarili");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();


                        //SqlCommand cmm= new SqlCommand("select p.adi, p.soyadi, d.personelId, d.adi as demirbasadi, d.adet, d.id, d.fiyat, d.lokasyon, d.aciklama, d.tarih from personelProfil as p left join demirbas as d on d.personelId = p.id", db.baglan());
                        //SqlDataReader oku = cmm.ExecuteReader();
                        //DataTable dt = new DataTable();
                        //dt.Load(oku);
                        //dataGridView1.DataSource = dt;
                        //db.kapat();

                    }

                    else
                    {
                        MessageBox.Show("Data güncellenemedi");
                    }
                    db.kapat();
                    SqlCommand cmmm = new SqlCommand("demirbasveriguncelle", db.baglan());
                    cmmm.CommandType = CommandType.StoredProcedure;
                    SqlDataReader drr = cmmm.ExecuteReader();
                    DataTable dtt = new DataTable();
                    dtt.Load(drr);
                    dataGridView1.DataSource = dtt;
                    db.kapat();
                }

                catch (Exception ex)
                {
                    int bak;
                    if (!int.TryParse(textBox2.Text, out bak))

                    {
                        MessageBox.Show("Lütfen Demirbaş adeti için sayısal değerler giriniz");
                    }

                    else if (!int.TryParse(textBox3.Text, out bak))

                    {
                        MessageBox.Show("Lütfen personel id için sayısal değer giriniz");
                    }

                    else if (!int.TryParse(textBox4.Text, out bak))

                    {
                        MessageBox.Show("Lütfen fiyat için sayısal değerler giriniz");
                    }
                    else
                    {
                        MessageBox.Show("güncelleme hatası" + ex);
                    }

                }
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int sayi2 = 0;
            int id = 0;
            //int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
            try
            {

                String t = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                if (t.Equals(""))
                {
                    MessageBox.Show("Bu personelin üzerine zimmetli demirbas yoktur.Silemezsiniz!!!!!!11");
                }
                else
                {
                    id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                    SqlCommand cmm2 = new SqlCommand("demirbasdatasil", db.baglan());
                    cmm2.CommandType = CommandType.StoredProcedure;

                    SqlParameter a = new SqlParameter("id", SqlDbType.Int);
                    a.Direction = ParameterDirection.Input;
                    a.Value = id;/*dataGridView1.CurrentRow.Cells[5].Value.ToString();*/
                    cmm2.Parameters.Add(a);

                  id = cmm2.ExecuteNonQuery();

                    if (id > 0)
                    {
                        MessageBox.Show("Data silme başarıyla gerçekleşti");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();

                        SqlCommand cmm = new SqlCommand("select p.adi, p.soyadi, d.personelId, d.adi as demirbasadi, d.adet, d.id, d.fiyat, d.lokasyon, d.aciklama, d.tarih from personelProfil as p left join demirbas as d on d.personelId = p.id", db.baglan());
                        SqlDataReader oku = cmm.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(oku);
                        dataGridView1.DataSource = dt;
                        db.kapat();


                    }
                    else
                    {
                        MessageBox.Show("Data silme başarısız");
                    }
                }
                }
            catch (Exception ex)
            {
               

                MessageBox.Show("Silme hatası" + ex);
            }
        
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            if (!textBox7.Text.Equals(""))
            {
                try
                {
                    String par = "";

                    String or = "";
                    String[] dizi = textBox7.Text.Split(' ');

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



                        par += dizi[i] + or;
                    }
                    String par1 = "'" + par + "'";
                    //MessageBox.Show(par1);
                    SqlCommand cmm3 = new SqlCommand("demirbasara", db.baglan());
                    cmm3.CommandType = CommandType.StoredProcedure;
                    SqlParameter ax = new SqlParameter("@ara", SqlDbType.VarChar, 50);
                    ax.Direction = ParameterDirection.Input;
                    ax.Value = par1;
                    cmm3.Parameters.Add(ax);
                    SqlDataReader oku = cmm3.ExecuteReader();
                    DataTable dt1 = new DataTable();
                    dt1.Load(oku);
                    dataGridView1.DataSource = dt1;
                    db.kapat();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("hata" + ex);
                }

            }
            else
            {

                DataTable dt = new DataTable();
                dt.Load(db.ozdatagetir("demirbasdatagetir"));
                dataGridView1.DataSource = dt;


            }

        }
    }
}
    

