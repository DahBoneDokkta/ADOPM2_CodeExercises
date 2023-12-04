using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Helpers;

namespace _03_Pearls;


public enum enPearlColor { Black, White, Pink }
public enum enPearlShape { Spherical, Droplet, Square }
public enum enPearlType { Freshwater, Saltwater, Swampwater }

class csPearl
{

    //public const int PearlMinSize = 5;
    //public const int PearlMaxSize = 25;

    public int Milimeter { get; init; }
    public enPearlColor Color { get; init; }
    public enPearlShape Shape { get; init; }
    public enPearlType Type { get; init; }

    public csPearl(csSeedGenerator _rnd)
    {
        Color = _rnd.FromEnum<enPearlColor>();
        Shape = _rnd.FromEnum<enPearlShape>();
        Type = _rnd.FromEnum<enPearlType>();
        Milimeter = _rnd.Next(5, 26);
    }

    public override string ToString()
    {
        return $"{Milimeter}mm {Color} {Shape} {Type} pearl \n";
    }

}

class Program
{

    static void Main(string[] args)
    {
        // Skapar en lista för att lagra pärlorna i halsbandet
        List<csPearl> necklace = new List<csPearl>();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Pärlhalsband: \n");
            
            var rnd = new csSeedGenerator();
            var pearl = new csPearl(rnd);

            necklace.Add(pearl);

            Console.WriteLine(pearl);
        }

        foreach (var pearl in necklace)
        {
            Console.WriteLine(pearl);
        }

    }
}

//Exercise:
// 1. Modellera en pärlan i en C# class. Utmärkande för en pärla är
//    Storlek: Diameter 5mm till 25mm
//    Färg: Svart, Vit, Rosa
//    Form: Rund, Droppformad
//    Typ: Sötvatten, Saltvatten
//
// 2. När pärlan väl är skapad så ska man inte kunna ändra den.

// 3. Gör om constructor csPearl(csSeedGenerator _seeder) som initierar en slumpmässig pärla

// 4. Skapa en ToString i din pärlklass som presenterar pärlan.
//
// 4. Skapa ett halsband bestående av 10 pärlor av slumpmässig storlek, färg
//    form, och typ
//
// 5. Skriv kod som visar vilken färg, form och typ har den minsta och den största pärlan i halsbandet?
//
// 6. Deklarera en contruktor som tillåter dig att själv bestämma alla csPearl public properties
//
// 7. Deklarera en Copy constructor.
//
// 8. Använd copy constructorn för att skapa ett nytt halsband som är en kopia av ursprunget



