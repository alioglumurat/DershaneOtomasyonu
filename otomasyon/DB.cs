﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;

namespace otomasyon
{
    class DB
    {
        private String dataSource = "OMER-PC";
        private String database = "dershaneERP";
        private String userId = "sa";
        private String pass = "54321";

        SqlConnection con;


        public DB()
        {
            try
            {
                con = new SqlConnection("Data Source="+dataSource+"; Database="+database+"; Persist Security Info=False; User ID="+userId+"; Password="+pass+"");
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

        public SqlDataReader dersGetir()
        {
            SqlDataReader oku = null;

            try
            {
                SqlCommand islem = new SqlCommand("dersGetir",baglan());
                oku = islem.ExecuteReader();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ders getirme hatası"+ex);
            }

            return oku;
        }

        public SqlCommand dersSaatiGetir(String kelime)
        {
            
            SqlCommand calis=null;
            try
            {
                calis = new SqlCommand("SELECT dbo.toplamDersSaati(@sorgu)", baglan());
                //calis.CommandType = CommandType.StoredProcedure;
                SqlParameter ax = new SqlParameter("@sorgu", SqlDbType.VarChar, 50);
                ax.Direction = ParameterDirection.Input;
                ax.Value = kelime;
                calis.Parameters.Add(ax);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders saati getirme hatası"+ex);
            }
            return calis;
     
        }

        public int fiyatGetir(Dictionary<int,String> dic)
        {
            try
            {
                for (int i = 0; i < dic.Values.Count; i++)
                {
                    String kelime = (String)dic[i];
                    MessageBox.Show(kelime);
                } 

                SqlCommand islem = new SqlCommand("SELECT dbo.fiyatGetir(@dersAd)",baglan());
                SqlParameter ax = new SqlParameter("@dersAd",SqlDbType.VarChar,50);
                ax.Direction = ParameterDirection.Input;
                //ax.Value=
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiyat getirme hatası");

            }
            int a = 9;
            return a;
        }
        public int saatUcreti(String dersAdi)
        {
            int sayi = 0;
            try
            {
                SqlCommand islem = new SqlCommand("SELECT dbo.saatUcreti(@d_adi)", baglan());
                SqlParameter ax = new SqlParameter("@d_adi", SqlDbType.VarChar, 50);
                ax.Direction = ParameterDirection.Input;
                ax.Value = dersAdi;
                islem.Parameters.Add(ax);
                sayi =Convert.ToInt32(islem.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ders saat ücreti getirme hatası");
            }
            return sayi;
        }

    }
}
