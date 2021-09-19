using System;
using System.Collections.Generic;
using System.Text;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.Employee;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IEmployeeService
    {
        ListOfEmployeesViewModel GetAllEmployees();
        EmployeeDetailsViewModel GetEmployeeDetails(string accountId);
        NewEmployeeViewModel EmployeeForEdit(string id);
        //void UpdateEmployee(NewEmployeeViewModel model);
    }
}
