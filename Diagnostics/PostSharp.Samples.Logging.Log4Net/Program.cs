﻿using System.IO;
using log4net.Config;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Log4Net;
using PostSharp.Samples.Logging.BusinessLogic;

[assembly: Log]


namespace PostSharp.Samples.Logging.Log4Net
{
    [Log(AttributeExclude = true)]
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Log4Net
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

            // Configure PostSharp Logging to use Log4Net
            var log4NetLoggingBackend = new Log4NetLoggingBackend();
            LoggingServices.DefaultBackend = log4NetLoggingBackend;

            // Simulate some business logic.
            QueueProcessor.ProcessQueue(@".\Private$\SyncRequestQueue");
        }
    }
}
