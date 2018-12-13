using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IAdmin
    {
        [OperationContract]
        bool DodajAutomobil(Automobil automobil);
        [OperationContract]
        bool IzmijeniAutomobil(Automobil automobil);
        [OperationContract]
        bool ObrisiAutomobil(string registracija);
        [OperationContract]
        void DodajZlClana(string korisnickoIme);
        [OperationContract]
        void ObrisiZlClana(string korisnickoIme);
        [OperationContract]
        void PretraziZlClana(string korisnickoIme);
        [OperationContract]
        void UkiniZlClanstvo(string korisnickoIme);
        [OperationContract]
        bool RezervisiAutomobil(Rezervacija rezervacija);
        [OperationContract]
        bool IzmijeniRezervaciju(Rezervacija rezervacija);
        [OperationContract]
        void ObrisiRezervaciju(Rezervacija rezervacija);
    }
}
