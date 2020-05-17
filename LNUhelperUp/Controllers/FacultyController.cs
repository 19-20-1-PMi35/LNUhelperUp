using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FacultyController : Controller
    {
        private readonly ILogger<FacultyController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFacultyService _facultyService;


        public FacultyController(IFacultyService facultyService, ILogger<FacultyController> logger, IHostingEnvironment hostingEnvironment)
        {
            _facultyService = facultyService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var facultyDb = await _facultyService.GetFacultyAsync(id);

            if (facultyDb == null)
            {
                return NotFound();
            }

            await _facultyService.DeleteFacultyAsync(facultyDb);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaculty(Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var facultyUpdated = await _facultyService.UpdateFacultyAsync(faculty);

            if (facultyUpdated == null)
            {
                return BadRequest(new { message = "Faculty id is incorrect" });
            }

            return Ok(facultyUpdated);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFaculty()
        {
            if (User.Identity.IsAuthenticated)
            {
                var faculties = await _facultyService.GetAllFacultyAsync();
                var name = User.Identity.Name;
                if (faculties == null)
                {
                    return NoContent();
                }

                return View(faculties);
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaculty(int id)
        {
            var faculty = await _facultyService.GetFacultyAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateFaculty(Faculty faculty)
        {
            var facultyNew = await _facultyService.CreateFacultyAsync(faculty);

            if (facultyNew == null)
            {
                return BadRequest(new { message = "Faculty is already exist" });
            }

            return Ok();
        }
    }
}