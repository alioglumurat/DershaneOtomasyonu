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

namespace chnProjeSinif
{
    public partial class Form1 : Form
    {

        DB db = new DB();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "")
            {
                MessageBox.Show("Lütfen Sınıf Adi Giriniz !");
            }
            else if (txtkapasite.Text == "")
            {
                MessageBox.Show("Lütfen Kapasite Giriniz !");
            }
         /*   else if (txtaciklama.Text == "")
            {
                MessageBox.Show("Lütfen Açıklama Giriniz !");
            }
            */
            else
            {
                try
                {
                    SqlCommand cm = new SqlCommand("sinifekle", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter adi = new SqlParameter("@adi", SqlDbType.VarChar, 500);
                    adi.Direction = ParameterDirection.Input;
                    adi.Value = txtad.Text;
                    cm.Parameters.Add(adi);
                    SqlParameter kapasite = new SqlParameter("@kapasite", SqlDbType.TinyInt);
                    kapasite.Direction = ParameterDirection.Input;
                    kapasite.Value = Convert.ToInt16(txtkapasite.Text);
                    cm.Parameters.Add(kapasite);
                    SqlParameter aciklama = new SqlParameter("@aciklama", SqlDbType.VarChar, 500);
                    aciklama.Direction = ParameterDirection.Input;
                    aciklama.Value = txtaciklama.Text;
                    cm.Parameters.Add(aciklama);
                    SqlParameter tarih = new SqlParameter("@tarih", SqlDbType.DateTime);
                    tarih.Direction = ParameterDirection.Input;
                    tarih.Value = dtp.Value;
                    cm.Parameters.Add(tarih);


                    cm.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Sınıf Eklendi.");
                    db.kapat();
                }
                catch (Exception ex)
                {
                    int a;
                    if (!int.TryParse(txtkapasite.Text, out a))
                    {
                        MessageBox.Show("Lütfen kapasite satırına sayı değeri giriniz !");
                    }
                    else
                    { MessageBox.Show("Ekleme işlemi başarısız !" + ex); }
                }
                txtad.Text = "";
                txtaciklama.Text = "";
                txtkapasite.Text = "";

            }
        }
    }
}
