using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainEntities;
using DomainEntities.IRepositories;
using Presentation.Screens;
using Repositories;
using Services;
using Services.IServices;
using Unity;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            RegisterTypes(container);

            MainMenu mainMenu = container.Resolve<MainMenu>();

            mainMenu.Start();
        }
        static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IWorkersRepository, ITWorkersRepository>(TypeLifetime.Singleton);

            container.RegisterType<ITeamRepository, TeamRepository>(TypeLifetime.Singleton);

            container.RegisterType<ITasksRepository, TasksRepository>(TypeLifetime.Singleton);

            container.RegisterType<IWorkersServices, ITWorkerServices>();

            container.RegisterType<ITaskServices, TaskServices>();

            container.RegisterType<ITeamServices, TeamsServices>();

            container.RegisterType<MainMenu>();
        }
    }
}
