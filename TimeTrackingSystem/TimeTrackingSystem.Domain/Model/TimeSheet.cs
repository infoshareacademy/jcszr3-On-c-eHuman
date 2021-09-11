using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time_from { get; set; }
        public DateTime Time_to { get; set; }
        public string Comments { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public DateTime Date_submitted { get; set; }

        
    }
}
