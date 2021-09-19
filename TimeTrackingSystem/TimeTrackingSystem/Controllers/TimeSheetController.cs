using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;
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
            var model = _timeSheetService.GetAllTimeSheets(user.Id);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> Index(DateTime searchBy)
            {
                var user = await _userManager.GetUserAsync(User);
            var model = _timeSheetService.GetAllTimeSheets(user.Id); 
            return View(model);
            }

            [HttpGet]
            public async Task<IActionResult> AddTimeSheet()
            {
                var user = await _userManager.GetUserAsync(User);
                var timeSheet = new NewTimeSheetViewModel();
                timeSheet.ApplicationUserId = user.Id;
            return View(timeSheet);
            }

            [HttpPost]
            public async Task<IActionResult> AddTimeSheet(NewTimeSheetViewModel model)
            {
                var id = _timeSheetService.AddTimeSheet(model);
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult EditTimeSheet(int id)
            {
                var employee = _timeSheetService.TimeSheetForEdit(id);
                return View(employee);
            }
            [HttpPost]
            public IActionResult EditTimeSheet(NewTimeSheetViewModel model)
            {
                _timeSheetService.UpdateTimeSheet(model);
                return RedirectToAction("ViewTimeSheet", new { id = model.Id });
                //View(model);
                //RedirectToAction("ViewEmployee", new { accountId = id });
            }

        [HttpGet]
            public IActionResult RemoveTimeSheet(int id)
            {
            _timeSheetService.RemoveTimeSheet(id);
            return RedirectToAction("Index");
        }

            public IActionResult ViewTimeSheet(int id)
            {
                var timesheetModel = _timeSheetService.GetTimeSheetDetails(id);
                return View(timesheetModel);
            }
        }

    }

