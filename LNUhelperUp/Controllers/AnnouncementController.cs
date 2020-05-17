using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class AnnouncementController : Controller
    {
        [Authorize]
        public IActionResult ShowAnnouncement()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult AddAnnouncement()
        {
            return View();
        }
    }
}