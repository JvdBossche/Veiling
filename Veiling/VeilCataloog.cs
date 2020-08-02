using System;
using System.Collections.Generic;
using System.IO;
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
            foreach (VerkoopObject item in cataloog)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
