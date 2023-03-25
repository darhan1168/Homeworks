namespace Homework2;

public class ConsoleApp
{
    public void App()
        {
            ManagedProject managedProject = new ManagedProject();
            ManagedTasks managedTasks = new ManagedTasks();
            ManagedStaff managedStaff = new ManagedStaff();
            ConsoleRobot consoleRobot = new ConsoleRobot();

            while (true)
            {
                Console.WriteLine("Choose what you want (1 - Project status review, 2 - Addition of options, 3 - Deletion of options, 4 - Replacement of options, 5 - Stop console app)");
                string? answerUserMethod = consoleRobot.ReadInput();

                switch (answerUserMethod)
                {
                    case "1":
                        Console.WriteLine("Projects:");
                        managedProject.ShowProject();
                        
                        Console.WriteLine("Tasks:");
                        managedTasks.ShowTasks();
                        
                        Console.WriteLine("Staff:");
                        managedStaff.ShowStaff();
                        break;
                    case "2":
                        ConsoleAppForAdding consoleAppForAdding = new ConsoleAppForAdding();
                        
                        consoleAppForAdding.ConsoleForAdding();
                        break;
                    case "3":
                        Console.WriteLine("Choose what you want delete (1 - project, 2 - task, 3 - staff)");
                        string? answerUserDelete = consoleRobot.ReadInput();

                        switch (answerUserDelete)
                        {
                            case "1":
                                Console.WriteLine("Enter the project sequence number");
                                int sequenceNumberProject = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
                                managedProject.DeleteProject(sequenceNumberProject - 1);
                                Console.WriteLine($"Project {sequenceNumberProject} deleted");
                                managedProject.ShowProject();
                                
                                break;
                            case "2":
                                Console.WriteLine("Enter the task sequence number");
                                int sequenceNumberTask = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
                                managedTasks.DeleteTasks(sequenceNumberTask - 1);
                                Console.WriteLine($"Task {sequenceNumberTask} deleted");
                                managedTasks.ShowTasks();

                                break;
                            case "3":
                                Console.WriteLine("Enter the staff sequence number");
                                int sequenceNumberStaff = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
                                
                                managedStaff.DeleteStaff(sequenceNumberStaff - 1);
                                Console.WriteLine($"Staff {sequenceNumberStaff} deleted");
                                managedStaff.ShowStaff();
                                
                                break;
                            default:
                                Console.WriteLine("- Your answer should be 1 to 3,  try again");
                                break;
                        }
                        
                        break;
                    case "4":
                        Console.WriteLine("Choose where you want replace options ((1 - project, 2 - task, 3 - staff)");
                        string? answerUserReplace = consoleRobot.ReadInput();

                        switch (answerUserReplace)
                        {
                            case "1":
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

                                break;
                            case "2":
                                Console.WriteLine("Enter a new value and sequence number");
                                
                                managedTasks.ReplaceDescription(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                                managedTasks.ShowTasks();

                                break;
                            case "3":
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

                                break;
                            default:
                                Console.WriteLine("- Your answer should be 1 to 3, try again");
                                break;
                        }
                        
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("- Your answer should be 1 to 6,  try again");
                        break;
                }
            }
        }
}