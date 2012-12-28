using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;

namespace LoggingApplicationBlockDemo
{
    [ConfigurationElementType(typeof(CustomLogFilterData))]
    public class BlackListFilter :ILogFilter
    {
        private readonly string _disallowedWord;

        public BlackListFilter(NameValueCollection collection)
        {
            _disallowedWord = collection["blacklist"];
        }

        public bool Filter(LogEntry log)
        {
            return !log.Message.Contains(_disallowedWord);
        }

        public string Name { get { return "Black List Filter"; } }
    }
}
