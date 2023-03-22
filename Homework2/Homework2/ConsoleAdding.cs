namespace Homework2;

public class ConsoleAdding
{
    public void AddProject()
        {
            ManagedProject managedProject = new ManagedProject();
            ConsoleRobot consoleRobot = new ConsoleRobot();
            
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
        }

        public void AddTask()
        {
            ManagedTasks managedTasks = new ManagedTasks();
            ConsoleRobot consoleRobot = new ConsoleRobot();
            
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
        }
        
        public void AddStaff()
        {
            ManagedStaff managedStaff = new ManagedStaff();
            ConsoleRobot consoleRobot = new ConsoleRobot();
            
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
        }
}