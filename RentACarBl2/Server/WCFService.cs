using Contract;
using SecurityManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class WCFService : IServer
    {
        public string ispisi(string ime,string pass)
        {

            Console.WriteLine(ime,pass);
            Audit a = new Audit();
            return null;
        }
    }
}
