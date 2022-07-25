using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Coders_Airlines.Auth.Model.DTO;
using Coders_Airlines.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Auth
{
    public class SignUpModel : PageModel
    {
        private readonly IUser UserService;
       


        [BindProperty]
        public RegisterDTO input { get; set; }

        public SignUpModel(IUser user)
        {
            UserService = user;
        }

        public async Task OnGet()
        {
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            RegisterDTO person = new RegisterDTO()
            {
                UserName = input.UserName,
                Email = input.Email,
                Password = input.Password,
                DateOfBirth = input.DateOfBirth,
                Gender = input.Gender,
                PhoneNumber = input.PhoneNumber
            };
            var user = await UserService.Register(person, this.ModelState);

            return RedirectToPage("/Auth/LogIn");
        }
    }
}
