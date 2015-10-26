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

namespace SaatEkle
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        int b;
        int @id;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            b = 1;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Başlama Saati Seçiniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Bitiş Saati Seçiniz");
            }

            else
            {
                try
                {
                    SqlCommand cm = new SqlCommand("SaatEkle", db.baglan());
                    cm.CommandType = CommandType.StoredProcedure;
                    SqlParameter gun = new SqlParameter("@gun", SqlDbType.TinyInt);
                    gun.Direction = ParameterDirection.Input;
                    gun.Value = b;
                    cm.Parameters.Add(gun);
                    SqlParameter baslamaSaati = new SqlParameter("@baslamaSaati", SqlDbType.VarChar, 50);
                    baslamaSaati.Direction = ParameterDirection.Input;
                    baslamaSaati.Value = textBox1.Text;
                    cm.Parameters.Add(baslamaSaati);
                    SqlParameter bitisSaati = new SqlParameter("@bitisSaati", SqlDbType.VarChar, 50);
                    bitisSaati.Direction = ParameterDirection.Input;
                    bitisSaati.Value = textBox2.Text;
                    cm.Parameters.Add(bitisSaati);

                    cm.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla saat Eklendi.");
                    db.kapat();
                }
                catch (Exception ex)
                {
                    DateTime a;
                    if (!DateTime.TryParse(textBox1.Text, out a))
                    {
                        MessageBox.Show("Lütfen Başlama Saatini 'ss:dd' Formatında Giriniz  !");
                    }
                    else if (!DateTime.TryParse(textBox2.Text, out a))
                    {
                        MessageBox.Show("Lütfen Bitiş Saatini 'ss:dd' Formatında Giriniz  !");
                    }
                    else
                    { MessageBox.Show("Saat Ekleme Başarısız" + ex); }
                }
                textBox1.Text = "00:00";
                textBox2.Text = "00:00";
                dataGridView1.DataSource = db.gridData("saatler");
                db.kapat();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Text = "00:00";
            textBox2.Text = "00:00";
            dataGridView1.DataSource = db.gridData("saatler");
            db.kapat();


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
         
            b = 2;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;






        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            b = 3;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            b = 4;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            b = 5;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox2.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            b = 6;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox2.Checked = false;
            checkBox7.Checked = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            b = 7;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox2.Checked = false;
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
           
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           textBox1.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["baslamaSaati"].Value);
           textBox2.Text = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["bitisSaati"].Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
                
             
                SqlCommand cm = new SqlCommand("SaatSil", db.baglan());
                cm.CommandType = CommandType.StoredProcedure;

                SqlParameter a1 = new SqlParameter("@id",SqlDbType.Int);

                a1.Direction = ParameterDirection.Input;

                a1.Value = id;

                cm.Parameters.Add(a1);
                cm.ExecuteNonQuery();
                MessageBox.Show("Başarıyla saat silindi.");
                dataGridView1.DataSource = db.gridData("saatler");
                db.kapat();


            }
            catch
            {
                MessageBox.Show(" saat silinmedi");
            }





        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
            int gun = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["gun"].Value);
            String baslamaSaati = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["baslamaSaati"].Value);
            String bitisSaati = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["bitisSaati"].Value);

            SqlCommand cm = new SqlCommand("SaatDüzenle", db.baglan());
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter a1 = new SqlParameter("@id", SqlDbType.Int);
            SqlParameter a2 = new SqlParameter("@gun", SqlDbType.Int);
            SqlParameter a3 = new SqlParameter("@baslamaSaati", SqlDbType.VarChar, 50);
            SqlParameter a4 = new SqlParameter("@bitisSaati", SqlDbType.VarChar, 50);

            a1.Direction = ParameterDirection.Input;
            a1.Value = id;
            cm.Parameters.Add(a1);
            a2.Direction = ParameterDirection.Input;
            a2.Value = b;
            cm.Parameters.Add(a2);
            a3.Direction = ParameterDirection.Input;
            a3.Value = textBox1.Text;
            cm.Parameters.Add(a3);
            a4.Direction = ParameterDirection.Input;
            a4.Value = textBox2.Text;
            cm.Parameters.Add(a4);
            cm.ExecuteNonQuery();
            MessageBox.Show("SAAT BAŞARIYLA DÜZENLENDİ");
            dataGridView1.DataSource = db.gridData("saatler");
            db.kapat();


            }
            catch
            {
                MessageBox.Show(" SAAT DÜZENLENEMEDİ !");
            }
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    } 
           
        }

        
       
