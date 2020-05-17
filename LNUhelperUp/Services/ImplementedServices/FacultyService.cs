using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
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

        public FacultyService(IUnitOfWork unitOfWork,  IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task DeleteFacultyAsync(FacultyDTO facultyDTO)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.SingleOrDefaultAsync(u => u.Id == facultyDTO.Id);
            _unitOfWork.FacultyRepository.Remove(facultyDb);

            await _unitOfWork.Complete();
        }

        public async Task<FacultyDTO> GetFacultyAsync(int id)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.GetAsync(id);
            var facultyDbDTO = _mapper.Map<Faculty, FacultyDTO>(facultyDb);

            return facultyDbDTO;
        }

        public async Task<IEnumerable<FacultyDTO>> GetAllFacultyAsync()
        {
            var faculties = await _unitOfWork.FacultyRepository.GetAllAsync();
            var facultiesDTO = faculties.Select(_mapper.Map<Faculty, FacultyDTO>);

            return facultiesDTO.Count() > 0 ? facultiesDTO : null;
        }

        public async Task<FacultyDTO> UpdateFacultyAsync(FacultyDTO facultyDTO)
        {
            var facultyDb = await _unitOfWork.FacultyRepository.SingleOrDefaultAsync(u => u.Id == facultyDTO.Id);

            if (facultyDb == null)
            {
                return null;
            }

            var facultyUpdated = _mapper.Map(facultyDTO, facultyDb);

            await _unitOfWork.Complete();

            return _mapper.Map<Faculty, FacultyDTO>(facultyUpdated);
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
