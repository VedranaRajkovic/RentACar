using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Admin : IAdmin
    {
        public bool DodajAutomobil(Automobil automobil)
        {
            throw new NotImplementedException();
        }

        public void DodajZlClana(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public bool IzmijeniAutomobil(Automobil automobil)
        {
            throw new NotImplementedException();
        }

        public bool IzmijeniRezervaciju(Rezervacija rezervacija)
        {
            throw new NotImplementedException();
        }

        public bool ObrisiAutomobil(string registracija)
        {
            throw new NotImplementedException();
        }

        public void ObrisiRezervaciju(Rezervacija rezervacija)
        {
            throw new NotImplementedException();
        }

        public void ObrisiZlClana(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public void PretraziZlClana(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public bool RezervisiAutomobil(Rezervacija rezervacija)
        {
            throw new NotImplementedException();
        }

        public void UkiniZlClanstvo(string korisnickoIme)
        {
            throw new NotImplementedException();
        }
    }
}
