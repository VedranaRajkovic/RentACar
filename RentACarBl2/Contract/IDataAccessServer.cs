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
        //ovo su metode za rad sa tekstualnim fajlovima, pravi se novi vs projekat, zatim implemantira se DataAccessProxy u okviru Clients klijentske aplikacije koja poziva metode IDataAccess interfejsa?
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        [FaultContract(typeof(NotFoundException))]
        void Write(string username, long id, string text);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        [FaultContract(typeof(NotFoundException))]
        string Read(string username, long id);

        //[OperationContract]
        //[FaultContract(typeof(SecurityException))]
        //Dictionary<long, string> ReadAll(string username);


        //[ServiceContract]
        //public interface IDataAccess {
        //    [OperationContract]
        //    [FaultContract(typeof(SecurityException))]
        //    [FaultContract(typeof(NotFoundException))]
        //    string Read(string username, string fileName);
        //    [OperationContract]
        //    [FaultContract(typeof(SecurityException))]
        //    [FaultContract(typeof(NotFoundException))]
        //    bool Write(string username, string fileName, string msg);
        //    [OperationContract]
        //    [FaultContract(typeof(SecurityException))]
        //    [FaultContract(typeof(NotFoundException))]
        //    bool Delete(string username, string fileName);
        //}

    }
}
