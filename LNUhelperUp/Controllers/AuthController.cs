using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFacultyService _facultyService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, ILogger<AuthController> logger, IFacultyService facultyService)
        {
            _facultyService = facultyService;
            _userService = userService;
            _logger = logger;
        }
        public IActionResult AddPhoto()
        {
            return View();
        }

        public IActionResult EndRegistration()
        {
            return View();
        }

        public IActionResult Enter()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetAsync(model);
                if (user != null)
                {
                    await Authenticate(model.Login);

                    return RedirectToAction("GetAllFaculty", "Faculty");
                }
                ModelState.AddModelError("", "Невірний пароль та(або) логін");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var faculties = await _facultyService.GetAllFacultyAsync();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _userService.CreateUserAsync(model);
                if (user != null)
                {
                    await Authenticate(model.Login);

                    return RedirectToAction("GetAllFaculty", "Faculty");
                }
                ModelState.AddModelError("", "Невірний пароль та(або) логін");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("facultyId");
            return RedirectToAction("Login", "Auth");
        }
    }
}