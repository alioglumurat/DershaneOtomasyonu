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
    public partial class muhasebe : Form
    {
        public muhasebe()
        {
            InitializeComponent();
        }
        DB db = new DB();
        private void label6_Click(object sender, EventArgs e)
        {
          
           
        }
        
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("") || textBox5.Text.Equals("") || textBox1.Text.Equals(""))
            {
                MessageBox.Show("öğrenci bilgilerini eksiksiz giriniz!!");
            }
            else
            {

                dataGridView1.DataSource = null;
                SqlCommand cm = new SqlCommand("ogrencibilgigetir", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                a1.Direction = ParameterDirection.Input;

                a1.Value = textBox4.Text;

                cm.Parameters.Add(a1);

                SqlParameter a2 = new SqlParameter("@ad", SqlDbType.VarChar, 50);

                a2.Direction = ParameterDirection.Input;

                a2.Value = textBox5.Text;

                cm.Parameters.Add(a2);

                SqlParameter a3 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                a3.Direction = ParameterDirection.Input;

                a3.Value = textBox1.Text;

                cm.Parameters.Add(a3);
                SqlDataReader dr = cm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                db.kapat();
                //textBox4.Text = "";
                //textBox5.Text = "";
                //textBox1.Text = "";
            }
        }
        
       
        private void button4_Click(object sender, EventArgs e)
        {

            
            int durum = -1;
            SqlCommand cm = new SqlCommand("hesapguncelle", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter a1 = new SqlParameter("@id", SqlDbType.Int);
            a1.Direction = ParameterDirection.Input;
            a1.Value = textBox9.Text;
            cm.Parameters.Add(a1);

            SqlParameter a2 = new SqlParameter("@odenmetarihi", SqlDbType.DateTime);
            a2.Direction = ParameterDirection.Input;
            a2.Value =  dateTimePicker1.Value;
            cm.Parameters.Add(a2);


            SqlParameter a3 = new SqlParameter("@durum", SqlDbType.TinyInt);
            a3.Direction = ParameterDirection.Input;
            a3.Value = textBox7.Text;
            cm.Parameters.Add(a3);

            SqlParameter a4 = new SqlParameter("@aciklama", SqlDbType.VarChar, 500);
            a4.Direction = ParameterDirection.Input;
            a4.Value = textBox10.Text;
            cm.Parameters.Add(a4);

            SqlParameter a5 = new SqlParameter("@tutar", SqlDbType.Money);
            a5.Direction = ParameterDirection.Input;
            a5.Value = textBox8.Text;
            cm.Parameters.Add(a5);

            durum = cm.ExecuteNonQuery();

            if (durum > 0)
            {
                MessageBox.Show("ödeme onayi");
            }
            else
            {
                MessageBox.Show("ödeme hatası!!!");
            }
            db.kapat();
            textBox8.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";

         
            SqlCommand cm1 = new SqlCommand("ogrencibilgigetir", db.baglan());
            cm1.CommandType = CommandType.StoredProcedure;
            SqlParameter a12 = new SqlParameter("@ogrencino", SqlDbType.Int);

            a12.Direction = ParameterDirection.Input;

            a12.Value = textBox4.Text;

            cm1.Parameters.Add(a12);

            SqlParameter a23 = new SqlParameter("@ad", SqlDbType.VarChar, 50);

            a23.Direction = ParameterDirection.Input;

            a23.Value = textBox5.Text;

            cm1.Parameters.Add(a23);

            SqlParameter a32 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

            a32.Direction = ParameterDirection.Input;

            a32.Value = textBox1.Text;

            cm1.Parameters.Add(a32);
            cm1.ExecuteNonQuery();

            db.kapat();
            int durumm = -1;
            SqlCommand cmm = new SqlCommand("guncellenmistablo", db.baglan());
            cmm.CommandType = CommandType.StoredProcedure;

            SqlParameter a123 = new SqlParameter("@ogrencino", SqlDbType.Int);

            a123.Direction = ParameterDirection.Input;

            a123.Value = textBox4.Text;

            cmm.Parameters.Add(a123);

            SqlParameter a234 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

            a234.Direction = ParameterDirection.Input;

            a234.Value = textBox5.Text;

            cmm.Parameters.Add(a234);

            SqlParameter a321 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

            a321.Direction = ParameterDirection.Input;

            a321.Value = textBox1.Text;

            cmm.Parameters.Add(a321);
            durumm = cmm.ExecuteNonQuery();
            SqlDataReader drr = cmm.ExecuteReader();
            DataTable dtt = new DataTable();
            dtt.Load(drr);
            dataGridView1.DataSource = dtt;
            db.kapat();
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PaintEventArgs pea = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
            this.InvokePaint(dataGridView1, pea);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

       

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
           // dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox6.Text.Equals("") || !radioButton1.Checked.Equals(true) && !radioButton2.Checked.Equals(true)&&!radioButton3.Checked.Equals(true))
            {
                MessageBox.Show("Seçiminizi kontrol ediniz");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    int durum = 0;
                    dataGridView2.DataSource = null;
                    SqlCommand cm = new SqlCommand("Pesinatliodeme", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a1.Direction = ParameterDirection.Input;

                    a1.Value = textBox2.Text;

                    cm.Parameters.Add(a1);

                    SqlParameter a2 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a2.Direction = ParameterDirection.Input;

                    a2.Value = textBox3.Text;

                    cm.Parameters.Add(a2);

                    SqlParameter a3 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a3.Direction = ParameterDirection.Input;

                    a3.Value = textBox6.Text;

                    cm.Parameters.Add(a3);
                    durum = cm.ExecuteNonQuery();

                    db.kapat();
                   
                   

                    int dur = 1;
                    SqlCommand cmm = new SqlCommand("pesinatliodemetablo", db.baglan());
                    cmm.CommandType = CommandType.StoredProcedure;

                    SqlParameter a11 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a11.Direction = ParameterDirection.Input;

                    a11.Value = textBox2.Text;

                    cmm.Parameters.Add(a11);

                    SqlParameter a21 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a21.Direction = ParameterDirection.Input;

                    a21.Value = textBox3.Text;

                    cmm.Parameters.Add(a21);

                    SqlParameter a31 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a31.Direction = ParameterDirection.Input;

                    a31.Value = textBox6.Text;

                    cmm.Parameters.Add(a31);

                    dur = cmm.ExecuteNonQuery();
                    SqlDataReader dr = cmm.ExecuteReader();
                    
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;


                   
                   
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                    db.kapat();
                }
                else if (radioButton2.Checked == true)
                {
                    int durum = 0;
                    dataGridView2.DataSource = null;
                    SqlCommand cm = new SqlCommand("Pesinatsiz", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a1.Direction = ParameterDirection.Input;

                    a1.Value = textBox2.Text;

                    cm.Parameters.Add(a1);

                    SqlParameter a2 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a2.Direction = ParameterDirection.Input;

                    a2.Value = textBox3.Text;

                    cm.Parameters.Add(a2);

                    SqlParameter a3 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a3.Direction = ParameterDirection.Input;

                    a3.Value = textBox6.Text;

                    cm.Parameters.Add(a3);
                    durum = cm.ExecuteNonQuery();

                    db.kapat();

                    int durum1 = -1;
                    SqlCommand cmmm = new SqlCommand("pesinatsizodemetablo", db.baglan());
                    cmmm.CommandType = CommandType.StoredProcedure;

                    SqlParameter a11 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a11.Direction = ParameterDirection.Input;

                    a11.Value = textBox2.Text;

                    cmmm.Parameters.Add(a11);

                    SqlParameter a22 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a22.Direction = ParameterDirection.Input;

                    a22.Value = textBox3.Text;

                    cmmm.Parameters.Add(a22);

                    SqlParameter a33 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a33.Direction = ParameterDirection.Input;

                    a33.Value = textBox6.Text;

                    cmmm.Parameters.Add(a33);
                    durum1 = cmmm.ExecuteNonQuery();
                    SqlDataReader dr = cmmm.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                    db.kapat();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";
                  
                }

                else if (radioButton3.Checked == true)
                {
                    int durum = 0;
                    dataGridView2.DataSource = null;
                    SqlCommand cm = new SqlCommand("cekodeme", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter a1 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a1.Direction = ParameterDirection.Input;

                    a1.Value = textBox2.Text;

                    cm.Parameters.Add(a1);

                    SqlParameter a2 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a2.Direction = ParameterDirection.Input;

                    a2.Value = textBox3.Text;

                    cm.Parameters.Add(a2);

                    SqlParameter a3 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a3.Direction = ParameterDirection.Input;

                    a3.Value = textBox6.Text;

                    cm.Parameters.Add(a3);
                    durum = cm.ExecuteNonQuery();

                    db.kapat();

                    int durum1 = -1;
                    SqlCommand cmmm = new SqlCommand("cekodemetablo", db.baglan());
                    cmmm.CommandType = CommandType.StoredProcedure;

                    SqlParameter a11 = new SqlParameter("@ogrencino", SqlDbType.Int);

                    a11.Direction = ParameterDirection.Input;

                    a11.Value = textBox2.Text;

                    cmmm.Parameters.Add(a11);

                    SqlParameter a22 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                    a22.Direction = ParameterDirection.Input;

                    a22.Value = textBox3.Text;

                    cmmm.Parameters.Add(a22);

                    SqlParameter a33 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                    a33.Direction = ParameterDirection.Input;

                    a33.Value = textBox6.Text;

                    cmmm.Parameters.Add(a33);
                    durum1 = cmmm.ExecuteNonQuery();
                    SqlDataReader dr = cmmm.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                    db.kapat();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox6.Text = "";

                }
            }
        }

        

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            label19.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            label20.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ( textBox12.Text.Equals("") || textBox13.Text.Equals(""))
            {
                MessageBox.Show("Ad ve Soyadı Eksiksiz Giriniz!!");
            }
            else
            {
                dataGridView3.DataSource = null;
                SqlCommand cm = new SqlCommand("ogrenciIdBul", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;
                SqlParameter a1 = new SqlParameter("@adi", SqlDbType.VarChar, 50);
                a1.Direction = ParameterDirection.Input;
                a1.Value = textBox12.Text;
                cm.Parameters.Add(a1);

                SqlParameter a2 = new SqlParameter("@soyadi", SqlDbType.VarChar, 50);
                a2.Direction = ParameterDirection.Input;
                a2.Value = textBox13.Text;
                cm.Parameters.Add(a2);

                SqlParameter a3 = new SqlParameter("@tc", SqlDbType.VarChar, 11);
                a3.Direction = ParameterDirection.Input;
                a3.Value = textBox11.Text;
                cm.Parameters.Add(a3);

                SqlDataReader dr = cm.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView3.DataSource = dt;
                    db.kapat();
                  
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";

            }
        }

        private void Yazdır_Click(object sender, EventArgs e)
        {
            printDocument2.Print();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PaintEventArgs pea = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
            this.InvokePaint(dataGridView2, pea);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox21.Text.Equals("") || textBox19.Text.Equals("") || textBox20.Text.Equals(""))
            {
                MessageBox.Show("Lütfen öğrenci Bilgilerini Giriniz");
            }
            else
            {
                int durum1 = -1;
                SqlCommand cmmm = new SqlCommand("cekodemetablo", db.baglan());
                cmmm.CommandType = CommandType.StoredProcedure;

                SqlParameter a11 = new SqlParameter("@ogrencino", SqlDbType.Int);

                a11.Direction = ParameterDirection.Input;

                a11.Value = textBox21.Text;

                cmmm.Parameters.Add(a11);

                SqlParameter a22 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

                a22.Direction = ParameterDirection.Input;

                a22.Value = textBox19.Text;

                cmmm.Parameters.Add(a22);

                SqlParameter a33 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

                a33.Direction = ParameterDirection.Input;

                a33.Value = textBox20.Text;

                cmmm.Parameters.Add(a33);
                durum1 = cmmm.ExecuteNonQuery();
                SqlDataReader dr = cmmm.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView4.DataSource = dt;
                db.kapat();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox18.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            textBox15.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
            textBox16.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            //dateTimePicker2.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            //dateTimePicker3.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int durum = -1;
            SqlCommand cm = new SqlCommand("cekguncelle", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;
            SqlParameter a1 = new SqlParameter("@id", SqlDbType.Int);
            a1.Direction = ParameterDirection.Input;
            a1.Value = textBox16.Text;
            cm.Parameters.Add(a1);

            SqlParameter a2 = new SqlParameter("@cekkabultarih", SqlDbType.DateTime);
            a2.Direction = ParameterDirection.Input;
            a2.Value = dateTimePicker3.Value;
            cm.Parameters.Add(a2);


            SqlParameter a3 = new SqlParameter("cekzamani", SqlDbType.DateTime);
            a3.Direction = ParameterDirection.Input;
            a3.Value = dateTimePicker2.Value;
            cm.Parameters.Add(a3);

            SqlParameter a4 = new SqlParameter("@durum", SqlDbType.TinyInt);
            a4.Direction = ParameterDirection.Input;
            a4.Value = textBox15.Text;
            cm.Parameters.Add(a4);

            SqlParameter a5 = new SqlParameter("@bankabilgisi", SqlDbType.VarChar,500);
            a5.Direction = ParameterDirection.Input;
            a5.Value = textBox18.Text;
            cm.Parameters.Add(a5);

            durum = cm.ExecuteNonQuery();

            if (durum > 0)
            {
                MessageBox.Show("Güncelleme Onayı");
            }
            else
            {
                MessageBox.Show("Güncelleme hatası!!!");
            }
            db.kapat();
            textBox18.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
           

            int durumm = -1;
            SqlCommand cmm = new SqlCommand("cekodemeguncelle", db.baglan());
            cmm.CommandType = CommandType.StoredProcedure;

            SqlParameter a123 = new SqlParameter("@ogrencino", SqlDbType.Int);

            a123.Direction = ParameterDirection.Input;

            a123.Value = textBox21.Text;

            cmm.Parameters.Add(a123);

            SqlParameter a234 = new SqlParameter("@adi", SqlDbType.VarChar, 50);

            a234.Direction = ParameterDirection.Input;

            a234.Value = textBox19.Text;

            cmm.Parameters.Add(a234);

            SqlParameter a321 = new SqlParameter("@soyad", SqlDbType.VarChar, 50);

            a321.Direction = ParameterDirection.Input;

            a321.Value = textBox20.Text;

            cmm.Parameters.Add(a321);
            durumm = cmm.ExecuteNonQuery();
            SqlDataReader drr = cmm.ExecuteReader();
            DataTable dtt = new DataTable();
            dtt.Load(drr);
            dataGridView4.DataSource = dtt;
            db.kapat();
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";


           
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("cekkontrol",db.baglan());
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView4.DataSource = dt;
            db.kapat();
        }

      

       

       

    

     }
        
}
 

