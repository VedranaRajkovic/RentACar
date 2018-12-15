﻿using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ZlClan : IZlClan
    {
        public void RezervisiAutomobil(Rezervacija rezervacija)
        {
            if (Podaci.automobili.ContainsKey(rezervacija.Registracija))
            {
                Podaci.rezervacijeNisuGotove.Add(rezervacija);
            }
        }

        public void UkiniZlClanstvo(string korisnickoIme)
        {
            throw new NotImplementedException();
        }
    }
}
