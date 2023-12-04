using Helpers;
using System.Security.Cryptography.X509Certificates;
namespace _04_wines;

class Program
{
    public enum enType
    {
        Red,
        White,
        Rosé,
    }
    public enum enGrape
    {
        Reissling, 
        Tempranillo, 
        Chardonay, 
        Shiraz, 
        Cabernet, 
        Savignoin, 
        Syrah,
    }
    public enum enCountry
    {
        Germany,
        France,
        Spain,
        Italy,
    }
    public class csWine
    {
        string wineName { get; }
        public decimal winePrice { get; set; }
        public enType Type { get; }
        public enGrape Grape { get; }
        public enCountry Country { get; }

        public csWine(csSeedGenerator _seed)
        {
            string names = "Pinot Paradise, Zinfandel Zen, Shiraz Sensation, Merlot Magic";

            Type = _seed.FromEnum<enType>();
            Grape = _seed.FromEnum<enGrape>();
            Country = _seed.FromEnum<enCountry>();
            wineName = _seed.FromString(names);
            winePrice = _seed.NextDecimal(5, 150);
        }
        public override string ToString()
        {
            return $"{wineName} costs: {winePrice:$0.00} is a {Type} wine from {Country} made from {Grape} grapes.";
        }
    }
    class csWineCellar
    {
        public List<csWine> Wines = new List<csWine>();

        public csWineCellar(csSeedGenerator _seed)
        {
            for (int i = 0; i < 10; i++)
            {
                Wines.Add(new csWine(_seed));
            }
           
        }
        public csWine FindCheapestWine()
        {
            csWine cheapest = null;
            decimal min = decimal.MaxValue;
            foreach (var wineBottle in Wines)
            {
                if( wineBottle.winePrice <= min)
                {
                    min = wineBottle.winePrice;
                    cheapest = wineBottle;
                }

            }
            return cheapest;
        }
        public csWine FindMostExpensiveWine()
        {
            csWine expensive = null;
            decimal max = decimal.MinValue;
            foreach (var wineBottle in Wines)
            {
                if (wineBottle.winePrice >= max)
                {
                    max = wineBottle.winePrice;
                    expensive = wineBottle;
                }

            }
            return expensive;
        }

    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Welcome to the Wine Generator! ");
        Console.WriteLine("------------------------------------------\n");
        var rnd = new csSeedGenerator();

        csWineCellar cellar = new csWineCellar(rnd);

        foreach (var item in cellar.Wines)
        {
            Console.WriteLine(item + "\n");
        }
        csWine cheapestBottle = cellar.FindCheapestWine();
        Console.WriteLine("Cheapest bottle of wine: ");
        Console.WriteLine("-------------------------");
        Console.WriteLine(cheapestBottle);

        csWine expensive = cellar.FindMostExpensiveWine();
        Console.WriteLine("\nMost expensive bottle of wine: ");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(expensive);

        Console.ReadKey();



    }
}
//Exercise:
// 1. Modellera en flaska vin en C# class. Utmärkande för ett vin är
//    Druva: Reissling, Tempranillo, Chardonay, Shiraz, Cabernet Savignoin, Syrah
//    Typ: Rött, vitt, rose
//    Namn: namnet på vinet
//    Land: Tyskland, Frankrike, Spanien
//    Pris:
//
// 2. När vinet väl är skapad så ska man bara kunna ändra pris.

// 3. Gör en constructor csWine(csSeedGenerator _seeder) som initierar ett vin
//
// 3. Skapa en ToString i din vinklass som presenterar vinet.
//
// 4. Skapa en vinkällare bestående av 10 flaskor av slumpmässig Druva,
//    Typ, Namn, Land och pris
//
// 5. Vilket är det billigaste och dyraste vinet i vinkällaren?
//
// 7. Vad är värdet av vinkällaren?
//
//
// 8. Deklarera en contruktor som tillåter dig att själv bestämma alla csWine public properties
//
// 9.Deklarera en Copy constructor.
//
// 10.Använd copy constructorn för att skapa en ny lista av 10 viner med samma
//    innehåll som ursprungslistan
