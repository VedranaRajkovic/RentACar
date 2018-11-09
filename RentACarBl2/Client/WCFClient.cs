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
    public class WCFClient : ChannelFactory<IServer>, IServer, IDisposable
    {
        IServer factory;
        string cliNameCrt = "wcfclient";
        string OU1 = "korisnik";
        string OU2 = "admin";
        public WCFClient(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            //definisanje tipa validacije sertifikata
            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.ChainTrust;
            this.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertificateValidator();
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            this.Credentials.ClientCertificate.Certificate = CertificateManager.GetSingleCertificate(StoreName.My, StoreLocation.LocalMachine,cliNameCrt,OU1,OU2);
            factory = this.CreateChannel();
        }

        public string ispisi(int a)
        {
            throw new NotImplementedException();
        }
    }
}