using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface ITimeSheetRepository
    {
        void DeleteTimeSheet(int timeSheetId);
        int AddTimeSheet(TimeSheet timeSheet);
        IQueryable<TimeSheet> GetTimeSheetsByEmployeeId(int accountId);
        IQueryable<TimeSheetAccountDTO> GetAllTimeSheets();
        TimeSheet GetTimeSheetDetails(int TimeSheetId);
        void UpdateTimeSheet(TimeSheet timesheet);
    }
}
