using ConsoleApp42;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void New_CreacionCorrecta()
        {
            Assert.DoesNotThrow(() => new Precio(13.12));
        }

        [Test]
        public void New_PrecioEstrictamentePositivoPositivo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(-13.12d));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(0));
        }

        [Test]
        public void New_PrecioTengaTresDecimales()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(13.123d));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(13.12000001d));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(122345678.123d));
        }


        [Test]
        public void Aumento_AumentarElPrecioCorrectamente()
        {
            var precio = new Precio(150d);
            var p2 = precio.Aumento(10);
            Assert.IsTrue(new Precio(165).Equals(p2));
        }

        [Test]
        public void Aumento_AumentoNoPuedeSerNegativo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(13.12d).Aumento(-10));
        }

        [Test]
        public void Descuento_DescuentoElPrecioCorrectamente()
        {
            var precio = new Precio(165);
            var p2 = precio.Descuento(10);
            Assert.IsTrue(new Precio(150).Equals(p2));
        }

        [Test]
        public void Descuento_DescuentoNoPuedeSerNegativo()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Precio(13.12d).Descuento(-10));
        }

        [Test]
        public void Cuotas_NumeroDeCuotas()
        {
            var precio = new Precio(13.12d);
            var cuotas = precio.Cuotas(3).ToArray().Count();
            Assert.That(3, Is.EqualTo(cuotas));
        }
        [Test]
        public void Cuotas_CuotaTres()
        {
            var precio = new Precio(100);
            var pre1 = new Precio(33.33);
            var pre2 = new Precio(33.34);
            var cuotas = precio.Cuotas(3).ToArray();
            Assert.That(pre1, Is.EqualTo(cuotas[0]));
            Assert.That(pre1, Is.EqualTo(cuotas[1]));
            Assert.That(pre2, Is.EqualTo(cuotas[2]));
        }
        [Test]
        public void Equals_Equals()
        {
            Assert.IsTrue(new Precio(10).Equals(new Precio(10)));
        }

        [Test]
        public void Parse_ValidarValorCorrecto()
        {
            Assert.Equals(new Precio(10), Precio.Parse("10"));
        }

        [Test]
        public void Parse_ValidarValorInnorrecto()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Precio.Parse("12,123"));
        }
        [Test]
        public void TryParse_ValidarValorCorrecto()
        {
            Assert.IsTrue(Precio.TryParse("10", out var p));
            Assert.Equals(new Precio(10), p);

            Assert.IsTrue(Precio.TryParse("$   10,0", out var a));
            Assert.Equals(new Precio(10), a);

            Assert.IsTrue(Precio.TryParse("1.234,56", out var d));
            Assert.Equals(new Precio(1234.56), d);
        }
        [Test]
        public void TryParse_ValidarValorInnorrecto()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Precio.TryParse("12,123", out var p));
            Assert.Throws<ArgumentOutOfRangeException>(() => Precio.TryParse("12,12$", out var p));
            Assert.Throws<ArgumentOutOfRangeException>(() => Precio.TryParse("P12,123", out var p));
        }
        [Test]
        public void Hash_GetHashCode()
        {
            Assert.Equals(new Precio(10).GetHashCode(), new Precio(10).GetHashCode());
            Assert.AreNotEqual(new Precio(11).GetHashCode(), new Precio(10).GetHashCode());
        }
    }
}