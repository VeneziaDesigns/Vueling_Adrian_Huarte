using System.IO;
using System;
using System.Web.Http;
using PokeAPIManagement.Business.ServiceContracts;
using PokeAPIManagement.Business.ServiceImplementations;
using PokeAPIManagement.Data.RepositoryImplementations;
using PokeAPIManagement.Domain.RepositoryContracts;
using Unity;
using Unity.WebApi;
using Serilog.Extensions.Logging;
using Serilog;
using Unity.Microsoft.Logging;
using PokeAPIManagement.Data.RepositoryImplementations.SecurityCopy;

namespace PokeAPIManagement.WebAPI
{
    public static class UnityConfig
    {
        private static string _logFilePath = @"C:\Users\ahuarte\source\repos\Vueling_Adrian_Huarte\PokeAPIManagement\PokeAPIManagement\Infrastructure.Logging\Logs\PokeApiManagementLog.log";

        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddExtension(new LoggingExtension());

            Microsoft.Extensions.Logging.ILogger logger = new SerilogLoggerProvider(new LoggerConfiguration()
                .MinimumLevel.Verbose().WriteTo.File(_logFilePath).CreateLogger()).CreateLogger("SerilogWithDIConfiguration");
            container.RegisterInstance(logger);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPokemonAttacksService, PokemonService>();
            container.RegisterType<IPokemonTypesRepository, PokemonTypesRepository>();
            container.RegisterType<IPokemonMovementsRepository, PokemonMovementsRepository>();
            container.RegisterType<ISecurityImplementation, SecurityImplementation>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}