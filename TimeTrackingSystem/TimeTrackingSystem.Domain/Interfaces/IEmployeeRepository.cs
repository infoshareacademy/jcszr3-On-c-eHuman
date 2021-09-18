using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(string id);
        IQueryable<ApplicationUser> GetAllActiveEmployees();
        ApplicationUser GetEmployeeDetails(string accountId);
        void UpdateEmployee(ApplicationUser employee);
    }
}
