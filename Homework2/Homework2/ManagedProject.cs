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

    public List<Project> GetProjects()
    {
        return _projects;
    }
}