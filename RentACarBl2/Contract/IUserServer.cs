using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IUserServer
    {
        //metode za realizaciju bezbjednosne provjere, autentifikacija i autorizacija
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        string Authenticate(string user, string pass); 
    }
}
