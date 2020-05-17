using LNUhelperUp.DTOs;
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
        Task<FacultyDTO> GetFacultyAsync(int id);
        Task<IEnumerable<FacultyDTO>> GetAllFacultyAsync();
        Task<FacultyDTO> UpdateFacultyAsync(FacultyDTO facultyDTO);
        Task DeleteFacultyAsync(FacultyDTO facultyDTO);
    }
}
