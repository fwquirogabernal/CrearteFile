using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class ListaOrdenada<T> where T : IComparable
    {
        private List<T> lista = new List<T>();

        public void Agregar(T item)
        {
            lista.Add(item);
            lista.Sort();
        }
        public bool Contiene(T item)
        {
           return lista.Contains(item);
        }

        public void Mostrar()
        {
            foreach (var item in lista)
            {
                Console.WriteLine($"- {item.ToString() }");
            }
        }
    }
}
