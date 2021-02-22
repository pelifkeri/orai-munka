using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using WebServer.Database.Exceptions;
using WebServerEntityFramework.Controllers;
using WebServerEntityFramework.DTOs;
using WebServerEntityFramework.Interfaces;
using Xunit;

namespace WebServerEntityFramework.Tests.Controllers
{
    public class UserControllerTests
    {
        public class GetAll
        {
            private readonly Mock<IUserService> _userServiceMock;

            private readonly UserController _userController;

            public GetAll()
            {
                _userServiceMock = new Mock<IUserService>();

                _userController = new UserController(_userServiceMock.Object);
            }

            [Fact]
            public async Task Get_ShouldReturn200()
            {
                // arrange
                _userServiceMock.Setup(x => x.GetAllUsers())
                    .ReturnsAsync(Generator.GetUserDtoList());

                // act
                var result = await _userController.GetUsers();

                // assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, ((ObjectResult)result).StatusCode);
            }

            [Fact]
            public async Task Get_ShouldReturn404()
            {
                // arrange
                _userServiceMock.Setup(x => x.GetAllUsers())
                    .Throws<EntityNotFoundException>();

                // act
                var result = await _userController.GetUsers();

                // assert
                Assert.NotNull(result);
                Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal(404, ((ObjectResult)result).StatusCode);
            }

            [Fact]
            public async Task Get_ShouldReturn500()
            {
                // arrange
                _userServiceMock.Setup(x => x.GetAllUsers())
                    .Throws<Exception>();

                // act
                var result = await _userController.GetUsers();

                // assert
                Assert.NotNull(result);
                Assert.IsType<ObjectResult>(result);
                Assert.Equal(500, ((ObjectResult)result).StatusCode);
            }
        }

        public class Post
        {
            private readonly Mock<IUserService> _userServiceMock;

            private readonly UserController _userController;

            public Post()
            {
                _userServiceMock = new Mock<IUserService>();

                _userController = new UserController(_userServiceMock.Object);
            }

            [Fact]
            public async Task Post_ShouldReturn200()
            {
                // arrange
                _userServiceMock.Setup(x => x.CreateNewUser(It.IsAny<UserDto>()))
                    .ReturnsAsync(Generator.GetUserDto());

                // act
                var result = await _userController.CreateNewUser(Generator.GetUserDto());

                // assert
                Assert.NotNull(result);
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, ((ObjectResult)result).StatusCode);
            }

            [Fact]
            public async Task Post_ShouldReturn500()
            {
                // arrange
                _userServiceMock.Setup(x => x.CreateNewUser(It.IsAny<UserDto>()))
                    .Throws<Exception>();

                // act
                var result = await _userController.CreateNewUser(Generator.GetUserDto());

                // assert
                Assert.NotNull(result);
                Assert.IsType<ObjectResult>(result);
                Assert.Equal(500, ((ObjectResult)result).StatusCode);
            }
        }
    }
}
