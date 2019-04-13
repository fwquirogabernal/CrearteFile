using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NameRanking
{

    class Program
    {
        public static async Task<string> DownloadPageAsync(string nombre)
        {
            string page = "https://www.google.com/search?q="+nombre;
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                
                return result;
            }
        }
        public static int SearchMatch(string text)
        {
            var exp = @"id=""resultStats"">\s*Cerca de\s*([0-9,]+)\s*resultados";
            Regex regex = new Regex(exp);
            var result = regex.Match(text);

            return int.Parse(result.Groups[1].Value.ToString().Replace(",",""));
        }
        public static int Concurrences(string nombre)
        {
            return  SearchMatch(DownloadPageAsync(nombre).Result);
        }
        
        static void Main(string[] args)
        {
            var res = Concurrences("Fernando");

            var names = new[]
            {
                "Alejandro",
                "Fabricio",
                "Sergio",
                "Fernando",
                "Pablo",
                "Andrea",
                "Tristan",
            };

            var result = names.Select(nombre => new { nombre, Veces = Concurrences(nombre) }).OrderByDescending(x => x.Veces);
            foreach (var item in result)
            {
                Console.WriteLine(item.nombre + " "+ item.Veces.ToString());
            }
            Console.ReadLine();
        }
    }
}
