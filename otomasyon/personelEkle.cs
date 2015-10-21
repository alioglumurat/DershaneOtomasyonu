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
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }
        DB db = new DB();

       

      
        private void button1_Click(object sender, EventArgs e)
        {
            bool sonuc = true;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (Controls[i] is TextBox || Controls[i] is MaskedTextBox)
                {
                  
                    if (Controls[i].Text.Equals(""))
                    {
                        sonuc = false;
                    }
                }
            }
            if (sonuc)
            {
                int durum = 0;

                SqlCommand cm = new SqlCommand("degis", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter b = new SqlParameter("@data", SqlDbType.VarChar, 50);
                SqlParameter a1 = new SqlParameter("@adi", SqlDbType.VarChar, 50);
                SqlParameter a2 = new SqlParameter("@soyadi", SqlDbType.VarChar, 50);
                SqlParameter a3 = new SqlParameter("@telefon", SqlDbType.VarChar, 50);
                SqlParameter a4 = new SqlParameter("@mail", SqlDbType.VarChar, 255);
                SqlParameter a5 = new SqlParameter("@tc", SqlDbType.VarChar, 11);
                SqlParameter a6 = new SqlParameter("@adres", SqlDbType.VarChar, 500);


                b.Direction = ParameterDirection.Input;
                a1.Direction = ParameterDirection.Input;
                a2.Direction = ParameterDirection.Input;
                a3.Direction = ParameterDirection.Input;
                a4.Direction = ParameterDirection.Input;
                a5.Direction = ParameterDirection.Input;
                a6.Direction = ParameterDirection.Input;


                b.Value = Form1.degisken;
                a1.Value = ad_txt.Text;
                a2.Value = soyad_txt.Text;
                a3.Value = tel_txt.Text;
                a4.Value = mail_txt.Text;
                a5.Value = tc_text.Text;
                a6.Value = adres_txt.Text;



                cm.Parameters.Add(b);
                cm.Parameters.Add(a1);
                cm.Parameters.Add(a2);
                cm.Parameters.Add(a3);
                cm.Parameters.Add(a4);
                cm.Parameters.Add(a5);
                cm.Parameters.Add(a6);


                durum = cm.ExecuteNonQuery();



                db.kapat();
                MessageBox.Show("Kayıt İşlemi Başarılı!");
                this.Hide();
                Form1 fr = new Form1();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz!");
            }
        }

        

        
    }
}
