using AutoMapper;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.ImplementedServices
{
    public class FacultyService: IFacultyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteFacultyAsync(Faculty faculty)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.SingleOrDefaultAsync(u => u.Id == faculty.Id);
            _unitOfWork.FacultyRepository.Remove(facultyDb);

            await _unitOfWork.Complete();
        }

        public async Task<Faculty> GetFacultyAsync(int id)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.GetAsync(id);

            return facultyDb;
        }

        public async Task<IEnumerable<Faculty>> GetAllFacultyAsync()
        {
            var faculties = await _unitOfWork.FacultyRepository.GetAllAsync();

            return faculties.Count() > 0 ? faculties : null;
        }

        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.SingleOrDefaultAsync(u => u.Id == faculty.Id);
            if (facultyDb == null)
            {
                return null;
            }

            var facultyUpdated = _mapper.Map(faculty, facultyDb);
            await _unitOfWork.Complete();

            return facultyUpdated;
        }

        public async Task<Faculty> CreateFacultyAsync(Faculty faculty)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.SingleOrDefaultAsync(u => u.Id == faculty.Id);
            if (facultyDb != null)
            {
                return null;
            }

            await _unitOfWork.FacultyRepository.AddAsync(faculty);
            await _unitOfWork.Complete();

            return faculty;
        }
    }
}
