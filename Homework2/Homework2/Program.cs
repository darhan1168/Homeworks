namespace Homework2
{
    class Program
    {
        public static void Main(string[] args)
        {
        public static void ConsoleApp()
        {
            ManagedProject managedProject = new ManagedProject();
            ManagedTasks managedTasks = new ManagedTasks();
            ManagedStaff managedStaff = new ManagedStaff();
            ConsoleRobot consoleRobot = new ConsoleRobot();

            while (true)
            {
                consoleRobot.WriteMassage("Choose what you want (1 - Project status review, 2 - Addition of options, 3 - Deletion of options, 4 - Replacement of options, 5 - Watching status of options,  6 - Stop console app)");
                string? answerUserMethod = consoleRobot.ReadInput();

                switch (answerUserMethod)
                {
                    case "1":
                        break;
                    case "2":
                        consoleRobot.WriteMassage("Choose what you want add (1 - new project, 2 - new task, 3 - new staff)");
                        string? answerUserAdd = consoleRobot.ReadInput();

                        switch (answerUserAdd)
                        {
                            case "1":
                                consoleRobot.WriteMassage("Enter name of project");
                                string? newNameProject = consoleRobot.ReadInput();

                                consoleRobot.WriteMassage("Enter description of project");
                                string? newDescriptionProject = consoleRobot.ReadInput();
                                
                                consoleRobot.WriteMassage("Enter deadline of project");
                                string? newDeadlineProject = consoleRobot.ReadInput();
                                
                                consoleRobot.WriteMassage("Enter budget of project");
                                decimal newBudgetProject = decimal.Parse(consoleRobot.ReadInput() ?? string.Empty);

                                if (newNameProject != null && newDescriptionProject != null && newDeadlineProject != null)
                                {
                                    Project newProject = new Project(newNameProject, newDescriptionProject, newDeadlineProject, newBudgetProject);
                                    managedProject.CreateProject(newProject);
                                    consoleRobot.WriteMassage("Your new project added");
                                    managedProject.ShowProject();
                                }
                                else
                                    throw new ArgumentNullException();
                                
                                break;
                            case "2":
                                consoleRobot.WriteMassage("Enter description of task");
                                string? newDescriptionTask = consoleRobot.ReadInput();

                                if (newDescriptionTask != null)
                                {
                                    Tasks tasks = new Tasks(newDescriptionTask);
                                    managedTasks.CreateTasks(tasks);
                                    consoleRobot.WriteMassage("Your new task added");
                                    managedTasks.ShowTasks();
                                }
                                else
                                    throw new ArgumentNullException();
                                
                                break;
                            case "3":
                                consoleRobot.WriteMassage("Enter name of person");
                                string? newNameStaff = consoleRobot.ReadInput();
                                
                                consoleRobot.WriteMassage("Enter post of person");
                                string? newPostStaff = consoleRobot.ReadInput();

                                if (newNameStaff != null && newPostStaff != null)
                                {
                                    Staff staff = new Staff(newNameStaff, newPostStaff);
                                    managedStaff.CreateStaff(staff);
                                    consoleRobot.WriteMassage("Your new staff added");
                                    managedStaff.ShowStaff();
                                }
                                else
                                    throw new ArgumentNullException();
                                
                                break;
                            default:
                                consoleRobot.WriteMassage("- Your answer should be 1 to 3,  try again");
                                break;
                        }
                        
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        return;
                    default:
                        consoleRobot.WriteMassage("- Your answer should be 1 to 6,  try again");
                        break;
                }
            }
        }
    }
}