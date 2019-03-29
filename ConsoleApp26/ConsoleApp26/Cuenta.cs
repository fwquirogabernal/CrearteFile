using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    public  class Cuenta
    {
        public string Descripcion { get; set; }
        public double Saldo { get; set; }

        public Cuenta(string descripcion, double saldo = 0)
        {
            Descripcion = descripcion;
            Saldo = saldo;
        }
        
    }

}
