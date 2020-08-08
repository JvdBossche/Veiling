using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Veiling
{
    class MaakCataloog
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Meubel Kast = new Meubel
            {
                Soort = Meubel.MeubelSoort.Kast,
                Afmetingen = new double[3] { 80, 60, 150 },
                Startprijs = 1, VerwachtePrijs = 80
            };
            Console.WriteLine(Kast);

            Speelgoed RubixCube = new Speelgoed
            {
                Merk = "Rubic", TypeNummer = "Cube 1",
                VanTotLeeftijd = new int[2] { 12, 120 },
                Startprijs = 0, VerwachtePrijs = 7
            };
            Console.WriteLine(RubixCube);

            Witgoed Frigo = new Witgoed
            { 
                Soort = Witgoed.WitgoedSoort.Koelkst, Merk = "Samsung", TypeNummer = "FR123",
                Startprijs = 30, VerwachtePrijs = 390
            };
            Console.WriteLine(Frigo);

            Bruingoed PlayStation = new Bruingoed
            {
                Soort = Bruingoed.BruingoedSoort.Spelconsole, Merk = "Sony", TypeNummer = "PS5",
                Startprijs = 1, VerwachtePrijs = 250
            };
            Console.WriteLine(PlayStation);

            Computer MacOne = new Computer
            {
                Soort = Computer.ComputerSoort.Desktop,
                Gewicht = 7.6f, Afmetingen = new double[3] { 45, 55, 55},
                Merk = "Apple", TypeNummer = "AppleOne SeaBlue",
                Startprijs = 20, VerwachtePrijs = 1390
            };
            Console.WriteLine(MacOne);

            Professioneel DTmax = new Professioneel
            {
                Merk = "TurnGood", TypeNummer = "Max 01",
                Soort = Professioneel.ProSoort.Draaibank,
                Voltage = Professioneel.Spanning.AC380,
                Startprijs = 300, VerwachtePrijs = 5600
            };
            Console.WriteLine(DTmax);

            KinderkKleding BumbaT = new KinderkKleding
            {
                Merk = "Studio100",
                ModelNaam = "Bumba T-shirt",
                Maat = new Kleding.LeeftijdMaat { Leeftijd = 4 },
                Startprijs = 0, VerwachtePrijs = 7
            };
            Console.WriteLine(BumbaT);

            Casual Levis501 = new Casual
            {
                Merk = "Levis",
                ModelNaam = "501 Blue",
                Maat = new Kleding.MeetlintMaat { Maat = 42 },
                Startprijs = 3, VerwachtePrijs = 51
            };
            Console.WriteLine(Levis501);

            SportKleding Trainer = new SportKleding
            {
                Merk = "Beayens",
                ModelNaam = "Set-up",
                Maat = new Kleding.SmlMaat { Maat = Kleding.SmlMaat.Sml.XL },
                Startprijs = 5, VerwachtePrijs = 120
            };
            Console.WriteLine(Trainer);

            VeiligheidsKleding Helm = new VeiligheidsKleding
            {
                Beschermt = VeiligheidsKleding.Bescherming.Hoofd,
                Startprijs = 10, VerwachtePrijs = 80
            };
            Console.WriteLine(Helm);


            List<VerkoopObject> cataloog = new List<VerkoopObject>();
            cataloog.Add(Kast);
            cataloog.Add(RubixCube);
            cataloog.Add(Frigo);
            cataloog.Add(PlayStation);
            cataloog.Add(MacOne);
            cataloog.Add(DTmax);
            cataloog.Add(BumbaT);
            cataloog.Add(Levis501);
            cataloog.Add(Trainer);
            cataloog.Add(Helm);

            // Klaarmaken om naar een bestand te schrijven.
            string defaultDir = @"C:\temp";
            string outputFile = Path.Combine(defaultDir, (args.Length == 1)?args[0]:"VeilingCataloog.bin");
            // Gebruik ofwel het commend line argument als path+filename (als er één is), zoniet C:\temp\VeilingCataloog.bin.
            // Het command line argument moet een absoluut path zijn, zoniet wordt het bestand in C:\temp geschreven, dankzij Path.Combine()

            // Serialize (Het één na één wegschtijven van een LIST<> naar een bestand.)
            using Stream fileStream = File.Open(outputFile, FileMode.Create);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binairFormaat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binairFormaat.Serialize(fileStream, cataloog);
            Console.WriteLine(JsonConvert.SerializeObject(cataloog, Formatting.Indented));
            Console.WriteLine($"De opgebouwde cataloog is weggeschreven naar bestand \"{outputFile}\"");
        }
    }
}
