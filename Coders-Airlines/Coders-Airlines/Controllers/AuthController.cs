using Coders_Airlines.Auth.Interfaces;
using Coders_Airlines.Auth.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coders_Airlines.Controllers
{
    public class AuthController : Controller
    {
        private IUser userService;
        public AuthController(IUser userSer)
        {
            userService = userSer;
        }

        /// <summary>
        /// This gets the sign in view for the Admins.
        /// </summary>
        /// <returns> Return the sign in view for the Admins. </returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This checks if the user exists.
        /// </summary>
        /// <param name="login"></param>
        /// <returns> Returns a view for the list of categories if user was found, else, redirect to the same view. </returns>
        public async Task<ActionResult<UserDTO>> Authenticate(LoginDTO login)
        {
            var user = await userService.Authenticate(login.UserName, login.Password);
            if (user == null)
            {
                return Redirect("/auth/index");
            }
            return RedirectToAction("List", "Category");
        }

        /// <summary>
        /// This method gets the sign up page for the Admins.
        /// </summary>
        /// <returns> Returns a view for the sign up page for the Admins. </returns>
        [Authorize(Roles = "editor,administrator")]
        public IActionResult SignUp()
        {
            return View();
        }

        /// <summary>
        /// This method checks for the sign up info.
        /// </summary>
        /// <param name="register"></param>
        /// <returns> Returns a view for the sign in view if the user got registered, else, return view for the same page. </returns>
        [Authorize(Roles = "editor,administrator")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterDTO register)
        {
            var user = await userService.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/auth/index");
            }
            return View(user);
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }

        /// <summary>
        /// This method is used to sign out the user.
        /// </summary>
        /// <returns> Returns a page of categories for the user. </returns>
        [Authorize(Roles = "user")]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Redirect("/Categories/Categories");
        }

        /// <summary>
        /// This method is used to sign out the Admins.
        /// </summary>
        /// <returns> Returns a view for the sign in view. </returns>
        [Authorize(Roles = "editor,administrator")]
        public async Task<IActionResult> AdminLogout()
        {
            await userService.Logout();
            return Redirect("/Auth/Index");
        }
    }
}
