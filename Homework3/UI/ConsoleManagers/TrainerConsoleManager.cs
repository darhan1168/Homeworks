using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class TrainerConsoleManager : ConsoleManager<ITrainerService, Trainer>, IConsoleManager
    {
        public TrainerConsoleManager(ITrainerService trainerService) : base(trainerService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllTrainersAsync },
                { "2", CreateTrainerAsync },
                { "3", UpdateTrainerAsync },
                { "4", DeleteTrainerAsync },
            };

            while (true)
            {
                Console.WriteLine("\nTrainer operations:");
                Console.WriteLine("1. Display all trainers");
                Console.WriteLine("2. Create a new trainer");
                Console.WriteLine("3. Update a trainer");
                Console.WriteLine("4. Delete a trainer");
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

        public async Task DisplayAllTrainersAsync()
        {
            // Implementation for displaying all trainers
        }

        public async Task CreateTrainerAsync()
        {
            // Implementation for creating a new trainer
        }

        public async Task UpdateTrainerAsync()
        {
            // Implementation for updating a trainer
        }

        public async Task DeleteTrainerAsync()
        {
            // Implementation for deleting a trainer
        }
    }
}