

using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.Models;

namespace Bd.Web.App.ModelMappers.AppUser
{
    public class AppUserViewModelAutoMapperProfiles : Profile
    {
        public AppUserViewModelAutoMapperProfiles()
        {
            CreateMap<AppUserDto, AppUserViewModel>().ReverseMap();
            CreateMap<UserDto, RegistratioViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
        }
    }
}
