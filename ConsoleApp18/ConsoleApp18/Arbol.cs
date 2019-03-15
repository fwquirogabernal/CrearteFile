using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class Arbol
    {
        public int? dato;
        public Arbol izquierdo, derecho;

        public void Agregar(int valor)
        {
            if (dato == null)
            {
                dato = valor;
            }
            else if (valor < dato)
            {
                if (izquierdo == null)
                    izquierdo = new Arbol();
                izquierdo.Agregar(valor);
            }
            else
            {
                if (derecho == null)
                    derecho = new Arbol();
                derecho.Agregar(valor);
            }
        }

        public void Recorrer()
        {
            izquierdo?.Recorrer();
            if (dato != null) Console.WriteLine($"- {dato}");
            derecho?.Recorrer();
        }

        public void Recorrer2()
        {
            var raiz = this;
            var pila = new Stack<Arbol>();
            while (raiz != null || pila.Count > 0)
            {
                if(raiz == null)
                {
                    var aux = pila.Pop();
                    Console.WriteLine($"- { aux.dato }");
                    raiz = aux.derecho;
                }
                else
                {
                    pila.Push(raiz);
                    raiz = raiz.izquierdo;
                }

            }
        }

        public int contar => dato == null ? 0 : (1 + (izquierdo?.contar ?? 0) + (derecho?.contar ?? 0));
    }
}
