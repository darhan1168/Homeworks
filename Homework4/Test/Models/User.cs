namespace Test.Models;

public class User
{
    public string Name { get; set; }
    
    public string Email { get; set; }
    
    public User(string name)
    {
        Name = name;
    }
}