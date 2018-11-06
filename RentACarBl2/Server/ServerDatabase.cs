using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerDatabase
    {
        public static readonly Dictionary<long, string> Data = new Dictionary<long, string>();
        //public static readonly Dictionary<string, MyUser> Users = new Dictionary<string, MyUser>();
        public static readonly Dictionary<string, Korisnik> Korisnici = new Dictionary<string, Korisnik>();
        public static readonly Dictionary<string, Admin> Admin = new Dictionary<string, Admin>();
        //pravili smo prilikom autentifikacije, kasnije kada uvodimo permisije dodajemo ih korisnicima
        public ServerDatabase() {
            
            Console.WriteLine("Adding users to server...");
         
            Korisnik k1 = new Korisnik();
            //k1.Ime = "Jelena";
            //k1.Prezime = "Ilic";
            //k1.Username = "jeca";
            //k1.Password = "123";
            //k1.Ovlascenje = "korisnik";
            k1.AddRight(ERights.Read);
            k1.AddRight(ERights.Write);
            k1.AddRight(ERights.ReadAll);
            ServerDatabase.Korisnici.Add(k1.Username, k1);
      

            //    MyUser admin = new MyUser("admin", "admin");
            //    foreach (ERights right in Enum.GetValues(typeof(ERights)))
            //    {
            //        admin.AddRight(right);
            //    }
            //    ServerDatabase.Users.Add(admin.Username, admin);
            //}
           
        }

    }
    }
