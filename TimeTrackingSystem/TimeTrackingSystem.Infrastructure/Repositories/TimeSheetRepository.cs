using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly Context _context;
        public TimeSheetRepository(Context context)
        {
            _context = context;
        }

        public void DeleteTimeSheet(int timeSheetId)
        {
            var timeSheet = _context.Accounts.Find(timeSheetId);
            if (timeSheet != null)
            {
                _context.Accounts.Remove(timeSheet);
                _context.SaveChanges();
            }
        }

        public int AddTimeSheet(TimeSheet timeSheet)
        {
            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return timeSheet.Id;
        }

        public IQueryable<TimeSheet> GetTimeSheetsByEmployeeId(int accountId)
        {
            var timesheets = _context.TimeSheets.Where(i => i.AccountId == accountId);
            return timesheets;
        }

        public IQueryable<TimeSheet> GetAllTimeSheets()
        {
            var timesheets = _context.TimeSheets;
            return timesheets;
        }
        public TimeSheet GetTimeSheetDetails(int timesheetId)
        {
            var timesheet = _context.TimeSheets.FirstOrDefault(i => i.Id == timesheetId);
            return timesheet;
        }
    }
}
