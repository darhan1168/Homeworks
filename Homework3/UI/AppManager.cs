using System;
using System.Threading.Tasks;
using UI.ConsoleManagers;

namespace UI
{
    public class AppManager
    {
        private readonly ClassConsoleManager _classConsoleManager;
        private readonly MemberConsoleManager _memberConsoleManager;
        private readonly BookingConsoleManager _bookingConsoleManager;
        private readonly SubscriptionConsoleManager _subscriptionConsoleManager;
        private readonly TrainerConsoleManager _trainerConsoleManager;
        private readonly UserConsoleManager _userConsoleManager;

        public AppManager(ClassConsoleManager classConsoleManager,
            MemberConsoleManager memberConsoleManager,
            BookingConsoleManager bookingConsoleManager,
            SubscriptionConsoleManager subscriptionConsoleManager,
            TrainerConsoleManager trainerConsoleManager,
            UserConsoleManager userConsoleManager)
        {
            _classConsoleManager = classConsoleManager;
            _memberConsoleManager = memberConsoleManager;
            _bookingConsoleManager = bookingConsoleManager;
            _subscriptionConsoleManager = subscriptionConsoleManager;
            _trainerConsoleManager = trainerConsoleManager;
            _userConsoleManager = userConsoleManager;
        }

        public async Task StartAsync()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Class operations");
                Console.WriteLine("2. Member operations");
                Console.WriteLine("3. Booking operations");
                Console.WriteLine("4. Subscription operations");
                Console.WriteLine("5. Trainer operations");
                Console.WriteLine("6. User operations");
                Console.WriteLine("7. Exit");

                Console.Write("Enter the operation number: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        await _classConsoleManager.PerformOperationsAsync();
                        break;
                    case "2":
                        await _memberConsoleManager.PerformOperationsAsync();
                        break;
                    case "3":
                        await _bookingConsoleManager.PerformOperationsAsync();
                        break;
                    case "4":
                        await _subscriptionConsoleManager.PerformOperationsAsync();
                        break;
                    case "5":
                        await _trainerConsoleManager.PerformOperationsAsync();
                        break;
                    case "6":
                        await _userConsoleManager.PerformOperationsAsync();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid operation number.");
                        break;
                }
            }
        }
    }
}