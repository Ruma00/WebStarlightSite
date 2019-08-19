using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarlightProject_Site.Models;

namespace StarlightProject_Site.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        RoleManager<IdentityRole> _roleManager;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Create()
        {
            IdentityRole role = await _roleManager.FindByNameAsync("zbt");
            if (role == null)
            {
                role = new IdentityRole("zbt");
                IdentityResult result = await _roleManager.CreateAsync(role);
            }

            role = await _roleManager.FindByNameAsync("admin");
            if (role == null)
            {
                role = new IdentityRole("admin");
                IdentityResult result = await _roleManager.CreateAsync(role);
            }

            role = await _roleManager.FindByNameAsync("user");
            if (role == null)
            {
                role = new IdentityRole("user");
                IdentityResult result = await _roleManager.CreateAsync(role);
            }

            return null;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            await Create();
            
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.Email.Contains("admin"))
                        await _userManager.AddToRoleAsync(user, "admin");
                    else
                    //await _userManager.AddToRoleAsync(user, "admin");
                        await _userManager.AddToRoleAsync(user, "zbt");

                    // установка куки
                    //await _signInManager.SignInAsync(user, false);
                    //return RedirectToAction("Index", "Home");
                    return RedirectToAction("Register", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}