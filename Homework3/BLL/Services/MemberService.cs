using System;
using System.Collections.Generic;
using System.Linq;
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
            await Add(member);

            return member;
        }

        public async Task<List<Member>> GetActiveMembers()
        {
            var members = await GetAll();

            return members.Where(m => m.IsActive == true).ToList();
        }

        public async Task<List<Member>> GetMembersBySubscriptionType(string subscriptionType)
        {
            var members = await GetAll();

            return members.Where(m => Equals(m.SubscriptionType, subscriptionType)).ToList();
        }

        public async Task<List<Member>> GetMembersWithUpcomingRenewal(DateTime startDate, DateTime endDate)
        {
            var members = await GetAll();

            return members.Where(m => m.SubscriptionStartDate > startDate && m.SubscriptionEndDate < endDate).ToList();
        }

        public async Task<bool> CheckMemberAttendance(Guid memberId, DateTime date)
        {
            var member = await GetById(memberId);

            if (member.SubscriptionStartDate == date)
            {
                return true;
            }

            return false;
        }

        public async Task RecordMemberAttendance(Guid memberId, DateTime date)
        {
            var member = await GetById(memberId);

            member.SubscriptionStartDate = date;

            await Update(memberId, member);
        }
    }
}