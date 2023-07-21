using System.Web.Http;
using SpatialCoordinatesDomain.ServiceImplementation;
using Unity;
using Unity.WebApi;
using SpatialCoordinatesDomain.IContracts;
using SpatialCoordinatesDomain.RepositoryContracts;
using SpatialCoordinatesInfrastructure.Data.CoordinatesRepository;

namespace SpatialCoordinates
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICoordinateService, CoordinatesServices>();
            container.RegisterType<ICoordinatesRepository, CoordinatesRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}