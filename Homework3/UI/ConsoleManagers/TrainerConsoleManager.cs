using System;
using System.Collections.Generic;
using System.Linq;
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
            int index = 1;

            foreach (var trainer in await Service.GetAll())
            {
                Console.WriteLine($"{index} - {trainer.FirstName}, {trainer.LastName}, {trainer.Specialization}, {trainer.Id}");

                index++;
            }
        }

        public async Task CreateTrainerAsync()
        {
            try
            {
                Console.WriteLine("Enter firstname of trainer");
                var firstName = Console.ReadLine();

                if (firstName is null)
                {
                    throw new Exception("firstName is not found");
                }
                
                Console.WriteLine("Enter lastname of trainer");
                var lastName = Console.ReadLine();
                
                if (lastName is null)
                {
                    throw new Exception("lastName is not found");
                }
                
                Console.WriteLine("Enter specialization of trainer");
                var specialization = Console.ReadLine();
                
                if (specialization is null)
                {
                    throw new Exception("specialization is not found");
                }
                
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
            try
            {
                Console.WriteLine("Enter id of trainer, which you need to update");
                var trainer = await Service.GetById(new Guid(Console.ReadLine()));
                
                Console.WriteLine("Eneter what you need to change (1 - Lastname, 2 - Firstname)");
                var answerUpdate = Console.ReadLine();
                
                if (answerUpdate == "1")
                {
                    Console.WriteLine("Enter new lastname");
                    var newLastName = Console.ReadLine();
                    trainer.LastName = newLastName;
                }
                else if (answerUpdate == "1")
                {
                    Console.WriteLine("Enter new firstname");
                    var newFirstName = Console.ReadLine();
                    trainer.FirstName = newFirstName;
                }
                else
                {
                    throw new Exception("Incorrect answer");
                }

                await Service.Update(trainer.Id, trainer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update trainer. Exception: {ex.Message}");
            }
        }

        public async Task DeleteTrainerAsync()
        {
            try
            {
                Console.WriteLine("Enter your trainer id");
                Guid trainerId = new Guid(Console.ReadLine());
                
                await Service.Delete(trainerId);
                Console.WriteLine("Trainer was deleted");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete trainer. Exception: {ex.Message}");
            }
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