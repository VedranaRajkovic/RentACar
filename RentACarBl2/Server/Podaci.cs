using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
   public class Podaci
    {
        public static readonly Dictionary<string, Automobil> automobili = new Dictionary<string, Automobil>();
        public static readonly List<Korisnik> ZlatniClan = new List<Korisnik>();
        public static readonly List<Korisnik> ZahtjevZlClana = new List<Korisnik>();
        public static readonly List<Korisnik> UklanjanjeZahZlClana = new List<Korisnik>();
        public static readonly Dictionary<string, Korisnik> korisnici = new Dictionary<string, Korisnik>();
        public static readonly Dictionary<string, Rezervacija> Rezervacije = new Dictionary<string, Rezervacija>();
        public static readonly List<Rezervacija> rezervacijeNisuGotove = new List<Rezervacija>();
    }
}
