using System;
using System.Collections.Generic;
using WebServer.Database.Models;
using WebServerEntityFramework.DTOs;

namespace WebServerEntityFramework.Tests
{
    public static class Generator
    {
        public static List<UserDto> GetUserDtoList()
        {
            return new List<UserDto>
            {
                new UserDto{DayOfBirth = DateTime.Now, Name = "Géza"},
                new UserDto{DayOfBirth = DateTime.Now.AddYears(-10), Name = "Pistike"}
            };
        }

        public static UserDto GetUserDto()
        {
            return new UserDto { DayOfBirth = DateTime.Today, Name = "Pityu" };
        }

        public static User GetUser()
        {
            return new User { Id = 1, Name = "Pityu", DayOfBirth = DateTime.Today };
        }

        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User{Id = 1, DayOfBirth = DateTime.Now, Name = "Géza"},
                new User{Id = 2, DayOfBirth = DateTime.Now.AddYears(-10), Name = "Pistike"}
            };
        }
    }
}
