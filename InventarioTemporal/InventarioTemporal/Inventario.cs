using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace InventarioTemporal
{
    public class Inventario
    {
        List<Producto> productos = new List<Producto>();

        public void Agregar(Producto p) => productos.Add(p);

        public Producto BuscarProducto(string desc) => productos.Where(x => x.Descripcion.Contains(desc)).FirstOrDefault();

        public void Guardar()
        {
            string output = JsonConvert.SerializeObject(this);
            File.WriteAllText("Inventario.JSON",output);
        }

        public Inventario Cargar()
        {
            string input = File.ReadAllText("Inventario.JSON");
            Inventario i = JsonConvert.DeserializeObject(input) as Inventario;
            return i;
        }
    }
}
