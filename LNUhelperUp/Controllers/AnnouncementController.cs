using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
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


        public AnnouncementController(IEventService eventService, ILogger<AnnouncementController> logger, IHostingEnvironment hostingEnvironment)
        {
            _eventService = eventService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpDelete("{id}")]
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

        [HttpPut("{id}")]
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
            //var announcementNew = await _announcementService.CreateAnnouncementAsync(announcement);

            //if (announcementNew == null)
            //{
            //    return BadRequest(new { message = "Announcement is already exist" });
            //}

            return View();
        }
    }
}