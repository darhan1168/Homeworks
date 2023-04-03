using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class FitnessClass : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Trainer Trainer { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<Member> Attendees { get; set; }
    }
}