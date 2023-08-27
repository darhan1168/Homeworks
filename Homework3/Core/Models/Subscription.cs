using System;
using Core.Enums;

namespace Core.Models
{
    public class Subscription : BaseEntity
    {
        public Member Member { get; set; }
        public SubscriptionType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}