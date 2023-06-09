using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.IServices;

namespace Presentation.Screens
{
    public class MainMenu
    {
        private string option;

        private readonly IWorkersServices _workersServices;

        private readonly ITeamServices _teamServices;

        private readonly ITaskServices _taskServices;

        private readonly OptionWorkerScreen _optionWorkerScreen;

        public MainMenu(IWorkersServices workersServices)
        {
            _workersServices = workersServices;
            _optionWorkerScreen = new OptionWorkerScreen(_workersServices);
        }
        public MainMenu(ITeamServices teamServices)
        {
            _teamServices = teamServices;
        }
        public MainMenu(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        public void Start()
        {
            do
            {
                ShowMenuAndGetOption();
                ProcessSelectedOption();
            } while (option != "12");
        }
        private void ShowMenuAndGetOption()
        {
            Console.WriteLine("1. Register new IT worker");
            Console.WriteLine("2. Register new team");
            Console.WriteLine("3. Register new task (unassigned to anyone)");
            Console.WriteLine("4. List all team names");
            Console.WriteLine("5. List team members by team name");
            Console.WriteLine("6. List unassigned tasksList");
            Console.WriteLine("7. List task assignments by team name");
            Console.WriteLine("8. Assign IT worker to a team as manager");
            Console.WriteLine("9. Assign IT worker to a team as technician");
            Console.WriteLine("10. Assign task to IT worker");
            Console.WriteLine("11. Unregister worker");
            Console.WriteLine("12. Exit");
            option = Console.ReadLine();

            Console.Clear();
        }

        private void ProcessSelectedOption()
        {
            switch (option)
            {
                case "1":
                    _optionWorkerScreen.Start();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "10":
                    break;
                case "11":
                    break;
                case "12":
                    Console.WriteLine("Bye!!!");
                    break;
                default:
                    Console.WriteLine("Please select an option from the list");
                    break;
            }
        }
    }
}
