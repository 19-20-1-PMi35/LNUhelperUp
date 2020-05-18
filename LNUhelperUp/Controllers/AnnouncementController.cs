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
    public class AnnouncementController : Controller
    {
        private readonly ILogger<AnnouncementController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAnnouncementService _announcementService;


        public AnnouncementController(IAnnouncementService announcementService, ILogger<AnnouncementController> logger, IHostingEnvironment hostingEnvironment)
        {
            _announcementService = announcementService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcementDb = await _announcementService.GetAnnouncementAsync(id);

            if (announcementDb == null)
            {
                return NotFound();
            }

            await _announcementService.DeleteAnnouncementAsync(announcementDb);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var announcementUpdated = await _announcementService.UpdateAnnouncementAsync(announcement);

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
                var announcements = await _announcementService.GetAllAnnouncementAsync();
                var name = User.Identity.Name;
                /*if (announcements == null)
                {
                    return NoContent();
                }*/

                return View(announcements);
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement(int id)
        {
            var announcement = await _announcementService.GetAnnouncementAsync(id);

            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateAnnouncement(Announcement announcement)
        {
            var announcementNew = await _announcementService.CreateAnnouncementAsync(announcement);

            if (announcementNew == null)
            {
                return BadRequest(new { message = "Announcement is already exist" });
            }

            return Ok();
        }
    }
}