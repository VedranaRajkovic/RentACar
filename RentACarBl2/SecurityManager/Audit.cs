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
        private static EventLog customLog = null;
        const string sourceName = "Manager";
        const string logName = "Logger";

        //kreiram windows event log datoteku
        public Audit(/*string LogName,string SourceName*/)
        {
            try
            {
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                }

                customLog = new EventLog(logName, Environment.MachineName, sourceName);
            }
            catch (Exception e)
            {
                customLog = null;

                Console.WriteLine("Error while trying to create log handle. Error: {0}.", e.Message);
            }
        }
        //biljezim dogadjaj, imam poruku o dogadjaju koju je potrebno upisati u log
        public static void AnnotateEvent(string message)
        {
            customLog.WriteEntry(message);
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
