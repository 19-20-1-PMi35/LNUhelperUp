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
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EventController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEventService _eventService;


        public EventController(IMapper mapper, IEventService eventService, ILogger<EventController> logger, IHostingEnvironment hostingEnvironment)
        {
            _mapper = mapper;
            _eventService = eventService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventDb = await _eventService.GetEventAsync(id);

            if (eventDb == null)
            {
                return NotFound();
            }

            await _eventService.DeleteEventAsync(eventDb);

            return Ok();
        }

        [HttpPut("{id}")]
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
                var events = await _eventService.GetAllEventAsync();
                
                if (events == null)
                {
                    return NoContent();
                }

                return View(events);
            }
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var _event = await _eventService.GetEventAsync(id);

            if (_event == null)
            {
                return NotFound();
            }

            return Ok(_event);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateEvent(EventDTO _eventDTO)
        { 
            var _event = _mapper.Map<Event>(_eventDTO);

            var eventNew = await _eventService.CreateEventAsync(_event);

            if (eventNew == null)
            {
                return BadRequest(new { message = "Event is already exist" });
            }

            return Ok();
        }
    }
}