using Contract;
using SecurityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static void Main(string[] args)
        {
            string srvCertCN = "wcfservice";
            string OU1 = "korisnik"; //organization unit
            string OU2 = "admin";
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 srvCert = CertificateManager.GetSingleCertificate(StoreName.My, StoreLocation.LocalMachine, srvCertCN,OU1,OU2);
            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:4000/WCFService"), //EndPointIdentity zbog obostrane autentifikacije
                                      new X509CertificateEndpointIdentity(srvCert)); //cer format sertifikata, jer klijent ne smije imati pristup pfx fajlu
            WCFClient c = new WCFClient(binding, address);
            //c.ispisi(23);
            //c.ispisi(ime, pass);
            Console.WriteLine("Unesite svoje podatke");
            Console.WriteLine("Username:");
            string ime = "";
            ime = Console.ReadLine();
            Console.WriteLine("Password:");
            string pass = "";
            pass = Console.ReadLine();
            if(ime=="admin" && pass=="admin")
            {
                Console.WriteLine("Ulogovani ste kao admin",c.ispisi(ime,pass));
              

            }else
            {
                Console.WriteLine("Ulogovani ste kao korisnik", c.ispisi(ime, pass));
            }

         
            Console.ReadLine();
        }
            

}
}
