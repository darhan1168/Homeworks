using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Enums;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class SubscriptionConsoleManager : ConsoleManager<ISubscriptionService, Subscription>, IConsoleManager
    {
        private readonly MemberConsoleManager _memberConsoleManager;
        
        public SubscriptionConsoleManager(ISubscriptionService subscriptionService, MemberConsoleManager memberConsoleManager) : base(subscriptionService)
        {
            _memberConsoleManager = memberConsoleManager;
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllSubscriptionsAsync },
                { "2", CreateSubscriptionAsync },
                { "3", UpdateSubscriptionAsync },
                { "4", DeleteSubscriptionAsync },
            };

            while (true)
            {
                Console.WriteLine("\nSubscription operations:");
                Console.WriteLine("1. Display all subscriptions");
                Console.WriteLine("2. Create a new subscription");
                Console.WriteLine("3. Update a subscription");
                Console.WriteLine("4. Delete a subscription");
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

        public async Task DisplayAllSubscriptionsAsync()
        {
            try
            {
                var subscriptions = await Service.GetAll();

                if (subscriptions is null)
                {
                    throw new Exception("Subscriptions are not found");
                }
                
                int index = 1;

                foreach (var subscription in subscriptions)
                {
                    Console.WriteLine($"{index} - Member: {subscription.Member.FirstName}, Type: {subscription.Type}, Start: {subscription.StartDate}, End: {subscription.EndDate}");
                    index++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to display all users. Exception: {ex.Message}");
            }
        }

        public async Task CreateSubscriptionAsync()
        {
            try
            {
                Console.WriteLine("Enter id of member");
                Guid memberId = new Guid(Console.ReadLine());
                var member = await _memberConsoleManager.GetByIdAsync(memberId);

                Console.WriteLine("Enter type (1 - Monthly, 2 - Quarterly, 3 - Annual,)");
                var answerType = Console.ReadLine();
                SubscriptionType type;
                DateTime endDay;

                if (answerType == "1")
                {
                    endDay = DateTime.Now.AddMonths(1);
                    type = SubscriptionType.Monthly;
                }
                else if (answerType == "2")
                {
                    endDay = DateTime.Now.AddMonths(3);
                    type = SubscriptionType.Quarterly;
                }
                else if (answerType == "3")
                {
                    endDay = DateTime.Now.AddYears(1);
                    type = SubscriptionType.Annual;
                }
                else
                {
                    throw new Exception("Incorrect answer about type");
                }

                DateTime startDay = DateTime.Now;

                await Service.CreateSubscription(new Subscription()
                {
                    Member = member,
                    Type = type,
                    StartDate = startDay,
                    EndDate = endDay
                });
                
                Console.WriteLine($"Subscription added");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create subscription. Exception: {ex.Message}");
            }
        }

        public async Task UpdateSubscriptionAsync()
        {
            // Implementation for updating a subscription
        }

        public async Task DeleteSubscriptionAsync()
        {
            // Implementation for deleting a subscription
        }
    }
}