using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.Activity;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ActivityController(IActivityService activityService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _activityService = activityService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            var model = _activityService.GetAll(Id);
            
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int projectId)
        {
            var activity = new ActivityDetailsViewModel();
            activity.ProjectId = projectId;
            return View(activity);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityDetailsViewModel model)
        {
            var id = _activityService.Add(model);
            return RedirectToAction("Index", new { Id = model.ProjectId });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _activityService.Edit(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(ActivityDetailsViewModel model)
        {
            _activityService.Update(model);
            return RedirectToAction("View", new { id = model.Id });
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _activityService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult View(int id)
        {
            var activityModel = _activityService.Get(id);
            return View(activityModel);
        }
    }
}

