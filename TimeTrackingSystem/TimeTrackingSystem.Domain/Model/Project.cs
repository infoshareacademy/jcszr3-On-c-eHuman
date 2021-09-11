using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class Project
    {
        public int Id { get; set; }
        public int Project_code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int AccountId { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Other_details { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

    }
}
