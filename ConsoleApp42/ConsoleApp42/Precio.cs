using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp42
{
    public class Precio
    {
        double _monto;
        public Precio(double monto)
        {
            if(monto <= 0)
                throw new ArgumentOutOfRangeException();
            if(monto - (Math.Truncate(monto)) > 0.001)
                throw new ArgumentOutOfRangeException();

            _monto = monto;
        }

        public Precio Aumento(int p)
        {
            if (p <= 0)
                throw new ArgumentOutOfRangeException();
            var aux = _monto * (1 + ((double)p / 100));
            return new Precio(aux);
        }
        public Precio Descuento(int desc)
        {
            if (desc <= 0)
                throw new ArgumentOutOfRangeException();
            var aux = _monto / (1 + (double)desc / 100);
            return new Precio(aux);
        }
        public IEnumerable<Precio> Cuotas(int nro)
        {
            if (!(nro % 2 == 0))
                _monto = _monto - 0.01;

            for (var i = 0; i<nro; i++)
            {
                if (i == nro - 1)
                    yield return new Precio(Math.Round((_monto / nro) + 0.01,2));

                yield return new Precio(Math.Round(_monto / nro,2));
            }
        }
        public static Precio Parse(string p)
        {
            return null;
        }
        public static bool TryParse(string p, out Precio pre)
        {
            pre = null;
            return false;
        }
        public override bool Equals(object obj)
        {
            return _monto == ((Precio)obj)._monto;
        }
        public override string ToString()
        {
            return $"${_monto}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
