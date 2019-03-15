using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp20
{
    class Definicion
    {
        private SortedDictionary<string, List<string>> palabras = new SortedDictionary<string, List<string>>();

        public void Agregar(string palabra, string definicion)
        {
            if (string.IsNullOrEmpty(palabra)) return;
            if (string.IsNullOrEmpty(definicion)) return;
            if (!palabras.ContainsKey(palabra))
                palabras.Add(palabra, new List<string>());

            if (!palabras[palabra].Contains(definicion))
            {
                palabras[palabra].Add(definicion);
            }
        }

        public (string ,List<string>) Buscar(string palabra)
        {
            if (string.IsNullOrEmpty(palabra)) return (palabra, new List<string>());
            if (!palabras.ContainsKey(palabra)) return (palabra, new List<string>());

            return (palabra, palabras[palabra]);
        }

        public void Mostrar()
        {
            foreach (var palabra in palabras)
            {
                Console.WriteLine($" - {palabra.Key}");
                int c = 1;
                foreach (var item in palabra.Value)
                {
                    Console.WriteLine($" {c++}. {item}");
                }
            }
        }

        public void Save()
        {
            string direct = Path.Combine(Directory.GetCurrentDirectory(), @"Docs\");
            string path = direct + "Diccionario.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var palabra in palabras)
                {
                    writer.WriteLine(palabra.Key);
                    int c = 1;
                    foreach (var item in palabra.Value)
                    {
                        var aux = $"{c++}.{item}";
                        writer.WriteLine( aux);
                    }
                }
            }
        }

        public void Load()
        {
            string direct = Path.Combine(Directory.GetCurrentDirectory(), @"Docs\");
            string path = direct + "Diccionario.txt";
            var archivo = File.ReadAllLines(path);
            var auxPal = "";
            var auxDef = "";
            foreach (var linea in archivo)
            {
                if (!string.IsNullOrEmpty(linea))
                {
                    if (!char.IsDigit(linea.Trim()[0]))
                    {
                        auxPal = linea.Trim();
                    }
                    else
                    {
                        auxDef = linea.Trim().Substring(2);
                        Agregar(auxPal, auxDef);
                    }
                    
                }
            }

        }
    }
}
