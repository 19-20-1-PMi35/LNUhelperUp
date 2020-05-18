using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IUserService userService, ILogger<ProfileController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [Authorize]
        public async Task<IActionResult> ShowProfile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetAsyncByEmail(User.Identity.Name);
                return View(user);
            }
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> MyEvents()
        {
            return View();
        }

        public async Task<IActionResult> MyDiscussions()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userService.GetUser(User.Identity.Name);
            ViewBag.FacultyId = user.FacultyId;
            ViewBag.Nickname = user.Nickname;
            ViewBag.Password = user.Password;
            ViewBag.Login = user.Login;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(User.Identity.Name, model);

                return RedirectToAction("ShowProfile", "Profile");
            }
            return View();
        }
    }
}