using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanquito
{
    public static class Reloj
    {
        public static int Hora = 1;

        public static int Incremento() => Hora++;

        public static void ActualizarHora(int hora)
        {
            if(hora <= 0) return;
            if (Hora == 1) return;
            if (Hora != 1) Hora = hora;
        }
    }
}
