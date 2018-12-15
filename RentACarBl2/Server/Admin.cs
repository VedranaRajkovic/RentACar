using Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server
{
    public class Admin : IAdmin
    {
        public bool DodajAutomobil(Automobil automobil)
        {
            string rola;
            try
            {
                string name = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                string[] a = name.Split(';');
                string[] b = a[0].Split(',');
                string c = b[1];
                rola = c.Split('=')[1];
            }
            catch
            {
                return false;
            }

            if (rola != "admin") { return false; }
            // u xml ito dodaj vozilo
            if (!Podaci.automobili.ContainsKey(automobil.Registracija))
            {
                Podaci.automobili.Add(automobil.Registracija, automobil);


                List<Automobil> lista = new List<Automobil>();

                foreach (var item in Podaci.automobili.Values)
                {
                    lista.Add(item);
                }

                UnosAutomobilaUFajl("Automobili.xml", lista);

                return true;
            }
            else
            {
                return false;
            }
        }

        public void DodajZlClana(string korisnickoIme)
        {
            string rola;
            try
            {
                string name = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                string[] a = name.Split(';');
                string[] b = a[0].Split(',');
                string c = b[1];
                rola = c.Split('=')[1];
            }
            catch
            {
                return;
            }

            if (rola != "admin") { return; }
            //Audit.AuthorizationSuccess(userName, OperationContext.Current.IncomingMessageHeaders.Action);
            foreach (Korisnik k in Podaci.ZahtjevZlClana)
            {
                if (k.ZlClan == false)
                {
                    if (k.IznajmljeniAutomobili.Count > 4)
                    {
                        if (Podaci.korisnici.ContainsKey(korisnickoIme))
                        {
                            Podaci.korisnici[korisnickoIme].ZlClan = true;

                            List<Korisnik> lista = new List<Korisnik>();

                            foreach (var item in Podaci.korisnici.Values)
                            {
                                lista.Add(item);
                            }

                            Podaci.ZahtjevZlClana.Remove(k);
                            UpisivanjeKorisnikaUFajl("ZahtjeviZlCl.xml", Podaci.ZahtjevZlClana);
                            UpisivanjeKorisnikaUFajl("Korisnici.xml", lista);

                        }
                    }
                    else
                    {
                        Podaci.ZahtjevZlClana.Remove(k);
                        UpisivanjeKorisnikaUFajl("ZahtjeviZlCl.xml", Podaci.ZahtjevZlClana);

                    }
                }
            }
        }
        public bool IzmijeniAutomobil(Automobil automobil)
        {

            string rola;
            try
            {
                string name = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                string[] a = name.Split(';');
                string[] b = a[0].Split(',');
                string c = b[1];
                rola = c.Split('=')[1];
            }
            catch
            {
                return false;
            }

            if (rola != "admin") { return false; }

            if (Podaci.automobili.ContainsKey(automobil.Registracija))
            {
                Podaci.automobili[automobil.Registracija] = automobil;

                List<Automobil> lista = new List<Automobil>();

                foreach (var item in Podaci.automobili.Values)
                {
                    lista.Add(item);
                }

                UnosAutomobilaUFajl("Automobili.xml", lista);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IzmijeniRezervaciju(Rezervacija rezervacija)
        {
            {
                List<Rezervacija> pom = Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili;

                int index = 0;
                foreach (var item in pom)
                {
                    if (item.Registracija == rezervacija.Registracija)
                    {
                        break;
                    }
                    index++;
                }

                Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili[index].DatumIzn = rezervacija.DatumIzn;

                List<Korisnik> lista = new List<Korisnik>();

                foreach (var item in Podaci.korisnici.Values)
                {
                    lista.Add(item);
                }

                UpisivanjeKorisnikaUFajl("Korisnici.xml", lista);
                return true;
            }
        }

        public bool ObrisiAutomobil(string registracija)
        {
            string rola;
            try
            {
                string name = ServiceSecurityContext.Current.PrimaryIdentity.Name;
                string[] a = name.Split(';');
                string[] b = a[0].Split(',');
                string c = b[1];
                rola = c.Split('=')[1];
            }
            catch
            {
                return false;
            }

            if (rola != "admin") { return false; }

            if (Podaci.automobili.ContainsKey(registracija))
            {
                Podaci.automobili.Remove(registracija);
                List<Automobil> lista = new List<Automobil>();

                foreach (var item in Podaci.automobili.Values)
                {
                    lista.Add(item);
                }

                UnosAutomobilaUFajl("Automobili.xml", lista);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ObrisiRezervaciju(Rezervacija rezervacija)
        {

            //if (Database.Rezervacije.ContainsKey(rezervacija.Registracija))
            {

                List<Rezervacija> pom = Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili;
                Podaci.automobili[rezervacija.Registracija].Iznajmljen = false;
                int index = 0;
                foreach (var item in pom)
                {
                    if (item.Registracija == rezervacija.Registracija)
                    {
                        break;
                    }
                    index++;
                }

                Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili.Remove(Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili[index]);

                List<Korisnik> lista = new List<Korisnik>();

                foreach (var item in Podaci.korisnici.Values)
                {
                    lista.Add(item);
                }

                List<Automobil> listaAutomobila = new List<Automobil>();

                foreach (var item in Podaci.automobili.Values)
                {
                    listaAutomobila.Add(item);
                }


                UnosAutomobilaUFajl("Automobili.xml", listaAutomobila);

                UpisivanjeKorisnikaUFajl("Korisnici.xml", lista);
            }
        }

        public void ObrisiZlClana(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public void PretraziZlClana(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public bool RezervisiAutomobil(Rezervacija rezervacija)
        {
            if (!Podaci.korisnici.ContainsKey(rezervacija.KorisnickoIme))
            {
                Podaci.korisnici[rezervacija.KorisnickoIme] = (new Korisnik(rezervacija.KorisnickoIme));
            }
            if (Podaci.automobili.ContainsKey(rezervacija.Registracija))
            {
                if (Podaci.automobili[rezervacija.Registracija].Iznajmljen == false)
                {
                    Podaci.automobili[rezervacija.Registracija].Iznajmljen = true;

                    if (Podaci.korisnici[rezervacija.KorisnickoIme].ZlClan == true)
                    {
                        double aa = rezervacija.CijenaAuta * rezervacija.Dani;
                        Podaci.korisnici[rezervacija.KorisnickoIme].StanjeNaRacunu = Podaci.korisnici[rezervacija.KorisnickoIme].StanjeNaRacunu - (aa * 0.95);
                    }
                    else
                    {
                        double aa = rezervacija.CijenaAuta * rezervacija.Dani;
                        Podaci.korisnici[rezervacija.KorisnickoIme].StanjeNaRacunu = Podaci.korisnici[rezervacija.KorisnickoIme].StanjeNaRacunu - (aa);
                    }

                    Podaci.Rezervacije[rezervacija.Registracija] = rezervacija;
                    Podaci.korisnici[rezervacija.KorisnickoIme].IznajmljeniAutomobili.Add(rezervacija);

                    List<Korisnik> lista = new List<Korisnik>();

                    foreach (var item in Podaci.korisnici.Values)
                    {
                        lista.Add(item);
                    }

                    List<Automobil> listaAutomobila = new List<Automobil>();

                    foreach (var item in Podaci.automobili.Values)
                    {
                        listaAutomobila.Add(item);
                    }


                    UpisivanjeKorisnikaUFajl("Korisnici.xml", lista);
                    UnosAutomobilaUFajl("Automobili.xml", listaAutomobila);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void UkiniZlClanstvo(string korisnickoIme)
        {
            throw new NotImplementedException();
        }

        public void UnosAutomobilaUFajl(string filename, List<Automobil> automobili)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<Automobil>));

            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    dcs.WriteObject(writer, automobili);
                }
            }
        }

        public void UpisivanjeKorisnikaUFajl(string filename, List<Korisnik> korisnici)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<Korisnik>));

            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8))
                {
                    writer.WriteStartDocument();
                    dcs.WriteObject(writer, korisnici);
                }
            }
        }
    }
}
