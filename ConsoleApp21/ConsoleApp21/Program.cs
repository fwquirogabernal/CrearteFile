using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
     
        static void Main(string[] args)
        {
            string entrada = "Mi edad es de 26 y se comple 20 marzo";

            string expresion = @"[1-9]\d?";

            Match m = Regex.Match(entrada, expresion);

            while (m.Success)
            {
                Console.WriteLine($"{m.Value} se encuentra en {m.Index}");
                m = m.NextMatch();
            }

            Console.ReadLine();

        }
    }
}
