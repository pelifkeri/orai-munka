using System;

namespace WebServerEntityFramework.DTOs
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
    }
}
