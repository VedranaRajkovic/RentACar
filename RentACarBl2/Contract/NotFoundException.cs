using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
        [DataContract]
        public class NotFoundException
        {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) { Message = message; }
        [DataMember]
        public string Message { get; private set; }
        public string Reason { get; set; }
    }
    }

