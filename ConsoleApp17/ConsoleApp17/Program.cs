using ConsoleApp17;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Entrada correo;
            Entrada correo1;
            Entrada domicilio;
            Entrada telefono;
            Contacto juan;
            Contacto jose;
            Agenda agenda;
            correo = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.lopez@mail.com" };
            telefono = new Entrada { TipoEntrada = TipoEntrada.Telefono, Valor = "345678" };
            correo1 = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.perez@mail.com" };
            domicilio = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "Mendoza 303" };
            juan = new Contacto { Apellido = "Perez", Nombre = "Juan", Nacimiento = DateTime.Today };
            jose = new Contacto { Apellido = "Lopez", Nombre = "jose", Nacimiento = DateTime.Today };
            agenda = new Agenda();
            juan.Agregar(correo);
            juan.Agregar(domicilio);
            jose.Agregar(telefono);
            jose.Agregar(correo1);
            agenda.Agregar(juan);
            agenda.Agregar(jose);

           

            

           
        }

        
    }
}
