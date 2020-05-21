using AutoMapper;
using LNUhelperUp.Models;
using LNUhelperUp.DTOs;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNUhelperUp.Models.ViewModels;

namespace LNUhelperUp.Services.ImplementedServices
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork,  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteEventAsync(EventDTO _eventDTO)
        {
            var eventDb = await _unitOfWork.EventRepository.SingleOrDefaultAsync(u => u.Id == _eventDTO.Id);
            _unitOfWork.EventRepository.Remove(eventDb);

            await _unitOfWork.Complete();
        }

        public async Task<EventDTO> GetEventAsync(int id)
        {
            var eventDb = await _unitOfWork.EventRepository.GetAsync(id);
            var eventDbDTO = _mapper.Map<Event, EventDTO>(eventDb);
            return eventDbDTO;
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventAsync()
        {
            var events = await _unitOfWork.EventRepository.GetAllAsync();
            var eventsDTO = events.Select(_mapper.Map<Event, EventDTO>);

            return eventsDTO.Count() > 0 ? eventsDTO : null;
        }

        public async Task<EventDTO> UpdateEventAsync(EventDTO _eventDTO)
        {
            var eventDb = await _unitOfWork.EventRepository.SingleOrDefaultAsync(u => u.Id == _eventDTO.Id);
            if (eventDb == null)
            {
                return null;
            }

            var eventUpdated = _mapper.Map(_eventDTO, eventDb);
            await _unitOfWork.Complete();

            return _mapper.Map<Event, EventDTO>(eventUpdated);
        }
        public async Task UpdatePhototAsync(int id, EditPhotoViewModel model)
        {
            var newEvent = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Id == id);


            _mapper.Map(model, newEvent);

            await _unitOfWork.Complete();
        }
        public async Task<Event> CreateEventAsync(EventDTO eventDTO)
        {
            var newEvent = _mapper.Map<Event>(eventDTO);

            await _unitOfWork.EventRepository.AddAsync(newEvent);
            await _unitOfWork.Complete();

            return newEvent;
        }
    }
}

