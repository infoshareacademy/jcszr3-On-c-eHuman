using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly Context _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public TimeSheetRepository(Context context)
        {
            _context = context;
        }

        public void Delete(int timeSheetId)
        {
            var timeSheet = _context.TimeSheets.Find(timeSheetId);
            if (timeSheet != null)
            {
                _context.TimeSheets.Remove(timeSheet);
                _context.SaveChanges();
            }
        }

        public int Add(TimeSheet timeSheet)
        {
            _context.TimeSheets.Add(timeSheet);
            _context.SaveChanges();
            return timeSheet.Id;
        }

        public TimeSheet Get(int timesheetId)
        {
            var timesheet = _context.TimeSheets.FirstOrDefault(i => i.Id == timesheetId);
            return timesheet;
        }

        public IQueryable<TimeSheetAccount> GetAll()
        {
            var timeSheet = from v in _context.TimeSheets
                join si in _context.ApplicationUsers on v.ApplicationUserId equals si.Id into loj
                from rs in loj.DefaultIfEmpty()
                where v.Date.Month == DateTime.Now.Month
                orderby v.Date
                select new TimeSheetAccount { ApplicationUser = rs, TimeSheet = v };
             return timeSheet;
        }

        public ILookup<DateTime, TimeSheet> GetAll(string ApplicationUserId)
        {
            var timeSheet = _context.TimeSheets.Include(x => x.ApplicationUser)
                .ToLookup(p => p.Date);
            return timeSheet;
        }

        public void Update(TimeSheet timesheet)
        {
            _context.Attach(timesheet);
            _context.Entry(timesheet).Property("Time_from").IsModified = true;
            _context.Entry(timesheet).Property("Time_to").IsModified = true;
            _context.Entry(timesheet).Property("Comments").IsModified = true;
            _context.SaveChanges();
        }
    }
}
