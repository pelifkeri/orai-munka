using System;
using System.Collections.Generic;
using System.Text;
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
            return new UserDto { DayOfBirth = DateTime.Now, Name = "Pityu" };
        }
    }
}
