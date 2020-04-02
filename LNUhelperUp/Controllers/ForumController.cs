using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult ShowQuestions()
        {
            return View();
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