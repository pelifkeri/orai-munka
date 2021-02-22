using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebServer.Database.Interfaces;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Services;
using Xunit;

namespace WebServerEntityFramework.Tests.Services
{
    public class UserServiceTests
    {
        public class UserServiceTestBase
        {
            protected readonly UserService _userService;

            protected readonly Mock<IRepository<User>> _userRepositoryMock;
            protected readonly IMapper _mapper;

            public UserServiceTestBase()
            {
                _userRepositoryMock = new Mock<IRepository<User>>();
                var config = new MapperConfiguration(opts =>
                {
                    opts.AddMaps(typeof(UserService).Assembly.FullName);
                });
                _mapper = config.CreateMapper();

                _userService = new UserService(_userRepositoryMock.Object, _mapper);
            }
        }

        public class GetAllUsers : UserServiceTestBase
        {
            [Fact]
            public async Task ShouldReturnUserDtoList()
            {
                // arrange
                _userRepositoryMock.Setup(x => x.ListAllAsync())
                    .ReturnsAsync(Generator.GetUsers());

                // act
                var result = await _userService.GetAllUsers();

                // assert
                Assert.Equal(2, result.Count);
                Assert.IsType<List<UserDto>>(result);
            }
        }

        public class CreateNewUser : UserServiceTestBase
        {
            [Fact]
            public async Task ShouldReturnNewUserWhenCreated()
            {
                // arrange
                var dto = Generator.GetUserDto();
                _userRepositoryMock.Setup(x => x.AddAsync(It.IsAny<User>()))
                    .ReturnsAsync(Generator.GetUser());

                // act
                var result = await _userService.CreateNewUser(dto);

                // assert
                Assert.Equal(dto.Name, result.Name);
                Assert.Equal(dto.DayOfBirth, result.DayOfBirth);
                Assert.IsType<UserDto>(result);
            }
        }
    }
}
