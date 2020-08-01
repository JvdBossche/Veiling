using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling
{
    public abstract class VerkoopObject
    {
        public double Startprijs { get; set; }
        public double VerwachtePrijs { get; set; }
        public double AfklokPrijs { get; set; }
    }

    public class Meubel : VerkoopObject
    {
        public enum MeubelSoort { Kast, Bed, Sofa, Stoel, Tafel }

        public MeubelSoort Soort { get; set; }
        public double[] Afmetingen { get; set; }
    }

    public class Speelgoed : VerkoopObject
    {
        public int[] VanTotLeeftijd { get; set; }
        public string Merk { get; set; }
        public string TypeNummer { get; set; }
    }

    public abstract class Elektronica : VerkoopObject
    {
        public string Merk { get; set; }
        public string TypeNummer { get; set; }
    }

    public class Witgoed : Elektronica
    {
        public enum WitgoedSoort { Koelkst, Diepvries, Microgolfoven, Oven, Kookplaat, Wasmachine, Droogkast}
        public WitgoedSoort Soort { get; set; }
    }

    public class Bruingoed : Elektronica
    {
        public enum BruingoedSoort { TV, Radio, CDspeler, BlueRay, Spelconsole }
        public BruingoedSoort Soort { get; set; }
    }

    public class Computer : Elektronica
    {
        public enum ComputerSoort { Desktop, Laptop, Tablet, Smartphone, SmartWatch }
        public ComputerSoort Soort { get; set; }
        public float Gewicht { get; set; }
        public double[] Afmetingen { get; set; }
    }

    public class Professioneel : Elektronica
    {
        public enum ProSoort { Boormachine, Draaibank, Zaagtafel}
        public ProSoort Soort { get; set; }
        public enum Spanning { DC12=12, DC24=24, AC230=230, AC380=380 }
        public Spanning Voltage { get; set; }
    }

    public abstract class Kleding : VerkoopObject
    {
        public abstract class KledingMaat { }
        public class LeeftijdMaat : KledingMaat { public int Leeftijd { get; set; } }
        public class MeetlintMaat : KledingMaat { public int Maat { get; set; } }
        public class SmlMaat : KledingMaat
        {
            public enum Sml { XXS, XS, S, M, L, XL, XXL, XXXL }
            public Sml Maat { get; set; }
        }

        public string Merk { get; set; }
        public string ModelNaam { get; set; }
    }

    public class KinderkKleding : Kleding
    {
        public LeeftijdMaat Maat { get; set; }
    }

    public abstract class VolwassenKleding : Kleding
    {
        public KledingMaat Maat { get; set; }
        // Optioneel: Dwing het gebruik van MeetlintMaat of SmlMaat en dus niet LeeftijdMaat af in get().
    }
    public class Casual : VolwassenKleding { }

    public class SportKleding : VolwassenKleding
    {
        public enum Sport { NietSpecifiek, Airsoft, Baseball, Volleyball, Paardrijden, Voetbal}
        public Sport GeschiktVoor { get; set; }
    }

    public class VeiligheidsKleding : VolwassenKleding
    {
        public enum Bescherming { Hoofd, Voeten, Ogen, Oren}
        public Bescherming Beschermt { get; set; }
    }
}
