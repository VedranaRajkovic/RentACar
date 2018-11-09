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
        public static X509Certificate2 GetCertificateFromStorage(StoreName storeName, StoreLocation storeLocation, string subjectName, string OU1,string O2)
        {
            //X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);
            return null;
        }

        public static X509Certificate2 GetSingleCertificate(StoreName my, StoreLocation localMachine, string srvCertCN,string OU1,string OU2) //dodajem organization unit kao parametre
        {
            throw new NotImplementedException();
        }
    }
}
