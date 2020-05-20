using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IAnnouncementService
    {
        Task<Announcement> CreateAnnouncementAsync(Announcement announcement);
        Task<AnnouncementDTO> GetAnnouncementAsync(int id);
        Task<IEnumerable<AnnouncementDTO>> GetAllAnnouncementAsync();
        Task<AnnouncementDTO> UpdateAnnouncementAsync(AnnouncementDTO announcementDTO);
        Task DeleteAnnouncementAsync(AnnouncementDTO annoucementDTO);
    }
}
