using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server
{
    class Server : IServer
    {
        private Dictionary<string, Korisnik> items;
        private Dictionary<string, Admin> itemsA;
        private Dictionary<string, Auta> itemsAuta;
      
        public Server()
        {
            items = new Dictionary<string, Korisnik>();
            itemsA = new Dictionary<string, Admin>();
            itemsAuta = new Dictionary<string, Auta>();
    }

        public void DodajKorisnika(Korisnik korisnik)
        {
            if (items.ContainsKey(korisnik.Username))
            {

                NotFoundException ex = new NotFoundException("Korisnik sa tim user name-om vec postoji.");
                throw new FaultException<NotFoundException>(ex);
            }
            else
            {
                items.Add(korisnik.Username, korisnik);
                Console.WriteLine(korisnik);
            }
        }

        public void DodajAdmina(Admin admin)
        {
            if (itemsA.ContainsKey(admin.Username))
            {

                NotFoundException ex = new NotFoundException("Korisnik sa tim user name-om vec postoji.");
                throw new FaultException<NotFoundException>(ex);
            }
            else
            {
                itemsA.Add(admin.Username, admin);
                Console.WriteLine(admin);
            }
        }

        public void DodajAuto(Auta auta)
        {
            if (itemsAuta.ContainsKey(auta.RegistracijaAuta))
            {

                NotFoundException ex = new NotFoundException("Auto registrovano na ovaj datum vec postoji.");
                throw new FaultException<NotFoundException>(ex);
            }
            else
            {
                itemsAuta.Add(auta.RegistracijaAuta, auta);
                Console.WriteLine(auta);
            }
        }

        public void DodijeliClanstvo(string ime, string prezime, string userName)
        {
            throw new NotImplementedException();
        }

        public void IzmijeniKorisnika(Korisnik korisnik)
        {
            if (items.ContainsKey(korisnik.Username))
            {
               
                items[korisnik.Username]=korisnik;
            }else
            {
                NotFoundException ex = new NotFoundException("Korisnik ne postoji.");
                throw new FaultException<NotFoundException>(ex);
            }
        }

        public void ObrisiKorisnika(Korisnik korisnik)
        {
            if (items.ContainsKey(korisnik.Username))
            {
                items.Remove(korisnik.Username);
                Console.WriteLine(korisnik);
            }
            else
            {
                NotFoundException ex = new NotFoundException("Korisnik ne postoji.");
                throw new FaultException<NotFoundException>(ex);
            }
        }

        public double Read(int id)
        {
            throw new NotImplementedException();
        }

        public void RezervisiVozilo(string nazivVozila, Type tipVozila)
        {
            throw new NotImplementedException();
        }

        public void UkloniClanstvo(string userName)
        {
            throw new NotImplementedException();
        }

        public void Write(int id, double input)
        {
            throw new NotImplementedException();
        }

        public void Serializacija()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Korisnik));
            XmlSerializer serializer1 = new XmlSerializer(typeof(Admin));
            using (TextWriter textWriter = new StreamWriter("korisnici.xml"))
            {
                foreach (Korisnik k in items.Values)
                    serializer.Serialize(textWriter, k);
                foreach (Admin a in itemsA.Values)     
                serializer1.Serialize(textWriter, a);

            }
               
        }

     
        public void SerializacijaAuta()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Auta));
            using (TextWriter textWriter = new StreamWriter("automobili.xml"))
            {
                foreach (Auta au in itemsAuta.Values)
                    serializer.Serialize(textWriter, au);

            }

        }


    }
}
