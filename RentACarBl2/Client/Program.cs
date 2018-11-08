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
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            string machine = "localhost";
            X509Certificate2 srvCert = CertificateManager.GetSingleCertificate(StoreName.My, StoreLocation.LocalMachine, srvCertCN);
            EndpointAddress address = new EndpointAddress(new Uri(String.Format("net.tcp://{0}:202/WCFServer", machine)),
                                      new X509CertificateEndpointIdentity(srvCert));
        }
            

}
}
