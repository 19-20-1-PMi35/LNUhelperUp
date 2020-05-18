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
        Task<Announcement> GetAnnouncementAsync(int id);
        Task<IEnumerable<Announcement>> GetAllAnnouncementAsync();
        Task<Announcement> UpdateAnnouncementAsync(Announcement announcement);
        Task DeleteAnnouncementAsync(Announcement annoucement);
    }
}
