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
                consoleRobot.WriteMassage("Choose what you want (1 - Project status review, 2 - Addition of options, 3 - Deletion of options, 4 - Replacement of options, 5 - Stop console app)");
                string? answerUserMethod = consoleRobot.ReadInput();

                switch (answerUserMethod)
                {
                    case "1":
                        consoleRobot.WriteMassage("Projects:");
                        managedProject.ShowProject();
                        
                        consoleRobot.WriteMassage("Tasks:");
                        managedTasks.ShowTasks();
                        
                        consoleRobot.WriteMassage("Staff:");
                        managedStaff.ShowStaff();
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
                        consoleRobot.WriteMassage("Choose what you want delete (1 - project, 2 - task, 3 - staff)");
                        string? answerUserDelete = consoleRobot.ReadInput();

                        switch (answerUserDelete)
                        {
                            case "1":
                                consoleRobot.WriteMassage("Enter the project sequence number");
                                int sequenceNumberProject = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
                                managedProject.DeleteProject(sequenceNumberProject - 1);
                                consoleRobot.WriteMassage($"Project {sequenceNumberProject} deleted");
                                managedProject.ShowProject();
                                
                                break;
                            case "2":
                                consoleRobot.WriteMassage("Enter the task sequence number");
                                int sequenceNumberTask = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
                                managedTasks.DeleteTasks(sequenceNumberTask - 1);
                                consoleRobot.WriteMassage($"Task {sequenceNumberTask} deleted");
                                managedTasks.ShowTasks();

                                break;
                            case "3":
                                consoleRobot.WriteMassage("Enter the staff sequence number");
                                int sequenceNumberStaff = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
                                
                                managedStaff.DeleteStaff(sequenceNumberStaff - 1);
                                consoleRobot.WriteMassage($"Staff {sequenceNumberStaff} deleted");
                                managedStaff.ShowStaff();
                                
                                break;
                            default:
                                consoleRobot.WriteMassage("- Your answer should be 1 to 3,  try again");
                                break;
                        }
                        
                        break;
                    case "4":
                        consoleRobot.WriteMassage("Choose where you want replace options ((1 - project, 2 - task, 3 - staff)");
                        string? answerUserReplace = consoleRobot.ReadInput();

                        switch (answerUserReplace)
                        {
                            case "1":
                                while (true)
                                {
                                    consoleRobot.WriteMassage("Choose which options you need to replace ((1 - name, 2 - description, 3 - deadline, 4 - budget, 5 - stop choosing)");
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
                                            consoleRobot.WriteMassage("- Your answer should be 1 to 3, try again");
                                            break;
                                    }
                                    
                                    managedProject.ShowProject();
                                }

                                break;
                            case "2":
                                consoleRobot.WriteMassage("Enter a new value and sequence number");
                                
                                managedTasks.ReplaceDescription(consoleRobot.GetNewValue(), consoleRobot.GetSequenceNumber());
                                managedTasks.ShowTasks();

                                break;
                            case "3":
                                while (true)
                                {
                                    consoleRobot.WriteMassage("Choose which options you need to replace ((1 - name, 2 - post, 3 - stop choosing)");
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
                                            consoleRobot.WriteMassage("- Your answer should be 1 to 3, try again");
                                            break;
                                    }
                                    
                                    managedStaff.ShowStaff();
                                }

                                break;
                            default:
                                consoleRobot.WriteMassage("- Your answer should be 1 to 3, try again");
                                break;
                        }
                        
                        break;
                    case "5":
                        return;
                    default:
                        consoleRobot.WriteMassage("- Your answer should be 1 to 6,  try again");
                        break;
                }
            }
        }
}