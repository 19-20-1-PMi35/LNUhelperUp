using AutoMapper;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.ImplementedServices
{
    public class EventService : IEventService
    {
        // private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork/*,  IMapper mapper */)
        {
            _unitOfWork = unitOfWork;
            // _mapper = mapper;
        }

        public async Task DeleteEventAsync(Event _event)
        {
            var eventDb = await _unitOfWork.EventRepository.SingleOrDefaultAsync(u => u.Id == _event.Id);
            _unitOfWork.EventRepository.Remove(eventDb);

            await _unitOfWork.Complete();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            var eventDb = await _unitOfWork.EventRepository.GetAsync(id);

            return eventDb;
        }

        public async Task<IEnumerable<Event>> GetAllEventAsync()
        {
            var events = await _unitOfWork.EventRepository.GetAllAsync();

            return events.Count() > 0 ? events : null;
        }

        public async Task<Event> UpdateEventAsync(Event _event)
        {
            var eventDb = await _unitOfWork.EventRepository.SingleOrDefaultAsync(u => u.Id == _event.Id);
            if (eventDb == null)
            {
                return null;
            }

            // var facultyUpdated = _mapper.Map(faculty, facultyDb);
            await _unitOfWork.Complete();

            return _event;
        }

        public async Task<Event> CreateEventAsync(Event _event)
        {
            var eventDb = await _unitOfWork.EventRepository.SingleOrDefaultAsync(u => u.Id == _event.Id);
            if (eventDb != null)
            {
                return null;
            }

            await _unitOfWork.EventRepository.AddAsync(_event);
            await _unitOfWork.Complete();

            return _event;
        }
    }
}

