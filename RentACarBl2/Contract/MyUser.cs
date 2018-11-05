using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [DataContract]
    public class MyUser
    {
        string _username, _password;
        bool _authenticated;
       
        HashSet<ERights> _rights = new HashSet<ERights>();

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        [DataMember]
        public bool Authenticated
        {
            get { return _authenticated; }
            set { _authenticated = value; }
        }

        public MyUser(string user, string pass)
        {
            _username = user;
            _password = pass;
        }

        //autorizacija
        public void AddRight(ERights right)
        {
            if (!_rights.Contains(right))
            {
                _rights.Add(right);
            }
        }

        public bool HasRight(ERights right)
        {
            return _rights.Contains(right);
        }
    }
}
