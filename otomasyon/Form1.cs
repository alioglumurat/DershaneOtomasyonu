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
       
        private void btn_giris_Click(object sender, EventArgs e)
        {

            DB db = new DB();
            int state;
            state= db.userState(txt_username.Text, db.MD5Sifrele(txt_userpass.Text));
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
    }
}
