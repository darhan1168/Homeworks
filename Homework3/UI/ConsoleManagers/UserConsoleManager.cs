using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Enums;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class UserConsoleManager : ConsoleManager<IUserService, User>, IConsoleManager<User>
    {
        public UserConsoleManager(IUserService userService) : base(userService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllUsersAsync },
                { "2", CreateUserAsync },
                { "3", UpdateUserAsync },
                { "4", DeleteUserAsync },
            };

            while (true)
            {
                Console.WriteLine("\nUser operations:");
                Console.WriteLine("1. Display all users");
                Console.WriteLine("2. Create a new user");
                Console.WriteLine("3. Update a user");
                Console.WriteLine("4. Delete a user");
                Console.WriteLine("5. Exit");

                Console.Write("Enter the operation number: ");
                string input = Console.ReadLine();

                if (input == "5")
                {
                    break;
                }

                if (actions.ContainsKey(input))
                {
                    await actions[input]();
                }
                else
                {
                    Console.WriteLine("Invalid operation number.");
                }
            }
        }

        public async Task DisplayAllUsersAsync()
        {
            try
            {
                Console.Clear();
                
                var users = await Service.GetAll();

                if (users is null)
                {
                    throw new Exception("Users are not found");
                }

                if (users.Count == 0)
                {
                    throw new Exception("Users are not added yet");
                }
                
                int index = 1;

                foreach (var user in users)
                {
                    Console.WriteLine($"{index} - Role: {user.Role}, Username: {user.Username}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to display all users. Exception: {ex.Message}");
            }
        }

        public async Task CreateUserAsync()
        {
            try
            {
                Console.Clear();
                
                var users = await Service.GetAll();
                
                Console.WriteLine("Enter your Username");
                var username = Console.ReadLine();

                foreach (var user in users)
                {
                    if (user.Username == username)
                    {
                        throw new Exception($"This Username: {username} already added");
                    }
                }
                
                Console.WriteLine("Enter your Password or 1 - generate random");
                var answerPassword = Console.ReadLine();
                string password;
                
                if (answerPassword == "1")
                {
                    password = GeneratePassword();
                    Console.WriteLine($"Your password: {password}");
                }
                else
                {
                    password = answerPassword;
                }

                Console.WriteLine("Enter your Role (1 - Admin, 2 - Trainer, 3 - Member)");
                var answerRole = Console.ReadLine();
                UserRole role;

                if (answerRole == "1")
                {
                    role = UserRole.Admin;
                }
                else if (answerRole == "2")
                {
                    role = UserRole.Trainer;
                }
                else if (answerRole == "3")
                {
                    role = UserRole.Member;
                }
                else
                {
                    throw new Exception("Incorrect answer about role");
                }
                
                await Service.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    PasswordHash = password,
                    Role = role,
                    IsLocked = false
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create user. Exception: {ex.Message}");
            }
        }

        public async Task UpdateUserAsync()
        {
            try
            {
                Console.Clear();
                
                Console.WriteLine("Enter your username");
                var username = Console.ReadLine();
                
                Console.WriteLine("Enter your password");
                var password = Console.ReadLine();

                var user = await Service.Authenticate(username, password);
                
                Console.WriteLine("What you want to change (1 - User name, 2 - Password, 3 - Role)");
                var answer = Console.ReadLine();
                
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Enter new username");
                        var newUsername = Console.ReadLine();
                        user.Username = newUsername;
                        
                        await UpdateAsync(user.Id, user);
                        break;
                    case "2":
                        Console.WriteLine("Enter new password or 1 - generate");
                        var answerPassword = Console.ReadLine();
                        string newPassword;
                
                        if (answerPassword == "1")
                        {
                            newPassword = GeneratePassword();
                            Console.WriteLine($"Your new password: {newPassword}");
                        }
                        else
                        {
                            newPassword = answerPassword;
                        }
                        
                        await Service.UpdatePassword(user.Id, newPassword);
                        break;
                    case "3":
                        Console.WriteLine("Enter your new Role (1 - Admin, 2 - Trainer, 3 - Member)");
                        var newRole = Console.ReadLine();
                        UserRole role;

                        if (newRole == "1")
                        {
                            role = UserRole.Admin;
                        }
                        else if (newRole == "2")
                        {
                            role = UserRole.Trainer;
                        }
                        else if (newRole == "3")
                        {
                            role = UserRole.Member;
                        }
                        else
                        {
                            throw new Exception("Incorrect answer about role");
                        }

                        user.Role = role;
                        await UpdateAsync(user.Id, user);
                        break;
                    default:
                        throw new Exception("Incorrect answer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update user. Exception: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync()
        {
            try
            {
                Console.Clear();
                
                Console.WriteLine("Enter your username");
                var username = Console.ReadLine();
                
                Console.WriteLine("Enter your password");
                var password = Console.ReadLine();

                var user = await Service.Authenticate(username, password);

                await DeleteAsync(user.Id);
                Console.WriteLine("User was deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete user. Exception: {ex.Message}");
            }
        }
        
        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}