using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static int NroLukija(string prompt)
    {
        int arvaus = 0;
        while (true)
        {
            Console.Write(prompt);
            string arvausTeksi = Console.ReadLine();
            try
            {
                arvaus = Convert.ToInt32(arvausTeksi);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("et antanut numeroa");
                continue;
            }
        }
        return arvaus;
    }

    public static void Main(string[] args)
    {
        Random rng = new Random();
        int min = 1; int max = 20;
        for (int i = 0; i < args.Length; i++)
        {
            string parametri;
            int colonIndex = args[i].IndexOf(':');
            if (colonIndex >= 0)
            {
                parametri = args[i].Substring(0, colonIndex);
            }
            else
            {
                parametri = args[i];
            }
            switch (parametri.ToLower())
            {
                case "-min":
                    if (colonIndex >= 0)
                    {
                        int valueStartIndex = colonIndex + 1;
                        try
                        {
                            min = Convert.ToInt32(args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Odotettiin numeroa parametrille {parametri.ToLower()}. Käytetään oletusta ({min})");
                        }
                    }
                    else
                    {
                        ++i;
                        Console.WriteLine($"Odotettiin min-parametrille annettavaksi numeroa arvoksi. Käytetään oletusta ({min})");
                        return;
                    }
                    break;

                case "-max":
                    if (colonIndex >= 0)
                    {
                        int valueStartIndex = colonIndex + 1;
                        try
                        {
                            max = Convert.ToInt32(args[i].Substring(valueStartIndex, args[i].Length - valueStartIndex));
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Odotettiin numeroa parametrille {parametri.ToLower()}. Käytetään oletusta ({max})");
                        }
                    }
                    else
                    {
                        ++i;
                        Console.WriteLine($"Odotettiin max-parametrille annettavaksi numeroa arvoksi. Käytetään oletusta ({max})");
                        return;
                    }
                    break;
                default:
                    System.Console.WriteLine("Unrecognized parameter \"{0}\".", parametri);
                    return;
            }

        }
        int salaisuus = rng.Next(min, max + 1);

        List<int> arvaukset = new List<int>();

        Console.WriteLine($"Arvauspeli!\nKoita arvata luku {min} ja {max} välillä");
        while (true)
        {
            int arvaus = NroLukija("Kirjoita arvaus: ");
            Console.WriteLine($"Arvasit {arvaus}");
            arvaukset.Add(arvaus);
            arvaukset.Sort();

            if (arvaus == salaisuus)
            {
                Console.WriteLine($"Oikein. Salainen luku oli {salaisuus}.\nKäytit {arvaukset.Count} arvausta");
            }
        }
    }
}
