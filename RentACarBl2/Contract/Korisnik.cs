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

        bool _authenticated;
        string password = string.Empty; //da se sifra ne bi skladistila u citljivom formatu, zbog bezbjednosti
        HashSet<ERights> _rights = new HashSet<ERights>();
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

        public Korisnik()
        {
            List<Korisnik> list = new List<Korisnik>();//mora se inicijalizovati lista

            //Username = user;
            //Password = pass;


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
