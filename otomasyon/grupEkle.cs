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
    public partial class grupEkle : Form
    {
        public grupEkle()
        {
            InitializeComponent();
        }

        DB db = new DB();

        ArrayList saatList = new ArrayList();
        ArrayList secilenSaatlerList = new ArrayList();
        ArrayList ogretmenler = new ArrayList();
        ArrayList tumSaat = new ArrayList();
        ArrayList diziLs = new ArrayList();
        ArrayList isimleriTopla = new ArrayList();
        ArrayList arananOgretmen = new ArrayList();

        String[] oncedenAtanmisSaatler;
        String[] ogrenciIndisSplit;
        String[] saatIndisSplit;

        String secilenSaatlerinIdDegerleri;
        String ogrenciIdleri = "";
        String virgul = "";
        String saatlerId = "";
        String gun;
        String saatAdBaslangicBitis = "";
        String gelenOgretmenAdi = "";
        String dersAdi = "";
        String ogretmenAdi = "";
        String sinifAdi = "";

        int indexOgretmen = -1;

        ArrayList ogrenciIndex = new ArrayList();
        ArrayList saatIndex = new ArrayList();

        struct ogretmenverileri
        {
            public int Id { get; set; }
            public String OgretmenAdi { get; set; }
            public String OgretmenTc { get; set; }

        }

        /////////////////////////////- Load İşlemleri-/////////////////////
        //////////////////////////////////////////////////////////////////


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbDoldur("ogretmenAdi", cmbOgretmenAdi);
            cmbDoldur("sinifAdi", cmbSinifAdi);
            dersAdiDoldur();
            ogretmenVerileri();
            ogrenciDoldur();
            grupListele();

        }

        /////////////////////////////- Ogretmen İşlemleri-/////////////////////
        //////////////////////////////////////////////////////////////////////
        public void ogretmenVerileri()
        {

            try
            {
                SqlCommand cm = new SqlCommand("ogretmenAdi", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cm.ExecuteReader();

                while (rd.Read())
                {
                    ogretmenverileri ogr = new ogretmenverileri();

                    ogr.Id = Convert.ToInt32(rd["id"]);
                    ogr.OgretmenAdi = rd["adi"].ToString();
                    ogr.OgretmenTc = rd["tc"].ToString();

                    ogretmenler.Add(ogr);
                }

                DataTable dt = new DataTable();
                dt.Load(rd);

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ogretmen verilerine ulaşırken bir hata oluştu" + ex);
            }

            db.kapat();
        }

        private void cmbOgretmenAdi_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            arananOgretmen.Clear();

            gelenOgretmenAdi = cmbOgretmenAdi.Text;

            for (int i = 0; i < ogretmenler.Count; i++)
            {

                ogretmenverileri or = (ogretmenverileri)ogretmenler[i];
                if (or.OgretmenAdi == gelenOgretmenAdi)
                {
                    arananOgretmen.Add(or);

                }

            }
            dataGridView1.DataSource = arananOgretmen;
        }

        /////////////////////////////- Saat İşlemleri-////////////////////////
        //////////////////////////////////////////////////////////////////////

        public void tumSaatleriGetir()
        {
            tumSaat.Clear();
            try
            {
                SqlCommand cm = new SqlCommand("saatCek", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cm.ExecuteReader();

                while (rd.Read())
                {
                    tumSaat.Add(rd["id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("saat getirme hatası" + ex);
            }

            db.kapat();
        }


        public void sinifinSecilenSaatleri()
        {
            diziLs.Clear();
            secilenSaatlerinIdDegerleri = "";
            oncedenAtanmisSaatler = null;
            try
            {
                SqlCommand cm = new SqlCommand("saatIdleriGetir", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter pr = new SqlParameter("@sinifAdi", SqlDbType.VarChar, 500);
                pr.Direction = ParameterDirection.Input;

                pr.Value = cmbSinifAdi.Text;
                cm.Parameters.Add(pr);

                SqlDataReader oku = cm.ExecuteReader();

                while (oku.Read())
                {
                    secilenSaatlerinIdDegerleri += oku["saatlerId"].ToString() + ",";

                }

                if (secilenSaatlerinIdDegerleri != null)
                {
                    oncedenAtanmisSaatler = secilenSaatlerinIdDegerleri.Split(',');
                }
                else
                {
                    oncedenAtanmisSaatler = null;
                }
                if (oncedenAtanmisSaatler == null)
                {

                }
                for (int j = 0; j < oncedenAtanmisSaatler.Length - 1; j++)
                {
                    if (oncedenAtanmisSaatler[j] == "")
                    {
                        diziLs.Add(0);
                    }
                    else
                    {
                        diziLs.Add(Convert.ToInt32(oncedenAtanmisSaatler[j]));
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("saat ekleme hatası" + ex);
            }
            db.kapat();
        }

        public void saatIdDuzenle()
        {
            int i = 0;
            string virgul = "";

            foreach (Object item in chckdListBoxDersSaati.CheckedItems)
            {
                int index = chckdListBoxDersSaati.Items.IndexOf(item);
                secilenSaatlerList.Add(tumSaat[index]);
            }

            foreach (var item in secilenSaatlerList)
            {
                if (i == secilenSaatlerList.Count - 1)
                {
                    virgul = "";
                }
                else
                {
                    virgul = ",";
                }
                saatlerId += item + virgul; i++;
            }


        }

        /////////////////////////////- Ekleme İşlemleri-//////////////////////
        //////////////////////////////////////////////////////////////////////

        private void btnGrupEkle_Click(object sender, EventArgs e)
        {
            ogrenciIdDuzenle();
            saatIdDuzenle();


            int ogretmenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            try
            {
                SqlCommand cm = new SqlCommand("grupOlustur", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;


                SqlParameter grupAdi = new SqlParameter("@grupAdi", SqlDbType.VarChar, 50);
                SqlParameter ogrtmnId = new SqlParameter("@ogretmenId", SqlDbType.Int);
                SqlParameter personelId = new SqlParameter("@personelId", SqlDbType.Int);
                SqlParameter sinifAdi = new SqlParameter("@sinifAdi", SqlDbType.VarChar, 500);
                SqlParameter dersAdi = new SqlParameter("@dersAdi", SqlDbType.VarChar, 500);
                SqlParameter baslangicTarihi = new SqlParameter("@baslangicTarihi", SqlDbType.DateTime);
                SqlParameter bitisTarihi = new SqlParameter("@bitisTarihi", SqlDbType.DateTime);
                SqlParameter ogrncIdleri = new SqlParameter("@ogrenciIdleri", SqlDbType.VarChar, 50);
                SqlParameter stIdleri = new SqlParameter("@saatIdleri", SqlDbType.VarChar, 50);


                grupAdi.Direction = ParameterDirection.Input;
                ogrtmnId.Direction = ParameterDirection.Input;
                personelId.Direction = ParameterDirection.Input;
                sinifAdi.Direction = ParameterDirection.Input;
                ogrncIdleri.Direction = ParameterDirection.Input;
                dersAdi.Direction = ParameterDirection.Input;
                stIdleri.Direction = ParameterDirection.Input;
                baslangicTarihi.Direction = ParameterDirection.Input;
                bitisTarihi.Direction = ParameterDirection.Input;

                grupAdi.Value = txtGrupAdi.Text;
                ogrtmnId.Value = ogretmenId;
                personelId.Value = 1;
                sinifAdi.Value = cmbSinifAdi.SelectedItem;
                ogrncIdleri.Value = ogrenciIdleri;
                dersAdi.Value = cmbDersAdi.SelectedItem;
                stIdleri.Value = saatlerId;
                baslangicTarihi.Value = timePickerGrupBaslangic.Value;
                bitisTarihi.Value = timePickerGrupBaslangic.Value;

                cm.Parameters.Add(grupAdi);
                cm.Parameters.Add(ogrtmnId);
                cm.Parameters.Add(personelId);
                cm.Parameters.Add(sinifAdi);
                cm.Parameters.Add(ogrncIdleri);
                cm.Parameters.Add(dersAdi);
                cm.Parameters.Add(stIdleri);
                cm.Parameters.Add(baslangicTarihi);
                cm.Parameters.Add(bitisTarihi);

                cm.ExecuteNonQuery();

                db.kapat();
                grupListele();
                MessageBox.Show("Grup Başarı ile Eklendi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata  : " + ex);
            }
        }

        /////////////////////////////- ComboBox Doldurma İşlemleri-/////////////////////
        ///////////////////////////////////////////////////////////////////////////////

        public void cmbDoldur(String procedurAdi, ComboBox cmbAdi)
        {

            try
            {
                SqlCommand cm = new SqlCommand(procedurAdi, db.baglan());
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    cmbAdi.Items.Add(rd["adi"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata  : " + ex);
            }

            db.kapat();
        }

        public void dersAdiDoldur()
        {
            try
            {
                SqlCommand cm = new SqlCommand("dersAdi", db.baglan());
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    cmbDersAdi.Items.Add(rd["dersAdi"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata  : " + ex);
            }

            db.kapat();
        }
        public void ogrenciDoldur()
        {
            try
            {
                SqlCommand cm = new SqlCommand("ogrenciBilgileriGetir", db.baglan());
                SqlDataReader rd = cm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);

                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata  : " + ex);
            }

            db.kapat();
        }

        /////////////////////////////- Ogrenci İşlemleri-/////////////////////
        //////////////////////////////////////////////////////////////////////

        public void ogrenciIdDuzenle()
        {
            for (int i = 0; i < dataGridView2.SelectedRows.Count; i++)
            {

                if (i == dataGridView2.SelectedRows.Count - 1)
                {
                    virgul = "";
                }
                else
                {
                    virgul = ",";
                }

                ogrenciIdleri += dataGridView2.SelectedRows[i].Cells[0].Value.ToString() + virgul;
            }
        }

        /////////////////////////////- Sınıf İşlemleri-///////////////////////
        //////////////////////////////////////////////////////////////////////

        private void cmbSinifAdi_TextChanged(object sender, EventArgs e)
        {

            chckdListBoxDersSaati.Items.Clear();

            tumSaatleriGetir();
            sinifinSecilenSaatleri();

            foreach (var item2 in diziLs)
            {
                tumSaat.Remove(item2);
            }

            if (tumSaat.Count == 0) MessageBox.Show("bu sınıf için tüm saatler dolu başka bir sınıf seçiniz");

            foreach (var item in tumSaat)
            {

                db.kapat();

                SqlCommand cm = new SqlCommand("saatCek", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    saatAdBaslangicBitis = "";
                    if (tumSaat.Contains(rd["id"]))
                    {
                        switch (rd["gun"].ToString())
                        {
                            case "1": gun = "Pazartesi "; break;
                            case "2": gun = "Salı          "; break;
                            case "3": gun = "Çarşamba"; break;
                            case "4": gun = "Perşembe"; break;
                            case "5": gun = "Cuma       "; break;
                            case "6": gun = "Cumartesi "; break;
                            case "7": gun = "Pazar        "; break;
                        }
                        saatAdBaslangicBitis += gun.ToString() + rd["baslamaSaati"].ToString() + "-" + rd["bitisSaati"].ToString();

                        isimleriTopla.Add(saatAdBaslangicBitis);
                    }

                }
            }
            int k = 0;
            foreach (var item in tumSaat)
            {
                chckdListBoxDersSaati.Items.Add(isimleriTopla[k]);
                k++;
            }
            db.kapat();
        }

        /////////////////////////////- Listeleme İşlemleri-///////////////////////
        /////////////////////////////////////////////////////////////////////////

        public void grupListele()
        {

            try
            {
                SqlCommand cm = new SqlCommand("grupListele", db.baglan());
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

        public void grupSil()
        {
            try
            {
                SqlCommand cm = new SqlCommand("grupSil", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter grupId = new SqlParameter("@grupId", SqlDbType.VarChar, 50);
                grupId.Direction = ParameterDirection.Input;
                grupId.Value = dataGridView3.CurrentRow.Cells[0].Value;
                cm.Parameters.Add(grupId);

                cm.ExecuteNonQuery();
                MessageBox.Show("Grup Silindi");
                db.kapat();
                grupListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata" + ex);
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            grupSil();
        }
        /////////////////////////////- Guncelleme İşlemleri-///////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void grupGuncelle()
        {

            txtGrupAdi.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            cmbDersAdi.Text = dersAdiBul();
            cmbOgretmenAdi.Text = ogretmenAdiBul();
            cmbSinifAdi.Text = sinifAdiBul();
            deneme();

            dataGridView1.Rows[indexOgretmen].Selected = true;
            foreach (int item in ogrenciIndex)
            {
                dataGridView2.Rows[item].Selected = true;
            }


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            grupGuncelle();
        }

        public String dersAdiBul()
        {
            SqlCommand cm = new SqlCommand("dersAdiBul", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter grupId = new SqlParameter("@dersId", SqlDbType.Int);
            grupId.Direction = ParameterDirection.Input;
            grupId.Value = Convert.ToInt32(dataGridView3.CurrentRow.Cells[6].Value);
            cm.Parameters.Add(grupId);

            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                dersAdi = rd["dersAdi"].ToString();
            }

            db.kapat();
            return dersAdi;

        }
        public String ogretmenAdiBul()
        {
            SqlCommand cm = new SqlCommand("ogretmenAdiBul", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter ogretmenId = new SqlParameter("@ogretmenId", SqlDbType.Int);
            ogretmenId.Direction = ParameterDirection.Input;
            ogretmenId.Value = Convert.ToInt32(dataGridView3.CurrentRow.Cells[2].Value);
            cm.Parameters.Add(ogretmenId);

            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                ogretmenAdi = rd["adi"].ToString();
            }

            db.kapat();
            return ogretmenAdi;

        }
        public String sinifAdiBul()
        {
            SqlCommand cm = new SqlCommand("sinifAdiBul", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter sinifId = new SqlParameter("@sinifId", SqlDbType.Int);
            sinifId.Direction = ParameterDirection.Input;
            sinifId.Value = Convert.ToInt32(dataGridView3.CurrentRow.Cells[4].Value);
            cm.Parameters.Add(sinifId);

            SqlDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                sinifAdi = rd["adi"].ToString();
            }

            db.kapat();
            return sinifAdi;

        }

        public void deneme()
        {

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(dataGridView3.CurrentRow.Cells[2].Value.ToString()))
                {

                    indexOgretmen = Convert.ToInt32(dataGridView1.Rows[i].Index);

                }

            }

            ogrenciIndisSplit = dataGridView3.CurrentRow.Cells[5].Value.ToString().Split(',');
            for (int j = 0; j < ogrenciIndisSplit.Length; j++)
            {
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {

                    if (dataGridView2.Rows[i].Cells[0].Value.ToString() == ogrenciIndisSplit[j])
                    {

                        ogrenciIndex.Add(dataGridView2.Rows[i].Index);

                    }

                }
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
