using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;

namespace LoggingApplicationBlockDemo
{
    [ConfigurationElementType(typeof(CustomFormatterData))]
    public class CapitalFormatter:ILogFormatter
    {
        public CapitalFormatter(NameValueCollection collection)
        {
            
        }
        public string Format(LogEntry log)
        {
            return log.Message.ToUpper();
        }
    }
}
