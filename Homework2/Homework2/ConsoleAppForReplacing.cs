namespace Homework2;

public class ConsoleAppForReplacing
{
    public void ConsoleForReplacing()
    {
        ConsoleRobot consoleRobot = new ConsoleRobot();

        Console.WriteLine("Choose where you want replace options ((1 - project, 2 - task, 3 - staff)");
        string? answerUserReplace = consoleRobot.ReadInput();

        switch (answerUserReplace)
        {
            case "1":
                ReplaceProject();
                break;
            case "2":
                ReplaceTask();
                break;
            case "3":
                ReplaceStaff();
                break;
            default:
                Console.WriteLine("- Your answer should be 1 to 3, try again");
                break;
        }
    }

    public void ReplaceProject()
    {
        ManagedProject managedProject = new ManagedProject();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        while (true)
        {
            Console.WriteLine("Choose which options you need to replace ((1 - name, 2 - description, 3 - deadline, 4 - budget, 5 - stop choosing)");
            string? answerWhatReplaceInProject = consoleRobot.ReadInput();
                                    
            if (answerWhatReplaceInProject == "5")
                break;
                                    
            switch (answerWhatReplaceInProject)
            {
                case "1":
                    managedProject.ReplaceName(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                    break;
                case "2":
                    managedProject.ReplaceDescription(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                    break;
                case "3":
                    managedProject.ReplaceDeadline(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                    break;
                case "4":
                    managedProject.ReplaceBudget(int.Parse(consoleRobot.GetNewValue()), consoleRobot.GetSequenceNumber());
                    break;
                default:
                    Console.WriteLine("- Your answer should be 1 to 3, try again");
                    break;
            }
                                    
            managedProject.ShowProject();
        }
    }

    public void ReplaceTask()
    {
        ManagedTasks managedTasks = new ManagedTasks();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter a new value and sequence number");
                                
        managedTasks.ReplaceDescription(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
        managedTasks.ShowTasks();
    }

    public void ReplaceStaff()
    {
        ManagedStaff managedStaff = new ManagedStaff();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        while (true)
        {
            Console.WriteLine("Choose which options you need to replace ((1 - name, 2 - post, 3 - stop choosing)");
            string? answerWhatReplaceInStaff = consoleRobot.ReadInput();

            if (answerWhatReplaceInStaff == "3")
                break;

            switch (answerWhatReplaceInStaff)
            {
                case "1":
                    managedStaff.ReplaceName(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                    break;
                case "2":
                    managedStaff.ReplacePost(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                    break;
                default:
                    Console.WriteLine("- Your answer should be 1 to 3, try again");
                    break;
            }
                                    
            managedStaff.ShowStaff();
        }
    }
}