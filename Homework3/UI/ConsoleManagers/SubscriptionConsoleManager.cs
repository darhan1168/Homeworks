using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class SubscriptionConsoleManager : ConsoleManager<ISubscriptionService, Subscription>, IConsoleManager
    {
        public SubscriptionConsoleManager(ISubscriptionService subscriptionService) : base(subscriptionService)
        {
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
            // Implementation for displaying all subscriptions
        }

        public async Task CreateSubscriptionAsync()
        {
            // Implementation for creating a new subscription
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