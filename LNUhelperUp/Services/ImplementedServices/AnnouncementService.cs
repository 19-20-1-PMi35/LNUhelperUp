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
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAnnouncementAsync(Announcement announcement)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.SingleOrDefaultAsync(u => u.Id == announcement.Id);
            _unitOfWork.AnnouncementRepository.Remove(announcementDb);

            await _unitOfWork.Complete();
        }

        public async Task<Announcement> GetAnnouncementAsync(int id)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.GetAsync(id);

            return announcementDb;
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementAsync()
        {
            var announcements = await _unitOfWork.AnnouncementRepository.GetAllAsync();

            return announcements.Count() > 0 ? announcements : null;
        }

        public async Task<Announcement> UpdateAnnouncementAsync(Announcement announcement)
        {
            var announcementDb = await _unitOfWork.AnnouncementRepository.SingleOrDefaultAsync(u => u.Id == announcement.Id);
            if (announcementDb == null)
            {
                return null;
            }

            await _unitOfWork.Complete();

            return announcement;
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
