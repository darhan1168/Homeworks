using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // CreateSubscription: Creates a new subscription for the specified member with the given subscription creation information.
    // GetSubscriptionsByMember: Retrieves a list of subscriptions associated with the specified member.
    // GetSubscriptionsByType: Retrieves a list of subscriptions with the specified subscription type.
    // RenewSubscription: Renews the specified subscription, extending its validity according to the subscription type's duration.
    // CancelSubscription: Cancels the specified subscription, making it inactive and removing its associated benefits.
    public interface ISubscriptionService : IGenericService<Subscription>
    {
        Task<Subscription> CreateSubscription(Subscription subscription);
        
        Task<List<Subscription>> GetSubscriptionsByMember(Guid memberId);
        
        Task<List<Subscription>> GetSubscriptionsByType(string subscriptionType);
        
        Task RenewSubscription(Guid subscriptionId);
        
        Task CancelSubscription(Guid subscriptionId);
    }
}