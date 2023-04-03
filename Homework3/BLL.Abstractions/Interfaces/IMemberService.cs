using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // RegisterMember: Registers a new member with the given registration information.
    // GetActiveMembers: Retrieves a list of active members in the club.
    // GetMembersBySubscriptionType: Retrieves a list of members with the specified subscription type.
    // GetMembersWithUpcomingRenewal: Retrieves a list of members with upcoming subscription renewals between the given start and end dates.
    // CheckMemberAttendance: Checks if the member attended the club on the specified date.
    // RecordMemberAttendance: Records the attendance of the member on the specified date.
    public interface IMemberService : IGenericService<Member>
    {
        Task<Member> RegisterMember(Member member);
        
        Task<List<Member>> GetActiveMembers();
        
        Task<List<Member>> GetMembersBySubscriptionType(string subscriptionType);
        
        Task<List<Member>> GetMembersWithUpcomingRenewal(DateTime startDate, DateTime endDate);
        
        Task<bool> CheckMemberAttendance(Guid memberId, DateTime date);
        
        Task RecordMemberAttendance(Guid memberId, DateTime date);
    }
}