﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class Audit : IDisposable
    {
        private static EventLog customLog = null;
        const string sourceName = "Manager";
        const string logName = "Logger";

        //kreiram windows event log datoteku
        public Audit(/*string LogName,string SourceName*/)
        {
            try
            {
                //pravi se customLog handle
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                }

                customLog = new EventLog(logName, Environment.MachineName, sourceName);
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }

        public static void AuthenticationSuccess(string userName)
        {
            if (customLog != null)
            {
                //poziva metodu AuditEvents da bi ispisao poruku u Log fajl
                customLog.WriteEntry(string.Format(AuditEvents.UserAuthenticationSuccess, userName), EventLogEntryType.SuccessAudit);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event with id {0} to event log", (int)AuditEventTypes.UserAuthenticationSuccess));
            }
        }

        public static void AuthenticationFailed(string userName)
        {
            if (customLog != null)
            {
                //poziva metodu AuditEvents da bi ispisao poruku u Log fajl
                customLog.WriteEntry(string.Format(AuditEvents.UserAuthenticationFailed, userName), EventLogEntryType.SuccessAudit);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event with id {0} to event log", (int)AuditEventTypes.UserAuthenticationFailed));
            }
        }

        public static void AuthorizationSuccess(string userName, string serviceName)
        {
            if (customLog != null)
            {
                //poziva metodu AuditEvents da bi ispisao poruku u Log fajl
                customLog.WriteEntry(string.Format(AuditEvents.UserAuthorizationSuccess, userName, serviceName), EventLogEntryType.SuccessAudit);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event with id {0} to event log", (int)AuditEventTypes.UserAuthorizationSuccess));
            }
        }

        public static void AuthorizationFailed(string userName, string serviceName, string reason)
        {
            if (customLog != null)
            {
                //poziva metodu AuditEvents da bi ispisao poruku u Log fajl
                customLog.WriteEntry(string.Format(AuditEvents.UserAuthorizationFailed, userName, serviceName, reason), EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event with id {0} to event log", (int)AuditEventTypes.UserAuthorizationFailed));
            }
        }



        public void Dispose()
        {
            if (customLog != null)
            {
                customLog.Dispose();
                customLog = null;
            }
        }
    }
}
