using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
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
        public async Task<IActionResult> ShowProfile(int id = 1)
        {
            var user = await _userService.GetAsync(id);
            return View(user);
        }

        public async Task<IActionResult> MyEvents()
        {
            return View();
        }

        public async Task<IActionResult> MyDiscussions()
        {
            return View();
        }

        public async Task<IActionResult> EditProfile()
        {
            return View();
        }
    }
}