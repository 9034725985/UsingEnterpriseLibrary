using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;
using Microsoft.Practices.Unity;

namespace LoggingApplicationBlockDemo
{
    class Program
    {
        static void Main()
        {
            var container = new UnityContainer();
            container.AddNewExtension<EnterpriseLibraryCoreExtension>();

            var logWriter = container.Resolve<LogWriter>();
            //logWriter.Write("I am Logging!");
            //logWriter.Write("I am Logging!", "Debug", 1, 3000, TraceEventType.Error, "Error Message");


            //var logEntry = new LogEntry
            //    {
            //        Message = "Logging with LogEntry",
            //        Categories = new List<string> {"Debug", "UI"},
            //        Priority = 3,
            //        EventId = 3000,
            //        Title = "Log Title",
            //        Severity = TraceEventType.Warning
            //    };

            //logWriter.Write(logEntry);

            //if (logWriter.IsLoggingEnabled())
            //    logWriter.Write("Logging using filter", "Demo");

            //logWriter.Write("Demo Logging Message", "Demo");
            //logWriter.Write("UI Logging Message", "UI");
            //logWriter.Write("Another UI Logging Message", "UI");
            //logWriter.Write("Data Logging Messager", "Data");

            var logEntry = new LogEntry
                {
                    Message = "Detailed Message", Categories = new List<string> {"General"}
                };

            var extendedInfo = new Dictionary<string, object>();

            var debugInfoProvider = new DebugInformationProvider();
            debugInfoProvider.PopulateDictionary(extendedInfo);

            var managedSecurity = new ManagedSecurityContextInformationProvider();
            managedSecurity.PopulateDictionary(extendedInfo);

            var unmanagedSecurity = new UnmanagedSecurityContextInformationProvider();
            unmanagedSecurity.PopulateDictionary(extendedInfo);

            var comInfo = new ComPlusInformationProvider();
            comInfo.PopulateDictionary(extendedInfo);

            extendedInfo.Add("My Custom Info", ".... INFO ....");

            logEntry.ExtendedProperties = extendedInfo;

            logWriter.Write(logEntry);
        }
    }
}
