﻿using System;
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

                subscription.IsActive = true;
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
            try
            {
                var subscription = await GetById(subscriptionId);
                
                if (subscription is null)
                {
                    throw new Exception("Subscription is null");
                }

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