using System;
using WebServerEntityFramework.DTOs;
using Xunit;

namespace WebServerEntityFramework.Tests.TestData
{
    public class UserValidatorTestData : TheoryData<UserDto>
    {
        private readonly string MoreThan30Characters = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        public UserValidatorTestData()
        {
            Add(new UserDto { Name = "Pista" });
            Add(new UserDto { DayOfBirth = new DateTime(1900, 1, 1), Name = "Pista" });
            Add(new UserDto { DayOfBirth = new DateTime(2000, 1, 1), Name = "Pista" });
            Add(new UserDto { DayOfBirth = DateTime.Now, Name = null });
            Add(new UserDto { DayOfBirth = DateTime.Now, Name = "" });
            Add(new UserDto { DayOfBirth = DateTime.Now, Name = MoreThan30Characters });
        }
    }
}
