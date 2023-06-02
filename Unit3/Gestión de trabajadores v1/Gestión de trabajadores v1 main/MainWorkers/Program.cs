using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibraryWorkers;
using TaskStatus = ClassLibraryWorkers.TaskStatus;

namespace MainWorkers
{
    public class Menu
    {
        private List<ITWorker> workersList;
        private List<Team> teamsList;
        private List<Tasks> tasksList;

        public Menu()
        {
            workersList = new List<ITWorker>();
            teamsList = new List<Team>();
            tasksList = new List<Tasks>();
        }

        #region Menu
        public void Run()
        {
            bool exit = false;

            do
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

                bool valid = int.TryParse(Console.ReadLine(), out int option);

                if (valid)
                {
                    switch (option)
                    {
                        case 1:
                            RegisterITWorker();
                            break;
                        case 2:
                            RegisterNewTeam();
                            break;
                        case 3:
                            RegisterNewTask();
                            break;
                        case 4:
                            ListAllteamsList();
                            break;
                        case 5:
                            ListTeamMenmbersByTeamName();
                            break;
                        case 6:
                            ListUnassignedTasks();
                            break;
                        case 7:
                            ListTaskAssignmentsByTeamName();
                            break;
                        case 8:
                            AssignITWorkerTeamManager();
                            break;
                        case 9:
                            AssignTechnicianITWorker();
                            break;
                        case 10:
                            AssignTaskToITWorker();
                            break;
                        case 11:
                            UnregisterWorker();
                            break;
                        case 12:
                            exit = true;
                            Console.WriteLine("Bye");
                            break;
                        default:
                            Console.WriteLine($"{option} is not in the list of valid options, please select an option from the list.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("The format entered is not correct, please select a valid option number.");
                }

                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                Console.Clear();

            } while (!exit);
        }
        #endregion

        #region RegisterITWorker
        public void RegisterITWorker()
        {
            Console.Clear();
            Console.WriteLine("Registering a new IT worker");

            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter surname: ");
            string surname = Console.ReadLine();

            bool validBornDate;
            int count = 0;
            DateTime bornDate;

            do
            {
                Console.WriteLine("Enter born date (dd-mm-yyyy): ");

                validBornDate = DateTime.TryParseExact(
                    Console.ReadLine(), new[] { "dd-MM-yyyy", "dd/MM/yyyy" },
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out bornDate);


                if (!validBornDate)
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
                    count++;
                }
                if (count == 3)
                {
                    //Si la fecha no es valida le ponemos la 
                    //fecha de hoy por si es menor de edad
                    Console.WriteLine("Too many unsuccessful attempts, could be a minor");
                    bornDate = new DateTime(2010, 08, 23);
                }
            } while (!validBornDate && count <= 2);

            int age = (int)CalculateAge(bornDate);

            if (age < 18)
            {
                Console.WriteLine("The minimum age to become an ITWorker is 18 years old.");
            }
            else
            {
                bool validYears;
                int yearsExperience;
                count = 0;

                do
                {
                    Console.WriteLine("Enter years of experience: ");
                    validYears = int.TryParse(Console.ReadLine(), out yearsExperience);
                    count++;

                    if (!validYears)
                    {
                        Console.WriteLine("Please introducing a years of experience.");
                    }
                    if (count == 3)
                    {
                        yearsExperience = 0;
                    }
                } while (!validYears && count <= 2);


                Level level = Level.Junior;
                bool exit = false;
                count = 0;

                do
                {
                    Console.Write("Enter worker level (Junior, Medium, Senior, J, M, S): ");
                    string input = Console.ReadLine().ToLower();
                    count++;

                    switch (input)
                    {
                        case "junior":
                            level = Level.Junior;
                            exit = true;
                            break;
                        case "medium":
                            level = Level.Medium;
                            exit = true;
                            break;
                        case "senior":
                            level = Level.Senior;
                            exit = true;
                            break;
                        case "j":
                            level = Level.Junior;
                            exit = true;
                            break;
                        case "m":
                            level = Level.Medium;
                            exit = true;
                            break;
                        case "s":
                            level = Level.Senior;
                            exit = true;
                            break;
                        default:
                            Console.WriteLine($"{input} is not a valid option. Please select an option from the list.");
                            break;
                    }
                } while (exit == false && count <= 2);

                if (level.Equals(Level.Senior) && yearsExperience < 5)
                {
                    Console.WriteLine("The minimum experience required for senior level is 5 years.");
                }
                else
                {
                    List<string> techKnowledges = new List<string>();

                    //Usamos un HashSet para saber si esa opcion ya ha sido añadida
                    HashSet<int> selectedOptions = new HashSet<int>();

                    bool done = false;

                    do
                    {
                        Console.WriteLine("Enter worker tech knowledges: ");
                        Console.WriteLine("1 - .NET");
                        Console.WriteLine("2 - Java");
                        Console.WriteLine("3 - React");
                        Console.WriteLine("4 - Kotlin");
                        Console.WriteLine("5 - SQL Server");
                        Console.WriteLine("6 - Git/Github");
                        Console.WriteLine("7 - PHP");
                        Console.WriteLine("8 - Done");

                        bool valid = int.TryParse(Console.ReadLine(), out int option);

                        if (valid)
                        {
                            if (selectedOptions.Contains(option))
                            {
                                Console.WriteLine("You have already selected this option. Please choose a different option.");
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                switch (option)
                                {
                                    case 1:
                                        techKnowledges.Add(".NET");
                                        break;
                                    case 2:
                                        techKnowledges.Add("Java");
                                        break;
                                    case 3:
                                        techKnowledges.Add("React");
                                        break;
                                    case 4:
                                        techKnowledges.Add("Kotlin");
                                        break;
                                    case 5:
                                        techKnowledges.Add("SQL Server");
                                        break;
                                    case 6:
                                        techKnowledges.Add("Git/Github");
                                        break;
                                    case 7:
                                        techKnowledges.Add("PHP");
                                        break;
                                    case 8:
                                        done = true;
                                        break;
                                    default:
                                        Console.WriteLine($"{option} is not in the list of valid options, please select an option from the list.");
                                        break;
                                }

                                selectedOptions.Add(option);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The format entered is not correct, please select a valid option number.");
                        }

                        Console.Clear();

                    } while (!done);


                    ITWorker work = new ITWorker(name, surname, bornDate, yearsExperience, techKnowledges, level);
                    workersList.Add(work);
                    Console.WriteLine($"Employee '{work.Name}' registered successfully with te id {work.Id}.");
                    Thread.Sleep(2500);
                }
            }
        }
        #endregion

        #region RegisterNewTeam
        public void RegisterNewTeam()
        {
            Console.WriteLine("Registering new team:");

            Console.Write("Enter team name: ");
            string teamName = Console.ReadLine();

            if (string.IsNullOrEmpty(teamName))
            {
                Console.WriteLine("Team name can not be null or empty");
            }
            else
            {
                Team team = new Team(teamName);
                teamsList.Add(team);

                Console.WriteLine($"Team '{team.TeamName}' registered successfully.");
            }

        }
        #endregion

        #region RegisterNewTask
        public void RegisterNewTask()
        {
            string description;
            string technology = "";
            int count = 0;

            do
            {
                Console.WriteLine("Enter description for task: ");
                description = Console.ReadLine();
                count++;

                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("The description task can not be null or empty");
                }

            } while (string.IsNullOrWhiteSpace(description) && count <= 2);

            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Unsuccessful attempt to register a task, please try again.");

            }
            else
            {
                count = 0;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Enter task technologies: ");
                    Console.WriteLine("1 - .NET");
                    Console.WriteLine("2 - Java");
                    Console.WriteLine("3 - React");
                    Console.WriteLine("4 - Kotlin");
                    Console.WriteLine("5 - SQL Server");
                    Console.WriteLine("6 - Git/Github");
                    Console.WriteLine("7 - PHP");

                    bool valid = int.TryParse(Console.ReadLine(), out int option);
                    count++;

                    if (valid)
                    {
                        switch (option)
                        {
                            case 1:
                                technology = ".NET";
                                break;
                            case 2:
                                technology = "Java";
                                break;
                            case 3:
                                technology = "React";
                                break;
                            case 4:
                                technology = "Kotlin";
                                break;
                            case 5:
                                technology = "SQL Server";
                                break;
                            case 6:
                                technology = "Git/Github";
                                break;
                            case 7:
                                technology = "PHP";
                                break;
                            default:
                                Console.WriteLine($"{option} is not in the list of valid options, please select an option from the list.");
                                Thread.Sleep(2500);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The format entered is not correct, please select a valid option number.");
                        Thread.Sleep(2500);
                    }

                } while (string.IsNullOrWhiteSpace(technology) && count <= 2);

                if (string.IsNullOrWhiteSpace(technology))
                {
                    Console.WriteLine("Unsuccessful attempt to register a task, please try again.");
                    Thread.Sleep(2500);
                }
                else
                {

                    count = 0;
                    TaskStatus status = TaskStatus.Todo;
                    bool exit = false;


                    do
                    {
                        Console.Write("Enter The status of task (To do, Doing, Done): ");
                        string input = Console.ReadLine().ToLower();
                        count++;

                        switch (input)
                        {
                            case "to do":
                                status = TaskStatus.Todo;
                                exit = true;
                                break;
                            case "doing":
                                status = TaskStatus.Doing;
                                exit = true;
                                break;
                            case "done":
                                status = TaskStatus.Done;
                                exit = true;
                                break;
                            default:
                                Console.WriteLine($"{input} is not a valid option. Please select an option from the list.");
                                break;
                        }
                    } while (exit == false && count <= 2);

                    Tasks task = new Tasks(description, technology, status);
                    tasksList.Add(task);
                    Console.WriteLine($"Task {task.Description} successfully created with id {task.Id}.");
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }
        #endregion

        #region ListAllteamsList
        public void ListAllteamsList()
        {
            Console.WriteLine("List of all teamsList: ");
            teamsList.ForEach(t => Console.WriteLine(t.TeamName));
        }
        #endregion 

        #region ListTeamMenmbersByTeamName
        public void ListTeamMenmbersByTeamName()
        {
            Console.WriteLine("Enter the team name");
            teamsList.ForEach(team => Console.WriteLine(team.TeamName));
            string teamName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(teamName))
            {
                Console.WriteLine("Please enter the team name");
            }
            else if (teamsList.Count() == 0)
            {
                Console.WriteLine("No teamsList created");
            }
            else
            {
                Team findTeam = teamsList.Find(team => team.TeamName.Equals(teamName));

                if (findTeam != null)
                {
                    if (findTeam.Technicians.Count == 0)
                    {
                        Console.WriteLine("There are no workers on team");
                    }
                    else
                    {
                        foreach (ITWorker technician in findTeam.Technicians)
                        {
                            Console.WriteLine($"{technician.Name} (ID: {technician.Id})");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Team name not found");
                }
            }
        }
        #endregion

        #region List unassigned tasksList
        public void ListUnassignedTasks()
        {
            if (tasksList.Count == 0)
            {
                Console.WriteLine("No unassigned tasks");
            }
            else
            {
                Console.WriteLine("Unassigned tasks: ");
                foreach (Tasks t in tasksList)
                {
                    //Si el ID de la tarea es 0 es que esta sin asignar
                    if (t.IdWorker == 0)
                    {
                        Console.WriteLine($"Task ID: {t.Id}, description: {t.Description}, " +
                        $"Technology: {t.Technology}, Status: {t.Status}");
                    }
                }
            }
        }
        #endregion

        #region List task assignments by team name
        public void ListTaskAssignmentsByTeamName()
        {
            if (teamsList.Count == 0)
            {
                Console.WriteLine("No teams have been created");
            }
            else
            {
                Console.WriteLine("Select a team from the list: ");
                teamsList.ForEach(t => Console.WriteLine(t.TeamName));
                string team = Console.ReadLine();

                Team findTeam = teamsList.Find(t => t.TeamName.Equals(team));

                if (findTeam == null)
                {
                    Console.WriteLine("Please select a team from the list");
                }
                else
                {
                    if (tasksList.Count == 0)
                    {
                        Console.WriteLine("There are no tasks assigned to this team");
                    }
                    else
                    {
                        Console.WriteLine($"Task assignments for team {findTeam.TeamName}:");
                        foreach (Tasks task in tasksList)
                        {
                            if (task.IdWorker != 0 && findTeam.Technicians.Exists(t => t.Id.Equals(task.IdWorker)))
                            {
                                ITWorker assignedWorker = workersList.Find(w => w.Id.Equals(task.IdWorker));
                                Console.WriteLine($"Task ID: {task.Id}, Description: {task.Description}, Assigned Worker: {assignedWorker.Name}");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Assign IT worker to a team as manager
        public void AssignITWorkerTeamManager()
        {
            if (workersList.Count() == 0)
            {
                Console.WriteLine("No employees have been created");
            }
            else
            {
                Console.WriteLine("Enter the name of the worker you want to add to the team as an IT manager.");
                WorkersList();
                string findName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(findName))
                {
                    Console.WriteLine("Please enter the name of employee of list");
                }
                else
                {

                    ITWorker findWorker = workersList.Find(worker => worker.Name.Equals(findName));

                    if (findWorker == null)
                    {
                        Console.WriteLine("No employee with this name has been found.");
                    }
                    else if (findWorker.WorkerLevel != Level.Senior)
                    {
                        Console.WriteLine($"The level required to become a Manger is Senior\r\n");
                    }
                    else
                    {
                        Console.WriteLine("To which team do you want to add it?");
                        teamsList.ForEach(team => Console.WriteLine(team.TeamName));
                        string addWorkerToTeam = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(addWorkerToTeam))
                        {
                            Console.WriteLine("Please enter the team name of list");
                        }
                        else
                        {
                            Team findTeam = teamsList.Find(team => team.TeamName.Equals(addWorkerToTeam));

                            if (findTeam == null)
                            {
                                Console.WriteLine("Team not found.");
                            }
                            else
                            {
                                findTeam.Manager = findWorker;
                                findTeam.Technicians.Add(findWorker);
                                Console.WriteLine($"The employee {findWorker.Name} was successfully added to the team {findTeam.TeamName}");
                                Thread.Sleep(2500);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region assign IT worker to a team as technician
        public void AssignTechnicianITWorker()
        {

            if (workersList.Count() == 0)
            {
                Console.WriteLine("No employees have been created");
            }
            else
            {
                Console.WriteLine("Enter the name of the worker you want to add to the team as an IT technician.");
                WorkersList();
                string findName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(findName))
                {
                    Console.WriteLine("Please enter the name of employee of list");
                }
                else
                {

                    ITWorker findWorker = workersList.Find(worker => worker.Name.Equals(findName));

                    if (findWorker == null)
                    {
                        Console.WriteLine("No employee with this name has been found.");
                    }
                    else
                    {
                        Console.WriteLine("To which team do you want to add it?");
                        teamsList.ForEach(team => Console.WriteLine(team.TeamName));
                        string addWorkerToTeam = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(addWorkerToTeam))
                        {
                            Console.WriteLine("Please enter the team name of list");
                        }
                        else
                        {
                            Team findTeam = teamsList.Find(team => team.TeamName.Equals(addWorkerToTeam));

                            if (findTeam == null)
                            {
                                Console.WriteLine("Team not found.");
                            }
                            else
                            {
                                findTeam.Technicians.Add(findWorker);
                                Console.WriteLine($"The employee {findWorker.Name} was successfully added to the team {findTeam.TeamName}");
                                Thread.Sleep(2500);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Assign task to IT worker
        public void AssignTaskToITWorker()
        {
            Console.WriteLine("Select the ID of the task you want to assign");
            ListUnassignedTasks();
            int taskId;

            if (!int.TryParse(Console.ReadLine(), out taskId))
            {
                Console.WriteLine("Invalid format.");
            }
            else
            {
                Tasks findTask = tasksList.Find(t => t.Id.Equals(taskId));

                if (findTask == null)
                {
                    Console.WriteLine("The selected id does not correspond to any task");
                }
                else
                {
                    if (findTask.Status.Equals(TaskStatus.Done))
                    {
                        Console.WriteLine("Task is done");
                    }
                    else
                    {
                        Console.WriteLine("Select the ID of the employee to assign the task to.");
                        WorkersList();
                        int workerId;

                        if (!int.TryParse(Console.ReadLine(), out workerId))
                        {
                            Console.WriteLine("Invalid format).");
                        }
                        else
                        {
                            ITWorker findWorker = workersList.Find(w => w.Id.Equals(workerId));
                            if (findWorker != null)
                            {
                                if (findWorker.TechKnowledges.Contains(findTask.Technology))
                                {
                                    //ID de la tarea = ID del trabajador
                                    findTask.IdWorker = findWorker.Id;
                                    Console.WriteLine($"Task ID: {findTask.Id} assigned to IT worker '{findWorker.Name}' (ID: {findWorker.Id}).");
                                }
                                else
                                {
                                    Console.WriteLine($"IT worker '{findWorker.Name}' (ID: {findWorker.Id}) does not have the required technology knowledge for the task.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("IT worker not found.");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Unregister worker
        public void UnregisterWorker()
        {
            Console.WriteLine("Please select a ID of employee to want unregistered");
            WorkersList();
            bool idWorker = int.TryParse(Console.ReadLine(), out int validID);

            if (idWorker == false)
            {
                Console.WriteLine("The number entered is not in the correct format");
            }
            else
            {
                ITWorker findWorker = workersList.Find(worker => worker.Id.Equals(validID));

                if (findWorker == null)
                {
                    Console.WriteLine("The id does not correspond to any employee");
                }
                else
                {
                    Team findTeamWorker = teamsList.Find(team => team.Technicians.Any(w => w.Id.Equals(findWorker.Id)));
                    findTeamWorker.RemoveTechnician(findWorker);
                    workersList.Remove(findWorker);
                    Console.WriteLine($"The employee with id {findWorker.Id} and name {findWorker.Name} has been deregistered.");
                }
            }
        }
        #endregion

        #region ComprobarEdad
        public int CalculateAge(DateTime born)
        {
            int age = DateTime.Today.AddTicks(-born.Ticks).Year - 1;
            return age;
        }
        #endregion

        #region List worker
        public void WorkersList()
        {
            workersList.ForEach(worker => Console.WriteLine($"First name: {worker.Name}, last name: {worker.Surname}, ID: {worker.Id}"));
        }
        #endregion
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Its the same but more simple
            new Menu().Run();

            //Menu menu = new Menu();
            //menu.Run();

            Console.WriteLine("Plase, press any button to finish the application");
            Console.ReadKey();
        }
    }
}
