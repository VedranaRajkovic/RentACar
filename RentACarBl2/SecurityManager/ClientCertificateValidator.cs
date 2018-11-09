using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class ClientCertificateValidator : X509CertificateValidator
    {
        string srvCertCN = "wcfservice";
        string OU1 = "korisnik";
        string OU2 = "admin";
        public override void Validate(X509Certificate2 certificate)
        {
            X509Certificate2 cert = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN,OU1,OU2);

            if (certificate.Issuer != cert.Issuer)
            {
                throw new Exception("Certificate is not self signed.\n");
            }
          
            else if (cert.NotAfter <= DateTime.Now)
            {  
                throw new Exception("Certificate has expired.\n");
            }
        }
    }
}
