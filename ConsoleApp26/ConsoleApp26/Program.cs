using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            var co = new Cuenta("Caja de ahorro");
            var comandos = new Transacciones();

            comandos.Agregar(new Ingreso(100,co));
            comandos.Agregar(new Egreso(50, co));
            comandos.Agregar(new Ingreso(100, co));
            comandos.Agregar(new Egreso(25, co));

            comandos.EjecutarTodo();

            Console.WriteLine(co.Saldo);
            Console.ReadLine();
        }
    }
}
