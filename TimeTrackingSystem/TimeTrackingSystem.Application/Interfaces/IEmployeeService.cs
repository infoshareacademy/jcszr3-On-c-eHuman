using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.Employee;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IEmployeeService
    {
        ListOfEmployeesViewModel GetAllEmployees();
        int AddEmployee(NewEmployeeViewModel model);
        int RemoveEmployee(EmployeeDetailsViewModel model);
        EmployeeDetailsViewModel GetEmployeeDetails(int accountId);
    }
}
