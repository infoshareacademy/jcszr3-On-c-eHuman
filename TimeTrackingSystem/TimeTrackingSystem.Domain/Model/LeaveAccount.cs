using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class LeaveAccount
    {
        public Leave Leave { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
