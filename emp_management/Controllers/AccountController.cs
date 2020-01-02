using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace emp_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser>  signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


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
                foreach(var error in result.Errors)
                {
                    // Add them to modelState object
                    ModelState.AddModelError("", error.Description); // This will show up in view in - asp-validation-summary section
                }
            }
            return View(model); // when model not valid, send model back to the view
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
