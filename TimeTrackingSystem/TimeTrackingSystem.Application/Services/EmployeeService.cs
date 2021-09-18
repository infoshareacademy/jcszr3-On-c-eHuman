using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Application.ViewModels.Employee;
using TimeTrackingSystem.Domain.Interfaces;
using TimeTrackingSystem.Domain.Model;

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

        public NewEmployeeViewModel EmployeeForEdit(string id)
        {
            var employee = _employeeRepo.GetEmployeeDetails(id);
            var employeeVM = _mapper.Map<NewEmployeeViewModel>(employee);
            return employeeVM;
        }
        
        //public void UpdateEmployee(NewEmployeeViewModel model)
        //{
        //    var employee = _mapper.Map<Account>(model);
        //    _employeeRepo.UpdateEmployee(employee); 
        //}
        
        public ListOfEmployeesViewModel GetAllEmployees()
        {
            var employees = _employeeRepo.GetAllActiveEmployees()//searching
                .ProjectTo<EmployeeDetailsViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
            var employeesList = new ListOfEmployeesViewModel()
            {
                Employees = employees
            };
            return employeesList;
        }

        public EmployeeDetailsViewModel GetEmployeeDetails(string accountId)
        {
            var employee = _employeeRepo.GetEmployeeDetails(accountId);
            var employeeVM = _mapper.Map<EmployeeDetailsViewModel>(employee); //single object
            return employeeVM;
        }

        //public void RemoveEmployee(int id)
        //{
        //    _employeeRepo.DeleteEmployee(id);
        //} 
    }
}
