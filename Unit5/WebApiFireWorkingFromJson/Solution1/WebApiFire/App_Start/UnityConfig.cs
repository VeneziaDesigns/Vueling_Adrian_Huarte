using System.Net.Http;
using System.Web.Http;
using FireDomain;
using FireInfrastructure;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace WebApiFire
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFireService, FireService>();
            container.RegisterType<IPokemonRepository, PokemonRepository>();
            


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}