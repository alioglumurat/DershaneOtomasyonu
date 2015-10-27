using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomasyon
{
    public partial class insan_kaynaklari : Form
    {
        public insan_kaynaklari()
        {
            InitializeComponent();
        }

        private void insan_kaynaklari_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void insan_kaynaklari_Load(object sender, EventArgs e)
        {

        }
    }
}
