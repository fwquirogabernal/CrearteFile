using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    class Transacciones
    {
        List<Comando> comandos = new List<Comando>();

        public void Agregar(Comando cmd)
        {
            comandos.Add(cmd);
        }

        public void EjecutarTodo()
        {
            comandos.ForEach(x => x.Ejecutar());
        }
    }
}
