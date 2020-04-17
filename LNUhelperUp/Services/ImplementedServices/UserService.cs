using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.ImplementedServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<UserDTO> CreateUserAsync(RegistrationViewModel userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public Task<UserDTO> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
