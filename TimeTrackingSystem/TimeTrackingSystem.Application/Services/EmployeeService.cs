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

        public NewEmployeeViewModel EmployeeForEdit(int id)
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
        
        public ListOfEmployeesViewModel GetAllEmployees(int pageSize, int pageNo, string searchBy)
        {
            var employees = _employeeRepo.GetAllActiveEmployees().Where(p => p.Email.Contains(searchBy)) //searching
                .ProjectTo<EmployeeDetailsViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects

            var employeesToShow = employees.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList(); //pagination

            var employeesList = new ListOfEmployeesViewModel()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchBy,
                Employees = employeesToShow,
                Count = employees.Count
            };
            return employeesList;
        }

        public EmployeeDetailsViewModel GetEmployeeDetails(int accountId)
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
