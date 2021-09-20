using System.Linq;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface ITimeSheetRepository
    {
        void Delete(int entityId);
        int Add(TimeSheet entity);
        TimeSheet Get(int entityId);
        IQueryable<TimeSheetAccount> GetAll(string ApplicationUserId);
        void Update(TimeSheet entity);
    }
}
