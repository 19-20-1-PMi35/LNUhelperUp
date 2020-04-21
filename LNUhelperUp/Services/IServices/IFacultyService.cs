using LNUhelperUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IFacultyService
    {
        Task<Faculty> CreateFacultyAsync(Faculty faculty);
        Task<Faculty> GetFacultyAsync(int id);
        Task<IEnumerable<Faculty>> GetAllFacultyAsync();
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(Faculty faculty);
    }
}
