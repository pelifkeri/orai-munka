using System;

namespace WebServer.Database.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
    }
}
