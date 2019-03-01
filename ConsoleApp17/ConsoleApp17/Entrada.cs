using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    public enum TipoEntrada
    {
        Direccion,Email,Telefono
    }

    public class Entrada
    {
        public string Valor { get; set; }
        public TipoEntrada TipoEntrada { get; set; }

        public bool Contiene(string _valor)
        {
            if (_valor == null) return false;
            if (_valor == "") return true;
            return Valor.Contains(_valor);
        }
    }
}
