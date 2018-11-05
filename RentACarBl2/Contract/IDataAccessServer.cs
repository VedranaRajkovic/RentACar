using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    [ServiceContract]
    public interface IDataAccessServer
    {
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        void Write(string username, long id, string text);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        [FaultContract(typeof(NotFoundException))]
        string Read(string username, long id);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        Dictionary<long, string> ReadAll(string username);

    }
}
