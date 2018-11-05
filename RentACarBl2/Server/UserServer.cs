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
        public string Authenticate(string user, string pass)
        {
            Console.WriteLine("Authenticaticating...");

            if (ServerDatabase.Users.ContainsKey(user))
            {
                if (ServerDatabase.Users[user].Password == pass)
                {
                    ServerDatabase.Users[user].Authenticated = true;
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
            if (ServerDatabase.Users.ContainsKey(username)) {
                return ServerDatabase.Users[username].Authenticated;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserAuthorized(string username, ERights right) {
            if (ServerDatabase.Users.ContainsKey(username)){
                return ServerDatabase.Users[username].HasRight(right);
            }
            else
            {
                return false;
            }
        }
    }
}
