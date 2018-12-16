using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class CertificateManager
    {
        //string tpservera = "INVISIBLECHARACTER433a665ca285e4251815509efd4138f22966f247";
        //string tpklijenta = "INVISIBLECHARACTER67416e1328388ecd1f229ace08a6fabca7f400fa";
        public static X509Certificate2 GetCertificateFromStorage(StoreName storeName, StoreLocation storeLocation, string subjectName)
        {
            //X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);
           
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection certCollection = store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, true);

            foreach (X509Certificate2 cert in certCollection)
            {
                if (cert.SubjectName.Name.Equals(string.Format("CN={0}", subjectName/*, "OU={1}",OU1,"OU={2}",OU2*/)))
                {
                    Audit.AuthenticationSuccess(subjectName);
                    return cert;
                }
            }
            Audit.AuthenticationFailed(subjectName);
            return null;

        }

        //        public static X509Certificate2 GetSingleCertificateFromStorage(StoreName storeName, StoreLocation storeLocation, string srvCertCN) //dodajem organization unit kao parametre
        //        {
        //            //string userCN = String.Format("CN={0}","OU={1}","OU={2}");
        //            string userCN = "CN=" + srvCertCN;
        //            //string orgUn1 = "OU1=" + OU1;
        //            //string orgUn2 = "OU2=" + OU2;
        //            X509Store store = new X509Store(storeName, storeLocation);
        //            store.Open(OpenFlags.ReadOnly);
        //            X509Certificate2 certificate = new X509Certificate2();
        //            List<X509Certificate2> certCollection = new List<X509Certificate2>();
        //            //List<X509Certificate2> certCollection1 = new List<X509Certificate2>();
        //            //List<X509Certificate2> certCollection2 = new List<X509Certificate2>();
        //            foreach (var cert in store.Certificates)
        //            {
        //                certCollection.Add(cert);
        //            }
        //            //foreach (var cert1 in store.Certificates)
        //            //{
        //            //    certCollection1.Add(cert1);
        //            //}
        //            //foreach (var cert2 in store.Certificates)
        //            //{
        //            //    certCollection2.Add(cert2);
        //            //}
        //            foreach (X509Certificate2 cert in certCollection)
        //            {
        //                string[] names = cert.Subject.Split('_');
        //                //string[] names1 = cert.Subject.Split('_');
        //                //string[] names2 = cert.Subject.Split('_');

        //                if (names[0] == userCN)
        //                {
        //                    certificate = cert;
        //                    break;
        //                }
        //                //else if (names1[0] == OU1)
        //                //{
        //                //    certificate = cert;
        //                //    break;
        //                //}
        //                //else if (names2[0] == OU2)
        //                //{
        //                //    certificate = cert;
        //                //    break;
        //                //}
        //            }
        //                return certificate;


        //        }

        //    }
        //}

        public static X509Certificate2 GetCertificateFromFile(string fileName)
        {
            X509Certificate2 certificate = null;

            ///In order to create .pfx file, access to a protected .pvk file will be required.
            ///For security reasons, password must not be kept as string. .NET class SecureString provides a confidentiality of a plaintext
            Console.Write("Insert password for the private key: ");
            string pwd = Console.ReadLine();

            ///Convert string to SecureString
            SecureString secPwd = new SecureString();
            foreach (char c in pwd)
            {
                secPwd.AppendChar(c);
            }
            pwd = String.Empty;

            /// try-catch necessary if either the speficied file doesn't exist or password is incorrect
            try
            {
                certificate = new X509Certificate2(fileName, secPwd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erroro while trying to GetCertificateFromFile {0}. ERROR = {1}", fileName, e.Message);
            }

            return certificate;
        }
    }
}
