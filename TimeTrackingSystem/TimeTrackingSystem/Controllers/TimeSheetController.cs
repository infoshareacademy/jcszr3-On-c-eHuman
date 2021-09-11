using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.TimeSheet;
using TimeTrackingSystem.Domain.Interfaces;

namespace TimeTrackingSystem.Controllers
{
    public class TimeSheetController : Controller
        {
            private readonly ITimeSheetService _timeSheetService;
            public TimeSheetController(ITimeSheetService timeSheetService)
            {
                _timeSheetService = timeSheetService;
            }
            [HttpGet]
            public IActionResult Index()
            {
                var model = _timeSheetService.GetAllTimeSheets(2, 1);
                return View(model);
            }

            [HttpPost]
            public IActionResult Index(int pageSize, int? pageNo, DateTime searchBy)
            {
                if (!pageNo.HasValue)
                {
                    pageNo = 1;
                }

                var model = _timeSheetService.GetAllTimeSheets(pageSize, pageNo.Value);
                return View(model);
            }

            [HttpGet]
            public IActionResult AddTimeSheet()
            {
                return View(new NewTimeSheetViewModel());
            }

            [HttpPost]
            public IActionResult AddTimeSheet(NewTimeSheetViewModel model)
            {
                var id = _timeSheetService.AddTimeSheet(model);
                return RedirectToAction("ViewTimeSheet", new { tsId = id });
            }


            [HttpGet]
            public IActionResult RemoveTimeSheet()
            {
                return View();
            }

            //[HttpPost]
            //public IActionResult RemoveEmployee(Account model)
            //{
            //    var id = _employeeService.RemoveEmployee(model);
            //    return View();
            //}

            public IActionResult ViewTimeSheet(int tsId)
            {
                var timesheetModel = _timeSheetService.GetTimeSheetDetails(tsId);
                return View(timesheetModel);
            }
        }

    }

