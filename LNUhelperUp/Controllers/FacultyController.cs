using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
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
        private readonly IFacultyService _facultyService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FacultyController(IFacultyService facultyService, ILogger<FacultyController> logger, IHostingEnvironment hostingEnvironment)
        {
            _facultyService = facultyService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult ShowFaculties()
        {
            return View(_context.Faculties.ToList());
        }

        [HttpGet]
        public IActionResult Add(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ShowFaculties");
            }
            ViewBag.FacultyId = id;
            return View();
        }

        [HttpPost]
        public string Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();

            return "You just add " + faculty.Name;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            await faculty = await _context.Faculties.Find

            return RedirectToAction("ShowFaculties");
        }
    }
}