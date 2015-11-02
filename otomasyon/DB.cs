using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace otomasyon
{
    class DB
    {
        private String dataSource = "SEFA";
        private String database = "dershaneERP";
        private String userId = "";
        private String pass = "";

        SqlConnection con;

        public DB()
        {
            try
            {
                con = new SqlConnection("Initial Catalog = dershaneERP; Data Source= SEFA;Integrated Security=True;");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı tanımlama hatası");
              
            }
        }

        public SqlConnection baglan()
        {
            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bağlantı açma hatası");
            }

            return con;
        }

        public void kapat()
        {
            try
            {
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kapatma hatası");
              
            }
        }

        public int userState(String username, String password)
        {
            int state=-1;

            try
            {
                SqlCommand islem = new SqlCommand("users", baglan());
                islem.CommandType = CommandType.StoredProcedure;

                SqlParameter ax = new SqlParameter("@userName",SqlDbType.VarChar,20);                
                ax.Direction = ParameterDirection.Input;
                ax.Value = username;
                islem.Parameters.Add(ax);

                SqlParameter bx = new SqlParameter("@password", SqlDbType.VarChar, 32);
                bx.Direction = ParameterDirection.Input;
                bx.Value = password;
                islem.Parameters.Add(bx);

                SqlDataReader oku = islem.ExecuteReader();

                if (oku.Read())
                {
                    state = Convert.ToInt32(oku["State"]);
                    MessageBox.Show("Sisteme hoşgeldiniz");
                }
                else
                {
                    MessageBox.Show("Hatalı giriş yaptınız");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Giriş kontrol hatası"+ex);
            }
            return state;
        }

        public int userSave(String username, String password, String state)
        {
            int sayi = 0;
            try
            {
                SqlCommand islem = new SqlCommand("userSave",baglan());
                islem.CommandType = CommandType.StoredProcedure;

                SqlParameter ax = new SqlParameter("@username", SqlDbType.VarChar, 20);
                ax.Direction = ParameterDirection.Input;
                ax.Value = username;
                islem.Parameters.Add(ax);

                SqlParameter bx = new SqlParameter("@pass", SqlDbType.VarChar, 32);
                bx.Direction = ParameterDirection.Input;
                bx.Value = password;
                islem.Parameters.Add(bx);

                SqlParameter cx = new SqlParameter("@state", SqlDbType.Char);
                cx.Direction = ParameterDirection.Input;
                cx.Value = state;
                islem.Parameters.Add(cx);

                sayi = islem.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt işleminde hata" + ex);
                sayi = -1;
              
            }
            return sayi;
        }
       
        public string MD5Sifrele(string metin)
        {
            
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

         
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

          
            StringBuilder sb = new StringBuilder();


            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

        
            return sb.ToString();
        }

    }
}
