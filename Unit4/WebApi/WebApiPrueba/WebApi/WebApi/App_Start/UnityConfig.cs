using System.Web.Http;
using DataDomain.RepositoryContracts;
using DataDomain.ServiceContracts;
using DataDomain.ServiceImplementation;
using DataInfrastructure;
using Unity;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataService, DataServices>();
            container.RegisterType<IDataRepository, DataRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}