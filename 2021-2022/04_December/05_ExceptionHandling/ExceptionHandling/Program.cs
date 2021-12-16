using System;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string>();

            var elso = lista.FirstOrDefault() ?? "default érték";

            try
            {
                elso = lista.First();
                Fuggveny();
            }
            catch (AggregateException ex)
            {
                elso = "valami default érték";
            }
            catch (Exception ex)
            {
                elso = "valami default érték";
            }

            Console.WriteLine($"Érték: {elso}");
        }

        static void Fuggveny()
        {
            try
            {
                List<string> lista = new List<string>();
                var elso = lista.First();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ó-ó", ex);
            }
        }
    }
}
