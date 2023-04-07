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
            try
            {
                if (member is null)
                {
                    throw new Exception("Member is null");
                }

                await Add(member);

                return member;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to register member. Exception: {ex.Message}");
            }
        }

        public async Task<List<Member>> GetActiveMembers()
        {
            try
            {
                var members = await GetAll();
                
                if (members is null)
                {
                    throw new Exception("Members are null");
                }

                return members.Where(m => m.IsActive).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get active members. Exception: {ex.Message}");
            }
        }

        public async Task<List<Member>> GetMembersBySubscriptionType(string subscriptionType)
        {
            try
            {
                var members = await GetAll();
                
                if (members is null)
                {
                    throw new Exception("Members are null");
                }

                return members.Where(m => Equals(m.SubscriptionType, subscriptionType)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get members by subscription type. Exception: {ex.Message}");
            }
        }

        public async Task<List<Member>> GetMembersWithUpcomingRenewal(DateTime startDate, DateTime endDate)
        {
            try
            {
                var members = await GetAll();
                
                if (members is null)
                {
                    throw new Exception("Members are null");
                }

                return members.Where(m => m.SubscriptionStartDate > startDate && m.SubscriptionEndDate < endDate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get members with upcoming renewal. Exception: {ex.Message}");
            }
        }

        public async Task<bool> CheckMemberAttendance(Guid memberId, DateTime date)
        {
            try
            {
                var member = await GetById(memberId);
                
                if (member is null)
                {
                    throw new Exception("Member is null");
                }

                if (member.SubscriptionStartDate == date)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check member attendance. Exception: {ex.Message}");
            }
        }

        public async Task RecordMemberAttendance(Guid memberId, DateTime date)
        {
            try
            {
                var member = await GetById(memberId);
                
                if (member is null)
                {
                    throw new Exception("Member is null");
                }

                member.SubscriptionStartDate = date;

                await Update(memberId, member);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to record member attendance. Exception: {ex.Message}");
            }
        }
    }
}