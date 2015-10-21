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
    public partial class i_k : Form
    {
        public i_k()
        {
            InitializeComponent();
        }

        DB db = new DB();    
        ArrayList ar = new ArrayList();
        ArrayList var = new ArrayList();
        private void insan_kaynaklari_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void insan_kaynaklari_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            SqlDataReader getir = db.dersGetir();
            while (getir.Read())
            {
               listBox1.Items.Add(getir["dersAdi"].ToString());
            }
            db.kapat();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int sonuc = 0;
            int saat = 0;
            ar.Clear();            
            lbl_dersSaati.Text = " ";

            for (int i = 0; i < listBox1.SelectedIndices.Count; i++)
            {
                deger dgg = new deger();
                String deger = listBox1.Items[listBox1.SelectedIndices[i]].ToString();
                SqlCommand isle = db.dersSaatiGetir(deger);             
                saat = Convert.ToInt32(isle.ExecuteScalar());

                dgg.gSaat = saat;
                dgg.gdersAdi = deger;
                ar.Add(dgg);

                sonuc += saat;
                db.kapat();
            }
            comboBox1.Items.Clear();    
           
            for (int i = 0; i < ar.Count; i++)
            {
                deger dgr = (deger)ar[i];

                lbl_dersSaati.Text+= "" + dgr.gdersAdi + "Dersi -" + dgr.gSaat + " Saat \n";
            }
         
            lbl_toplamSaat.Text = sonuc.ToString();

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                comboBox1.Items.Add(listBox1.SelectedItems[i]);        
            }

        }
        int toplamF=0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            deger dg = new deger();           
            dg.dersAdi = comboBox1.SelectedItem.ToString();
            dg.saat = Convert.ToInt32(numericUpDown1.Value);
            var.Add(dg);

            int saatU = 0;
            int musSaat = 0;
            
            String ifade = "";
            
            for (int i = 0; i < var.Count; i++)
            {
                deger dgt = (deger)var[i];

                musSaat = dgt.saat;
               
                saatU = db.saatUcreti(dgt.dersAdi);
                toplamF += musSaat * saatU;
                ifade += " " + dgt.dersAdi + " dersi fiyatı " + (saatU * musSaat) + " lira \n";

                if (i == ar.Count-1)
                {
                    ifade += "\n Toplam Fiyat " + toplamF + " lira";
                }
            }             
                           
            lbl_fiyat.Text = ifade;
                          
        }

      
        private void lbl_fiyat_TextChanged(object sender, EventArgs e)
        {
            lbl_sonFiyat.Text = toplamF.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            toplamF -= Convert.ToInt32(numericUpDown2.Value);
            lbl_sonFiyat.Text = toplamF.ToString();
        }

       
    }
}
