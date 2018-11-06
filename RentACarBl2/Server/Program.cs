using Contract;
using SecurityManager;
using Server;
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
        private static ServiceHost svc1 = null;
        //private static ServiceHost svc3 = null;
        public static void Main(string[] args) {

            Start();
            Console.ReadKey(true);
            Stop();
           
        }
        private static void Start()
        {
            svc = new ServiceHost(typeof(Server));
            svc.AddServiceEndpoint(typeof(IServer), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IServer"));
            //svc.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager(); //iz drugih vjezbi
            svc.Open();
            svc1 = new ServiceHost(typeof(UserServer));
            svc1.AddServiceEndpoint(typeof(IUserServer), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IUserServer"));
            //svc1.Authorization.ServiceAuthorizationManager = new CustomAuthorizationManager(); //iz drugih vjezbi

            //List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            //policies.Add(new CustomAuthorizationPolicy());
            //svc1.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            svc1.Open();
            //svc3 = new ServiceHost(typeof(DataAccessServer));
            //svc3.AddServiceEndpoint(typeof(IDataAccessServer), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IDataAccessServer"));
            //svc3.Open();
            Console.WriteLine("WCF server ready and waiting for requests.");
           

        }
      
        private static void Stop()
        {
            svc.Close();
            svc1.Close();
            //svc3.Close();
            Console.WriteLine("WCF server stopped.");
        }
      
    }
}