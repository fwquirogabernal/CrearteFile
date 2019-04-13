

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp28;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class ProducTest
    {

        [Test]
        public void ValidarUnidadDeUnProducto()
        {
            var prod = new Producto("0001");
            prod.Comprar(10);
            Assert.That(prod.Existencia, Is.EqualTo(10));
        }

        [Test]
        public void ValidarPrecioDeUnProducto()
        {
            var prod = new Producto("0001");
            prod.CambiarPrecio(20);
            prod.CambiarPrecio(30);
            prod.CambiarPrecio(10);

            Assert.That(prod.Precio, Is.EqualTo(10));
        }

        [Test]
        public void ConsultarPrecioEnUnHorario()
        {
            var prod = new Producto("0001");
            prod.CambiarPrecio(20);
            prod.CambiarPrecio(30);
            prod.CambiarPrecio(10);

            Assert.That(prod.ConsultarPrecioHora(2), Is.EqualTo(30));

        }

        [Test]
        public void ConsultarStockEnUnHorario()
        {
            var prod = new Producto("0001");
            prod.Comprar(10);
            prod.Vender(5);
            prod.Comprar(10);
            prod.Vender(5);
            prod.Comprar(10);

            Assert.That(prod.ConsultarExitenciaHora(4), Is.EqualTo(10));

        }
    }
}
