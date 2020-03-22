using LNUhelperUp.Models;
using LNUhelperUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories.ImplementedRepositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context): base(context)
        {

        }
    }
}
