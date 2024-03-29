namespace Homework2;

public class Project
{
    private string _name;
    private string _description;
    private string _deadline;
    private decimal _budget;
    private List<Staff> _staff = new List<Staff>();
    private List<Tasks> _tasks = new List<Tasks>();

    public string Name
    {
        get => _name;
        set
        {
            if (int.TryParse(value, out _))
                throw new ArgumentException("Name is num");
            _name = value;
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (int.TryParse(value, out _))
                throw new ArgumentException("Description is num");
            _description = value;
        }
    }

    public string Deadline
    {
        get => _deadline;
        set
        {
            if (int.TryParse(value, out _))
                throw new ArgumentException("Deadline is num");
            _deadline = value;
        }
    }

    public decimal Budget
    {
        get => _budget;
        set
        {
            if (value < 0 || value > 1_000_000)
                throw new ArgumentOutOfRangeException($"Budget isn`t rahge");
            _budget = value;
        }
    }

    public Project(string name, string description, string deadline, decimal budget)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        Budget = budget;
    }
    
    public Project(string name, string description, string deadline, decimal budget, List<Staff> staff, List<Tasks> tasks)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        Budget = budget;
        _staff = staff;
        _tasks = tasks;
    }
}