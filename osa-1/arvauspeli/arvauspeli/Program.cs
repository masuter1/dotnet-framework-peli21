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
        foreach (string s in args)
        {
            string parametri;


        }
    }
}
