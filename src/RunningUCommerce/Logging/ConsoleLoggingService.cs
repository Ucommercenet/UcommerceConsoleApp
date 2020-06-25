using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningUCommerce.Logging
{
    public class ConsoleLoggingService : Ucommerce.Infrastructure.Logging.ILoggingService
    {
        public void Log<T>(string customMessage)
        {
            Console.WriteLine(customMessage);
        }

        public void Log<T>(Exception exception)
        {
            Console.WriteLine(exception);
        }

        public void Log<T>(Exception exception, string customMessage)
        {
            Console.WriteLine(customMessage);
            Console.WriteLine(exception);
        }
    }
}
