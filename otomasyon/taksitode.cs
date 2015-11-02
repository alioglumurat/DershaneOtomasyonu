using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otomasyon
{
    class taksitode
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private String taksitno;


        public String Taksitno
        {
            get { return taksitno; }
            set { taksitno = value; }
        }


        private String taksitTutari;

        public String TaksitTutari
        {
            get { return taksitTutari; }
            set { taksitTutari = value; }
        }

        private DateTime odemeGunu;

        public DateTime OdemeGunu
        {
            get { return odemeGunu; }
            set { odemeGunu = value; }
        }

        private DateTime odenmeGunu;

        public DateTime OdenmeGunu
        {
            get { return odenmeGunu; }
            set { odenmeGunu = value; }
        }
        private int durum;

        public int Durum
        {
            get { return durum; }
            set { durum = value; }
        }

        private String aciklama;

        public String Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }


       

    }
}
