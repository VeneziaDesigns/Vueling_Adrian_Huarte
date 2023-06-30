using System.IO;
using System;
using System.Web.Http;
using Serilog;
using Serilog.Extensions.Logging;
using Unity;
using Unity.Microsoft.Logging;
using Unity.WebApi;

namespace AsyncProgramming
{
    public static class UnityConfig
    {
        // Creamos la var Static ya que la clase lo es
        private static string _logFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "AsyncProgrammingLog.log");

        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddExtension(new LoggingExtension());

            Microsoft.Extensions.Logging.ILogger logger = new SerilogLoggerProvider(new LoggerConfiguration()
                    .WriteTo.File(_logFilePath).CreateLogger()).CreateLogger("AsyncProgrammingLog");
            container.RegisterInstance(logger);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}