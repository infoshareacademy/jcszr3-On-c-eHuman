using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TimeTrackingSystem.Application.Interfaces;
using TimeTrackingSystem.Application.ViewModels;
using TimeTrackingSystem.Domain.Model;
using TimeTrackingSystem.Infrastructure;

namespace TimeTrackingSystem.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Context _context;
        public EmployeesController(IEmployeeService employeeService,
        SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
        Context context)
        {
            _employeeService = employeeService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string contentAsString = reader.ReadToEnd();
                byte[] contentAsByteArray = ConvertToBytes(file);
                return File(contentAsByteArray, file.ContentType);
            }
        }

        private byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }



        public async Task<ActionResult> Edit()
        {
            var myUserId = _userManager.GetUserId(User);
            var myUser = _context.ApplicationUsers.FirstOrDefault(x => x.Id == myUserId);

            if (myUserId == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await _userManager.FindByIdAsync(myUserId);

            if (user == null)
            {
                //return HttpNotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            return View(new EmployeeDetailsViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Full_Name = user.First_Name + " " + user.Last_Name,
                PhotoProfile = user.PhotoProfile
            });
        }

        //
        // POST: /User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "FirstName,LastName,DisplayName,Gender,UserName,Email,Id,Year,Month,Day")] EmployeeDetailsViewModel editUser)
        //{
        //    DateTime dob = new DateTime(editUser.Year, editUser.Month, editUser.Day);
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByIdAsync(editUser.Id);
        //        if (user == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        user.Email = editUser.Email;
        //        user.First_Name = editUser.First_Name;
        //        user.Last_Name = editUser.Last_Name;
        //        user.Full_Name = user.First_Name + " " + user.Last_Name;


        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", result.Errors.First());
        //            return View();
        //        }
        //        result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(userRoles).ToArray<string>());

        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", result.Errors.First());
        //            return View();
        //        }

        //        var name = user.DisplayName;
        //        var message = editsuccess.Content;
        //        context.Clients.All.addNewMessageToPage(name, message);
        //        return RedirectToAction("MyProfile");
        //    }
        //    ModelState.AddModelError("", "Something failed.");
        //    return View();
        //}
    }
}
