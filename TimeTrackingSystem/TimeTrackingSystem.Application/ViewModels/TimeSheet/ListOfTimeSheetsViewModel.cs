using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Application.ViewModels.TimeSheet
{
    public class ListOfTimeSheetsViewModel
    {
        public List<TimeSheetDetailsViewModel> TimeSheets { get; set; }
        public int Count { get; set; }
    }
}
