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
                string? answer = consoleRobot.ReadInput("Answer:");

                switch (answer)
                {
                    case "1":
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
                        return;
                    default:
                        consoleRobot.WriteMassage("- Your answer should be 1 to 6,  try again");
                        break;
                }
            }
        }
    }
}