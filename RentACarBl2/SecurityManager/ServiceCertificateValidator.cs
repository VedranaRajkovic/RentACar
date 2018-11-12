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
        //string tpservera = "INVISIBLECHARACTER433a665ca285e4251815509efd4138f22966f247";
        //string tpklijenta = "INVISIBLECHARACTER67416e1328388ecd1f229ace08a6fabca7f400fa";
        public override void Validate(X509Certificate2 certificate) //sertifikat koji treba da se validuje-certificate
        {
            X509Certificate2 cert = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,cliNameCrt,OU1,OU2);
          

            if (!certificate.Issuer.Equals(cert.Issuer)) //ako sertifikaciono tijelo sertifikata kojeg provjeravamo nije jednak sertifikacionom tijelu onog sertifikata za kojeg imamo podatke
            {
                Audit.AnnotateEvent("Authentication failed. Certificate is not from a valid issuer.\n");
                throw new Exception("Certificate is not from a valid issuer.\n");
            }
            //else if (certificate.SubjectName != cert.SubjectName)
            //{
            //    //Audit.AnnotateEvent("Authentication failed. Invalid common name.\n");

            //    throw new Exception("Invaid common name.\n");
            //}

            else if (certificate.Thumbprint!=cert.Thumbprint)
            {
                Audit.AnnotateEvent("Authentication failed. Invalid thumbprint value.\n");
                throw new Exception("Invalid certificate thumbprint value.\n");
            }
           
            else if (certificate.NotAfter <= DateTime.Now) //ako je istekao sertifikat
            {
                Audit.AnnotateEvent("Authentication failed. Certificate has expired.\n");
                throw new Exception("Certificate has expired.\n");
            }
        }
    }
}
