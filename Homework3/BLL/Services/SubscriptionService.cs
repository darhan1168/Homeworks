using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class SubscriptionService : GenericService<Subscription>, ISubscriptionService
    {
        private readonly IMemberService _memberService;
        
        public SubscriptionService(IRepository<Subscription> repository, IMemberService memberService) : base(repository)
        {
            _memberService = memberService;
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

                await Add(subscription);

                return subscription;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create subscription {subscription}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Subscription>> GetSubscriptionsByMember(Guid memberId)
        {
            try
            {
                var subscriptions = await GetAll();
                var member = await _memberService.GetById(memberId);
                
                if (subscriptions is null)
                {
                    throw new Exception("Subscriptions are null");
                }
                
                if (member is null)
                {
                    throw new Exception("Member is null");
                }

                return subscriptions.Where(s => s.Member == member).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscriptions by member {memberId}. Exception: {ex.Message}");
            }
        }

        public async Task<List<Subscription>> GetSubscriptionsByType(string subscriptionType)
        {
            try
            {
                var subscriptions = await GetAll();

                if (subscriptions is null)
                {
                    throw new Exception("Subscriptions are null");
                }
                
                return subscriptions.Where(s => Equals(s.Type, subscriptionType)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get subscriptions by type {subscriptionType}. Exception: {ex.Message}");
            }
        }

        public async Task RenewSubscription(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task CancelSubscription(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}