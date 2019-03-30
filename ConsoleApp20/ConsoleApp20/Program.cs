using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static void Main(string[] args)
        {
            Definicion def = new Definicion();

            def.Agregar("Hola", "Saludo1");
            def.Agregar("Hola", "Saludo2");
            def.Agregar("Hola", "Saludo2");
            def.Agregar("Hola", "Saludo3");


            def.Agregar("chau", "adios");
            def.Agregar("chau", "despedir");
            def.Agregar("Cleto", "personaje de los simpsons ");
            def.Mostrar();

            //var result = def.Buscar("Cleto");

            //Console.WriteLine($"Palabra: { result.Item1 }");
            //var c = 1;
            //foreach (var item in result.Item2)
            //{
            //    Console.WriteLine($"{c++}. { item }");
            //}
            Console.WriteLine("----------------------------------------");
            def.Load();
            def.Mostrar();
            Console.ReadLine();

        }
    }
}
