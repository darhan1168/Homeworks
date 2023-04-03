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
            // Implementation for displaying all users
        }

        public async Task CreateUserAsync()
        {
            // Implementation for creating a new user
        }

        public async Task UpdateUserAsync()
        {
            // Implementation for updating a user
        }

        public async Task DeleteUserAsync()
        {
            // Implementation for deleting a user
        }
    }
}