using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class MemberService : GenericService<Member>, IMemberService
    {
        private readonly ISubscriptionService _subscriptionService;

        public MemberService(IRepository<Member> repository, ISubscriptionService subscriptionService) : base(repository)
        {
            _subscriptionService = subscriptionService;
        }

        public async Task<Member> RegisterMember(Member member)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Member>> GetActiveMembers()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Member>> GetMembersBySubscriptionType(string subscriptionType)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Member>> GetMembersWithUpcomingRenewal(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckMemberAttendance(Guid memberId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task RecordMemberAttendance(Guid memberId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}