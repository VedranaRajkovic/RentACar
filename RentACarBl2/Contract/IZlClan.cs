using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IZlClan
    {
        [OperationContract]
        void RezervisiAutomobil(Rezervacija rezervacija);
        [OperationContract]
        void UkiniZlClanstvo(Korisnik korisnik);
    }
}
