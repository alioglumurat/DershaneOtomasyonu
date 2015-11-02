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
    public partial class DevamCizelgesi : Form
    {
        DB db = new DB();
        public DevamCizelgesi()
        {
            InitializeComponent();
        }


        String[] gelenOgrenciIdleri;
        String[] gelenSaatIdleri2;
        String[] ogrenciIndisSplit;
        ArrayList gelenOgIdArray = new ArrayList();
        ArrayList gelenSaIdArray = new ArrayList();
        ArrayList ogrenciIndex = new ArrayList();
        String ogrenciId;
        String saatId;
        int indexsaat;

        public void grupDoldur()
        {
            SqlCommand cm = new SqlCommand("grupAdi", db.baglan());
            SqlDataReader rd = cm.ExecuteReader();

            while (rd.Read())
            {
                comboBox1.Items.Add(rd["grupAdi"].ToString());

            }

            db.kapat();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            grupDoldur();
            devamsizlikListele();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            saatListele();
            ogrenciListele();
        }

        public void ogrenciIdleriSec()
        {
            ogrenciId = "";
            gelenOgIdArray.Clear();
            SqlCommand cm = new SqlCommand("grupOgrenciveSaatIdGetir", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter grupAdi = new SqlParameter("@grupAdi", SqlDbType.VarChar, 50);

            grupAdi.Direction = ParameterDirection.Input;

            grupAdi.Value = comboBox1.SelectedItem;

            cm.Parameters.Add(grupAdi);

            SqlDataReader rd = cm.ExecuteReader();

            while (rd.Read())
            {
                ogrenciId += rd["ogrenciId"].ToString();

            }


            gelenOgrenciIdleri = ogrenciId.Split(',');


            foreach (var item in gelenOgrenciIdleri)
            {
                gelenOgIdArray.Add(Convert.ToInt32(item));
            }

            db.kapat();
        }
        public void saatIdleriSec()
        {
            gelenSaIdArray.Clear();
            SqlCommand cm = new SqlCommand("grupOgrenciveSaatIdGetir", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter grupAdi = new SqlParameter("@grupAdi", SqlDbType.VarChar, 50);

            grupAdi.Direction = ParameterDirection.Input;

            grupAdi.Value = comboBox1.SelectedItem;

            cm.Parameters.Add(grupAdi);

            SqlDataReader rd = cm.ExecuteReader();

            while (rd.Read())
            {
                saatId = rd["saatlerId"].ToString();
            }

            gelenSaatIdleri2 = saatId.Split(',');

            foreach (var item in gelenSaatIdleri2)
            {
                gelenSaIdArray.Add(item);
            }

            db.kapat();
        }

        public void ogrenciListele()
        {

            ogrenciIdleriSec();
            dataGridView1.DataSource = null;

            DataTable dt = new DataTable();
            foreach (var item in gelenOgIdArray)
            {
                SqlCommand cm2 = new SqlCommand("grupOgrenciGetir", db.baglan());
                cm2.CommandType = CommandType.StoredProcedure;

                SqlParameter grupAdi = new SqlParameter("@ogrenciId", SqlDbType.Int);
                grupAdi.Direction = ParameterDirection.Input;
                grupAdi.Value = item;
                cm2.Parameters.Add(grupAdi);

                SqlDataReader rd = cm2.ExecuteReader();

                dt.Load(rd);

                db.kapat();

            }
            dataGridView1.DataSource = dt;

        }
        public void saatListele()
        {
            saatIdleriSec();


            DataTable dt = new DataTable();
            foreach (var item in gelenSaIdArray)
            {
                try
                {
                    SqlCommand cm2 = new SqlCommand("grupSaatGetir", db.baglan());
                    cm2.CommandType = CommandType.StoredProcedure;

                    SqlParameter saatId = new SqlParameter("@saatId", SqlDbType.Int);
                    saatId.Direction = ParameterDirection.Input;
                    saatId.Value = item;
                    cm2.Parameters.Add(saatId);

                    SqlDataReader rd = cm2.ExecuteReader();

                    dt.Load(rd);

                    db.kapat();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("bu grupta ogrenci veya saat yok");
                }


            }
            dataGridView2.DataSource = dt;

        }

        String virgul;
        String ogrenciIdleri;
        public String ogrenciIdDuzenle()
        {
            ogrenciIdleri = "";
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {

                if (i == dataGridView1.SelectedRows.Count - 1)
                {
                    virgul = "";
                }
                else
                {
                    virgul = ",";
                }

                ogrenciIdleri += dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + virgul;

            }
            MessageBox.Show(ogrenciIdleri);
            return ogrenciIdleri;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cm = new SqlCommand("devamsizlik", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter grupAdi = new SqlParameter("@grupAdi", SqlDbType.VarChar, 50);
                SqlParameter saatId = new SqlParameter("@saatId", SqlDbType.Int);
                SqlParameter ogrenciId = new SqlParameter("@ogrenciId", SqlDbType.VarChar, 50);
                SqlParameter tarih = new SqlParameter("@tarih", SqlDbType.DateTime);

                grupAdi.Direction = ParameterDirection.Input;
                ogrenciId.Direction = ParameterDirection.Input;
                tarih.Direction = ParameterDirection.Input;
                saatId.Direction = ParameterDirection.Input;

                grupAdi.Value = comboBox1.Text;
                ogrenciId.Value = ogrenciIdDuzenle();
                tarih.Value = dateTimePicker1.Value;
                saatId.Value = dataGridView2.CurrentRow.Cells[0].Value;

                cm.Parameters.Add(grupAdi);
                cm.Parameters.Add(ogrenciId);
                cm.Parameters.Add(tarih);
                cm.Parameters.Add(saatId);

                cm.ExecuteNonQuery();

                db.kapat();
                devamsizlikListele();
                MessageBox.Show("Başarıyla Eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

        }

        public void devamsizlikListele()
        {
            try
            {
                SqlCommand cm = new SqlCommand("devamsizlikListele", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlDataReader rd = cm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView3.DataSource = dt;
                db.kapat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

        }
        public void devamsizlikSil()
        {
            try
            {
                SqlCommand cm = new SqlCommand("devamsizlikSil", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter devamsizlikId = new SqlParameter("@devamsizlikId", SqlDbType.VarChar, 50);
                devamsizlikId.Direction = ParameterDirection.Input;
                devamsizlikId.Value = dataGridView3.CurrentRow.Cells[0].Value;
                cm.Parameters.Add(devamsizlikId);

                cm.ExecuteNonQuery();
                MessageBox.Show("silindi");
                db.kapat();
                devamsizlikListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            devamsizlikSil();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("devamsizlikGuncelle", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter data = new SqlParameter("@grupAdi", SqlDbType.VarChar, 50);
            data.Direction = ParameterDirection.Input;
            data.Value = comboBox1.Text;
            cm.Parameters.Add(data);

            SqlParameter devamsizlikId = new SqlParameter("@devamsizlikId", SqlDbType.Int);
            devamsizlikId.Direction = ParameterDirection.Input;
            devamsizlikId.Value = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            cm.Parameters.Add(devamsizlikId);

            SqlParameter ogrenciId = new SqlParameter("@ogrenciId", SqlDbType.VarChar, 50);
            ogrenciId.Direction = ParameterDirection.Input;

            ogrenciId.Value = ogrenciIdDuzenle();
            cm.Parameters.Add(ogrenciId);

            SqlParameter saatId = new SqlParameter("@saatId", SqlDbType.Int);
            saatId.Direction = ParameterDirection.Input;
            saatId.Value = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cm.Parameters.Add(saatId);


            SqlParameter tarih = new SqlParameter("@tarih", SqlDbType.DateTime);
            tarih.Direction = ParameterDirection.Input;
            tarih.Value = dateTimePicker1.Value;
            cm.Parameters.Add(tarih);

            cm.ExecuteNonQuery();

            db.kapat();
            devamsizlikListele();
            MessageBox.Show("devamsizlik Başarı ile Guncellendi");

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = " ";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;


            comboBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            deneme();
            dataGridView2.Rows[indexsaat].Selected = true;
            foreach (int item in ogrenciIndex)
            {
                dataGridView1.Rows[item].Selected = true;
            }
        }


        public void deneme()
        {
            ogrenciIndex.Clear();

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {

                if (dataGridView2.Rows[i].Cells[0].Value.ToString().Equals(dataGridView3.CurrentRow.Cells[3].Value.ToString()))
                {

                    indexsaat = Convert.ToInt32(dataGridView2.Rows[i].Index);

                }

            }

            ogrenciIndisSplit = dataGridView3.CurrentRow.Cells[2].Value.ToString().Split(',');
            for (int j = 0; j < ogrenciIndisSplit.Length; j++)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == ogrenciIndisSplit[j])
                    {

                        ogrenciIndex.Add(dataGridView1.Rows[i].Index);

                    }

                }
            }

        }
    }
}

