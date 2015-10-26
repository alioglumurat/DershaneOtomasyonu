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
    public partial class SınıfForm : Form
    {
        DB db = new DB();
        public SınıfForm()
        {
            InitializeComponent();
        }

        private void btnsekleg_Click(object sender, EventArgs e)
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

                dataGridView1.DataSource = db.gridData("siniflar");
                db.kapat();

            }
        }

        private void btnsguncel_Click(object sender, EventArgs e)
        {
           
            try
            {
               
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                String adi = Convert.ToString (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["adi"].Value);
                int kapasite = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["kapasite"].Value);
                String aciklama = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["aciklama"].Value);
                DateTime tarih =Convert.ToDateTime(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["tarih"].Value);
                DialogResult sonuc;
                sonuc = MessageBox.Show(" Seçilen Satırda Değişiklik Yapmak İstediğinizden Eminmisiniz?", "Değiştir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (sonuc == DialogResult.Yes)

                {
                    SqlCommand cm = new SqlCommand("sinifguncelle", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter c1 = new SqlParameter("@id", SqlDbType.Int);
                    c1.Direction = ParameterDirection.Input;
                    c1.Value = id;
                    cm.Parameters.Add(c1);

                    SqlParameter c2 = new SqlParameter("@adi", SqlDbType.VarChar, 500);
                    c2.Direction = ParameterDirection.Input;
                    c2.Value = adi;
                    cm.Parameters.Add(c2);

                    SqlParameter c3 = new SqlParameter("@kapasite", SqlDbType.Int);
                    c3.Direction = ParameterDirection.Input;
                    c3.Value = kapasite;
                    cm.Parameters.Add(c3);

                    SqlParameter c4 = new SqlParameter("@aciklama", SqlDbType.VarChar, 500);
                    c4.Direction = ParameterDirection.Input;
                    c4.Value = aciklama;
                    cm.Parameters.Add(c4);

                    SqlParameter c5 = new SqlParameter("@tarih", SqlDbType.DateTime);
                    c5.Direction = ParameterDirection.Input;
                    c5.Value = dtp.Value;
                    cm.Parameters.Add(c5);


                    SqlDataAdapter sqld = new SqlDataAdapter(cm);
                    DataSet ds = new DataSet();
                    sqld.Fill(ds);

                    MessageBox.Show("güncelleme işlemi tamamlandı");
                }

                    dataGridView1.DataSource = db.gridData("siniflar");

                    db.kapat();
               
            }
            catch
            {
                MessageBox.Show("güncelleme başarısız");
            }
        }

        private void SınıfForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.gridData("siniflar");
            db.kapat();
          
        }

        private void btnssil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                DialogResult sonuc;
                sonuc = MessageBox.Show(" Seçilen Satırı Silmek İstediğinizden Eminmisiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (sonuc == DialogResult.Yes)
                {
                    SqlCommand cm = new SqlCommand("sinifsil", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter c1 = new SqlParameter("@sid", SqlDbType.Int);
                    c1.Direction = ParameterDirection.Input;
                    c1.Value = id;
                    cm.Parameters.Add(c1);
                    cm.ExecuteNonQuery();


                    MessageBox.Show("silme işlemi tamamlandı");
                }
                    dataGridView1.DataSource = db.gridData("siniflar");

                    db.kapat();

            }
            catch
            {
                MessageBox.Show("silme başarısız");
            }
        }
    }
}
