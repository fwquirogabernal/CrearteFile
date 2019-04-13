using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiniBanquito
{
    public class CuentaCorriente
    {
        public string Nombre { get; set; }
        public double Saldo() => movimientos.Count == 0 ? 0 : movimientos.Sum(x => x.Monto);
        public double Desc() => descubiertos.Count == 0 ? 0 : descubiertos.LastOrDefault().Monto;
        [JsonProperty]
        List<Movimiento> movimientos = new List<Movimiento>();
        [JsonProperty]
        List<Descubierto> descubiertos = new List<Descubierto>();

        public CuentaCorriente(string nombre, double saldo = 0, double desc = 0)
        {
            Nombre = nombre;
        }

        public double Saldo(int hora) => movimientos.Where(x => x.Hora <= hora).Sum(x => x.Monto);

        public double Desc(int hora) => descubiertos.Where(x => x.Hora <= hora).LastOrDefault().Monto;

        public  void Depositar(double monto) => movimientos.Add(new Movimiento(monto));

        public void Extraer(double monto) => movimientos.Add(new Movimiento(-monto));

        public void ActualizarDescubierto(double monto) => descubiertos.Add(new Descubierto(monto));

        private class Movimiento
        {
            public double Monto { get; }
            public int Hora { get; }

            public Movimiento(double monto)
            {
                Monto = monto;
                Hora = Reloj.Incremento();
            }
        }

        private class Descubierto
        {
            public double Monto { get; }
            public int Hora { get; }

            public Descubierto(double monto)
            {
                Monto = monto;
                Hora = Reloj.Incremento();
            }
        }

        public int UltimaHora()
        {
            return movimientos.LastOrDefault().Hora > descubiertos.LastOrDefault().Hora
                ? movimientos.LastOrDefault().Hora
                : descubiertos.LastOrDefault().Hora;
        }
    }
}
