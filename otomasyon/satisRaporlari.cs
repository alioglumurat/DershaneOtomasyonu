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
    public partial class satisRaporlari : Form
    {
        public satisRaporlari()
        {
            InitializeComponent();
        }
        DB db = new DB();

        private void satisRaporlari_Load(object sender, EventArgs e)
        {
            SqlDataReader oku = calisanListele();
           
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["bilgi"].ToString());
            }
            db.kapat();
        }

        public SqlDataReader calisanListele()
        {
            SqlDataReader oku=null;
            try
            {
                SqlCommand liste = new SqlCommand("calisanGetir", db.baglan());
                liste.CommandType = CommandType.StoredProcedure;
                oku = liste.ExecuteReader();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çalışan listeleme hatası");

            }
            return oku;
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        int sonuc = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) sonuc = 0;
            if (radioButton2.Checked == true) sonuc = 1;
            if (radioButton3.Checked == true) sonuc = 2;

            SqlCommand islem = new SqlCommand("rapor",db.baglan());
            islem.CommandType = CommandType.StoredProcedure;

            SqlParameter ax = new SqlParameter("@personelAdi",SqlDbType.VarChar,50);
            ax.Direction = ParameterDirection.Input;
            ax.Value = comboBox1.Text;

            SqlParameter bx = new SqlParameter("@sonuc",SqlDbType.Int);
            bx.Direction = ParameterDirection.Input;
            bx.Value = sonuc;

            SqlParameter cx = new SqlParameter("@yil",SqlDbType.Int);
            cx.Direction = ParameterDirection.Input;
            cx.Value = Convert.ToInt32(comboBox3.Text);

            SqlParameter dx = new SqlParameter("@ay",SqlDbType.Int);
            dx.Direction = ParameterDirection.Input;
            dx.Value = ay;


            islem.Parameters.Add(ax);
            islem.Parameters.Add(bx);
            islem.Parameters.Add(cx);
            islem.Parameters.Add(dx);

            SqlDataReader oku = islem.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(oku);
            dataGridView1.DataSource = dt;

        }

        int ay = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Equals("Ocak")) ay = 01;
            if (comboBox2.Text.Equals("Şubat")) ay = 02;
            if (comboBox2.Text.Equals("Mart")) ay = 03;
            if (comboBox2.Text.Equals("Nisan")) ay = 04;
            if (comboBox2.Text.Equals("Mayıs")) ay = 05;
            if (comboBox2.Text.Equals("Haziran")) ay = 06;
            if (comboBox2.Text.Equals("Temmuz")) ay = 07;
            if (comboBox2.Text.Equals("Ağustos")) ay = 08;
            if (comboBox2.Text.Equals("Eylül")) ay = 09;
            if (comboBox2.Text.Equals("Ekim")) ay = 10;
            if (comboBox2.Text.Equals("Kasım")) ay = 11;
            if (comboBox2.Text.Equals("Aralık")) ay = 12;
        }
    }
}
