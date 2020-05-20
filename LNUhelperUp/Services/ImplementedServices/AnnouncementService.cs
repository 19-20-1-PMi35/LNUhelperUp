using AutoMapper;
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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteAnnouncementAsync(AnnouncementDTO announcementDTO)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.SingleOrDefaultAsync(u => u.Id == announcementDTO.Id);
            _unitOfWork.AnnouncementRepository.Remove(announcementDb);

            await _unitOfWork.Complete();
        }

        public async Task<AnnouncementDTO> GetAnnouncementAsync(int id)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.GetAsync(id);
            var announcementDTO = _mapper.Map<Announcement, AnnouncementDTO>(announcementDb);
            return announcementDTO;
        }

        public async Task<IEnumerable<AnnouncementDTO>> GetAllAnnouncementAsync()
        {
            var announcements = await _unitOfWork.AnnouncementRepository.GetAllAsync();
            var announcementsDTO = announcements.Select(_mapper.Map<Announcement, AnnouncementDTO>);

            return announcementsDTO.Count() > 0 ? announcementsDTO : null;
        }

        public async Task<AnnouncementDTO> UpdateAnnouncementAsync(AnnouncementDTO announcementDTO)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.SingleOrDefaultAsync(u => u.Id == announcementDTO.Id);
            if (announcementDb == null)
            {
                return null;
            }
            var announcementUpdated = _mapper.Map(announcementDTO, announcementDb);
            await _unitOfWork.Complete();

            return _mapper.Map<Announcement, AnnouncementDTO>(announcementUpdated);
        }

        public async Task<Announcement> CreateAnnouncementAsync(Announcement announcement)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.SingleOrDefaultAsync(u => u.Id == announcement.Id);
            if (announcementDb != null)
            {
                return null;
            }

            await _unitOfWork.AnnouncementRepository.AddAsync(announcement);
            await _unitOfWork.Complete();

            return announcement;
        }
    }
}
