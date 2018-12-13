using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class Rezervacija
    {
        private int dani;
        private double cijenaAuta;
        private DateTime datumIzn;
        private string registracija;
        private string korisnickoIme;

        public Rezervacija()
        {

        }

        [DataMember]
        public int Dani
        {
            get { return dani; }
            set { dani = value; }
        }

        [DataMember]
        public double CijenaAuta
        {
            get { return cijenaAuta; }
            set { cijenaAuta = value; }
        }

        [DataMember]
        public DateTime DatumIzn
        {
            get { return datumIzn; }
            set { datumIzn = value; }
        }
        [DataMember]
        public string Registracija
        {
            get { return registracija; }
            set { registracija = value; }
        }
        [DataMember]
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        public Rezervacija(int dani, double cijena, DateTime datumIzn, string korisnickoIme)
        {
            this.Dani = dani;
            this.CijenaAuta = 150;
            this.DatumIzn = datumIzn;
            this.KorisnickoIme = korisnickoIme;

        }
    }
}
