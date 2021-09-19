using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface ITimeSheetService
    {
        ListOfTimeSheetsViewModel GetAllTimeSheets(string Id);
        int AddTimeSheet(NewTimeSheetViewModel model);
        void RemoveTimeSheet(int id);
        TimeSheetDetailsViewModel GetTimeSheetDetails(int id);
        NewTimeSheetViewModel TimeSheetForEdit(int id);
        void UpdateTimeSheet(NewTimeSheetViewModel model);
        
    }
}
