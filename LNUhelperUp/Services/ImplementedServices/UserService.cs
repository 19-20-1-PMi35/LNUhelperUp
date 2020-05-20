using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
        public async Task<UserDTO> CreateUserAsync(RegistrationViewModel registrationModel)
        {
            var user = _mapper.Map<User>(registrationModel);
            var existedUser = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == user.Login);
            if (existedUser != null)
            {
                throw new ValidationException();
            }
            ConfigureUserProfile(user);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.Complete();
            return _mapper.Map<User, UserDTO>(user);
        }

        private void ConfigureUserProfile(User user)
        {
            user.RoleId = 2;
            user.ImageId = 1;
            // TODO password hashing
        }

        public async Task<UserDTO> GetAsyncById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> GetAsyncByEmail(string login)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == login);
            var faculty = await _unitOfWork.FacultyRepository.GetAsync(user.FacultyId);
            var image = await _unitOfWork.ImageRepository.GetAsync(user.ImageId);
            var userDTO = _mapper.Map<User, UserDTO>(user);
            userDTO.FacultyName = faculty.Name;
            userDTO.ImagePath = image.Path;
            return userDTO;
        }

        public async Task<UserDTO> GetAsync(LoginViewModel model)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
            var faculty = await _unitOfWork.FacultyRepository.GetAsync(user.FacultyId);
            var userDTO = _mapper.Map<User, UserDTO>(user);
            userDTO.FacultyName = faculty.Name;
            return userDTO;
        }

        public async Task<User> GetUser(string login)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == login);
            return user;
        }

        public async Task UpdateAsync(string login, EditProfileViewModel model)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == login);


            _mapper.Map(model, user);

            await _unitOfWork.Complete();
        }

        public async Task UpdatePhototAsync(string login, EditPhotoViewModel model)
        {
            var user = await _unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Login == login);


            _mapper.Map(model, user);

            await _unitOfWork.Complete();
        }
    }
}
