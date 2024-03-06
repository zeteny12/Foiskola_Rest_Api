using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;  //A HTTP kérések végrehajtásához szükséges osztályok használata
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Foiskola_Rest_Api
{
    internal class Program
    {
        static async Task Main(string[] args)   //Az aszinkron belépési pont meghatározása
        {
            //Tárolás || 'Foiskolak' típusú lista létrehozása
            List<Foiskolak> FoiskolakList = new List<Foiskolak>();

            //A függvény aszinkron hívása, ez esetben 'MagyarFoiskolak()'
            FoiskolakList = await MagyarFoiskolak();

            //Összes adat || Végigmegyünk a 'FoiskolakList' összes elemén
            foreach (Foiskolak item in FoiskolakList)
            {
                //Adatok kiírása
                Console.WriteLine($"{item.Name}, {item.Country}");
            }

            Console.WriteLine($"\n\nProgram vége...");
            Console.ReadKey();
        }

        //Aszinkron függvénydefiníció, 'Foiskolak' listával tér vissza
        private static async Task<List<Foiskolak>> MagyarFoiskolak()
        {
            //'Foiskolak' típusú lista létrehozása
            List<Foiskolak> FoiskolakList = new List<Foiskolak>();

            //HTTP kliens példányosítása
            HttpClient client = new HttpClient();

            //HTTP 'GET' kérés küldése
            HttpResponseMessage response = await client.GetAsync($"http://universities.hipolabs.com/search?country=hungary");

            //Ellenőrzés, hogy a válasz sikeres volt-e
            if (response.IsSuccessStatusCode)
            {
                //Válasz szövegének kiolvasása
                string jsonString = await response.Content.ReadAsStringAsync();

                //JSON adatok deszerializálása és 'Foiskolak' objektumokká alakítása
                FoiskolakList = Foiskolak.FromJson( jsonString ).ToList();
            }

            //Válasz || 'Foiskolak' lista visszaadása
            return FoiskolakList;
        }
    }
}
