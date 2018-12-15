using Contract;
using SecurityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class WCFClient : ChannelFactory<IAdmin>, IAdmin, IDisposable
    {
        IAdmin factory;
        //string cliNameCrt = "wcfclient";
        //string OU1 = "admin";
        //string OU2 = "clan";
        public WCFClient(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            string cliNameCrt = SecurityManager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            //definisanje tipa validacije sertifikata
            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.Custom;
            this.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertificateValidator();
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;
            this.Credentials.ClientCertificate.Certificate = CertificateManager.GetSingleCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine,cliNameCrt);
            factory = this.CreateChannel();
        }

        //public string ispisi(string ime,string pass)
        //{
        //    try
        //    {
        //        string res = factory.ispisi(ime,pass);
        //        return res;
        //    }
        //    catch (Exception e )
        //    {
        //        return null;
        //    }
        //}

        public bool DodajAutomobil(Automobil automobil)
        {
            bool retVal = false;
            try
            {
                retVal = factory.DodajAutomobil(automobil);
                return retVal;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool IzmijeniAutomobil(Automobil automobil)
        {
            bool retVal;
            try
            {
                retVal = factory.IzmijeniAutomobil(automobil);
                return retVal;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool ObrisiAutomobil(string registracija)
        {
            bool retVal;
            try
            {
                retVal = factory.ObrisiAutomobil(registracija);
                return retVal;
            }catch(Exception e)
            {
                return false;
            }
        }

        public void DodajZlClana(string korisnickoIme)
        {
            factory.DodajZlClana(korisnickoIme);
        }

        public void ObrisiZlClana(string korisnickoIme)
        {
            factory.ObrisiZlClana(korisnickoIme);
        }

        public void PretraziZlClana(string korisnickoIme)
        {
            factory.PretraziZlClana(korisnickoIme);
        }

        public void UkiniZlClanstvo(string korisnickoIme)
        {
            factory.UkiniZlClanstvo(korisnickoIme);
        }

        public bool RezervisiAutomobil(Rezervacija rezervacija)
        {
            bool retVal;
            try
            {
                retVal = factory.RezervisiAutomobil(rezervacija);
                return retVal;
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool IzmijeniRezervaciju(Rezervacija rezervacija)
        {
            bool retVal;
            try
            {
                retVal = factory.IzmijeniRezervaciju(rezervacija);
                return retVal;
            }catch(Exception e)
            {
                return false;
            }
        }

        public void ObrisiRezervaciju(Rezervacija rezervacija)
        {
            factory.ObrisiRezervaciju(rezervacija);
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }

            this.Close();
        }
    }
}