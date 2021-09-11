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

        public IQueryable<TimeSheet> GetTimeSheetsByTimeSheetId(int timeSheetId)
        {
            var timeSheets = _context.TimeSheets.Where(i => i.Id == timeSheetId);
            return timeSheets;
        }

        public TimeSheet GetTimeSheetById(int TimeSheetId)
        {
            var TimeSheet = _context.TimeSheets.FirstOrDefault(i => i.Id == TimeSheetId);
            return TimeSheet;
        }
    }
}
