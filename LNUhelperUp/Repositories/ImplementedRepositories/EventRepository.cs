using LNUhelperUp.Models;
using LNUhelperUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories.ImplementedRepositories
{
    public class EventRepository: BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context)
        {

        }

    }
}
