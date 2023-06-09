using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Business;
using Domain.IRepositories;
using Infrastructure.Data;
using Unity;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            var container = new UnityContainer();
            container.RegisterType<IAccountRepository, AccountRepository>(TypeLifetime.Singleton);
            container.RegisterType<IAccountService, AccountService>();

            config.DependencyResolver = new UnityResolver(container);

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private interface IAccountServices
        {
        }
    }
}
