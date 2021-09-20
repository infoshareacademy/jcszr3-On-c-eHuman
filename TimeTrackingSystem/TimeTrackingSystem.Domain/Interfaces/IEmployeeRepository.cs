using System.Linq;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IQueryable<ApplicationUser> GetAll();
        ApplicationUser Get(string accountId);
    }
}
