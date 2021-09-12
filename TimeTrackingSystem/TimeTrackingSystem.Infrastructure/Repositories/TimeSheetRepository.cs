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
            var timeSheet = _context.TimeSheets.Find(timeSheetId);
            if (timeSheet != null)
            {
                _context.TimeSheets.Remove(timeSheet);
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

        public IQueryable<TimeSheetAccountDTO> GetAllTimeSheets()
        {
            var timesheetAccount = from v in _context.TimeSheets
                                   join si in _context.Accounts on v.AccountId equals si.Id into loj
                from rs in loj.DefaultIfEmpty()
                
                select new TimeSheetAccountDTO() { Employee = rs, TimeSheet = v };

            //var timesheetAccount = from v in _context.Accounts
            //    join si in _context.TimeSheets on v.Id equals si.AccountId into loj
            //    from rs in loj.DefaultIfEmpty()
            //    where
            //        v.IsEnable == true
            //    select new TimeSheetAccountDTO() { Employee = v, TimeSheet = rs };
            return timesheetAccount;
        }

        public TimeSheet GetTimeSheetDetails(int timesheetId)
        {
            var timesheet = _context.TimeSheets.FirstOrDefault(i => i.Id == timesheetId);
            
            return timesheet;
        }

        public void UpdateTimeSheet(TimeSheet timesheet)
        {
            _context.Attach(timesheet);
            _context.Entry(timesheet).Property("Time_from").IsModified = true;
            _context.Entry(timesheet).Property("Time_to").IsModified = true;
            _context.Entry(timesheet).Property("Comments").IsModified = true;
            _context.SaveChanges();
        }
    }
}
