using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Producto
    {
        public string Descripcion { get; set; }
        public double Precio => cambiosPrecio.Count == 0 ? 0 : cambiosPrecio.LastOrDefault().Monto;
        public int Existencia => cambiosStock.Count == 0 ? 0 : cambiosStock.Sum(x => x.Unidades);
        List<CambioStock> cambiosStock = new List<CambioStock>();
        List<CambioPrecio> cambiosPrecio = new List<CambioPrecio>();


        public Producto(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void Comprar(int Cantidad) => cambiosStock.Add(new CambioStock(Cantidad));

        public void Vender(int Cantidad) => cambiosStock.Add(new CambioStock(Cantidad*-1));

        public void CambiarPrecio(double monto) => cambiosPrecio.Add(new CambioPrecio(monto));


        private class CambioStock
        {
            public int Unidades;
            public int hora;

            public CambioStock(int unidades)
            {
                hora = Reloj.Ingrementar();
                Unidades = unidades;
            }
        }

        private class CambioPrecio
        {
            public double Monto;
            public int hora;

            public CambioPrecio(double monto)
            {
                hora = Reloj.Ingrementar();
                Monto = monto;
            }
        }

        public int ConsultarExitenciaHora(int hora)
        {

            return cambiosStock.Where(x => x.hora <= hora).Sum(x => x.Unidades);
        }

        public double ConsultarPrecioHora(int hora)
        {
            foreach (var st in cambiosPrecio)
            {
                if (st.hora == hora)
                    return st.Monto;
            }

            return 0;
        }
    }
}
