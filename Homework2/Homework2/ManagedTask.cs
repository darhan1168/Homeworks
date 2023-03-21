namespace Homework2;

public class ManagedTasks
{
    private List<Tasks> _tasks;

    public ManagedTasks()
    {
        _tasks = new List<Tasks>();
    }
    
    public void CreateTasks(Tasks tasks)
    {
        _tasks.Add(tasks);
    }

    public void DeleteTasks(int index)
    {
        _tasks.RemoveAt(index);
    }

    public List<Tasks> GetTasks()
    {
        return _tasks;
    }
}