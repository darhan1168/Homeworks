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
            try
            {
                Console.WriteLine("Enter firstname of trainer");
                var firstName = Console.ReadLine();
                
                Console.WriteLine("Enter lastname of trainer");
                var lastName = Console.ReadLine();
                
                Console.WriteLine("Enter specialization of trainer");
                var specialization = Console.ReadLine();
                
                Console.WriteLine("Enter available dates of trainer");

                await Service.AddTrainer(new Trainer
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Specialization = specialization,
                    AvailableDates = CreateDateList()
                });
                
                Console.WriteLine("Trainer succeeded added");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create Trainer. Exception: {ex.Message}");
            }
        }

        public async Task UpdateTrainerAsync()
        {
            // Implementation for updating a trainer
        }

        public async Task DeleteTrainerAsync()
        {
            // Implementation for deleting a trainer
        }

        public ICollection<DateTime> CreateDateList()
        {
            ICollection<DateTime> availableDates = new List<DateTime>{};
            
            while (true)
            {
                Console.WriteLine($"Enter year");
                int year = Int32.Parse(Console.ReadLine());
                    
                if (year < DateTime.Today.Year)
                {
                    throw new ArgumentOutOfRangeException("Incorrect year");
                }
                    
                Console.WriteLine($"Enter month");
                int month = Int32.Parse(Console.ReadLine());
                    
                if (year == DateTime.Today.Year && month < DateTime.Today.Month)
                {
                    throw new ArgumentOutOfRangeException("Incorrect month");
                }
                    
                Console.WriteLine($"Enter day");
                int day = Int32.Parse(Console.ReadLine());
                    
                if (year == DateTime.Today.Year && month == DateTime.Today.Month && day < DateTime.Today.Day)
                {
                    throw new ArgumentOutOfRangeException("Incorrect day");
                }
                    
                availableDates.Add(new DateTime(year, month, day));
                    
                Console.WriteLine("If you want stop, enter 1");
                var answer = Console.ReadLine();

                if (answer == "1")
                {
                    break;
                }
            }

            return availableDates;
        }
    }
}