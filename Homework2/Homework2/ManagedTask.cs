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

    public void ShowTasks()
    {
        int index = 1;
        
        if (_tasks.Count == 0)
            Console.WriteLine("Tasks not added yet");
        
        foreach (var task in _tasks)
        {
            Console.WriteLine($"{index} - {task.Description}");
            index++;
        }
    }

    public void ReplaceDescription(string value, int index)
    {
        _tasks[index - 1].Description = value;
    }
    
    public List<Tasks> GetTasks()
    {
        return _tasks;
    }
}