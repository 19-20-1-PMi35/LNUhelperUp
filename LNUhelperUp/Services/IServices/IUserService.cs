using LNUhelperUp.DTOs;
using LNUhelperUp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(RegistrationViewModel userDTO);
        Task<UserDTO> GetAsyncById(int id);
        Task<UserDTO> GetAsync(LoginViewModel email);
    }
}
