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
    public partial class tanima : Form
    {
        public tanima()
        {
            InitializeComponent();
        }
        DB db = new DB();
        private void button1_Click(object sender, EventArgs e)
        {
            //int durum = -1;
            try
            {
                if (textBox1.Text == "" || textBox2.Text =="" ||  textBox3.Text =="" ||  textBox4.Text == "")
                {
                    MessageBox.Show("Zorunlu Alanları Doldurunuz !");
                }
                else
                {

                    SqlCommand cm = new SqlCommand("tanimaKayit", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter a1 = new SqlParameter("@adi", SqlDbType.VarChar, 50);
                    a1.Direction = ParameterDirection.Input;
                    a1.Value = textBox1.Text;
                    cm.Parameters.Add(a1);

                    SqlParameter a2 = new SqlParameter("@soyadi", SqlDbType.VarChar, 50);
                    a2.Direction = ParameterDirection.Input;
                    a2.Value = textBox2.Text;
                    cm.Parameters.Add(a2);

                    SqlParameter a3 = new SqlParameter("@telefon", SqlDbType.VarChar, 50);
                    a3.Direction = ParameterDirection.Input;
                    a3.Value = Convert.ToString(textBox3.Text);
                    cm.Parameters.Add(a3);

                    SqlParameter a4 = new SqlParameter("@mail", SqlDbType.VarChar, 255);
                    a4.Direction = ParameterDirection.Input;
                    a4.Value = textBox4.Text;
                    cm.Parameters.Add(a4);

                    SqlParameter a5 = new SqlParameter("@ilgilendigiAlan", SqlDbType.VarChar, 500);
                    a5.Direction = ParameterDirection.Input;
                    a5.Value = textBox5.Text;
                    cm.Parameters.Add(a5);

                    SqlParameter a6 = new SqlParameter("@ilgilendigiDers", SqlDbType.VarChar, 500);
                    a6.Direction = ParameterDirection.Input;
                    a6.Value = comboBox1.Text;
                    cm.Parameters.Add(a6);

                    cm.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Tamamlandı");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Kayıt hatası : "+ex);
            }
            db.kapat();

            
            
        }

        private void tanima_FormClosed(object sender, FormClosedEventArgs e)
        {
            muhasebe mh = new muhasebe();
            mh.Show();
            this.Hide();
        }

        private void tanima_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cm = new SqlCommand("dersadial", db.baglan());
                SqlDataReader rd = cm.ExecuteReader();

                while (rd.Read())
                {
                    comboBox1.Items.Add(rd["dersAdi"]);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("hata : " + ex);
            }
            db.kapat();
        }
    }
}
