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

            return Ok();
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
                var events = await _eventService.GetAllEventAsync();
               
                if (events == null)
                {
                    return View();
                }

                return View(events);
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
        public async Task<IActionResult> CreateAnnouncement(AddEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                string startPath = "/Images/" + uniqueFileName;
                var user = await _userService.GetAsyncByEmail(User.Identity.Name);
                int facultyId = Int32.Parse(HttpContext.Request.Cookies["facultyId"]);
                var eventDTO = new EventDTO
                {
                    Name = model.Name,
                    Text = model.Text,
                    CreateAt = DateTime.Now,
                    Time = DateTime.Now,
                    UserId = user.Id,
                    FacultyId = facultyId,
                    IsOfficial = true
                };
                var newEvent = await _eventService.CreateEventAsync(eventDTO);
                var image = await _imageService.CreateAsync(model.Photo.Name, startPath);
                var editPhotoEvent = new EditPhotoViewModel { ImageId = image.Id };
                await _eventService.UpdatePhototAsync(newEvent.Id, editPhotoEvent);
                return RedirectToAction("GetAllAnnouncement", "Announcement");
            }
            return View(model);
        }
        
    }
}