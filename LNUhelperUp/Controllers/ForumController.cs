using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models;
using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LNUhelperUp.Controllers
{
    [Controller]
    public class ForumController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ForumController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAnnouncementService _announcementService;


        public ForumController(IMapper mapper, IAnnouncementService announcementService, ILogger<ForumController> logger, IHostingEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _announcementService = announcementService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcementDb = await _announcementService.GetAnnouncementAsync(id);

            if (announcementDb == null)
            {
                return NotFound();
            }

            await _announcementService.DeleteAnnouncementAsync(announcementDb);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnnouncement(AnnouncementDTO announcementDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var announcementUpdated = await _announcementService.UpdateAnnouncementAsync(announcementDTO);

            if (announcementUpdated == null)
            {
                return BadRequest(new { message = "Announcement id is incorrect" });
            }
            else
            {
                return RedirectToAction("GetAllAnnouncement", "Announcement");
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateFaculty(int id)
        {
            var _announcement = await _announcementService.GetAnnouncementAsync(id);
            ViewBag.Name = _announcement.Name;
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllQuestions()
        {
            if (User.Identity.IsAuthenticated)
            {
                var announcements = await _announcementService.GetAllAnnouncementAsync();

                if (announcements == null)
                {
                    return NoContent();
                }

                return View(announcements);
            }
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> GetAnnouncement(int id)
        {
            var _announcement = await _announcementService.GetAnnouncementAsync(id);

            if (_announcement == null)
            {
                return NotFound();
            }

            return View(_announcement);
        }

        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement(AnnouncementDTO _announcementDTO)
        {
            var _announcement = _mapper.Map<Announcement>(_announcementDTO);

            var announcementNew = await _announcementService.CreateAnnouncementAsync(_announcement);

            if (announcementNew == null)
            {
                return BadRequest(new { message = "Announcement is already exist" });
            }

            return View();
        }
    }
}