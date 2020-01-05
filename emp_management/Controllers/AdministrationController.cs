using emp_management.Models;
using emp_management.ViewModes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emp_management.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<ApplicationUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                // If there's any error ... it will fall down here..
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model); 
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles; 
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            // uses roleId to get role from RoleManagerService 
            var role =  await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found..";
                return View("NotFound");
            }
            else
            {

            }
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };
            //Get uses within the role by using IdentityUser Service
            foreach(var user in  _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {

            if(ModelState.IsValid)
            {

            }
            // uses roleId to get role from RoleManagerService 
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found..";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                // Now we update the role using "roleManager.UpdateAsync"  ==> this returns IdentityResult
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                // If there's any errro
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

    }
}
