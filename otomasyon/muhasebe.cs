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

    public partial class muhasebe : Form
    {
        DB db = new DB();
        public muhasebe()
        {
            InitializeComponent();
        }
        Dictionary<int, String> uye = new Dictionary<int, String>();
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cm = new SqlCommand("odemeKontroll", db.baglan());
                SqlDataReader rd = cm.ExecuteReader();
                dt.Load(rd);
                dataGridView2.DataSource = dt;
                MessageBox.Show("Ödeme için Gerekenleri Ara !");

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata : " + ex);
            }
            db.kapat();

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        ArrayList ar = new ArrayList();

        private void button2_Click(object sender, EventArgs e)
        {




            dataGridView1.DataSource = null;
            try
            {


                SqlCommand cm = new SqlCommand("vadeal", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                a1.Direction = ParameterDirection.Input;

                a1.Value = textBox4.Text;

                cm.Parameters.Add(a1);

                SqlDataReader rd = cm.ExecuteReader();
                rd.Read();

                double para = Convert.ToDouble(rd["indirimliFiyat"]); //bölme işlemi olduğundan dolayı double kullanıldı
                double vade = Convert.ToDouble(rd["vadeSayisi"]);
                DateTime bugun = Convert.ToDateTime(rd["tarih"]); ;
                MessageBox.Show("ajysha" + bugun);
                double odenecek = para / vade;

                DateTime odemegunu;

                db.kapat();
                for (int i = 0; i < vade; i++)
                {
                    odemeTaksit ns = new odemeTaksit();
                    ns.Taksitno = Convert.ToString(i + 1);
                    ns.TaksitTutari = Convert.ToString(odenecek);
                    odemegunu = bugun.AddMonths(i + 1); // taksitlendirme bir sonraki ay başlıyor... Ör: Ocak'da satın alınan ürün taksidi Şubat ayından itibaren başlamakta 
                    ns.OdemeGunu = odemegunu;
                    if (odemegunu.DayOfWeek.ToString() == "Saturday") // Ödeme günü Cumartesi 'ne denk gelirse bir önceki günü göster ödemeyi yaptır
                    {
                        odemegunu = odemegunu.AddDays(-1);
                        ns.OdemeGunu = odemegunu;
                    }
                    else if (odemegunu.DayOfWeek.ToString() == "Sunday") // Ödeme günü Pazar'a denk gelirse bir sonraki günü göster ödemeyi yaptır
                    {
                        odemegunu = odemegunu.AddDays(1);
                        ns.OdemeGunu = odemegunu;
                    }

                    //ar.Add(odemegunu.ToLongDateString());
                    ar.Add(ns);

                }


                SqlCommand cmm = new SqlCommand("");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Taksitlendirme Hatası : " + ex);
            }

            dataGridView1.DataSource = null;
            try
            {
                SqlCommand cm = new SqlCommand("gelirgetir", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                a1.Direction = ParameterDirection.Input;

                a1.Value = textBox4.Text;

                cm.Parameters.Add(a1);
                SqlParameter a2 = new SqlParameter("@satisid", SqlDbType.Int);

                a2.Direction = ParameterDirection.Input;

                a2.Value = textBox1.Text;

                cm.Parameters.Add(a2);

                SqlDataReader rd = cm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {

                MessageBox.Show("Dataagetir hatası : " + ex);
            }

        }

        private void muhasebe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cm = new SqlCommand("taksitebol", db.baglan());
                SqlDataReader rd = cm.ExecuteReader();
                MessageBox.Show("taksitlendi.");


            }
            catch (Exception ex)
            {
                MessageBox.Show("hata : " + ex);
            }
            db.kapat();

            SqlCommand cmm = new SqlCommand("vadeal", db.baglan());
            cmm.CommandType = CommandType.StoredProcedure;
            SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

            a1.Direction = ParameterDirection.Input;

            a1.Value = textBox4.Text;

            cmm.Parameters.Add(a1);

            SqlDataReader rdd = cmm.ExecuteReader();
            rdd.Read();

            double para = Convert.ToDouble(rdd["indirimliFiyat"]); //bölme işlemi olduğundan dolayı double kullanıldı
            double vade = Convert.ToDouble(rdd["vadeSayisi"]);
            DateTime bugun = Convert.ToDateTime(rdd["tarih"]);
            db.kapat();
            DateTime odemegunu;


            for (int i = 0; i < vade; i++)
            {
                odemeTaksit ns = new odemeTaksit();


                odemegunu = bugun.AddMonths(i + 1); // taksitlendirme bir sonraki ay başlıyor... Ör: Ocak'da satın alınan ürün taksidi Şubat ayından itibaren başlamakta 

                if (odemegunu.DayOfWeek.ToString() == "Saturday") // Ödeme günü Cumartesi 'ne denk gelirse bir önceki günü göster ödemeyi yaptır
                {
                    odemegunu = odemegunu.AddDays(-1);
                    ns.OdemeGunu = odemegunu;
                }
                else if (odemegunu.DayOfWeek.ToString() == "Sunday") // Ödeme günü Pazar'a denk gelirse bir sonraki günü göster ödemeyi yaptır
                {
                    odemegunu = odemegunu.AddDays(1);
                    ns.OdemeGunu = odemegunu;
                }

            }
        }
    }
}
