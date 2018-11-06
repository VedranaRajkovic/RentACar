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
            Administrate = 3
        }

        public enum Roles //uloge
        {
            User = 0,
            Admin = 1,
            GoldenUser = 2
        }
    }
}
