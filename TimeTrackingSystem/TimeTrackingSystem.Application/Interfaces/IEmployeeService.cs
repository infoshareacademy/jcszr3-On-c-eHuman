using TimeTrackingSystem.Application.ViewModels;

namespace TimeTrackingSystem.Application.Interfaces
{
    public interface IEmployeeService
    {
        ListOfEmployeesViewModel GetAll();
        EmployeeDetailsViewModel Get(string accountId);
    }
}
