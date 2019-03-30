﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    public class Ingreso : Comando
    {
        public double Monto { get; set; }
        public Cuenta Destino { get; set; }

        public Ingreso(double monto, Cuenta cuenta)
        {
            Destino = cuenta;
            Monto = monto;
        }

        public override void Ejecutar()
        {
            Destino.Saldo += Monto;
        }
    }
}
