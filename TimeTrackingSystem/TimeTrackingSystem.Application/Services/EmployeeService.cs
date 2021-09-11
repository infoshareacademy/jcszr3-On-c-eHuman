using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.Employee;
using TimeTrackingSystem.Domain.Interfaces;

namespace TimeTrackingSystem.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public int AddEmployee(NewEmployeeViewModel model)
        {
            throw new NotImplementedException();
        }

        public ListOfEmployeesViewModel GetAllEmployees()
        {
            var employees = _employeeRepo.GetAllActiveEmployees().ProjectTo<EmployeeDetailsViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
            var employeesList = new ListOfEmployeesViewModel()
            {
                Employees = employees,
                Count = employees.Count
            };
            return employeesList;
        }

        public EmployeeDetailsViewModel GetEmployeeDetails(int accountId)
        {
            var employee = _employeeRepo.GetEmployeeDetails(accountId);
            var employeeVM = _mapper.Map<EmployeeDetailsViewModel>(employee); //single object

            throw new NotImplementedException();
        }

        public int RemoveEmployee(EmployeeDetailsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
