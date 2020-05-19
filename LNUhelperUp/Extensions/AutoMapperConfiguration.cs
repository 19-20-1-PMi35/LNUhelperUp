using AutoMapper;
using LNUhelperUp.DTOs;
using LNUhelperUp.Models;
using LNUhelperUp.Models.Entities;
using LNUhelperUp.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNUhelperUp.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>().ReverseMap();
                c.CreateMap<RegistrationViewModel, User>();
                c.CreateMap<EditViewModel, User>();
                c.CreateMap<EditPhotoViewModel, User>();
                c.CreateMap<Image, ImageDTO>().ReverseMap();
                c.CreateMap<Faculty, FacultyDTO>().ReverseMap();
                c.CreateMap<Event, EventDTO>().ReverseMap();
                c.CreateMap<Event, EventDTO>().ReverseMap();
                c.CreateMap<Announcement, AnnouncementDTO>().ReverseMap();

            }).CreateMapper());
        }
    }
}
