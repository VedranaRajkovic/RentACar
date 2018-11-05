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
   public class Auta
    {
        private string opisA,markaA,modelA,tipA, bojaAuta,motorA,snagaMotora,cijenaA,registracijaAuta;
        //private DateTime registracijaAuta;
        private int godProizvodnje;
        private bool iznajmljeno;

        public Auta (string opis,string marka, string model,string motor, string snaga,string tip, int godProizv, string boja, string cijena, string reg)
        {
            opisA = opis;
            markaA = marka;
            modelA = model;
            motorA = motor;
            snagaMotora = snaga;
            tipA = tip;
            godProizvodnje = godProizv;
            bojaAuta = boja;
            cijenaA = cijena;
            registracijaAuta = reg;
        }
        public Auta()
        {
            List<Auta> autaL = new List<Auta>();
        }

        [DataMember]
        [XmlElement]
        public string OpisA
        {
            get { return opisA; }
            set { opisA = value; }
        }


        [DataMember]
        [XmlElement]
        public string MarkaA
        {
            get { return markaA; }
            set { markaA = value; }
        }

        [DataMember]
        [XmlElement]
        public string ModelA
        {
            get { return modelA; }
            set { modelA = value; }
        }

        [DataMember]
        [XmlElement]
        public string MotorA
        {
            get { return motorA; }
            set { motorA = value; }
        }

        [DataMember]
        [XmlElement]
        public string SnagaMotora
        {
            get { return snagaMotora; }
            set { snagaMotora = value; }
        }

        [DataMember]
        [XmlElement]
        public string TipA
        {
            get { return tipA; }
            set { tipA = value; }
        }

        [DataMember]
        [XmlElement]
        public int GodProizvodnje
        {
            get { return godProizvodnje; }
            set { godProizvodnje = value; }
        }

        [DataMember]
        [XmlElement]
        public string BojaAuta
        {
            get { return bojaAuta; }
            set { bojaAuta = value; }
        }

        [DataMember]
        [XmlElement]
        public string CijenaA
        {
            get { return cijenaA; }
            set { cijenaA = value; }
        }

        [DataMember]
        [XmlElement]
        public string RegistracijaAuta
        {
            get { return registracijaAuta; }
            set { registracijaAuta = value; }
        }


        [DataMember]
        [XmlElement]
        public bool Iznajmljeno
        {
            get { return iznajmljeno; }
            set { iznajmljeno = value; }
        }
    }
}

