using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public async Task<List<Subscription>> GetSubscriptionsByMember(Guid memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subscription>> GetSubscriptionsByType(string subscriptionType)
        {
            throw new NotImplementedException();
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