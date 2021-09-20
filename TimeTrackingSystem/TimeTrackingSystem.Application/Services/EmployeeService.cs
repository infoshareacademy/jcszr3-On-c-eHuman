using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
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

        public ListOfEmployeesViewModel GetAll()
        {
            var employees = _employeeRepo.GetAll() //searching
                .ProjectTo<EmployeeDetailsViewModel>(_mapper.ConfigurationProvider).ToList(); //list of objects
            var employeesList = new ListOfEmployeesViewModel
            {
                Employees = employees
            };
            return employeesList;
        }

        public EmployeeDetailsViewModel Get(string accountId)
        {
            var employee = _employeeRepo.Get(accountId);
            var employeeVM = _mapper.Map<EmployeeDetailsViewModel>(employee); //single object
            return employeeVM;
        }
    }
}
