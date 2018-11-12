using Contract;
using SecurityManager;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
     class Program
    {
        public static string logName = null;
        public static string logSourceName = null;
        static void Main(string[] args)
        {
            string servNameCrt = "wcfservice";
            string OU1= "korisnik"; 
            string OU2 = "admin";
            //string MachineName = Environment.MachineName;
            //string[] parts = MachineName.Split('-');
            //string MachineNameSplit = String.Format("{0}", parts[0]);
            //logName = String.Format("{0}LogFile", MachineNameSplit);
            //logSourceName = String.Format("{0}LogSourceName", "net.tcp://localhost:4000");
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            string address = "net.tcp://localhost:4000/WCFService";
            Audit audit = new Audit();

            ServiceHost host = new ServiceHost(typeof(WCFService));

            //-----konfigurisanje ServiceHost obj da podrze zapisivanje bezbj.dogadjaja
            ServiceSecurityAuditBehavior newAuditBehavior = new ServiceSecurityAuditBehavior();
            host.Description.Behaviors.Remove<ServiceSecurityAuditBehavior>();
            host.Description.Behaviors.Add(newAuditBehavior);
            //-----

            host.AddServiceEndpoint(typeof(IServer), binding, address);
            //host.Authorization.ServiceAuthorizationManager = new ServiceAuthorizationManager(); //provjeriti !
            //host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            //host.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });



            host.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            host.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServiceCertificateValidator();
            host.Credentials.ClientCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            host.Credentials.ServiceCertificate.Certificate = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,servNameCrt,OU1,OU2 /*servNameCrt,OU1,OU2*/);
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