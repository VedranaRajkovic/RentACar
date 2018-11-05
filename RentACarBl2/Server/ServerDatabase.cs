using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerDatabase
    {
        public static readonly Dictionary<long, string> Data = new Dictionary<long, string>();
        public static readonly Dictionary<string, MyUser> Users = new Dictionary<string, MyUser>();
 //pravili smo prilikom autentifikacije, kasnije kada uvodimo permisije dodajemo ih korisnicima
        public ServerDatabase() {
            
            Console.WriteLine("Adding users to server...");
            MyUser pera = new MyUser("pera", "pera");
            pera.AddRight(ERights.Read);
            pera.AddRight(ERights.Write);
            pera.AddRight(ERights.ReadAll);
            ServerDatabase.Users.Add(pera.Username, pera);
            MyUser admin = new MyUser("admin", "admin");
            foreach (ERights right in Enum.GetValues(typeof(ERights)))
            {
                admin.AddRight(right);
            }
            ServerDatabase.Users.Add(admin.Username, admin);
        }

  
    }
}
