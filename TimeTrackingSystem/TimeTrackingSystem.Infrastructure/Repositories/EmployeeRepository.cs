using System.Linq;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            var accounts = _context.ApplicationUsers;
            return accounts;
        }

        public ApplicationUser Get(string ApplicationUserId)
        {
            var account = _context.ApplicationUsers.FirstOrDefault(i => i.Id == ApplicationUserId);
            return account;
        }
    }
}
