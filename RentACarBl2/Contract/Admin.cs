using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    [DataContract]
    public class Admin
    {
        string password = string.Empty;
        bool _authenticated;

        HashSet<ERights> _rights = new HashSet<ERights>();
       

        public Admin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Admin()
        {
        }

        //[DataMember]
        //[XmlElement]
        //public string Ime { get; set; }

        //[DataMember]
        //[XmlElement]
        //public string Prezime { get; set; }

        [DataMember]
        [XmlElement]
        public string Username { get; set; }

        [DataMember]
        [XmlElement]
        public string Password { get; set; }

        //[DataMember]
        //[XmlElement]
        //public string Ovlascenje { get; set; }
        [DataMember]
        public bool Authenticated
        {
            get { return _authenticated; }
            set { _authenticated = value; }
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
