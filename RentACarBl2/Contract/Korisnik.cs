using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class Korisnik
    {
        private string korisnickoIme;
        private double stanjeNaRacunu;
        private bool zlClan = false;

        private List<Rezervacija> iznajmljeniAutomobili;

        [DataMember]
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        [DataMember]
        public double StanjeNaRacunu
        {
            get { return stanjeNaRacunu; }
            set { stanjeNaRacunu = value; }
        }
        [DataMember]
        public bool ZlClan
        {
            get { return zlClan; }
            set { zlClan = value; }
        }
        [DataMember]
        public List<Rezervacija> IznajmljeniAutomobili
        {
            get { return iznajmljeniAutomobili; }
            set { iznajmljeniAutomobili = value; }
        }
        public Korisnik(string korisnickoIme, double stanjeNaRacunu, bool zlClan)
        {
            this.KorisnickoIme = korisnickoIme;
            this.StanjeNaRacunu = 5000;
            this.ZlClan = zlClan;
            IznajmljeniAutomobili = new List<Rezervacija>();
        }

        public Korisnik(string korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
        }
    }
}
