using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class UserConsoleManager : ConsoleManager<IUserService, User>, IConsoleManager
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
                var users = await Service.GetAll();

                if (users is null)
                {
                    throw new Exception("Users are not found");
                }
                
                int index = 1;

                foreach (var user in users)
                {
                    Console.WriteLine($"{index} - Role: {user.Role}, Username: {user.Username}");
                    index++;
                }
        }

        public async Task CreateUserAsync()
        {
            try
            {
                var users = await Service.GetAll();
                
                Console.WriteLine("Enter your Username");
                var username = Console.ReadLine();
                var userEqUsername = users.Where(u => u.Username == username).ToList();

                if (userEqUsername.Count > 0)
                {
                    throw new Exception("Username already added");
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
                    role = UserRole.Admin;
                }
                else if (answerRole == "3")
                {
                    role = UserRole.Admin;
                }
                else
                {
                    throw new Exception("Incorrect answer about role");
                }
                
                await Service.Add(new User()
                {
                    Id = new Guid(),
                    Username = username,
                    PasswordHash = password,
                    Role = role,
                    IsLocked = false
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create user. Exception: {ex.Message}");
            }
        }

        public async Task UpdateUserAsync()
        {
            // Implementation for updating a user
        }

        public async Task DeleteUserAsync()
        {
            // Implementation for deleting a user
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