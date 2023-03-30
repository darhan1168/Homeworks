namespace Homework2;

public class ConsoleAppForDeletion
{
    public void ConsoleForDeletion()
    {
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Choose what you want delete (1 - project, 2 - task, 3 - staff)");
        string? answerUserDelete = consoleRobot.ReadInput();

        switch (answerUserDelete)
        {
            case "1":
                DeletionProject();
                break;
            case "2":
                DeletionTask();
                break;
            case "3":
                DeletionStaff();
                break;
            default:
                Console.WriteLine("- Your answer should be 1 to 3,  try again");
                break;
        }
    }

    public void DeletionProject()
    {
        ManagedProject managedProject = new ManagedProject();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter the project sequence number");
        int sequenceNumberProject = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
        managedProject.DeleteProject(sequenceNumberProject - 1);
        Console.WriteLine($"Project {sequenceNumberProject} deleted");
        managedProject.ShowProject();
    }
    
    public void DeletionTask()
    {
        ManagedTasks managedTasks = new ManagedTasks();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter the task sequence number");
        int sequenceNumberTask = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
            
        managedTasks.DeleteTasks(sequenceNumberTask - 1);
        Console.WriteLine($"Task {sequenceNumberTask} deleted");
        managedTasks.ShowTasks();
    }
    
    public void DeletionStaff()
    {
        ManagedStaff managedStaff = new ManagedStaff();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter the staff sequence number");
        int sequenceNumberStaff = int.Parse(consoleRobot.ReadInput() ?? string.Empty);
                                
        managedStaff.DeleteStaff(sequenceNumberStaff - 1);
        Console.WriteLine($"Staff {sequenceNumberStaff} deleted");
        managedStaff.ShowStaff();
    }
}