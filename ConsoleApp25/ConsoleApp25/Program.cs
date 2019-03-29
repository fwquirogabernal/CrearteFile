using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {

            MethodInfo[] methods = typeof(ClaseRandom).GetMethods();
            ConstructorInfo[] constructors = typeof(ClaseRandom).GetConstructors();

            foreach (var item in methods)
            {
                Console.WriteLine($"Metodo: {item.Name}");
            }

            foreach (var item in constructors)
            {
                Console.WriteLine($"Constructor: {item.Name}");
                foreach (var items in item.GetParameters())
                {
                    Console.WriteLine($"Parm: {items.Name} tipo {items.ParameterType}");
                }
            }

            Console.ReadLine();
        }
    }
}
