using System;
using System.IO;
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
using LNUhelperUp.Models.ViewModels;

namespace LNUhelperUp.Controllers
{
    [Controller]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EventController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEventService _eventService;
        private readonly IImageService _imageService;
        private readonly IUserService _userService;

        public EventController(IMapper mapper, IEventService eventService, ILogger<EventController> logger, IHostingEnvironment hostingEnvironment, IImageService imageService, IUserService userService)
        {
            _mapper = mapper;
            _eventService = eventService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _imageService = imageService;
            _userService = userService;
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventDb = await _eventService.GetEventAsync(id);

            if (eventDb == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEventAsync(eventDb);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventDTO _eventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventUpdated = await _eventService.UpdateEventAsync(_eventDTO);

            if (eventUpdated == null)
            {
                return BadRequest(new { message = "Event id is incorrect" });
            }
            else
            {
                return RedirectToAction("GetAllEvent", "Event");
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateFaculty(int id)
        {
            var _event = await _eventService.GetEventAsync(id);
            ViewBag.Name = _event.Name;
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllEvent()
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
                    ViewBag.userId = Int32.Parse(HttpContext.Request.Cookies["userId"]);
                    return View(events);
                }
                else
                {
                    return RedirectToAction("GetAllFaculty", "Faculty");
                }
            }
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> GetEvent(int id)
        {
            var _event = await _eventService.GetEventAsync(id);

            if (_event == null)
            {
                return NotFound();
            }

            return View(_event);
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        /*public async Task<IActionResult> CreateEvent(EventDTO _eventDTO)
        {
            var eventNew = await _eventService.CreateEventAsync(_eventDTO);

            if (eventNew == null)
            {
                return BadRequest(new { message = "Event is already exist" });
            }

            return View();
        }*/
        public async Task<IActionResult> CreateEvent(AddEventViewModel model)
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
                    Price = Convert.ToDouble(model.Price),
                    ParticipantAmount = model.ParticipantAmount,
                    Place = model.Place,
                    CreateAt = DateTime.Now,
                    Time = DateTime.Now,
                    UserId = Int32.Parse(HttpContext.Request.Cookies["userId"]),
                    FacultyId = Int32.Parse(HttpContext.Request.Cookies["facultyId"]),
                    ImagePath = startPath,
                    IsOfficial = false
                };
                var newEvent = await _eventService.CreateEventAsync(eventDTO);
                return RedirectToAction("GetAllEvent", "Event");
            }
            return View(model);
        }
    }
    
}