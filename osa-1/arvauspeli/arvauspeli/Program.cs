using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using TurboReader;
using Fclp;

class Program
{

    public static void Main(string[] args)
    {
        // arvotaan luku
        Random rng = new Random();
        int min; int max;

        // parametrit
        var p = new FluentCommandLineParser();

        p.Setup<int>('m')
            .Callback(minVal => min = minVal)
            .SetDefault(1);
        p.Parse(args);

        

        int salaisuus = rng.Next(min, max + 1);

        List<int> arvaukset = new List<int>();

        Console.WriteLine($"Arvauspeli!\nKoita arvata luku {min} ja {max} välillä");
        while (true)
        {
            int count = 0;
            int arvaus = ThatInput.NroLukija("Kirjoita arvaus: ");
            Console.WriteLine($"Arvasit {arvaus}");
            arvaukset.Add(arvaus);

            if (arvaus == salaisuus)
            {
                Console.WriteLine($"Oikein. Salainen luku oli {salaisuus}.\nKäytit {arvaukset.Count} arvausta");
            }
            else if (arvaus < salaisuus)
            {
                Console.WriteLine("Oikea luku on suurempi");
            }
            else
            {
                Console.WriteLine("Oikea luku on pienempi");
            }
            
            Console.WriteLine("Edelliset arvaukset");
            foreach (int g in arvaukset)
            {
                count++;
                Console.WriteLine($"{g}\t{count}");
            }
        }
    }
}
