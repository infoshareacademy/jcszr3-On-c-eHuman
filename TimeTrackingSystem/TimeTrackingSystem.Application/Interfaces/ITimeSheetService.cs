using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService
    {
        ListOfTimeSheetsViewModel GetAllTimeSheets(int pageSize, int pageNo);
        int AddTimeSheet(NewTimeSheetViewModel model);
        int RemoveTimeSheet(TimeSheetDetailsViewModel model);
        TimeSheetDetailsViewModel GetTimeSheetDetails(int id);
        NewTimeSheetViewModel TimeSheetForEdit(int id);
        void UpdateTimeSheet(NewTimeSheetViewModel model);
        
    }
}
