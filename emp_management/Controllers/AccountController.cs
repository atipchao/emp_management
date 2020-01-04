using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace emp_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [AllowAnonymous]
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use.");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //First thing, check model-state
            if (ModelState.IsValid)
            {
                // crete a new indentity object
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // when NOT successful result, we want to loop thru each result
                foreach (var error in result.Errors)
                {
                    // Add them to modelState object
                    ModelState.AddModelError("", error.Description); // This will show up in view in - asp-validation-summary section
                }
            }
            return View(model); // when model not valid, send model back to the view
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //First thing, check model-state
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //Add prevent OpenRedirect attacks
                    if (!string.IsNullOrEmpty(returnUrl) && (Url.IsLocalUrl(returnUrl)))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                    
                }

                // when NOT successful result, we want to loop thru each result


                // Add them to modelState object
                ModelState.AddModelError(string.Empty, "Invalid Login Attemped!"); // This will show up in view in - asp-validation-summary section

            }
            return View(model); // when model not valid, send model back to the view
        }
    }
}
