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
    public class Korisnik
    {
  

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

        public Korisnik()
        {
            List<Korisnik> list = new List<Korisnik>();//mora se inicijalizovati lista

        }

    }
}
