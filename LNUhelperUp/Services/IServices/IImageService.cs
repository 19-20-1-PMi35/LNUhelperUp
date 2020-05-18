using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.IServices
{
    public interface IImageService
    {
        Task<ImageDTO> GetAsync(int id);
    }
}