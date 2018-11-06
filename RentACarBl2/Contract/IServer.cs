using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
        [ServiceContract]
        public interface IServer
        {
            [OperationContract]
            void DodajAdmina(Admin admin);
            [OperationContract]
            void DodajKorisnika(Korisnik korisnik);
            [OperationContract]
            void IzmijeniKorisnika(Korisnik korisnik);
            [OperationContract]
            void ObrisiKorisnika(Korisnik korisnik);
            [OperationContract]
            void DodijeliClanstvo(string ime, string prezime, string userName);
            [OperationContract]
            void UkloniClanstvo(string userName);
            [OperationContract]
            void DodajAuto(Auta auta); 
            [OperationContract]
            void RezervisiVozilo(string nazivVozila, Type tipVozila);
            [OperationContract]
            void Serializacija();
            [OperationContract]
            void SerializacijaAuta();
            //dodajem prilikom autentifikacije
            [OperationContract]
            bool Login(string username, string password/*, string computerName*/);
            [OperationContract]
            bool Logout(string username);
    }
    }

