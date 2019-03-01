using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp17
{
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
            return contactos.Where(x => x.Contiene(valor)).FirstOrDefault();
        }

        public void GrabarArchivo()
        {
            var json = JsonConvert.SerializeObject(this);
            string direct = Path.Combine(Directory.GetCurrentDirectory(), @"json\");
            string path = direct + "agenda.json";
            Directory.CreateDirectory(direct);
            File.WriteAllText(path, json);
        }

        public Agenda LeerArchivo()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), @"json\agenda.json");
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                return JsonConvert.DeserializeObject<Agenda>(json);
            }
        }
    }
}
