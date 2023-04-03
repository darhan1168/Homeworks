using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class ClassConsoleManager : ConsoleManager<IClassService, FitnessClass>, IConsoleManager
    {
        public ClassConsoleManager(IClassService classService) : base(classService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllClassesAsync },
                { "2", CreateClassAsync },
                { "3", UpdateClassAsync },
                { "4", DeleteClassAsync },
            };

            while (true)
            {
                Console.WriteLine("\nClass operations:");
                Console.WriteLine("1. Display all classes");
                Console.WriteLine("2. Create a new class");
                Console.WriteLine("3. Update a class");
                Console.WriteLine("4. Delete a class");
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
        
        public async Task DisplayAllClassesAsync()
        {
            // Implementation for displaying all classes
        }

        public async Task CreateClassAsync()
        {
            // Implementation for creating a new class
        }

        public async Task UpdateClassAsync()
        {
            // Implementation for updating a class
        }

        public async Task DeleteClassAsync()
        {
            // Implementation for deleting a class
        }
    }
}