using ConsoleApp17;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAgendaTest
{
    [TestFixture]
    class AgendaTest
    {
        Entrada correo;
        Entrada correo1;
        Entrada domicilio;
        Entrada telefono;
        Contacto juan;
        Contacto jose;
        Agenda agenda;

        [SetUp]
        public void SetUp()
        {
            correo = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.lopez@mail.com" };
            telefono = new Entrada { TipoEntrada = TipoEntrada.Telefono, Valor = "345678" };
            correo1 = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.perez@mail.com" };
            domicilio = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "Mendoza 303" };
            juan = new Contacto { Apellido = "Perez", Nombre = "Juan", Nacimiento = DateTime.Today };
            jose = new Contacto { Apellido = "Lopez", Nombre = "Juan", Nacimiento = DateTime.Today };

            agenda = new Agenda();
            juan.Agregar(correo);
            juan.Agregar(domicilio);
            jose.Agregar(telefono);
            jose.Agregar(correo1);
        }

        [Test]
        public void ValidarAgregarContacto()
        {
            agenda.Agregar(juan);
            agenda.Agregar(jose);

            var result = agenda.LeerTodo().Count();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void ValidarNoAgregarContactoNulo()
        {
            agenda.Agregar(null);

            var result = agenda.LeerTodo().Count();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ValidarExistenciaDeContacto()
        {
            agenda.Agregar(juan);
            agenda.Agregar(jose);

            var result = agenda.Leer("Juan");

            Assert.That(result, Is.EqualTo(juan));
        }

        [Test]
        public void ValidarContactoInexistente()
        {
            agenda.Agregar(jose);

            var result = agenda.Leer("xxx");

            Assert.IsNull(result);
        }

        [Test]
        public void ValidarArchivoGrabadoConExito()
        {
            agenda.Agregar(juan);
            agenda.Agregar(jose);

            MemoryStream destino = new MemoryStream();
            var escritor = new StreamWriter(destino);

            agenda.GrabarArchivo(escritor);

            escritor.Flush();
            destino.Seek(0, SeekOrigin.Begin);
            var lector = new StreamReader(destino);
            var resultado = lector.ReadLine();
            Assert.IsTrue(resultado.Contains("Juan"));
        }
    }
}
