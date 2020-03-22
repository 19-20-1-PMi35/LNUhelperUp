using LNUhelperUp.Models;
using LNUhelperUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories.ImplementedRepositories
{
    public class AnnouncementRepository: BaseRepository<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(DbContext context): base(context)
        {

        }
    }
}
