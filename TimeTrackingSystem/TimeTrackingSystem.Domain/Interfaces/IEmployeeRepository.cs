using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int accountId);
        int AddEmployee(Account account);
        IQueryable<Account> GetEmployeesByRoleId(int roleId);
        IQueryable<Account> GetAllActiveEmployees();
        Account GetEmployeeDetails(int accountId);
    }
}
