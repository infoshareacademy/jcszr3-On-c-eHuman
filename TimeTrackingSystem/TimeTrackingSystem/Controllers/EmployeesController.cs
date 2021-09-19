using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.Employee;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public EmployeesController(IEmployeeService employeeService,
        SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _employeeService.GetAllEmployees();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Index(string searchBy)
        {
            if (searchBy is null)
            {
                searchBy = String.Empty;
            }
            var model = _employeeService.GetAllEmployees();
            return View(model);
        }

        //[HttpGet]
        //public IActionResult AddEmployee()
        //{
        //    return View(new NewEmployeeViewModel());
        //}

        //[HttpPost]
        //public IActionResult AddEmployee(NewEmployeeViewModel model)
        //{
        //    var id = _employeeService.AddEmployee(model);
        //    return RedirectToAction("ViewEmployee", new { accountId = id });
        //}

        //[HttpGet]
        //public IActionResult EditEmployee(string id)
        //{
        //    var employee = _employeeService.EmployeeForEdit(id);
        //    return View(employee);
        //}
        //[HttpPost]
        //public IActionResult EditEmployee(NewEmployeeViewModel model)
        //{
        //    //_employeeService.UpdateEmployee(model);
        //    //return RedirectToAction("ViewEmployee", new { accountId = model.Id });
        //    ////View(model);
        //    //RedirectToAction("ViewEmployee", new { accountId = id });
        //}

        //[HttpGet]
        //public IActionResult RemoveEmployee(int id)
        //{
        //    _employeeService.RemoveEmployee(id);
        //    return RedirectToAction("Index");
        //}
        public async Task<IActionResult> ViewEmployee(string ApplicationUserId)
        {
            var employeeModel = _employeeService.GetEmployeeDetails(ApplicationUserId);
            return View(employeeModel);
        }
    }
}
