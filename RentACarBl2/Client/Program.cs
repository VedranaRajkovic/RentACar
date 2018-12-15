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
    class Program
    {
        private static void Main(string[] args)
        {
            string srvCertCN = "wcfservicem";
            //string OU1 = "admin"; //organization unit
            //string OU2 = "clan";
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            X509Certificate2 srvCert = CertificateManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN/*, OU1, OU2*/);
            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:4000/WCFService"), //EndPointIdentity zbog obostrane autentifikacije
                                      new X509CertificateEndpointIdentity(srvCert)); //cer format sertifikata, jer klijent ne smije imati pristup pfx fajlu
                                                                                     //            WCFClient c = new WCFClient(binding, address);
                                                                                     //            //c.ispisi(23);
                                                                                     //            //c.ispisi(ime, pass);
                                                                                     //            Console.WriteLine("Unesite svoje podatke");
                                                                                     //            Console.WriteLine("Username:");
                                                                                     //            string ime = "";
                                                                                     //            ime = Console.ReadLine();
                                                                                     //            Console.WriteLine("Password:");
                                                                                     //            string pass = "";
                                                                                     //            pass = Console.ReadLine();
                                                                                     //            if(ime=="admin" && pass=="admin")
                                                                                     //            {
                                                                                     //                Console.WriteLine("Ulogovani ste kao admin",c.ispisi(ime,pass));


            //            }else
            //            {
            //                Console.WriteLine("Ulogovani ste kao korisnik", c.ispisi(ime, pass));
            //            }


            //            Console.ReadLine();
            //        }


            //}
            //}
            while (true)
            {
                using (WCFClient proxy = new WCFClient(binding, address))
                {
                    string s = SecurityManager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
                    do
                    {
                        Console.WriteLine("--- Vase opcije: ---");
                        Console.WriteLine("1 - Dodaj automobil");
                        Console.WriteLine("2 - Izmijeni automobil");
                        Console.WriteLine("3 - Obrisi automobil");
                        Console.WriteLine("4 - Zatrazi zahtjev da postanes zlatni clan");
                        Console.WriteLine("5 - Dodaj Zlatnog clana");
                        Console.WriteLine("6 - Zatrazi zahtjev za ukidanje zlatnog clanstva");
                        Console.WriteLine("7 - Ukloni zlatnog clana");
                        Console.WriteLine("8 - Rezervisi odredjeni automobil");
                        Console.WriteLine("9 - Izmijeni rezervaciju");
                        Console.WriteLine("10 - Izbrisi rezervaciju");
                        Console.WriteLine("Odaberite operaciju:");
                        string odabir = Console.ReadLine();

                        switch (odabir)
                        {
                            case ("1"):
                                Automobil a = new Automobil();
                                Console.WriteLine("Unesite registraciju:");
                                a.Registracija = Console.ReadLine();
                                int izbor = -1;
                                do
                                {
                                    Console.WriteLine("Izaberite tip vozila:");
                                    Console.WriteLine("0 Limunzina:");
                                    Console.WriteLine("1 Kombi:");
                                    Console.WriteLine("2 Auto:");
                                    Console.WriteLine("3 Karavan:");
                                    Console.WriteLine("4 Kabriolet:");
                                    try
                                    {
                                        izbor = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        izbor = -2;
                                    }
                                    while (true)
                                    {
                                        if (izbor == 0 || izbor == 1 || izbor == 2)
                                            break;
                                    }
                                } while (izbor == -2);
                                a.Tip = (TipAutomobila)Enum.ToObject(typeof(TipAutomobila), izbor);

                                bool retVal = proxy.DodajAutomobil(a);
                                if (retVal)
                                    Console.WriteLine("Automobil je uspjesno dodat.\n");
                                else
                                    Console.WriteLine("Doslo je do greske!\n");

                                break;
                            case ("2"):
                                a = new Automobil();
                                Console.WriteLine("Unesite registarski broj:");
                                a.Registracija = Console.ReadLine();

                                izbor = -1;
                                do
                                {
                                    Console.WriteLine("Izaberite tip automobila:");
                                    Console.WriteLine("0 Limunzina:");
                                    Console.WriteLine("1 Kombi:");
                                    Console.WriteLine("2 Auto:");
                                    Console.WriteLine("3 Karavan:");
                                    Console.WriteLine("4 Kabriolet:");

                                    try
                                    {
                                        izbor = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch
                                    {
                                        izbor = -2;
                                    }
                                    while (true)
                                    {
                                        if (izbor == 0 || izbor == 1 || izbor == 2)
                                            break;
                                    }
                                } while (izbor == -2);
                                a.Tip = (TipAutomobila)Enum.ToObject(typeof(TipAutomobila), izbor);

                                retVal = proxy.IzmijeniAutomobil(a);
                                if (retVal)
                                    Console.WriteLine("Automobil je uspjesno izmijenjen.\n");
                                else
                                    Console.WriteLine("Doslo je do greske!\n");

                                break;
                            case "3":
                                Console.WriteLine("Unesite registraciju:");
                                string Registracija = Console.ReadLine();

                                retVal = proxy.ObrisiAutomobil(Registracija);
                                if (retVal)
                                    Console.WriteLine("Automobil je uspjesno izmijenjen.\n");
                                else
                                    Console.WriteLine("Doslo je do greske!\n");

                                break;

                            case "4":
                                proxy.PretraziZlClana(s); //verovano ce ici srvCertCN----------------
                                Console.WriteLine("Zahtev za zlatno clanstvo je poslat.");
                                break;
                            case "5":
                                proxy.DodajZlClana("clan1");
                                Console.WriteLine("Dodijeljeno je zlatno clanstvo");
                                break;
                            case "6":
                                proxy.UkiniZlClanstvo(s);
                                Console.WriteLine("Zahtjev za ukidanje zlatnog clanstva poslat.");
                                break;
                            case "7":
                                proxy.ObrisiZlClana("clan1");
                                Console.WriteLine("Uklonjeno je zlatno clanstvo");
                                break;
                            case "8":
                                Rezervacija r = new Rezervacija();
                                Console.WriteLine("Unesite registraciju vozila:");
                                r.Registracija = Console.ReadLine();
                                Console.WriteLine("Unesite datum (YYYY-MM-DD)");
                                r.DatumIzn = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Unesite broj dana");
                                r.Dani = Convert.ToInt32(Console.ReadLine());
                                r.KorisnickoIme = s;
                                retVal = proxy.RezervisiAutomobil(r);

                                if (retVal)
                                    Console.WriteLine("Automobil je rezervisan.\n");
                                else
                                    Console.WriteLine("Doslo je do greske!\n");
                                break;
                            case "9":
                                Rezervacija r1 = new Rezervacija();
                                Console.WriteLine("Unesite registraciju vozila:");
                                r1.Registracija = Console.ReadLine();
                                Console.WriteLine("Unesite datum (YYYY-MM-DD)");
                                r1.DatumIzn = Convert.ToDateTime(Console.ReadLine());
                                r1.KorisnickoIme = s;
                                retVal = proxy.IzmijeniRezervaciju(r1);

                                if (retVal)
                                    Console.WriteLine("Rezervacija je izmijenjena.\n");
                                else
                                    Console.WriteLine("Doslo je do greske!\n");
                                break;
                            case "10":
                                Rezervacija r2 = new Rezervacija();
                                Console.WriteLine("Unesite registraciju vozila:");
                                r2.Registracija = Console.ReadLine();
                                r2.KorisnickoIme = s;
                                proxy.ObrisiRezervaciju(r2);


                                break;
                            default:
                                break;
                        }
                    } while (true);
                }
            }
        }
    }
}
