using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class ServiceCertificateValidator : X509CertificateValidator
    {
        string cliNameCrt = "wcfclient";
        string OU1 = "korisnik";
        string OU2 = "admin";
       
        public override void Validate(X509Certificate2 certificate) //sertifikat koji treba da se validuje-certificate
        {
            X509Certificate2 cert = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,cliNameCrt,OU1,OU2);

            if (!certificate.Issuer.Equals(cert.Issuer)) //ako sertifikaciono tijelo sertifikata kojeg provjeravamo nije jednak sertifikacionom tijelu onog sertifikata za kojeg imamo podatke
            {
                throw new Exception("Certificate is not from a valid issuer.\n");
            }
            else if (certificate.NotAfter <= DateTime.Now) //ako je istekao sertifikat
            {
                throw new Exception("Certificate has expired.\n");
            }
        }
    }
}
