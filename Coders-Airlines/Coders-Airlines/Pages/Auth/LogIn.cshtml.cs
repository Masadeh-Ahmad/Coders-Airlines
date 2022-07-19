using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Coders_Airlines.Pages.Auth
{
    public class LogInModel : PageModel
    {
        private readonly IUser UserService;

        [BindProperty]
        public LoginDTO input { get; set; }
        public UserDTO user;

        public LogInModel(IUser user)
        {
            UserService = user;
        }

        public async Task OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            LoginDTO person = new LoginDTO()
            {
                UserName = input.UserName,
                Password = input.Password
            };
            user = await UserService.Authenticate(person.UserName, person.Password);
            if (user != null)
                return RedirectToPage("/");
            return RedirectToPage("/Auth/LogIn");

        }
    }
}
