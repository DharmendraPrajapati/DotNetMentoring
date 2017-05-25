using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingAndLoggingTask
{
    public class EventLogging
    {
        public bool CreateLog(string logName)
        {            
            try
            {
                EventLog.CreateEventSource(logName, logName);

                var eventLog = new EventLog {Source = logName, Log = logName};
                eventLog.WriteEntry("Created");
                return true;
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);

                throw ;
            }

           
        }
    }
}
