using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    public class Contacto
    {
        public List<Entrada> entradas = new List<Entrada>();
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Nacimiento { get; set; }

        public void Agregar(Entrada e)
        {
            if (e == null) return;
            entradas.Add(e);
        }

        public bool Contiene(string valor)
        {
            if (valor == null) return false;
            if (valor == "") return true;
            var palabras = valor.Split(new[] { ' ' });
            var cantidad = 0;
            foreach (var item in palabras)
            {
                if (Nombre.Contains(item) || Apellido.Contains(item) || LeerTodo().Any(x => x.Contiene(item) ))
                {
                    cantidad++;
                }
            }
            return palabras.Length == cantidad;
               
        }

        public IEnumerable<Entrada> LeerTodo()
        {
            return entradas;
        }
    }
}
