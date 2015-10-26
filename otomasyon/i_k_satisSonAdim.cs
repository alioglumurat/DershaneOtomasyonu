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
    public partial class i_k_satisSonAdim : Form
    {
        DB db = new DB();
        public i_k_satisSonAdim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            string yol = "";

            yol = openFileDialog1.FileName.ToString();

            textBox1.Text = yol;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                int sonuc;
                SqlCommand cm = new SqlCommand("Select dbo.idGetir(@adId)", db.baglan());
                SqlParameter id = new SqlParameter("@adId", SqlDbType.VarChar, 50);
                id.Direction = ParameterDirection.Input;
                id.Value = comboBox1.Text;
                cm.Parameters.Add(id);
                sonuc = Convert.ToInt32(cm.ExecuteScalar());


                SqlCommand sc = new SqlCommand("satisGuncelle", db.baglan());
                sc.CommandType = CommandType.StoredProcedure;
                SqlParameter a1 = new SqlParameter("@evrakPath", SqlDbType.VarChar, 50);
                SqlParameter a2 = new SqlParameter("@odemeTipi", SqlDbType.TinyInt);
                SqlParameter a3 = new SqlParameter("@vadeSayisi", SqlDbType.TinyInt);
                a1.Direction = ParameterDirection.Input;
                a2.Direction = ParameterDirection.Input;
                a3.Direction = ParameterDirection.Input;
                a1.Value = textBox1.Text;
                a2.Value = sonuc;
                a3.Value = numericUpDown1.Value.ToString();
                sc.Parameters.Add(a1);
                sc.Parameters.Add(a2);
                sc.Parameters.Add(a3);
                sonuc = sc.ExecuteNonQuery();
                MessageBox.Show("Kaydetme İşlemi Başarı ile Tamamlanmıştır!!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kaydetme Hatası!" +ex);
            }

            db.kapat();
        }

        private void i_k_satisSonAdim_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("cmbVrYukle", db.baglan());
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataReader oku = sc.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add(oku[0]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Combobox Veri Yükleme Hatası" + ex);
            }

            db.kapat(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Nakit")
            {
                numericUpDown1.Visible = true;
                label3.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
                label3.Visible = false;
            }

        }
    }
}
