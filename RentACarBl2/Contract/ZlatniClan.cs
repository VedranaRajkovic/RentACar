﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Contract
{
    [DataContract]
   public class ZlatniClan
    {
        [DataMember]
        [XmlElement]
        public double BrKartice { get; set; }

       
    }
}
