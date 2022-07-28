using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity;

namespace Coders_Airlines.Pages.Profile
{
    [Authorize]
    public class editModel : PageModel
    {
        private readonly IUser _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        public editModel(IUser user, UserManager<ApplicationUser> manager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userService = user;
            _userManager = manager;
            _passwordHasher = passwordHasher;
        }

        [BindProperty]
        public ApplicationUser user { get; set; }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public string Gender { get; set; }
        [BindProperty]
        public DateTime DateOfBirth { get; set; }

        public async Task OnGet()
        {
            user = await _userService.GetUser();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userService.GetUser();

            if (!string.IsNullOrEmpty(UserName))
                user.UserName = UserName;
            else
                ModelState.AddModelError("", "UserName cannot be empty");
            if (!string.IsNullOrEmpty(Email))
                user.Email = Email;
            else
                ModelState.AddModelError("", "Email cannot be empty");


            if (!string.IsNullOrEmpty(PhoneNumber))
                user.PhoneNumber = PhoneNumber;
            else
                ModelState.AddModelError("", "PhoneNumber cannot be empty");
            if (!string.IsNullOrEmpty(Gender))
                user.Gender = Gender;
            else
                ModelState.AddModelError("", "Gender cannot be empty");
            
                user.DateOfBirth = DateOfBirth;
            if (!string.IsNullOrEmpty(Password))
                user.PasswordHash = _passwordHasher.HashPassword(user, Password);
            else
                ModelState.AddModelError("", "Password cannot be empty");
            
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(UserName))
            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (!ModelState.IsValid)
                {
                    return Page();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}