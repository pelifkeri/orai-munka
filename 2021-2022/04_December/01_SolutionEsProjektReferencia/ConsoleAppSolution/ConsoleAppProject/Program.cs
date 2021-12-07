
using ClassLibrary;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleAppProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var asd = now.AddDays(100);
            Console.WriteLine(asd.DayOfWeek);

            var person = new Person(now, birthName: "Jóska");
        }
    }
}