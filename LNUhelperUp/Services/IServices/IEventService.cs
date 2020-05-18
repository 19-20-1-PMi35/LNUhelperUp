using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IEventService
    {
        Task<Event> CreateEventAsync(Event _event);
        Task<EventDTO> GetEventAsync(int id);
        Task<IEnumerable<EventDTO>> GetAllEventAsync();
        Task<EventDTO> UpdateEventAsync(EventDTO _eventDTO);
        Task DeleteEventAsync(EventDTO _eventDTO);
    }
}
