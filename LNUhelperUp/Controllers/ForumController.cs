using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class ForumController : Controller
    {
        [Authorize]
        public IActionResult ShowQuestions()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult ShowCurrentQuestion()
        {
            return View();
        }
        public IActionResult AddQuestion()
        {
            return View();
        }
    }
}