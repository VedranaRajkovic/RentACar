using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
   public class CertificateManager
    {
        public static X509Certificate2 GetCertificateFromStorage(StoreName storeName, StoreLocation storeLocation, string subjectName, string OU1,string OU2)
        {
            //X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);

            foreach (X509Certificate2 cert in certCollection)
            {
                if (cert.SubjectName.Name.Equals(string.Format("CN={0}", subjectName, "OU={1}",OU1,"OU={2}",OU2)))
                {
                    return cert;
                }
            }

            return null;
        }

        public static X509Certificate2 GetSingleCertificate(StoreName storeName, StoreLocation storeLocation, string srvCertCN,string OU1,string OU2) //dodajem organization unit kao parametre
        {
            string userCN = String.Format("CN={0}","OU={1}","OU={2}");
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2 certificate = new X509Certificate2();
            List<X509Certificate2> certCollection = new List<X509Certificate2>();
            foreach (var cert in store.Certificates)
            {
                certCollection.Add(cert);
            }

            foreach (X509Certificate2 cert in certCollection)
            {
                string[] names = cert.Subject.Split('_');

                if (names[0] == userCN)
                {
                    certificate = cert;
                    break;
                }
            }
            return certificate;
        }
    }

    }

