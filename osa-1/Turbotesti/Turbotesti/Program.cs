using System;
using Fclp;
using TurboReader;

class Program
{
    public static void Main(string[] args)
    {
        // Määritetään argumentit
        string filePath = "luvut.txt";

        var p = new FluentCommandLineParser();

        p.Setup<string>('f', "file")
            .Callback(file => filePath = file);

        p.Parse(args);

        try
        {

        }

        // Ei Numerot Debug
        var notNumbers = new Dictionary<int, string>();
        notNumbers = (Dictionary<int, string>)FileInput.ReadNaNs(filePath);
        foreach (KeyValuePair<int, string> kvp in notNumbers)
        {
            Console.WriteLine("Line: {0}, String: {1}", kvp.Key, kvp.Value);
        }


    }
}