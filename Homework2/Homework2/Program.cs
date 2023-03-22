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
            ConsoleAdding consoleAdding = new ConsoleAdding();

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
                                consoleAdding.AddProject();
                                break;
                            case "2":
                                consoleAdding.AddTask();
                                break;
                            case "3":
                                consoleAdding.AddStaff();
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