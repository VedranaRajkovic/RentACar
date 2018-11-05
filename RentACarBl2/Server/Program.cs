using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        private static ServiceHost svc = null;
        public static void Main(string[] args) {

            Start();
            Console.ReadKey(true);
            Stop();
        }
        private static void Start()
        {
            svc = new ServiceHost(typeof(Server));
            svc.AddServiceEndpoint(typeof(IServer), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IServer"));
            svc.Open();
            Console.WriteLine("WCF server ready and waiting for requests.");
        }
        private static void Stop()
        {
            svc.Close();
            Console.WriteLine("WCF server stopped.");
        }
    }
}