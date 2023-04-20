using Homework4;
using Test.UIModels;
namespace Test;

class Program
{
    static void Main(string[] args)
    { 
        User aiuser = new User();
        Models.User user = new Models.User("Daryna");
        Console.WriteLine(aiuser.Name);
        Console.WriteLine(user.Name);
        
        user.MapTo(aiuser);
        Console.WriteLine(aiuser.Name);
    }
}