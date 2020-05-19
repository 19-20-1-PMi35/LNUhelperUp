﻿using AutoMapper;
using LNUhelperUp.Models;
using LNUhelperUp.DTOs;
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
            foreach (var item in eventsDTO)
            {
                var image = await _unitOfWork.ImageRepository.GetAsync(item.ImageId);
                item.ImagePath = image.Path;
            }

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

