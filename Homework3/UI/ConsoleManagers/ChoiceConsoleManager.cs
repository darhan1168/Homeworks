using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using BLL.Services;
using Core.Models;
using DAL.Abstractions.Interfaces;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class ChoiceConsoleManager : IConsoleManager
    {
        private readonly BookingConsoleManager _bookingConsoleManager;
        private readonly ClassConsoleManager _classConsoleManager;
        private readonly MemberConsoleManager _memberConsoleManager;
        private readonly SubscriptionConsoleManager _subscriptionConsoleManager;
        private readonly TrainerConsoleManager _trainerConsoleManager;
        private readonly UserConsoleManager _userConsoleManager;

        public ChoiceConsoleManager(ISubscriptionService subscriptionService, IMemberService memberService, IBookingService bookingService, IClassService classService, ITrainerService trainerService, IUserService userService)
        {
            _bookingConsoleManager = new BookingConsoleManager(bookingService, new ClassConsoleManager(classService), new MemberConsoleManager(memberService));
            _classConsoleManager = new ClassConsoleManager(classService);
            _memberConsoleManager = new MemberConsoleManager(memberService);
            _subscriptionConsoleManager = new SubscriptionConsoleManager(subscriptionService, new MemberConsoleManager(memberService));
            _trainerConsoleManager = new TrainerConsoleManager(trainerService);
            _userConsoleManager = new UserConsoleManager(userService);
        }

        public async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", _bookingConsoleManager.PerformOperationsAsync },
                { "2", _classConsoleManager.PerformOperationsAsync },
                { "3", _memberConsoleManager.PerformOperationsAsync },
                { "4", _subscriptionConsoleManager.PerformOperationsAsync },
                { "5", _trainerConsoleManager.PerformOperationsAsync },
                { "6", _userConsoleManager.PerformOperationsAsync },
            };

            while (true)
            {
                Console.WriteLine("\nUser operations:");
                Console.WriteLine("1. Do some operations with booking");
                Console.WriteLine("2. Do some operations with class");
                Console.WriteLine("3. Do some operations with member");
                Console.WriteLine("4. Do some operations with subscription");
                Console.WriteLine("5. Do some operations with trainer");
                Console.WriteLine("6. Do some operations with user");
                Console.WriteLine("7. Exit");

                Console.Write("Enter the operation number: ");
                string input = Console.ReadLine();

                if (input == "7")
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
    }
}