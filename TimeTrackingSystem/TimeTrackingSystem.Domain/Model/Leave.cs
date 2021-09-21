using System;
using System.Collections.Generic;

namespace TimeTrackingSystem.Domain.Model
{
    public class Leave
    {
        public int Id { get; set; }
        public int Leave_type { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Other_details { get; set; }
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
