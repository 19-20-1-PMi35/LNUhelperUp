using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class EventController : Controller
    {
        public IActionResult ShowEvents()
        {
            return View();
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