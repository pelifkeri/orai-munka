using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Models
{
    public class Person
    {
        public Person(DateTime dateOfBirth, string name)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

// 1. feladat: generáljunk random 100 darab Person példányt
// 2. feladat: randomizáljuk a születési idejüket létrehozásnál
// 3. feladat: írassuk ki a consolera a születési idejüket