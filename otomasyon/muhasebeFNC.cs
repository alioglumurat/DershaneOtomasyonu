using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace otomasyon
{
    class fnc
    {
        DB db = new DB();

        public DataTable giderTipiListele()
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand("giderTipiListele", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return dt;
        }

        public int giderTipiEkle(String x)
        {
            int durum = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("giderTipiEkle", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sp = new SqlParameter("@giderAdi", SqlDbType.VarChar, 250);
                sp.Direction = ParameterDirection.Input;
                sp.Value = x;
                cmd.Parameters.Add(sp);

                durum = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                durum = 0;
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return durum;
        }

        public int giderTipiGuncelle(int x, String y)
        {
            int durum = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("giderTipiGuncelle", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sp1 = new SqlParameter("@giderID", SqlDbType.Int);
                sp1.Direction = ParameterDirection.Input;
                sp1.Value = x;
                cmd.Parameters.Add(sp1);

                SqlParameter sp2 = new SqlParameter("@giderAdi", SqlDbType.VarChar, 250);
                sp2.Direction = ParameterDirection.Input;
                sp2.Value = y;
                cmd.Parameters.Add(sp2);

                durum = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                durum = 0;
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return durum;
        }

        public DataTable giderListele()
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand("giderListele", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return dt;
        }

        public int giderEkle(String a, float b, String c, String d)
        {
            int durum = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("giderEkle", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sp1 = new SqlParameter("@giderAdi", SqlDbType.VarChar, 250);
                sp1.Direction = ParameterDirection.Input;
                sp1.Value = a;
                cmd.Parameters.Add(sp1);

                SqlParameter sp2 = new SqlParameter("@tutar", SqlDbType.Money);
                sp2.Direction = ParameterDirection.Input;
                sp2.Value = b;
                cmd.Parameters.Add(sp2);

                SqlParameter sp3 = new SqlParameter("@aciklama", SqlDbType.VarChar, 500);
                sp3.Direction = ParameterDirection.Input;
                sp3.Value = c;
                cmd.Parameters.Add(sp3);

                SqlParameter sp4 = new SqlParameter("@dosya", SqlDbType.VarChar, 1000);
                sp4.Direction = ParameterDirection.Input;
                sp4.Value = d;
                cmd.Parameters.Add(sp4);

                durum = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                durum = 0;
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return durum;    
        }

        public int giderGuncelle(int i, String a, Double b, String c, String d)
        {
            int durum = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("giderGuncelle", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter spi = new SqlParameter("@ID", SqlDbType.Int);
                spi.Direction = ParameterDirection.Input;
                spi.Value = i;
                cmd.Parameters.Add(spi);

                SqlParameter sp1 = new SqlParameter("@gadi", SqlDbType.VarChar,250);
                sp1.Direction = ParameterDirection.Input;
                sp1.Value = a;
                cmd.Parameters.Add(sp1);

                SqlParameter sp2 = new SqlParameter("@tutar", SqlDbType.Money);
                sp2.Direction = ParameterDirection.Input;
                sp2.Value = b;
                cmd.Parameters.Add(sp2);

                SqlParameter sp3 = new SqlParameter("@aciklama", SqlDbType.VarChar, 500);
                sp3.Direction = ParameterDirection.Input;
                sp3.Value = c;
                cmd.Parameters.Add(sp3);

                SqlParameter sp4 = new SqlParameter("@dosya", SqlDbType.VarChar, 1000);
                sp4.Direction = ParameterDirection.Input;
                sp4.Value = d;
                cmd.Parameters.Add(sp4);

                durum = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                durum = 0;
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return durum;
        }

        public int giderSil(int id)
        {
            int durum = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("giderSil", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sp = new SqlParameter("@giderID", SqlDbType.Int);
                sp.Direction = ParameterDirection.Input;
                sp.Value = id;
                cmd.Parameters.Add(sp);

                durum = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                durum = 0;
                MessageBox.Show("HATA : " + ex);
            }
            db.kapat();

            return durum;
        }

        public SqlDataReader giderAra(String x)
        {
            SqlCommand cmd = new SqlCommand("giderArama", db.baglan());
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlParameter sp = new SqlParameter("@kelime", SqlDbType.VarChar, 250);
            sp.Direction = ParameterDirection.Input;
            sp.Value = x;
            cmd.Parameters.Add(sp);

            SqlDataReader dr = cmd.ExecuteReader();
            //db.kapat();

            return dr;
        }

        public SqlDataReader cmbVeriYukle(String x)
        {
            SqlDataReader durum = null;
            try
            {
                SqlCommand cmd = new SqlCommand("giderAdiCombo", db.baglan());
                cmd.CommandType = CommandType.StoredProcedure;
                durum = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                durum = null;
                MessageBox.Show("HATA : " + ex);
            }

            return durum;
        }
    }
}