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

        var NewUser = new User()
        {
            Name = "Name",
            Email = "Email"
        };
        
        var validator = new Validator<User>();
        validator.AddValidator(new EmptyStringValidators<User>("Email"));
        
        var validationResult = validator.Validate(NewUser);
        var emailValidator = new EmptyStringValidators<User>("Email");
        bool isEmailValidator = emailValidator.Validate(NewUser);
        if (isEmailValidator)
        {
            Console.WriteLine("Is valid");
        }
        else
        {
            Console.WriteLine("User is invalid. Errors:");
            foreach (var error in validationResult.GetErrors())
            {
                Console.WriteLine(error);
            }
        }
    }
}