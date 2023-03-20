namespace Homework2;

public class Staff
{
    private string _name;
    private string _post;
    
    public string Name
    {
        get => _name;
        set
        {
            if (int.TryParse(value, out _))
                throw new AggregateException("Name is num");
            _name = value;
        }
    }
    
    public string Post
    {
        get => _post;
        set
        {
            if (int.TryParse(value, out _))
                throw new AggregateException("Post is num");
            _post = value;
        }
    }

    public Staff(string name, string post)
    {
        Name = name;
        Post = post;
    }
}