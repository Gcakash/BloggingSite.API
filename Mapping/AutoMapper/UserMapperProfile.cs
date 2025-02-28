using AutoMapper;
using BloggingSite.API.DTOs;
using BloggingSite.API.Models;
using BloggingSite.API.Services;

namespace BloggingSite.API.Mapping.AutoMapper
{

    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserModel>().ReverseMap();
        }
    }
}
