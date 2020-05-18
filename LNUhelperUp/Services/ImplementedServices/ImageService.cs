using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.Entities;
using LNUhelperUp.Models.ViewModels;
using LNUhelperUp.Services.IServices;
using LNUhelperUp.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Services.ImplementedServices
{
    public class ImageService : IImageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ImageDTO> GetAsync(int id)
        {
            var image = await _unitOfWork.ImageRepository.GetAsync(id);

            return _mapper.Map<Image, ImageDTO>(image);
        }
        public async Task<ImageDTO> CreateAsync(string name, string path)
        {
            var image = new Image { Name = name, Path = path };
            var imageNew = await _unitOfWork.ImageRepository.SingleOrDefaultAsync(u => u.Path == path);
            if (imageNew != null)
            {
                throw new ValidationException();
            }
            await _unitOfWork.ImageRepository.AddAsync(image);
            await _unitOfWork.Complete();
            return _mapper.Map<Image, ImageDTO>(image);
        }

        public async Task<ImageDTO> GetAsyncByPath(string path)
        {
            var image = await _unitOfWork.ImageRepository.SingleOrDefaultAsync(u => u.Path == path);

            return _mapper.Map<Image, ImageDTO>(image);
        }

    }
}