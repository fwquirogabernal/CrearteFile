using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ConsoleApp28
{
    public class ActualizarPrecio : Comando
    {
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public int hora;

        public ActualizarPrecio(Producto producto, double precio)
        {
            Producto = producto;
            Precio = precio;
        }
        public override void Ejecutar()
        {
            //Producto.Precio = Precio;
            hora = Reloj.Ingrementar();
        }
        public int GetHora() => hora;

    }
}
