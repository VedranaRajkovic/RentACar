using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientProxy:ChannelFactory<IServer>,IServer,IDisposable
    {
        IServer factory;
        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }
        public void DodajAdmina(Admin admin)
        {
           try
            {
                factory.DodajAdmina(admin);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DodajAuto(Auta auta)
        {
            try
            {
                factory.DodajAuto(auta);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DodajKorisnika(Korisnik korisnik)
        {
            try
            {
                factory.DodajKorisnika(korisnik);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void DodijeliClanstvo(string ime, string prezime, string userName)
        {
            throw new NotImplementedException();
        }

        public void IzmijeniKorisnika(Korisnik korisnik)
        {
            throw new NotImplementedException();
        }

        public void ObrisiKorisnika(Korisnik korisnik)
        {
            throw new NotImplementedException();
        }

        public void RezervisiVozilo(string nazivVozila, Type tipVozila)
        {
            throw new NotImplementedException();
        }

        public void Serializacija()
        {
            try
            {
                factory.Serializacija();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void SerializacijaAuta()
        {
            try
            {
                factory.SerializacijaAuta();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void UkloniClanstvo(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
