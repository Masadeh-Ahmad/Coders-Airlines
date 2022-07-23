using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coders_Airlines.Auth;
using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Coders_Airlines.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly IUser UserService;
        public IndexModel(IUser user)
        {
            UserService = user;
        }

        [BindProperty]
        public ApplicationUser user { get; set; }
        public async Task OnGet()
        {
            user = await UserService.GetUser();
        }
    }
}