using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// kütüphaneler
using System.Data;
using System.Data.SqlClient;

namespace SaatEkle
{

    class DB
    {
        // bağlantı için gerekli datalar alınıyor
        private String dbName = "dershaneERP";
        private String userName = "sa";
        private String pass = "12345";
        private String dataSource = "WISSEN302";

        // sqlConnection
        private SqlConnection baglanti = null;



        public DB()
        {
            try
            {
                baglanti = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=" + dbName + "; Persist Security Info=False;User ID=" + userName + ";Password=" + pass + ";");
            }
            catch (Exception ex)
            {
                // 
                MessageBox.Show("Bağlantı Hatası : " + ex);
            }
        }




       // public DB(String dbName, String userName, String pass, String dataSource) {
       //     try
       //     {
       //         baglanti = new SqlConnection("Data Source=" + dataSource + ";Initial Catalog=" + dbName + "; Persist Security Info=False;User ID=" + userName + ";Password=" + pass + ";");
       //     }
       //     catch (Exception ex)
       //     {
       //         MessageBox.Show("Bağlantı Hatası : " + ex);
       //     } 
       // }


        // bağlantı fonksiyonu oluşturuluyor - Aç
        public SqlConnection baglan() {
            try
            {
                if (baglanti.State == ConnectionState.Closed) {
                    baglanti.Open();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Bağlantı Hatası : " + ex);
            }
            return baglanti;
        }




        // bağlantı kapat fonksiyonu
        public void kapat() {
            try
            {
                if (baglanti.State == ConnectionState.Open) {
                    baglanti.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Bağlantı Kapatma Hatası : " + ex);
            }
        }
        public DataTable gridData(String tableName)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cm = new SqlCommand("select *from " + tableName + "", baglan());
                SqlDataReader rd = cm.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        

    }
}

