﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LNUhelperUp.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult AddPhoto()
        {
            return View();
        }

        public IActionResult EndRegistration()
        {
            return View();
        }

        public IActionResult Enter()
        {
            return View();
        }
    }
}