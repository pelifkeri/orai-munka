using System;
using System.Collections.Generic;
using System.Text;

namespace RandomPersonGenerator
{
    class Person
    {
        public Person(string name, DateTime date)
        {
            Name = name;
            DateOfBirth = date;
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
