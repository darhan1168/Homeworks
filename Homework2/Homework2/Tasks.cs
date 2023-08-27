namespace Homework2;

public class Tasks
{
    private string _description;

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

    public Tasks(string description)
    {
        Description = description;
    }
}