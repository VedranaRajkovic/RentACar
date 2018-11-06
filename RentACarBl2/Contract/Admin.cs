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
        [DataMember]
        [XmlElement]
        public string Ime { get; set; }

        [DataMember]
        [XmlElement]
        public string Prezime { get; set; }

        [DataMember]
        [XmlElement]
        public string Username { get; set; }

        [DataMember]
        [XmlElement]
        public string Password { get; set; }

        [DataMember]
        [XmlElement]
        public string Ovlascenje { get; set; }
        [DataMember]
        public bool Authenticated
        {
            get { return _authenticated; }
            set { _authenticated = value; }
        }
    }
}
