using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Veiling
{
    class VeilCataloog
    {
        static void Main(string[] args)
        {
            // Klaarmaken om uit een bestand te lezen.
            string defaultDir = @"C:\temp";
            string inputFile = Path.Combine(defaultDir, (args.Length == 1) ? args[0] : "VeilingCataloog.bin");
            // Gebruik ofwel het commend line argument als path+filename (als er één is), zoniet C:\temp\VeilingCataloog.bin.
            // Het command line argument moet een absoluut path zijn, zoniet wordt geprobeerd het bestand uit C:\temp te lezen, dankzij Path.Combine()

            // Serialize (Het één na één wegschtijven van een LIST<> naar een bestand.)
            using Stream fileStream = File.Open(inputFile, FileMode.Open);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binairFormaat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            List<VerkoopObject> cataloog = (List<VerkoopObject>)binairFormaat.Deserialize(fileStream);

            Console.WriteLine($"Cataloog gelezen uit bestand {inputFile}:");
            Console.WriteLine("De veiling van het eerste item begint zometeen. Druk op een knop om de veilingklok te stoppen.");
            Verdergaan("Verdergaan? (J/N)");
            foreach (VerkoopObject item in cataloog)
            {
                Veil(item);
            }
        }

        static void Veil(VerkoopObject item)
        {
            Console.WriteLine();
            Console.WriteLine(item);

            //Bepaal increment waarde
            decimal increment = item.GetIncrement();
            decimal huidigePrijs = item.Startprijs;
            do
            {
                Console.CursorVisible = false;
                Console.Write($"\r{huidigePrijs,8:F2}");
                System.Threading.Thread.Sleep(50);
                huidigePrijs += increment;
            } while (!Console.KeyAvailable);
            item.AfklokPrijs = huidigePrijs;
            Console.CursorVisible = true;
            Console.WriteLine();
            Console.WriteLine($"{item.ToString()} is verkocht aan {item.AfklokPrijs,1:F2}");
            Console.WriteLine($"Dat is {Math.Abs(item.AfklokPrijs - item.VerwachtePrijs),1:F2} {((item.AfklokPrijs < item.VerwachtePrijs) ? "minder" : "boven")} de verwachte prijs {item.VerwachtePrijs,1:F2}.");

            if (Verdergaan("Verdergaan met het volgende item? (J/N)"))
            {
                return; // Volgende item Veilen
            }
            else
            {
                Environment.Exit(1); // %errorlevel% == 1: Vroegtijdig beeindigd.
            }
        }

        static bool Verdergaan(String bericht)
        {
            char[] toegelatenAntwoorden = { 'j', 'J', 'n', 'N' };
            Console.WriteLine(bericht);
            ConsoleKeyInfo key = Console.ReadKey();
            while (!toegelatenAntwoorden.Contains<char>(key.KeyChar))
            {
                Console.Beep();
                key = Console.ReadKey();
            }            
            if ( key.KeyChar == 'j' || key.KeyChar == 'J') return true; else return false;
        }
        
    }
}
