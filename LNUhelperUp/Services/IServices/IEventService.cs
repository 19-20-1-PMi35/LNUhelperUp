using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IEventService
    {
        Task UpdatePhototAsync(int id, EditPhotoViewModel model);
        Task<Event> CreateEventAsync(EventDTO eventDTO);
        Task<EventDTO> GetEventAsync(int id);
        Task<IEnumerable<EventDTO>> GetAllEventAsync();
        Task<EventDTO> UpdateEventAsync(EventDTO _eventDTO);
        Task DeleteEventAsync(EventDTO _eventDTO);
    }
}
