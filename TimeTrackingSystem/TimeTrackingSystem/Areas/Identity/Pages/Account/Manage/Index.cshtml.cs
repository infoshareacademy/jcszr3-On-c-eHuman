using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeTrackingSystem.Domain.Model;

namespace TimeTrackingSystem.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "First name")]
            public string First_Name { get; set; }
            [Display(Name = "Last name")]
            public string Last_Name { get; set; }
            [Display(Name = "Photo profile")]
            public byte[] PhotoProfile { get; set; }
            public IFormFile PhotoProfileIFormFile { get; set; }

            public string Full_Name { get; set; }
            public string ProfilePhoto { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            var base64 = Convert.ToBase64String(user.PhotoProfile);
            string base64String = Convert.ToBase64String(user.PhotoProfile, 0, user.PhotoProfile.Length);
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Full_Name = user.First_Name + " " + user.Last_Name,
                PhotoProfile = user.PhotoProfile,
                ProfilePhoto = "data:image/png;base64," + base64String
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            user.First_Name = Input.First_Name;
            user.Last_Name = Input.Last_Name;
            user.Full_Name = Input.First_Name + " " + Input.Last_Name;
            using (var reader = new StreamReader(Input.PhotoProfileIFormFile.OpenReadStream()))
            {
                string contentAsString = reader.ReadToEnd();
                user.PhotoProfile = ConvertToBytes(Input.PhotoProfileIFormFile);
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}
