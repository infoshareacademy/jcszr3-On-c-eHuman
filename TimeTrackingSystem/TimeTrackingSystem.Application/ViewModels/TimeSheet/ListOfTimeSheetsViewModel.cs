using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTrackingSystem.Application.ViewModels.TimeSheet
{
    public class ListOfTimeSheetsViewModel
    {
        public List<TimeSheetAccountDTOViewModel> TimeSheets { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public DateTime SearchByDate { get; set; }
        public int Count { get; set; }
    }
}
