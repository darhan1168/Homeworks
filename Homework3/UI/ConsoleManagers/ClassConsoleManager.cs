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
            try
            {
                var classes = await Service.GetAll();

                if (classes is null)
                {
                    throw new Exception("Classes are not found");
                }
                
                int index = 1;

                foreach (var fitClass in classes)
                {
                    Console.WriteLine($"{index} - Firstname: {fitClass.Name}, Lastname: {fitClass.Type}, Id: {fitClass.Id}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to display all classes. Exception: {ex.Message}");
            }
        }

        public async Task CreateClassAsync()
        {
            try
            {
                Console.WriteLine("Enter name");
                var name = Console.ReadLine();

                if (name is null)
                {
                    throw new Exception("Name is null");
                }
                
                Console.WriteLine("Enter type");
                var type = Console.ReadLine();
                
                if (type is null)
                {
                    throw new Exception("Type is null");
                }

                await Service.ScheduleClass(new FitnessClass()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Type = type
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create class. Exception: {ex.Message}");
            }
        }

        public async Task UpdateClassAsync()
        {
            try
            {
                Console.WriteLine("Enter id of class, which you need to update");
                var fitClass = await Service.GetById(Guid.Parse(Console.ReadLine()));
            
                Console.WriteLine("Eneter what yoy need to change (1 - Name, 2 - Type)");
                var answerUpdate = Console.ReadLine();

                if (answerUpdate == "1")
                {
                    Console.WriteLine("Enter new name");
                    var newName = Console.ReadLine();
                    fitClass.Name = newName;
                }
                else if (answerUpdate == "1")
                {
                    Console.WriteLine("Enter new type");
                    var newType = Console.ReadLine();
                    fitClass.Type = newType;
                }
                else
                {
                    throw new Exception("Incorrect answer");
                }

                await Service.Update(fitClass.Id, fitClass);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update class. Exception: {ex.Message}");
            }
        }

        public async Task DeleteClassAsync()
        {
            try
            {
                Console.WriteLine("Enter your class id");
                Guid classId = Guid.Parse(Console.ReadLine());
                
                await Service.Delete(classId);
                Console.WriteLine("Class was deleted");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete class. Exception: {ex.Message}");
            }
        }
    }
}