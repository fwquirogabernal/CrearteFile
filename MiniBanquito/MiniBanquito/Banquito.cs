using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiniBanquito
{
    public class Banquito
    {
        [JsonProperty]
        List<CuentaCorriente> cuentaCorrientes = new  List<CuentaCorriente>();

        public void Agregar(CuentaCorriente cuenta) => cuentaCorrientes.Add(cuenta);

        public void Listar()
        {
            cuentaCorrientes.ForEach(x => Console.WriteLine("- Nombre: " + x.Nombre + " saldo:" + x.Saldo() + " Desc: " +x.Desc() +"\n" ));
        }

        public void Guardar()
        {
            string output = JsonConvert.SerializeObject(this);
            File.WriteAllText("banquito.json",output);
        }

        public Banquito Cargar()
        {
            string input = File.ReadAllText("banquito.json");

            Banquito b = JsonConvert.DeserializeObject<Banquito>(input);

            return b;
        }

        public CuentaCorriente Extraer(string nombre, double monto)
        {
            cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault().Extraer(monto);

            return cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault();
        }


        public CuentaCorriente Depositar(string nombre, double monto)
        {
            cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault().Depositar(monto);

            return cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault();
        }

        public CuentaCorriente ActualizarDesc(string nombre, double monto)
        {
            cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault().ActualizarDescubierto(monto);

            return cuentaCorrientes.Where(x => x.Nombre.Contains(nombre)).FirstOrDefault();
        }
        public void ListarClientes()
        {
            cuentaCorrientes.ForEach(x => Console.WriteLine(x.Nombre + "\n"));
        }

        public int CalcularHora()
        {
            return cuentaCorrientes.LastOrDefault().UltimaHora();
        }

    }
}
