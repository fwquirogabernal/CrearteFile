using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertiraBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero entero ");
            int Num = Convert.ToInt32(Console.ReadLine());
            if (Num > 0)
            {
                String cad = "";
                while (Num > 0)
                {
                    if (Num % 2 == 0)
                    {
                        cad = "0" + cad;
                    }
                    else
                    {
                        cad = "1" + cad;
                    }
                    Num = (int)(Num / 2);
                }
                Console.WriteLine(cad);
            }
            else
            {
                if (Num == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    Console.WriteLine("Solo numeros positivos");
                }
            }
            Console.ReadLine();
        }
    }
}