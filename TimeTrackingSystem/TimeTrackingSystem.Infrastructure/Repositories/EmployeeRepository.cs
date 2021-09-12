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

        public void DeleteEmployee(int accountId)
        {
            var account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
        }

        public int AddEmployee(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return account.Id;
        }

        public IQueryable<Account> GetEmployeesByRoleId(int roleId)
        {
            var accounts = _context.Accounts.Where(i => i.RoleId == roleId);
            return accounts;
        }

        public IQueryable<Account> GetAllActiveEmployees()
        {
            var accounts = _context.Accounts.Where(i => i.IsEnable);
            return accounts;
        }
        public Account GetEmployeeDetails(int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(i => i.Id == accountId);
            return account;
        }

        public void UpdateEmployee(Account employee)
        {
            _context.Attach(employee);
            _context.Entry(employee).Property("Email").IsModified = true;
            _context.Entry(employee).Property("Status").IsModified = true;
            _context.SaveChanges();
        }
    }
}
