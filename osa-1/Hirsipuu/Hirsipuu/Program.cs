using System;
using Fclp;
using TurboReader;

class Program
{
    public static void Main(string[] args)
    {
        // Määritetään argumentit
        string defaultFileName = "sanat.txt";
        string fileName = defaultFileName;

        var p = new FluentCommandLineParser();

        p.Setup<string>('f', "file")
            .Callback(file => fileName = file);

        p.Parse(args);

        if (!FileInput.CanReadFile(fileName) && !FileInput.CanReadFile(defaultFileName))
        {
            Console.WriteLine("Oletustiedostoa eikä tiedostoa nimellä {0} löydetty tai sitä ei voi lukea.", fileName);
            return;
        }
    }
}