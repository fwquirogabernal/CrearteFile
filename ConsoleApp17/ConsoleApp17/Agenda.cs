using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp17
{
    public static class Extenciones
    {
        public static bool IniciaCon(this string palabra, string ComienzaCon)
        {
            var palabras = palabra.Split(new[] { ' ' });
            return palabras.Any(x => x.StartsWith(ComienzaCon));
        }

    }
    public class Agenda
    {
        public List<Contacto> contactos = new List<Contacto>();

        public void Agregar(Contacto contacto)
        {
            if (contacto == null) return;
            contactos.Add(contacto);
        }

        public IEnumerable<Contacto> LeerTodo()
        {
            return contactos;
        }

        public Contacto Leer(string valor)
        {
             return contactos.Where(c => valor.Split(new[] { ' '}).All(x => c.Contiene(x))).FirstOrDefault();
        }

        public void GrabarArchivo(StreamWriter streamWriter)
        {
            var json = JsonConvert.SerializeObject(this);
            streamWriter.WriteLine(json);
        }

        static public Agenda LeerArchivo(StreamReader streamReader)
        {
            var json = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<Agenda>(json);
        }
    }
}
