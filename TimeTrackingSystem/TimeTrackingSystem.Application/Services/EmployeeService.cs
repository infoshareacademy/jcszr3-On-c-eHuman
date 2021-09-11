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

        public int AddEmployee(NewEmployeeViewModel employee)
        {
            var emp = _mapper.Map<Account>(employee);
            var id = _employeeRepo.AddEmployee(emp);
            return id;

        }

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

        public int RemoveEmployee(EmployeeDetailsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
