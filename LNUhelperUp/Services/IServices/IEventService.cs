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
        Task<Event> GetEventAsync(int id);
        Task<IEnumerable<Event>> GetAllEventAsync();
        Task<Event> UpdateEventAsync(Event _event);
        Task DeleteEventAsync(Event _event);
    }
}
