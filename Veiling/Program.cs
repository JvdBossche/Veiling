using System;

namespace Veiling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Meubel Kast = new Meubel
            {
                Soort = Meubel.MeubelSoort.Kast,
                Afmetingen = new double[3] { 80, 60, 150 }
            };
            Console.WriteLine(Kast);

            Speelgoed RubixCube = new Speelgoed
            {
                Merk = "Rubic", TypeNummer = "Cube 1",
                VanTotLeeftijd = new int[2] { 12, 120 }
            };
            Console.WriteLine(RubixCube);

            Witgoed Frigo = new Witgoed
            { 
                Soort = Witgoed.WitgoedSoort.Koelkst, Merk = "Samsung", TypeNummer = "FR123"
            };
            Console.WriteLine(Frigo);

            Bruingoed PlayStation = new Bruingoed
            {
                Soort = Bruingoed.BruingoedSoort.Spelconsole, Merk = "Sony", TypeNummer = "PS5"
            };
            Console.WriteLine(PlayStation);

            Computer MacOne = new Computer
            {
                Soort = Computer.ComputerSoort.Desktop,
                Gewicht = 7.6f, Afmetingen = new double[3] { 45, 55, 55},
                Merk = "Apple", TypeNummer = "AppleOne SeaBlue"
            };
            Console.WriteLine(MacOne);

            Professioneel DTmax = new Professioneel
            {
                Merk = "TurnGood", TypeNummer = "Max 01",
                Soort = Professioneel.ProSoort.Draaibank,
                Voltage = Professioneel.Spanning.AC380
            };
            Console.WriteLine(DTmax);

            KinderkKleding BumbaT = new KinderkKleding
            {
                Merk = "Studio100",
                ModelNaam = "Bumba T-shirt",
                Maat = new Kleding.LeeftijdMaat { Leeftijd = 4 }
            };
            Console.WriteLine(BumbaT);

            Casual Levis58 = new Casual
            {
                Merk = "Levis",
                ModelNaam = "58",
                Maat = new Kleding.MeetlintMaat { Maat = 42 }
            };
            Console.WriteLine(Levis58);

            SportKleding Trainer = new SportKleding
            {
                Merk = "Beayens",
                ModelNaam = "Set-up",
                Maat = new Kleding.SmlMaat { Maat = Kleding.SmlMaat.Sml.XL }
            };
            Console.WriteLine(Trainer);

            VeiligheidsKleding Helm = new VeiligheidsKleding
            {
                Beschermt = VeiligheidsKleding.Bescherming.Hoofd
            };
            Console.WriteLine(Helm);

        }
    }
}
