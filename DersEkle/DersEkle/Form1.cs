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

namespace DersEkle
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Ders Adi Giriniz !");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Saat Ücreti Giriniz !");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Vade Farkı  Giriniz !");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Toplam Saati Giriniz !");
            }

            else
            {
                try
                {
                    SqlCommand cm = new SqlCommand("DersEkle", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter dersAdi = new SqlParameter("@DersAdi", SqlDbType.VarChar, 500);
                    dersAdi.Direction = ParameterDirection.Input;
                    dersAdi.Value = textBox1.Text;
                    cm.Parameters.Add(dersAdi);
                    SqlParameter saatUcreti = new SqlParameter("@saatUcreti", SqlDbType.TinyInt);
                    saatUcreti.Direction = ParameterDirection.Input;
                    saatUcreti.Value = Convert.ToDouble(textBox2.Text);
                    cm.Parameters.Add(saatUcreti);
                    SqlParameter toplamSaat = new SqlParameter("@toplamSaat", SqlDbType.TinyInt);
                    toplamSaat.Direction = ParameterDirection.Input;
                    toplamSaat.Value = Convert.ToInt32(textBox4.Text);
                    cm.Parameters.Add(toplamSaat);
                    SqlParameter vadeFarki = new SqlParameter("@VadeFarkı", SqlDbType.VarChar, 500);
                    vadeFarki.Direction = ParameterDirection.Input;
                    vadeFarki.Value = Convert.ToDouble(textBox3.Text);
                    cm.Parameters.Add(vadeFarki);
                    SqlParameter tarih = new SqlParameter("@tarih", SqlDbType.DateTime);
                    tarih.Direction = ParameterDirection.Input;
                    tarih.Value = dateTimePicker1.Value;
                    cm.Parameters.Add(tarih);
                    cm.ExecuteNonQuery();
                    dataGridView1.DataSource = db.gridData("dersler");
                    
                    
                    MessageBox.Show("DERS BAŞARIYLA EKLENDİ !");
                    db.kapat();
                }
                catch (Exception ex)
                {
                    Double a;
                    if (!Double.TryParse(textBox2.Text, out a))
                    {
                        MessageBox.Show("Lütfen Saat Ücreti Bölümüne Sayıyal Değer Giriniz  !");
                    }
                        else if(!Double.TryParse(textBox3.Text, out a))
                         {
                        MessageBox.Show("Lütfen Vade Farkı Bölümüne Sayıyal Değer Giriniz  !");
                    }
                    else
                    { MessageBox.Show("Ders Ekleme Başarısız" + ex); }
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);


                SqlCommand cm = new SqlCommand("DersSil", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter a1 = new SqlParameter("@id", SqlDbType.Int);

                a1.Direction = ParameterDirection.Input;

                a1.Value = id;

                cm.Parameters.Add(a1);
                cm.ExecuteNonQuery();
                MessageBox.Show("DERS BAŞARIYLA SİLİNDİ");
                dataGridView1.DataSource = db.gridData("dersler");
                db.kapat();


            }
            catch
            {
                MessageBox.Show(" DERS SİLİNEMEDİ !");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dataGridView1.DataSource = db.gridData("dersler");
            db.kapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                String dersAdi = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["dersAdi"].Value);
                Double saatUcreti = Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["saatUcreti"].Value);
                Double vadeFarki = Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["vadeFarki"].Value);
                DateTime tarih = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["tarih"].Value);
                int toplamSaat = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["toplamSaat"].Value);
                SqlCommand cm = new SqlCommand("DersDüzenle", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter a1 = new SqlParameter("@id", SqlDbType.Int);
                SqlParameter a2 = new SqlParameter("@dersAdi", SqlDbType.VarChar, 500);
                SqlParameter a3 = new SqlParameter("@saatUcreti", SqlDbType.Money);
                SqlParameter a4 = new SqlParameter("@vadeFarki", SqlDbType.Float);
                SqlParameter a5 = new SqlParameter("@tarih", SqlDbType.DateTime);
                SqlParameter a6 = new SqlParameter("@toplamSaat", SqlDbType.TinyInt);
                a1.Direction = ParameterDirection.Input;
                a1.Value = id;
                cm.Parameters.Add(a1);
                a2.Direction = ParameterDirection.Input;
                a2.Value = textBox1.Text;
                cm.Parameters.Add(a2);
                a3.Direction = ParameterDirection.Input;
                a3.Value = textBox2.Text;
                cm.Parameters.Add(a3);
                a4.Direction = ParameterDirection.Input;
                a4.Value = textBox3.Text;
                cm.Parameters.Add(a4);
                //cm.ExecuteNonQuery();
                a5.Direction = ParameterDirection.Input;
                a5.Value = dateTimePicker1.Value;
                cm.Parameters.Add(a5);
                a6.Direction = ParameterDirection.Input;
                a6.Value = id;
                cm.Parameters.Add(a6);
                cm.ExecuteNonQuery();
                MessageBox.Show("DERS BAŞARIYLA DÜZENLENDİ");
                dataGridView1.DataSource = db.gridData("dersler");
                db.kapat();
            }
            catch
            {
                MessageBox.Show(" DERS DÜZENLENEMEDİ !");
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["dersAdi"].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["saatUcreti"].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["toplamSaat"].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["vadeFarki"].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["tarih"].Value);
        }
    }
}
