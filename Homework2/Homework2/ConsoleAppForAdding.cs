namespace Homework2;

public class ConsoleAppForAdding
{
    public void ConsoleForAdding()
    {
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Choose what you want add (1 - new project, 2 - new task, 3 - new staff)");
        string? answerUserAdd = consoleRobot.ReadInput();

        switch (answerUserAdd)
        {
            case "1":
                AddProject();
                break;
            case "2":
                AddTask();
                break;
            case "3":
                AddStaff();
                break;
            default:
                Console.WriteLine("- Your answer should be 1 to 3,  try again");
                break;
        }
    }

    public void AddProject()
    {
        ManagedProject managedProject = new ManagedProject();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter name of project");
        string? newNameProject = consoleRobot.ReadInput();

        Console.WriteLine("Enter description of project");
        string? newDescriptionProject = consoleRobot.ReadInput();
                                
        Console.WriteLine("Enter deadline of project");
        string? newDeadlineProject = consoleRobot.ReadInput();
                                
        Console.WriteLine("Enter budget of project");
        decimal newBudgetProject = decimal.Parse(consoleRobot.ReadInput() ?? string.Empty);

        if (newNameProject != null && newDescriptionProject != null && newDeadlineProject != null)
        {
            Project newProject = new Project(newNameProject, newDescriptionProject, newDeadlineProject, newBudgetProject);
            managedProject.CreateProject(newProject);
            Console.WriteLine("Your new project added");
            managedProject.ShowProject();
        }
        else
        {
            throw new ArgumentNullException();   
        }
    }

    public void AddTask()
    {
        ManagedTasks managedTasks = new ManagedTasks();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter description of task");
        string? newDescriptionTask = consoleRobot.ReadInput();

        if (newDescriptionTask != null)
        {
            Tasks tasks = new Tasks(newDescriptionTask);
            managedTasks.CreateTasks(tasks);
            Console.WriteLine("Your new task added");
            managedTasks.ShowTasks();
        }
        else
            throw new ArgumentNullException();
    }

    public void AddStaff()
    {
        ManagedStaff managedStaff = new ManagedStaff();
        ConsoleRobot consoleRobot = new ConsoleRobot();
        
        Console.WriteLine("Enter name of person");
        string? newNameStaff = consoleRobot.ReadInput();
                                
        Console.WriteLine("Enter post of person");
        string? newPostStaff = consoleRobot.ReadInput();

        if (newNameStaff != null && newPostStaff != null)
        {
            Staff staff = new Staff(newNameStaff, newPostStaff);
            managedStaff.CreateStaff(staff);
            Console.WriteLine("Your new staff added");
            managedStaff.ShowStaff();
        }
        else
            throw new ArgumentNullException();
    }
}