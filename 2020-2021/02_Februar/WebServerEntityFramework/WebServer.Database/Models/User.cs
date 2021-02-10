using System;

namespace WebServer.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DayOfBirth { get; set; }
    }
}
