using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio_Dev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Dev.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Login)
        {
            
            if (!ModelState.IsValid)
                 return View(Login);

                var user = await _userManager.FindByNameAsync(Login.UserName);
            
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, Login.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(Login.ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        return Redirect(Login.ReturnUrl);
                    }
                }
            
               ModelState.AddModelError("", "Falha ao realizar Login!");
               return View("Login");
        }
        public  IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel Register)
        {
            if (ModelState.IsValid)
            {
                var User = new IdentityUser(){ UserName=Register.UserName, Email = Register.Email };
                
                    var result = await _userManager.CreateAsync(User, Register.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("Registro", "Falha ao realizar cadastro!");
                    }
                
                
            }
            return View(Register);
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.User = null;
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
