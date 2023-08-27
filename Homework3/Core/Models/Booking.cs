using System;

namespace Core.Models
{
    public class Booking : BaseEntity
    {
        public Member Member { get; set; }
        public FitnessClass Class { get; set; }
        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; }
    }
}