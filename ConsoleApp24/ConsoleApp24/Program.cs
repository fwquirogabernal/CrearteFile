using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "     llamame al 3815343458  antes     de venir       ";
            string cadena2 = "llamame al asd@asd.com antes de venir" ;

            string expre = @"\s+([1-9]\d{2})([1-9]\d{2})(\d{4})\s+";
            string expre2 = @"\b(\S+@\S+\.\S+)\b";

            string expre3 = @"\s+";
            string expre4 = @"(^\s*|\s*$)";

            string cond2 = "$1";
            string cond1 = " ($1) $2-$3 ";
            string cond3 = "$2";

            float A = 1.0f / 3;
            float B = 3 * A;
            var resultado = Regex.Replace(cadena2, expre2, (x => x.Value.ToUpper()));
            var resultado2 = Regex.Replace(cadena, expre3, " ");
            resultado2 = Regex.Replace(resultado2, expre4, "");

            Console.WriteLine($".-{resultado2}-.");

            Console.ReadLine(); 

        }
    }
}
