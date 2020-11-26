using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningUCommerce.Logging
{
    public class ConsoleLoggingService : Ucommerce.Infrastructure.Logging.ILoggingService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Log<T>(string customMessage)
        {
            log.Info(customMessage);
        }

        public void Log<T>(Exception exception)
        {
            Exception exceptionToLog = exception;
            while (exceptionToLog != null)
            {
                log.Error("{0}", exceptionToLog);
                exceptionToLog = exceptionToLog.InnerException;
            }
        }

        public void Log<T>(Exception exception, string customMessage)
        {
            Console.WriteLine(customMessage);
            Exception exceptionToLog = exception;
            while (exceptionToLog != null)
            {
                log.Error("{0}", exceptionToLog);
                exceptionToLog = exceptionToLog.InnerException;
            }
        }
    }
}
