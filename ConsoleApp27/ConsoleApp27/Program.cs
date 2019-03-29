using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    class Program
    {
        public static double CalcularEntropia(string numeros)
        {
            var charArray = numeros.ToCharArray();
            var tamaño = numeros.Length;
            Dictionary<char,double> dado = new  Dictionary<char, double>();
            foreach (var val in charArray)
            {
                dado[val] = charArray.Where(x => x == val).Count()/tamaño;
            }
           return dado.Values.Select(p => Math.Log(p, 2) * p).Sum();

        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Entropia {CalcularEntropia("11213152162444")}");
            Console.ReadLine();
        }
    }
}
