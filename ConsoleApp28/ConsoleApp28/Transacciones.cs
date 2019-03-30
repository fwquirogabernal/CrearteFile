using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Transacciones
    {
        private List<Comando> comandos = new List<Comando>();

        public void Agregar(Comando cmd) => comandos.Add(cmd);

        public void EjecutarTodo() => comandos.ForEach(x => x.Ejecutar());

    }
}
