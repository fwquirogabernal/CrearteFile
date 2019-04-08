using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleApp30
{
    [TestFixture]
    class NombrePropioTest
    {
        [Test]
        public void CrearNombreYApeSeparados1()
        {
            var np = new NombrePropio("Fernando","Quiroga");

            Assert.That(np.Nombre, Is.EqualTo("Fernando"));
        }

        [Test]
        public void CrearNombreYApeSeparados2()
        {
            var np = new NombrePropio("Fernando", "Quiroga");

            Assert.That(np.Apellido, Is.EqualTo("Quiroga"));
        }

        [Test]
        public void CrearNombreYApeJuntos()
        {
            var np = new NombrePropio("Quiroga, Fernando");

            Assert.That(np.Nombre, Is.EqualTo("Fernando"));
        }

        [Test]
        public void CrearNombreYApeJuntosConIgual()
        {
            NombrePropio np = "Quiroga, Fernando";

            Assert.That(np.Nombre, Is.EqualTo("Fernando"));
        }

        [Test]
        public void CrearNombreYApeJuntosConIgualError()
        {
            NombrePropio np;

            Assert.Throws(typeof(Exception),  () => np = "Quiroga Fernando");
        }

        [Test]
        public void CrearNombreYApeJuntosConComasRepetidas()
        {
            NombrePropio np;

            Assert.Throws(typeof(Exception), () => np = "Quiroga Fernando");
        }
        [Test]

        public void CrearNombreYApeJuntosConComasRepetidass()
        {
            var np = new NombrePropio("Quiroga, Fernando");

            Assert.That(np, Is.EqualTo("Quiroga, Fernando"));
        }
    }

   
}
