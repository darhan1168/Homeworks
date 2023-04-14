using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Enums;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class SubscriptionService : GenericService<Subscription>, ISubscriptionService
    {
        public SubscriptionService(IRepository<Subscription> repository) : base(repository)
        {
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            try
            {
                var subscriptions = await GetAll();
                
                if (subscription is null)
                {
                    throw new Exception("Subscription is null");
                }

                if (subscriptions.Contains(subscription))
                {
                    throw new Exception("Subscription is already added");
                }

                subscription.IsActive = true;
                await Add(subscription);

                return subscription;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create subscription {subscription}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Subscription>> GetSubscriptionsByType(string subscriptionType)
        {
            try
            {
                var subscriptions = await GetAll();

                SubscriptionType avaibleTipe;

                switch (subscriptionType)
                {
                    case "Annual":
                        avaibleTipe = SubscriptionType.Annual;
                        break;
                    case "Monthly":
                        avaibleTipe = SubscriptionType.Monthly;
                        break;
                    case "Quarterly":
                        avaibleTipe = SubscriptionType.Quarterly;
                        break;
                    default:
                        throw new Exception("Incorrect role");
                }

                return subscriptions.Where(u => u.Type == avaibleTipe).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscriptions by type {subscriptionType}. Exception: {ex.Message}");
            }
        }

        public async Task RenewSubscription(Guid subscriptionId)
        {
            try
            {
                var subscription = await GetById(subscriptionId);
                
                if (subscription is null)
                {
                    throw new Exception("Subscription is null");
                }

                subscription.StartDate = subscription.EndDate;
                
                switch (subscription.Type)
                {
                    case SubscriptionType.Monthly:
                        subscription.EndDate = subscription.EndDate.AddMonths(1);
                        break;
                    case SubscriptionType.Quarterly:
                        subscription.EndDate = subscription.EndDate.AddMonths(3);
                        break;
                    case SubscriptionType.Annual:
                        subscription.EndDate = subscription.EndDate.AddYears(1);
                        break;
                    default:
                        throw new Exception("Invalid subscription type");
                }

                await Update(subscriptionId, subscription);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to renew subscription {subscriptionId}. Exception: {ex.Message}");
            }
        }

        public async Task CancelSubscription(Guid subscriptionId)
        {
            try
            {
                var subscription = await GetById(subscriptionId);

                if (subscription is null)
                {
                    throw new Exception("Subscription is null");
                }

                if (!subscription.IsActive)
                {
                    throw new Exception("Subscription is already inactive");
                }

                subscription.IsActive = false;
                
                await Delete(subscriptionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to cancel subscription {subscriptionId}. Exception: {ex.Message}");
            }
        }
    }
}