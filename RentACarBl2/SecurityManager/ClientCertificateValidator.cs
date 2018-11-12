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
        //string tpklijenta = "INVISIBLECHARACTER67416e1328388ecd1f229ace08a6fabca7f400fa";
        public override void Validate(X509Certificate2 certificate)
        {
            X509Certificate2 cert = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN,OU1,OU2);
          

            if (certificate.Issuer != cert.Issuer)
            {
                Audit.AnnotateEvent("Authentication failed. Certificate is not self signed.\n");
                throw new Exception("Certificate is not self signed.\n");
            }
            //else if (certificate.SubjectName != cert.SubjectName)
            //{
            //    Audit.AnnotateEvent("Authentication failed. Invalid common name.\n");

            //    throw new Exception("Invaid common name.\n");
          
            else if (certificate.Thumbprint != cert.Thumbprint)
            {
                Audit.AnnotateEvent("Authentication failed. Invalid thumbprint value.\n");
                throw new Exception("Invalid certificate thumbprint value.\n");
            }
            else if (cert.NotAfter <= DateTime.Now)
            {
                Audit.AnnotateEvent("Authentication failed. Certificate has expired.\n");
                throw new Exception("Certificate has expired.\n");
            }
        }
    }
}
