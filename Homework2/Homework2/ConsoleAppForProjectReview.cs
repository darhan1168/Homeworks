namespace Homework2;

public class ConsoleAppForProjectReview
{
    public void ConsoleForProjectReview()
    {
        ManagedProject managedProject = new ManagedProject();
        ManagedTasks managedTasks = new ManagedTasks();
        ManagedStaff managedStaff = new ManagedStaff();

        Console.WriteLine("Projects:");
        managedProject.ShowProject();
                        
        Console.WriteLine("Tasks:");
        managedTasks.ShowTasks();
                        
        Console.WriteLine("Staff:");
        managedStaff.ShowStaff();
    }
}