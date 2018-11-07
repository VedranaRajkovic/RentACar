using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
       private static void Main(string[] args)
        {
            ChannelFactory<IServer> factory = new ChannelFactory<IServer>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/IServer"));
            IServer proxy = factory.CreateChannel();
            ChannelFactory<IUserServer> factory1 = new ChannelFactory<IUserServer>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/IUserServer"));
            IUserServer proxy1 = factory1.CreateChannel();

            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows; //dodajem zbog autentifikacije
          
                Console.WriteLine("Unesite username:");
                string user = "";
                user = Console.ReadLine();
                Console.WriteLine("Unesite password:");
                string pass = "";
                pass = Console.ReadLine();


                //    Korisnik k1 = new Korisnik();
                //k1.Ime = "Jelena";
                //k1.Prezime = "Ilic";
                //k1.Username = "jeca";
                //k1.Password = "123";
                //k1.Ovlascenje = "korisnik";

                //Korisnik k2 = new Korisnik();
                //k2.Ime = "Ivan";
                //k2.Prezime = "Janjic";
                //k2.Username = "ive01";
                //k2.Password = "456";
                //k2.Ovlascenje = "korisnik";

                Korisnik k3 = new Korisnik();
                //k3.Ime = "Danka";
                //k3.Prezime = "Saric";
                k3.User = "danka";
                k3.User = "789";
                //k3.Ovlascenje = "korisnik";

                Korisnik k4 = new Korisnik();
                //k4.Ime = "Marko";
                //k4.Prezime = "Ivanovic";
                k4.User = "marko";
                k4.User = "321";
                //k4.Ovlascenje = "korisnik";

                Admin a = new Admin();
                //a.Ime = "Sandra";
                //a.Prezime = "Jelic";
                a.Username = "admin";
                a.Password = "admin";
                //a.Ovlascenje = "administrator";

                Auta au = new Auta();
                //au.RegistracijaAuta = DateTime.FromFileTime(17 / 4 / 2018);
                au.RegistracijaAuta = "maj";
                au.OpisA = "Compact vozilo";
                au.MarkaA = "Opel";
                au.ModelA = "Astra";
                au.TipA = "1.4 16V";
                au.GodProizvodnje = 2014;
                au.MotorA = "Benzin";
                au.SnagaMotora = "63kW";
                au.BojaAuta = "Plava";
                au.CijenaA = "60e/dan";

                Auta au1 = new Auta();
                //au1.RegistracijaAuta = DateTime.FromFileTime(11 /1 / 2018);
                au1.RegistracijaAuta = "januar";
                au1.OpisA = "Economy vozilo";
                au1.MarkaA = "Opel";
                au1.ModelA = "Corsa";
                au1.TipA = "1.2 16V";
                au1.GodProizvodnje = 2013;
                au1.MotorA = "Benzin";
                au1.SnagaMotora = "63kW";
                au1.BojaAuta = "Crvena";
                au1.CijenaA = "45e/dan";

                Auta au2 = new Auta();
                //au2.RegistracijaAuta = DateTime.FromFileTime(22 / 9 / 2018);
                au2.RegistracijaAuta = "novembar";
                au2.OpisA = "Premium vozilo";
                au2.MarkaA = "Opel";
                au2.ModelA = "Insignia";
                au2.TipA = "2.0 CDTI";
                au2.GodProizvodnje = 2013;
                au2.MotorA = "Diesel";
                au2.SnagaMotora = "115kW";
                au2.BojaAuta = "Crna";
                au2.CijenaA = "100e/dan";

                Auta au3 = new Auta();
                //au3.RegistracijaAuta = DateTime.FromFileTime(15 / 7 / 2018);
                au3.RegistracijaAuta = "decembar";
                au3.OpisA = "Kombi vozilo";
                au3.MarkaA = "Renault";
                au3.ModelA = "Traffic";
                au3.TipA = "1.9 dCi";
                au3.GodProizvodnje = 2003;
                au3.MotorA = "Diesel";
                au3.SnagaMotora = "74kW";
                au3.BojaAuta = "Bijela";
                au3.CijenaA = "50e/dan";

                Auta au4 = new Auta();
                //au4.RegistracijaAuta = DateTime.FromFileTime(2 / 5 / 2018);
                au4.RegistracijaAuta = "februar";
                au4.OpisA = "Economy vozilo";
                au4.MarkaA = "Renault";
                au4.ModelA = "Clio";
                au4.TipA = "1.2 16V";
                au4.GodProizvodnje = 2011;
                au4.MotorA = "Benzin";
                au4.SnagaMotora = "55kW";
                au4.BojaAuta = "Siva";
                au4.CijenaA = "50e/dan";

                Auta au5 = new Auta();
                //au5.RegistracijaAuta = DateTime.FromFileTime(2 / 3 / 2018);
                au5.RegistracijaAuta = "oktobar";
                au5.OpisA = "Luksuzno vozilo";
                au5.MarkaA = "Porsche";
                au5.ModelA = "Cayenne";
                au5.TipA = "S";
                au5.GodProizvodnje = 2006;
                au5.MotorA = "Benzin";
                au5.SnagaMotora = "250kW";
                au5.BojaAuta = "Siva";
                au5.CijenaA = "50e/dan";

                try
                {
                    proxy.DodajKorisnika(k3);
                    proxy.DodajKorisnika(k4);
                    //proxy.DodajAdmina(a);
                }
                catch (FaultException<NotFoundException> ex)
                {
                    Console.WriteLine(ex.Detail.Reason);
                }

                try
                {
                    proxy.DodajAdmina(a);
                }
                catch (FaultException<NotFoundException> ex)
                {
                    Console.WriteLine(ex.Detail.Reason);
                }
                try
                {
                    proxy.DodajAuto(au);
                    proxy.DodajAuto(au1);
                    proxy.DodajAuto(au2);
                    proxy.DodajAuto(au3);
                    proxy.DodajAuto(au4);
                    proxy.DodajAuto(au5);
                }
                catch (FaultException<NotFoundException> ex)
                {
                    Console.WriteLine(ex.Detail.Reason);
                }
                string authenticationSuccess = string.Empty;
                try
                {
                    authenticationSuccess = proxy1.Authenticate("danka", "789");
                    Console.WriteLine("Authentication: {0}", authenticationSuccess);
                }
                catch (FaultException<SecurityException> ex)
                {
                    Console.WriteLine(ex.Detail.Reason);
                }
            //try
            //{
            //    authenticationSuccess = proxy1.Authenticate("marko", "321");
            //    Console.WriteLine("Authentication: {0}", authenticationSuccess);
            //}
            //catch (FaultException<SecurityException> ex)
            //{
            //    Console.WriteLine(ex.Detail.Reason);
            //}


            proxy.Serializacija();
                proxy.SerializacijaAuta();
            
                Console.ReadLine();
            

        }

}
}
