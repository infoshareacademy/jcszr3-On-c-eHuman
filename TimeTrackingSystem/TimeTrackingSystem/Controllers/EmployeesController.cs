using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeTrackingSystem.Application.Interfaces;
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
            var model = _employeeService.GetAll();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult Index(string searchBy)
        {
            if (searchBy is null)
            {
                searchBy = String.Empty;
            }
            var model = _employeeService.GetAll();
            return View(model);
        }

        public async Task<IActionResult> View(string ApplicationUserId)
        {
            var employeeModel = _employeeService.Get(ApplicationUserId);
            return View(employeeModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
