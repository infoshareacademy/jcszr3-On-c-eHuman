using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels.Project;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ProjectController(IProjectService ProjectService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _projectService = ProjectService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _projectService.GetAll(user.Id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DateTime searchBy)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _projectService.GetAll(user.Id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddProject()
        {
            var user = await _userManager.GetUserAsync(User);
            var project = new ProjectDetailsViewModel();
            project.ApplicationUserId = user.Id;
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDetailsViewModel model)
        {
            var id = _projectService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProject(int id)
        {
            var employee = _projectService.Edit(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditProject(ProjectDetailsViewModel model)
        {
            _projectService.Update(model);
            return RedirectToAction("ViewProject", new { id = model.Id });
        }

        [HttpGet]
        public IActionResult RemoveProject(int id)
        {
            _projectService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ViewProject(int id)
        {
            var projectModel = _projectService.Get(id);
            return View(projectModel);
        }
    }
}

