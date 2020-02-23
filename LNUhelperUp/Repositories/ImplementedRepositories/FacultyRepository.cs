using LNUhelperUp.Models;
using LNUhelperUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories.ImplementedRepositories
{
    public class FacultyRepository: BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(DbContext context) : base(context)
        {

        }

    }
}
