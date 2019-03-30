using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Vender : Comando
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int hora { get; set; }

        public Vender(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public override void Ejecutar()
        {
            hora = Reloj.Ingrementar();
            //Producto.Existencia -= Cantidad;
        }

        public int GetHora() => hora;
    }
}
