using System;
using System.Linq;

public static class Kata
{
    public static void Main()
    {

    }

    public static int GetAverage(int[] marks)
    {
        return Convert.ToInt32(Math.Floor(marks.Average()));
    }
}