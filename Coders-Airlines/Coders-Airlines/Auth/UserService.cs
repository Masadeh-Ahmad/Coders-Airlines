using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model;
using Coders_Airlines.Auth.Model.DTO;
using Coders_Airlines.Data;
using Coders_Airlines.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coders_Airlines.Auth
{
    public class UserService : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        // Use the signInManager and userManager to sign in and sign up.
        private SignInManager<ApplicationUser> _signInManager;
        private readonly AirlinesDbContext _context;
        private readonly IEmail _email;
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor to assign these variables.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="SignInMngr"></param>
        /// <param name="dbContext"></param>
        /// <param name="email"></param>
        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr, AirlinesDbContext dbContext, IEmail email, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = SignInMngr;
            _context = dbContext;
            _email = email;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// This method is responsible for the registration of any user.
        /// </summary>
        /// <param name="registerDto"></param>
        /// <param name="modelstate"></param>
        /// <returns> It returns UserDTO object when created, else, show list of errors. </returns>
        public async Task<UserDTO> Register(RegisterDTO registerDto, ModelStateDictionary modelstate)
        {
            //Cart cart = new Cart { };
            //_context.Entry(cart).State = EntityState.Added;
            //await _context.SaveChangesAsync();

            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Gender = registerDto.Gender,
                DateOfBirth = registerDto.DateOfBirth
                //Cart = cart

            };
            // user.CartID = user.Id;

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // here goes the roles specifications ... 
                IList<string> Roles = new List<string>();

                Roles.Add("administrator");

                await _userManager.AddToRolesAsync(user, Roles);
                //await _email.WelcomeMail(registerDto.Email);
                return new UserDTO
                {
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }
            // Else, that means there is an error, let us collect all the errors using the modelState
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.UserName) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;
        }



        /// <summary>
        /// Check if we have a username and a password in our database for a user in our database.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns> Return a userDTO or null if it doesn't exist or if the login info does not match. </returns>
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            // replace the usage of the userManager and use the signinmanager
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            // get the user from the user manager after successfully operating login
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new UserDTO
                {
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            return null;
        }

        /// <summary>
        /// This method is used to sign out the current logged in user.
        /// </summary>
        /// <returns> It doesn't return anything. </returns>
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> GetUser()
        {
            return await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);

        }
    }
}
