using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int id);
        IQueryable<Account> GetAllActiveEmployees();
        ApplicationUser GetEmployeeDetails(int accountId);
        void UpdateEmployee(ApplicationUser employee);
    }
}
