using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Reloj
    {
        private static int hora = 1;

        public static int Ingrementar()
        {
            return hora++;
        }
    }
}
