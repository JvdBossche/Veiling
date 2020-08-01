using System;
using System.Collections.Generic;
using System.Text;

namespace Veiling
{
    public abstract class VerkoopObject
    {
        double Startprijs { get; set; }
        double VerwachtePrijs { get; set; }
        double AfklokPrijs { get; set; }
    }

    public class Meubels : VerkoopObject
    {
        private enum MeubelSoort { Kast, Bed, Sofa, Stoel, Tafel }

        MeubelSoort Soort { get; set; }
        double[] Afmetingen { get; set; }
    }

    class Speelgoed : VerkoopObject
    {
        int[] VanTotLeeftijd { get; set; }
        string Merk { get; set; }
        string TypeNummer { get; set; }
    }

    public abstract class Elektronica : VerkoopObject
    {

    }

    public class Witgoed : Elektronica
    {
        private enum WitgoedSoort { Koelkst, Diepvries, Microgolfoven, Oven, Kookplaat, Wasmachine, Droogkast}
        WitgoedSoort Soort { get; set; }
    }

    public class Bruingoed : Elektronica
    {
        private enum BruingoedSoort { TV, Radio, CDspeler, BlueRay, Spelconsole }
        BruingoedSoort Soort { get; set; }
    }

    public class Computers : Elektronica
    {
        private enum ComputerSoort { Desktop, Laptop, Tablet, Smartphone, SmartWatch }
        ComputerSoort Soort { get; set; }
        float Gewicht { get; set; }
        double[] Afmetingen { get; set; }
    }

    public class Professioneel : Elektronica
    {
        private enum ProSoort { Boormachine, Draaibank, Zaagtafel}
        ProSoort Soort { get; set; }
        private enum Spanning { DC12, DC24, AC230, AC380 }
        Spanning Voltage { get; set; }
    }

    public abstract class Kleding : VerkoopObject
    {
        public abstract class KledingMaat { }
        public class LeeftijdMaat : KledingMaat { int Leeftijd { get; set; } }
        public class MeetlintMaat : KledingMaat { int Maat { get; set; } }
        public class SmlMaat : KledingMaat
        {
            private enum Sml { XXS, XS, S, M, L, XL, XXL, XXXL }
            Sml Maat { get; set; }
        }
    }

    public class Kinderkkleding : Kleding
    {
        LeeftijdMaat Maat { get; set; }
    }

    public abstract class VolwassenKleding : Kleding
    {
        KledingMaat Maat { get; set; }
        // Optioneel: Dwing het gebruik van MeetlintMaat of SmlMaat en dus niet LeeftijdMaat af in get().
    }
    public class Casual : VolwassenKleding { }
    public class SportKleding : VolwassenKleding
    {
        enum Sport { NietSpecifiek, Airsoft, Baseball, Volleyball, Paardrijden, Voetbal}
        Sport GeschiktVoor { get; set; }
    }

    public class VeiligheidsKleding : VolwassenKleding
    {
        private enum Bescherming { Hoof, Voeten, Ogen, Oren}
        Bescherming Beschermt { get; set; }
    }
}
