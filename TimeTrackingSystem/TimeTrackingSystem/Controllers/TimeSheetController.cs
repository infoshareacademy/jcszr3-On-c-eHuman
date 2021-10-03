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
            var timeSheetAccount = _timeSheetService.GetAll(user.Id).TimeSheets.Where(x=>x.TimeSheet.Date.Month == DateTime.Now.Month).ToList();
            if (timeSheetAccount != null)
            {
                var timeSheetList = new List<TimeSheetDetailsViewModel>();
                foreach (var item in timeSheetAccount)
                {
                    timeSheetList.Add(item.TimeSheet);
                }
                
                return View(timeSheetList);
            }
            else
            {
                DateTime date = DateTime.Now;
                int lastDayOfMonth = (new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1)).Day;

                var timeSheetDetails = new List<TimeSheetDetailsViewModel>();
                for (int i = 1; i <= lastDayOfMonth; i++)
                {
                    var model = new TimeSheetDetailsViewModel()
                    {
                        ApplicationUserId = user.Id,
                        Date = new DateTime(date.Year, date.Month, i)
                    };
                    timeSheetDetails.Add(model);
                }
                
                return View(timeSheetDetails);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> YourTimeSheet(List<TimeSheetDetailsViewModel> model)
        {
            var user = await _userManager.GetUserAsync(User);
            var timeSheetAccount = _timeSheetService.GetAll(user.Id).TimeSheets.Where(x => x.TimeSheet.Date.Month == DateTime.Now.Month).ToList();
            if (timeSheetAccount != null)
            {
                foreach (var item in model)
                {
                    _timeSheetService.Update(item);
                }
            }
            else
            {
                _timeSheetService.AddList(model);
            }
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

