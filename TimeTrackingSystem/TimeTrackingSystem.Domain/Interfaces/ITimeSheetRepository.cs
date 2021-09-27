using System;
using System.Linq;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface ITimeSheetRepository : IGenericRepository<TimeSheet>
    {
        IQueryable<TimeSheetAccount> GetAll();
    }
}
