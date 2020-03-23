using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ShowProfile()
        {
            return View();
        }

        public IActionResult MyEvents()
        {
            return View();
        }

        public IActionResult MyDiscussions()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }
    }
}