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

        public void DeleteEmployee(string id)
        {
            var account = _context.ApplicationUsers.Find(id);
            if (account != null)
            {
                _context.ApplicationUsers.Remove(account);
                _context.SaveChanges();
            }
        }

        public IQueryable<ApplicationUser> GetAllActiveEmployees()
        {
            var accounts = _context.ApplicationUsers;
            return accounts;
        }
        public ApplicationUser GetEmployeeDetails(string ApplicationUserId)
        {
            var account = _context.ApplicationUsers.FirstOrDefault(i => i.Id == ApplicationUserId);
            return account;
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
