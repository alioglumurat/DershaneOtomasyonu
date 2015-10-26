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
    public partial class muhasebe : Form
    {
        public muhasebe()
        {
            InitializeComponent();
        }

        private void muhasebe_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void muhasebe_Load(object sender, EventArgs e)
        {
            
        }
    }
}
