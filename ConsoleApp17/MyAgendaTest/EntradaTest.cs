using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp17;
using NUnit.Framework;

namespace MyAgendaTest
{
    [TestFixture]
    class EntradaTest
    {
        Entrada correo;
        Entrada telefono;
        [SetUp]
        public void SetUp()
        {
            correo   = new Entrada { TipoEntrada = TipoEntrada.Direccion, Valor = "jose.lopez@mail.com"};
            telefono = new Entrada { TipoEntrada = TipoEntrada.Telefono,  Valor = "345678" };
        }

        [Test]
        public void ValidarSiContieneEntrada()
        {
            var result = correo.Contiene("jose");
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidarNoContieneEntrada()
        {
            var result = telefono.Contiene("jose");
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidarQueNoPermitaEntradasNulas()
        {
            var result = correo.Contiene(null);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidarQuePermitaEspaciosEnBlanco()
        {
            var result = correo.Contiene(string.Empty);
            Assert.IsTrue(result);
        }
    }
}
