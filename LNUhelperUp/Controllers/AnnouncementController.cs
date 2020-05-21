using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ILogger<AnnouncementController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;
        private readonly IUserService _userService;

        public AnnouncementController(IEventService eventService, ILogger<AnnouncementController> logger, 
            IHostingEnvironment hostingEnvironment, IImageService imageService, IUserService userService)
        {
            _imageService = imageService;
            _eventService = eventService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcementDb = await _eventService.GetEventAsync(id);

            if (announcementDb == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEventAsync(announcementDb);

            return RedirectToAction("GetAllAnnouncement", "Announcement");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement(EventDTO _eventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var announcementUpdated = await _eventService.UpdateEventAsync(_eventDTO);

            if (announcementUpdated == null)
            {
                return BadRequest(new { message = "Announcement id is incorrect" });
            }

            return Ok(announcementUpdated);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAnnouncement()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (HttpContext.Request.Cookies.ContainsKey("facultyId"))
                {
                    var events = await _eventService.GetAllEventAsync();

                    if (events == null)
                    {
                        return View();
                    }
                    ViewBag.facultyId = Int32.Parse(HttpContext.Request.Cookies["facultyId"]);
                    ViewBag.userRole = Int32.Parse(HttpContext.Request.Cookies["userRole"]);
                    return View(events);
                }
                else
                {
                    return RedirectToAction("GetAllFaculty", "Faculty");
                }
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public async Task<IActionResult> GetAnnouncement(int id)
        {
            var announcement = await _eventService.GetEventAsync(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement(AddOffEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                string startPath = "/Images/" + uniqueFileName;
                var eventDTO = new EventDTO
                {
                    Name = model.Name,
                    Text = model.Text,
                    CreateAt = DateTime.Now,
                    Time = Convert.ToDateTime(model.Time),
                    UserId = Int32.Parse(HttpContext.Request.Cookies["userId"]),
                    FacultyId = Int32.Parse(HttpContext.Request.Cookies["facultyId"]),
                    ImagePath = startPath,
                    IsOfficial = true
                };
                var newEvent = await _eventService.CreateEventAsync(eventDTO);
                return RedirectToAction("GetAllAnnouncement", "Announcement");
            }
            return View(model);
        }
        
    }
}