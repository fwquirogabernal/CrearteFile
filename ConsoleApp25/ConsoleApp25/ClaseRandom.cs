using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    class ClaseRandom
    {
        public int Valor1 { get; set; }
        public int Valor2 { get; set; }
        public int Resultado { get; private set;}

        public ClaseRandom(int a, int b)
        {
            Valor1 = a;
            Valor2 = b;
        }

        public ClaseRandom(int a)
        {
            Valor1 = a;
        }

        public int Sumar()
        {
            return Resultado = Valor1 + Valor2;
        }

        public int Restar()
        {
            return Resultado = Valor1 - Valor2;
        }

        public int Multiplicar()
        {
            return Resultado = Valor1 * Valor2;
        }
        
    }
}
