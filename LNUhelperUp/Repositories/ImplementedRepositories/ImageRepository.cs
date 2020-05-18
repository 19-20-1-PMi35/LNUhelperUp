using LNUhelperUp.Models.Entities;
using LNUhelperUp.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Repositories.ImplementedRepositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(DbContext context) : base(context)
        {

        }
    }
}