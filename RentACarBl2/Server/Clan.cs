using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Clan : IClan
    {
        public void PretraziZlClana(Korisnik korisnik)
        {
            if (Podaci.korisnici.ContainsKey(korisnik.KorisnickoIme))
            {
                Podaci.ZahtjevZlClana.Add(korisnik);
            }
        }

        public void RezervisiAutomobil(Rezervacija rezervacija)
        {
            if (Podaci.automobili.ContainsKey(rezervacija.Registracija))
            {
                Podaci.rezervacijeNisuGotove.Add(rezervacija);
            }
        }
    }
}
