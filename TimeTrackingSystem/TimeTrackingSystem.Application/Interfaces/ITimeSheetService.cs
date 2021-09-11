using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService
    {
        ListOfTimeSheetsViewModel GetAllTimeSheets();
        int AddTimeSheet(NewTimeSheetViewModel model);
        int RemoveTimeSheet(TimeSheetDetailsViewModel model);
        TimeSheetDetailsViewModel GetTimeSheetDetails(int accountId);
    }
}
