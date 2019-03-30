using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 3;
            byte b = unchecked((byte)~3);

            if (a == b)
            {
               
                Console.WriteLine(a+b);
            }
            Console.WriteLine(a);
            Console.WriteLine(b);

            int c = 3;
            int d = unchecked(~3);

            if (c == d)
            {

                Console.WriteLine(a + b);
            }
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.ReadLine();
        }
    }
}
