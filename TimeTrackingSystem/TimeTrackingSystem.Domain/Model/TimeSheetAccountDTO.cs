using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Domain.Model
{
    public class TimeSheetAccountDTO
    {
        public TimeSheet TimeSheet { get; set; }
        public Account Employee { get; set; }
    }
}
