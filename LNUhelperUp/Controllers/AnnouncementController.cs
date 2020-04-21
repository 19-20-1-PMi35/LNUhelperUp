using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class AnnouncementController : Controller
    {
        public IActionResult ShowAnnouncement()
        {
            return View();
        }

        public IActionResult AddAnnouncement()
        {
            return View();
        }
    }
}