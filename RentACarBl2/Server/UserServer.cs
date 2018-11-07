using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class UserServer : IUserServer
    {
        public UserServer()
        {
            Console.WriteLine("Adding users to server...");

            Korisnik danka = new Korisnik("danka", "789");
            danka.AddRight(ERights.Read);
            ServerDatabase.Korisnici.Add(danka.User, danka);


            //Korisnik marko = new Korisnik("marko", "321");
            //marko.AddRight(ERights.Read);
            //ServerDatabase.Korisnici.Add(marko.Username, marko);

            Admin admin = new Admin("admin", "admin");

            foreach (ERights right in Enum.GetValues(typeof(ERights))) //pay attention!
            {
                admin.AddRight(right);
            }
            ServerDatabase.Admin.Add(admin.Username, admin);
        }
        //treba i za admina 
        public string Authenticate(string user, string pass)
        {
            Console.WriteLine("Authenticaticating...");

            if (ServerDatabase.Korisnici.ContainsKey(user))
            {
                if (ServerDatabase.Korisnici[user].Pass == pass) //Pass je iz klase Korisnik
                {
                    ServerDatabase.Korisnici[user].Authenticated = true;
                    return "Success";
                }
                else
                {
                    SecurityException ex = new SecurityException();
                    ex.Reason = "Invalid password.";
                    throw new FaultException<SecurityException>(ex);
                }
            }
            else
            {
                SecurityException ex = new SecurityException();
                ex.Reason = "Invalid username.";
                throw new FaultException<SecurityException>(ex);
            }
        }
        public static bool IsUserAuthenticated(string username) {
            if (ServerDatabase.Korisnici.ContainsKey(username)) {
                return ServerDatabase.Korisnici[username].Authenticated;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserAuthorized(string username, ERights right) {
            if (ServerDatabase.Korisnici.ContainsKey(username)){
                return ServerDatabase.Korisnici[username].HasRight(right);
            }
            else
            {
                return false;
            }
        }
    }
}
