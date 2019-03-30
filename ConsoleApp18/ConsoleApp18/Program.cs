 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arbol a = new Arbol();
            //var r = new Random(1);

            //for (int i = 0; i <= 20; i++)
            //{
            //    a.Agregar(r.Next(10,99));
            //}
            //a.Recorrer();
            //Console.WriteLine("Recorrer iterarivo");
            //a.Recorrer2();
            //Console.ReadLine();

            ListaOrdenada<int> lista = new ListaOrdenada<int>();
            lista.Agregar(3);
            lista.Agregar(3);
            lista.Agregar(5);
            lista.Agregar(1);
            lista.Agregar(9);
            lista.Agregar(8);
            lista.Agregar(2);
            lista.Agregar(4);
            lista.Mostrar();

            Console.ReadLine();

        }
    }
}
