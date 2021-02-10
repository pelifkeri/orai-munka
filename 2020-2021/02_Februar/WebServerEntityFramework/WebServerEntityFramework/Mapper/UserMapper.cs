using AutoMapper;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;

namespace WebServerEntityFramework.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
