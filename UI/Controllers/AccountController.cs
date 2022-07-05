using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.Extensions;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            var model = new UserViewModel
            {
                User = new User()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewBag.ErrorMsgRegister = _userService.Add(user);
            if (ViewBag.ErrorMsgRegister <= 1)
            {
                return View();
            }
            TempData["message"] = "Registered succesfully";
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(User user)
        {
            if (_userService.Validate(user))
            {
                //HttpContext.Session.SetString("CurrentUserName", user.Username);
                //HttpContext.Session.Remove("CurrentUserName");
                var claims = new List<Claim>
                {
                    new Claim("user", user.Username),
                    new Claim("role", _userService.RoleToString(user))
                };
                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));
                TempData["message"] = "Logged in successfully";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMsgLogin = true;
            return View();
        }
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            
            await HttpContext.SignOutAsync();
            TempData["message"] = "Logged out succesfully";
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Users()
        {
            var model = new UserViewModel
            {
                Users = _userService.GetAll()
            };
            return View(model);
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Delete(int id)
        {
            TempData["message"] = _userService.GetById(id).Username + " deleted";
            _userService.Delete(_userService.GetById(id));
            return RedirectToAction("Users", "Account");
        }
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Edit(int id)
        {
            var model = new UserViewModel
            {
                User = _userService.GetById(id)
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _userService.Update(user);
            TempData["message"] = user.Username +" updated successfully";
            return RedirectToAction("Users", "Account");
        }
    }
}
