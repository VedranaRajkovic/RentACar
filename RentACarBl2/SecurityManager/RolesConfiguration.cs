using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SecurityManager
{
    public class RolesConfiguration
    {
        public enum Permisions //privilegije
        {
            Add = 0,
            Modify = 1,
            Delete = 2,
            Administrate = 3,
            Read = 4
        }

        public enum Roles //uloge
        {
            User = 0,
            Admin = 1,
            GoldenUser = 2
        }
        public class RolesConfig
        {
         static string[] Admin = new string[] { Permisions.Add.ToString(), Permisions.Modify.ToString(), Permisions.Delete.ToString(), Permisions.Administrate.ToString() };
        static string[] User = new string[] { Permisions.Add.ToString(), Permisions.Modify.ToString(), Permisions.Delete.ToString() };
        static string[] GoldenUser = new string[] { Permisions.Read.ToString() };
        static string[] Empty = new string[] { };

        public static string[] GetPermissions(string role)
        {
            switch (role)
            {
                case "admins": return Admin;
                case "users": return User;
                case "goldenusers": return GoldenUser;
                default: return Empty;
            }
        }
    }
    }
}
