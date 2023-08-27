using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Trainer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public ICollection<DateTime> AvailableDates { get; set; }
    }
}