namespace Homework2;

public class ManagedProject
{
    private List<Project> _projects;

    public ManagedProject()
    {
        _projects = new List<Project>();
    }

    public void CreateProject(Project project)
    {
        _projects.Add(project);
    }

    public void DeleteProject(int index)
    {
        _projects.RemoveAt(index);
    }

    public void ShowProject()
    {
        int index = 1;
        
        if (_projects.Count == 0)
            Console.WriteLine("Project not added yet");
        
        foreach (var project in _projects)
        {
            Console.WriteLine($"{index} - Title: {project.Name}, Description: {project.Description}, Deadline: {project.Deadline}, Budget: {project.Budget}");
            index++;
        }
    }
    
    public List<Project> GetProjects()
    {
        return _projects;
    }
}