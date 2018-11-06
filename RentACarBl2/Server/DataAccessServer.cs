using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DataAccessServer : IDataAccessServer
    {
        public object Identity { get; private set; }

        public void Write(string username, long id, string text)
        {
            if (UserServer.IsUserAuthenticated(username))
            {
                if (UserServer.IsUserAuthorized(username, ERights.Write))
                {
                    ServerDatabase.Data[id] = text;
                }
                else
                {
                    SecurityException ex = new SecurityException() { Reason = "User not athorized to execute this operation" };
                    throw new FaultException<SecurityException>(ex);
                }
            }
            else
            {
                SecurityException ex = new SecurityException() { Reason = "User is not authenticated" };
                throw new FaultException<SecurityException>(ex);
            }
        }

        public string Read(string username, long id)
        {
            if (UserServer.IsUserAuthenticated(username))
            {
                if (ServerDatabase.Data.ContainsKey(id))
                {
                    if (UserServer.IsUserAuthorized(username, ERights.Read))
                    {
                        return ServerDatabase.Data[id];
                    }
                    else
                    {
                        SecurityException ex = new SecurityException() { Reason = "User not athorized to execute this operation" };
                        throw new FaultException<SecurityException>(ex);
                    }
                }
                else
                {
                    NotFoundException ex = new NotFoundException() { Reason = "Idem with ID this cannot be found." };
                    throw new FaultException<NotFoundException>(ex);
                }
                //foreach (IdentityReference group in this.Identity.Groups)
                //{
                //    Securityidentifier sid =
                //    (SecurityIdentifier)group.Translate(typeof(SecurityIdentifier));
                //    var name = sid.Translate(typeof(NTAccunt));
                //}
            }
            else
            {
                SecurityException ex = new SecurityException() { Reason = "User is not authenticated" };
                throw new FaultException<SecurityException>(ex);
            }

           
        }


        //public Dictionary<long, string> ReadAll(string username)
        //{
        //    if (UserServer.IsUserAuthenticated(username))
        //    {
        //        if (UserServer.IsUserAuthorized(username, ERights.ReadAll))
        //        {
        //            return ServerDatabase.Data;
        //        }
        //        else
        //        {
        //            NotFoundException ex = new NotFoundException() { Reason = "User not athorized to execute this operation" };
        //            throw new FaultException<NotFoundException>(ex);
        //        }
        //    }
        //    else
        //    {
        //        NotFoundException ex = new NotFoundException() { Reason = "User is not authenticated" };
        //        throw new FaultException<NotFoundException>(ex);
        //    }

        //}
    }
}
