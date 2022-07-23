using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity;

namespace Coders_Airlines.Pages.Profile
{
    public class editModel : PageModel
    {
        private readonly IUser _userService;
        public editModel(IUser user)
        {
            _userService = user;
        }

        [BindProperty]
        public ApplicationUser user { get; set; }

        public async Task OnGet()
        {
            user = await _userService.GetUser();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _userService.UpdateUser(user);

            return RedirectToPage("./Index");
        }
    }
}
