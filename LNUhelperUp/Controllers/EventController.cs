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
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IEventService _eventService;


        public EventController(IEventService eventService, ILogger<EventController> logger, IHostingEnvironment hostingEnvironment)
        {
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
        public async Task<IActionResult> UpdateEvent(Event _event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventUpdated = await _eventService.UpdateEventAsync(_event);

            if (eventUpdated == null)
            {
                return BadRequest(new { message = "Event id is incorrect" });
            }

            return Ok(eventUpdated);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllEvent()
        {
            if (User.Identity.IsAuthenticated)
            {
                var events = await _eventService.GetAllEventAsync();
                var name = User.Identity.Name;
                /*if (events == null)
                {
                    return NoContent();
                }*/

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
        public async Task<IActionResult> CreateEvent(Event _event)
        {
            var eventNew = await _eventService.CreateEventAsync(_event);

            if (eventNew == null)
            {
                return BadRequest(new { message = "Event is already exist" });
            }

            return Ok();
        }
    }
}