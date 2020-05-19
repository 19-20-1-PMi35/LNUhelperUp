using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    [Controller]
    public class FacultyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FacultyController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFacultyService _facultyService;


        public FacultyController(IMapper mapper, IFacultyService facultyService, ILogger<FacultyController> logger, IHostingEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _facultyService = facultyService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFaculty()
        {
            if (User.Identity.IsAuthenticated)
            {
                var faculties = await _facultyService.GetAllFacultyAsync();
                if (faculties == null)
                {
                    return NoContent();
                }

                return View(faculties);
            }
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> GetFaculty(int id)
        {
            var faculty = await _facultyService.GetFacultyAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        [HttpGet]
        public IActionResult CreateFaculty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaculty(FacultyDTO facultyDTO)
        {
            var faculty = _mapper.Map<Faculty>(facultyDTO);

            var facultyNew = await _facultyService.CreateFacultyAsync(faculty);

            if (facultyNew == null)
            {
                return BadRequest(new { message = "Faculty is already exist" });
            }

            return View();
        }


        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var facultyDb = await _facultyService.GetFacultyAsync(id);

            if (facultyDb == null)
            {
                return NotFound();
            }

            await _facultyService.DeleteFacultyAsync(facultyDb);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFaculty(int id)
        {
            var faculty = await _facultyService.GetFacultyAsync(id);
            ViewBag.Name = faculty.Name;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFaculty(FacultyDTO facultyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var facultyUpdated = await _facultyService.UpdateFacultyAsync(facultyDTO);

            if (facultyUpdated == null)
            {
                return BadRequest(new { message = "Faculty id is incorrect" });
            }
            else
            {
                return RedirectToAction("GetAllFaculty", "Faculty");
            }
        }

    }
}