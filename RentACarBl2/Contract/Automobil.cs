using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public enum TipAutomobila { Auto,Kombi,Limuzina,Karavan,Kabriolet}
    [DataContract]
    public class Automobil
    {
        private TipAutomobila tipA;
        private string registracija;
        private bool iznajmljen = false;

        public Automobil() {

        }
        public Automobil(string reg, TipAutomobila tipA)
        {
            Registracija = reg;
            Tip = tipA;
        }

        [DataMember]
        public TipAutomobila Tip
        {
            get
            {
                return tipA;
            }

            set
            {
                tipA = value;
            }
        }

        [DataMember]
        public string Registracija
        {
            get
            {
                return registracija;
            }

            set
            {
                registracija = value;
            }
        }

        [DataMember]
        public bool Iznajmljen
        {
            get
            {
                return iznajmljen;
            }

            set
            {
                iznajmljen = value;
            }
        }



    }
}
