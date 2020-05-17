using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class EventController : Controller
    {
        [Authorize]
        public IActionResult ShowEvents()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult ShowDetailesAboutEvent()
        {
            return View();
        }

        public IActionResult AddEvent()
        {
            return View();
        }

        public IActionResult TakePartInEvent()
        {
            return View();
        }

        public IActionResult AddPhoto()
        {
            return View();
        }
    }
}