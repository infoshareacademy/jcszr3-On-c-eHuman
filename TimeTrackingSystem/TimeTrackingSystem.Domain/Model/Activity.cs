using System;
using System.Collections.Generic;

namespace TimeTrackingSystem.Domain.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public int ProjectId { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Other_details { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }
    }
}
