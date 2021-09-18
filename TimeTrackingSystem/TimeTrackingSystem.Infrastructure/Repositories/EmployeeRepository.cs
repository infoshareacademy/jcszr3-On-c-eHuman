using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void DeleteEmployee(int id)
        {
            var account = _context.ApplicationUsers.Find(id);
            if (account != null)
            {
                _context.ApplicationUsers.Remove(account);
                _context.SaveChanges();
            }
        }

        public IQueryable<Account> GetAllActiveEmployees()
        {
            //var accounts = _context.ApplicationUsers.Where(i => i.IsEnable);
            return default;
        }
        public ApplicationUser GetEmployeeDetails(int accountId)
        {
            //var account = _context.ApplicationUsers.FirstOrDefault(i => i.Id == accountId);
            return default;
        }

        public void UpdateEmployee(ApplicationUser employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).Property("Email").IsModified = true;
            _context.Entry(employee).Property("Status").IsModified = true;
            _context.SaveChanges();
        }
    }
}
