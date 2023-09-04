using System;
using Fclp;
using TurboReader;

class Program
{
    public static void Main(string[] args)
    {
        // Määritetään argumentit
        string defaultFileName = "luvut.txt";
        string fileName = defaultFileName;

        var p = new FluentCommandLineParser();

        p.Setup<string>('f', "file")
            .Callback(file => fileName = file);

        p.Parse(args);

        if (!FileInput.CanReadFile(fileName)&&!FileInput.CanReadFile(defaultFileName))
        {
            Console.WriteLine("Oletustiedostoa eikä tiedostoa nimellä {0} löydetty tai sitä ei voi lukea.", fileName);
            return;
        }
        /*
        // Ei Numerot Debug
        var notNumbers = new Dictionary<int, string>();
        notNumbers = (Dictionary<int, string>)FileInput.ReadNaNs(fileName);
        foreach (KeyValuePair<int, string> kvp in notNumbers)
        {
            Console.WriteLine("Line: {0}, String: {1}", kvp.Key, kvp.Value);
        }
        */

        int[] fileNumbers = FileInput.ReadInts(fileName);
        if (fileNumbers.Length == 0)
        {
            Console.WriteLine("Tiedostossa ei ole lukuja");
        }
        else
        {
            int fileSum = 0;
            for (int i = 0; i < fileNumbers.Length; i++)
            {
                fileSum += fileNumbers[i];
            }
            Console.WriteLine("Tiedoston lukujen summa on {0}.", fileSum);
        }
        

        var notNumbers = new Dictionary<int, string>();
        notNumbers = (Dictionary<int, string>)FileInput.ReadNaNs(fileName);
        foreach (KeyValuePair<int, string> kvp in notNumbers)
        {
            Console.WriteLine("Rivillä {0}, \"{1}\" ei ole luku.", kvp.Key, kvp.Value);
        }


    }
}