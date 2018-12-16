using Contract;
using SecurityManager;
using Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server
{
     class Program
    {
        public static string logName = null;
        public static string logSourceName = null;
        static void Main(string[] args)
        {

            //iscitavam podatke iz baze
            Console.ReadLine();
            List<Automobil> iscitaniAutomobili = new List<Automobil>();

            DataContractSerializer dcs = new DataContractSerializer(typeof(List<Automobil>));

            using (Stream stream = new FileStream("Automobili.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    reader.ReadContentAsObject();
                    iscitaniAutomobili = (List<Automobil>)dcs.ReadObject(reader);
                }
            }

            foreach (var item in iscitaniAutomobili)
            {
                Podaci.automobili[item.Registracija] = item;
            }

            List<Korisnik> iscitaniKorisnici = new List<Korisnik>();

            DataContractSerializer dcs1 = new DataContractSerializer(typeof(List<Korisnik>));

            using (Stream stream = new FileStream("Korisnici.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    reader.ReadContentAsObject();
                    iscitaniKorisnici = (List<Korisnik>)dcs1.ReadObject(reader);
                }
            }

            foreach (var item in iscitaniKorisnici)
            {
                Podaci.korisnici[item.KorisnickoIme] = item;
            }

            List<Korisnik> iscitaniZahtjevi = new List<Korisnik>();

            DataContractSerializer dcs2 = new DataContractSerializer(typeof(List<Korisnik>));

            using (Stream stream = new FileStream("ZahtjeviZlCl.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    reader.ReadContentAsObject();
                    iscitaniZahtjevi = (List<Korisnik>)dcs2.ReadObject(reader);
                }
            }
            foreach (var item in iscitaniKorisnici)
            {
                Podaci.ZahtjevZlClana.Add(item);
            }
            string servNameCrt = SecurityManager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            //string servNameCrt = "wcfservicem";
            //string OU1= "admin"; 
            //string OU2 = "clan";
            //string MachineName = Environment.MachineName;
            //string[] parts = MachineName.Split('-');
            //string MachineNameSplit = String.Format("{0}", parts[0]);
            //logName = String.Format("{0}LogFile", MachineNameSplit);
            //logSourceName = String.Format("{0}LogSourceName", "net.tcp://localhost:4000");
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            string address = "net.tcp://localhost:4000/WCFService";
            Audit audit = new Audit();

            ServiceHost host = new ServiceHost(typeof(Admin));

            //-----konfigurisanje ServiceHost obj da podrze zapisivanje bezbj.dogadjaja
            ServiceSecurityAuditBehavior newAuditBehavior = new ServiceSecurityAuditBehavior();
            host.Description.Behaviors.Remove<ServiceSecurityAuditBehavior>();
            host.Description.Behaviors.Add(newAuditBehavior);
            //-----

            host.AddServiceEndpoint(typeof(IAdmin), binding, address);
            //host.Authorization.ServiceAuthorizationManager = new ServiceAuthorizationManager(); //provjeriti !
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });



            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertificateValidator();
            host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            host.Credentials.ServiceCertificate.Certificate = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,servNameCrt /*servNameCrt,OU1,OU2*/);
            //host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My,X509FindType.FindBySubjectName,servNameCrt);
            //host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint,OU1);
            //host.Credentials.ServiceCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindByThumbprint,"");
            host.Open();

            Console.WriteLine("WCFService is opened. Press <enter> to finish...");
            Console.ReadLine();

            host.Close();


        }
    }
}