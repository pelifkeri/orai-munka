using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Mapper;
using Xunit;

namespace WebServerEntityFramework.Tests.Mapper
{
    public class UserMapperTests
    {
        private readonly IMapper _mapper;

        public UserMapperTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserMapper>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void ShouldReturnUser_WhenValidDtoIsGiven()
        {
            // arrange
            var userDto = Generator.GetUserDto();

            // act
            var result = _mapper.Map<User>(userDto);

            // assert
            Assert.Equal(userDto.DayOfBirth, result.DayOfBirth);
            Assert.Equal(userDto.Name, result.Name);
        }

        [Fact]
        public void ShouldReturnUserDto_WhenValidUserIsGiven()
        {
            // arrange
            var user = Generator.GetUser();

            // act
            var result = _mapper.Map<UserDto>(user);

            // assert
            Assert.Equal(user.DayOfBirth, result.DayOfBirth);
            Assert.Equal(user.Name, result.Name);
        }
    }
}
