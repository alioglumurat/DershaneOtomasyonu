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
using System.Security.Cryptography;

namespace otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static String degisken = "";
        public static int state;

        DB db = new DB();

        private void btn_giris_Click(object sender, EventArgs e)
        {

            db.userState(txt_username.Text, db.MD5Sifrele(txt_userpass.Text));
            db.kapat();
            if (Form1.state==3 || Form1.state==1 || Form1.state==2)
            {
                SqlCommand sc = new SqlCommand("SELECT dbo.wer(@uName)", db.baglan());
                SqlParameter a1 = new SqlParameter("@uName", SqlDbType.VarChar, 50);
                a1.Direction = ParameterDirection.Input;
                a1.Value = Form1.degisken;

                sc.Parameters.Add(a1);

                int asa = Convert.ToInt32(sc.ExecuteScalar());
                if (asa == 0)
                {
                    personelEkle pr = new personelEkle();
                    pr.Show();
                    this.Hide();
                }
                else
                {

                    switch (state)
                    {
                        case 0:
                            this.Hide();
                            admin_panel adm = new admin_panel();
                            adm.Show();
                            break;
                        case 1:
                            this.Hide();
                            i_k ink = new i_k();
                            ink.Show();
                            break;
                        case 2:
                            this.Hide();
                            muhasebe mh = new muhasebe();
                            mh.Show();
                            break;
                        case 3:
                            this.Hide();
                            ogrenci_isleri ogr = new ogrenci_isleri();
                            ogr.Show();
                            break;
                        default:
                            break;

                    }

                }
            }
          if (Form1.state==0)
            {
                this.Hide();
                admin_panel adm = new admin_panel();
                adm.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kaydetkul kyt = new kaydetkul();
            kyt.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            kaydetkul kyt = new kaydetkul();
            kyt.Show();
        }

        public void profilKontrol()
        {
            
            }
        }
    }

