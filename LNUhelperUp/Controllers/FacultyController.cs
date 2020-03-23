using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class FacultyController : Controller
    {
        public IActionResult ShowFaculties()
        {
            return View();
        }
    }
}