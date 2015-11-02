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
    public partial class kaydetkul : Form
    {
        public kaydetkul()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            int sayi = db.userSave(txt_username.Text, db.MD5Sifrele(txt_password.Text), txt_state.Text);
            if (sayi>0)
            {
                MessageBox.Show("Kayıt işlemi gerçekleştirildi");
            }
            else
            {
                MessageBox.Show("Kayıt işleminde hata");
            }

            db.kapat();

            this.Hide();
            Form1 frm = new Form1();
            frm.Show();

        }
    }
}
