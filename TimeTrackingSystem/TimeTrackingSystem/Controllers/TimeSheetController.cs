using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Controllers
{
    [Authorize]
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TimeSheetController(ITimeSheetService timeSheetService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _timeSheetService = timeSheetService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _timeSheetService.GetAll(user.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime searchBy)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _timeSheetService.GetAll(user.Id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTimeSheet()
        {
            var user = await _userManager.GetUserAsync(User);
            var timeSheet = new TimeSheetDetailsViewModel();
            timeSheet.ApplicationUserId = user.Id;
            return View(timeSheet);
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeSheet(TimeSheetDetailsViewModel model)
        {
            var id = _timeSheetService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> YourTimeSheet()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new TimeSheetDetailsViewModel()
            {
                ApplicationUserId = user.Id,
                
            };
            var timeSheet = new List<TimeSheetDetailsViewModel>(31);
            timeSheet.AddRange(Enumerable.Repeat(model, 31));
            return View(timeSheet);
        }

        [HttpPost]
        public IActionResult YourTimeSheet(List<TimeSheetDetailsViewModel> model)
        {
            _timeSheetService.AddList(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTimeSheet(int id)
        {
            var employee = _timeSheetService.Edit(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditTimeSheet(TimeSheetDetailsViewModel model)
        {
            _timeSheetService.Update(model);
            return RedirectToAction("ViewTimeSheet", new { id = model.Id });
        }

        [HttpGet]
        public IActionResult RemoveTimeSheet(int id)
        {
            _timeSheetService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViewTimeSheet(int id)
        {
            var timesheetModel = _timeSheetService.Get(id);
            return View(timesheetModel);
        }

        [HttpGet]
        public IActionResult Callendar(int id)
        {
            var timesheetModel = _timeSheetService.GetAllForCallendar();
            var day= (new DateTime(2021, 9, 5)).DayOfWeek.ToString();
            return View(timesheetModel);
        }

    }
}

