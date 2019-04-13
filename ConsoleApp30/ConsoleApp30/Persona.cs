using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp30
{
    public struct  NombrePropio
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }

        public NombrePropio(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public NombrePropio(string ApeNom)
        {
            if (ApeNom.Split(',').Length == 1)
                throw new Exception();

            if (ApeNom.Split(',').Length == 3)
                throw new Exception();


            Nombre = ApeNom.Split(',')[1].Trim();
            Apellido = ApeNom.Split(',')[0].Trim();
        }

        public bool ValidarNombreCompleto(string val)
        {
            string input = @"^[\w\.\-\s]+$";

            Regex rx = new Regex(input);

            return rx.IsMatch(val);
        }

        public static implicit operator NombrePropio(string apeNom) => new NombrePropio(apeNom);

        public static implicit operator string(NombrePropio np) => np.Apellido + ", " + np.Nombre;
    }
    public class Persona
    {
        
    }
}
