using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTemporal
{
    public class Producto
    {
        public string Descripcion { get; set; }
        public int Existencias { get; set; }
        public double Precio { get; set; }
        List<MovimientoStock> movimientos = new List<MovimientoStock>();
        List<CambioPrecio> cambios = new List<CambioPrecio>();
        
        public Producto(string desc, int exist =0, double prec = 0)
        {
            Descripcion = desc;
            Existencias = exist;
            Precio = prec;
        }

        public void Comprar(int cantidad) => movimientos.Add(new MovimientoStock(cantidad));

        public void Vender(int cantidad) => movimientos.Add(new MovimientoStock(-cantidad));

        public void CambiarPrecio(double precio) => cambios.Add(new CambioPrecio(precio));

        private class MovimientoStock
        {
            public int Unidades;
            public int Hora;

            public MovimientoStock(int unidades)
            {
                Unidades = unidades;
                Hora = Reloj.IncrementoDeTiempo();
            }
        }

        private class CambioPrecio
        {
            public double Precio;
            public int Hora;

            public CambioPrecio(double precio)
            {
                Precio = precio;
                Hora = Reloj.IncrementoDeTiempo();
            }
        }
    }
}
