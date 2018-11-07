using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManager
{
    public class Audit : IDisposable
    {
        //prvi korak inicijalizacija promjenljivih za upravljanjem Windows Event Logom
        private EventLog customLog = null;
        private string logName = string.Empty;

        public Audit(string LogName,string SourceName)
        {
            try
            {
                logName = LogName;

                if (!EventLog.SourceExists(SourceName)) //kreiranje logfajla ukoliko ne postoji
                {
                    EventLog.CreateEventSource(SourceName, LogName);
                }

                customLog = new EventLog(LogName, Environment.MachineName, SourceName); //registrovanje
            }
            catch (Exception e)
            {
                customLog = null;
                Console.WriteLine("Error while trying to create log handle. Error = {0}", e.Message);
            }
        }
        public void AuthenticationSuccess(string userName)
        {
            // string UserAuthenticationSuccess -> read string format from .resx file
            if (customLog != null)
            {
                string message = String.Format(AuditEvents.UserAuthenticationSuccess, userName);
                customLog.WriteEntry(message);
                // string message -> create message based on UserAuthenticationSuccess and params
                // write message in customLog, EventLogEntryType is Information or SuccessAudit 
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthenticationSuccess));
            }
        }

        public  void AuthorizationSuccess(string userName, string serviceName)
        {
            if (customLog != null)
            {
                string message = String.Format(AuditEvents.UserAuthorizationSuccess, userName, serviceName);
                customLog.WriteEntry(message);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthorizationSuccess));
            }
        }
        public void AuthorizationFailed(string userName, string serviceName, string reason)
        {
            if (customLog != null)
            {
                string message = String.Format(AuditEvents.UserAuthorizationFailed, userName, serviceName, reason);
                customLog.WriteEntry(message, EventLogEntryType.Error);
            }
            else
            {
                throw new ArgumentException(string.Format("Error while trying to write event (eventid = {0}) to event log.", (int)AuditEventTypes.UserAuthorizationFailed));
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
