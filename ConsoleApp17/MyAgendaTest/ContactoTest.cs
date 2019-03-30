using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConsoleApp17;

namespace MyAgendaTest
{
    [TestFixture]
    class ContactoTest
    {
        Entrada correo;
        Entrada correo1;
        Entrada domicilio;
        Entrada telefono;
        Contacto juanP;
        Contacto jose;
        [SetUp]
        public void SetUp()
        {
            correo = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.lopez@mail.com" };
            telefono = new Entrada { TipoEntrada = TipoEntrada.Telefono, Valor = "345678" };
            correo1 = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.perez@mail.com" };
            domicilio = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "Mendoza 303" };
            juanP = new Contacto { Apellido = "Perez", Nombre = "Juan", Nacimiento = DateTime.Today };
            jose = new Contacto { Apellido = "Lopez", Nombre = "Jose", Nacimiento = DateTime.Today };
        }

        [Test]
        public void VerificarSiContactoTieneUnaEntrada()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("jose");

            Assert.IsTrue(result);
        }

        [Test]
        public void VerificarSiContieneNombre()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("Jose");

            Assert.IsTrue(result);
        }

        [Test]
        public void VerificarSiContieneApellido()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("Lopez");

            Assert.IsTrue(result);
        }

        [Test]
        public void VerificarSiContactoNoTieneUnaEntrada()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("juan");

            Assert.IsFalse(result);
        }

        [Test]
        public void VerificarEntradaNula()
        {
            var result = jose.Contiene(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void VerificarEntradaVacia()
        {
            var result = jose.Contiene(string.Empty);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerificarEntradasAgregadas()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.LeerTodo().Count();

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void VerificarEntradasNula()
        {
            jose.Agregar(null);

            var result = jose.LeerTodo().Count();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void VerificarSiContieneNombreApellido()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("Jose Lopez");

            Assert.IsTrue(result);
        }

        [Test]
        public void VerificarSiContieneApellidoNombre()
        {
            jose.Agregar(correo);
            jose.Agregar(domicilio);

            var result = jose.Contiene("Lopez Jose");

            Assert.IsTrue(result);
        }

    }
}
