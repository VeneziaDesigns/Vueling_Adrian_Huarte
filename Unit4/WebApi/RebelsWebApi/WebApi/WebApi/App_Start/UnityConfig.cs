using System.Web.Http;
using Unity;
using Unity.WebApi;
using WebApi.Domain.DomainEntities.ServiceContracts;
using WebApi.Domain.DomainEntities.ServiceImplementations;
using WebApi.Domain.RepositoryContracts;
using WebApi.Infrastructure.RepositoryImplementations;

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
            container.RegisterType<IDataServices, DataServices>();
            container.RegisterType<IDataRepository, DataRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}