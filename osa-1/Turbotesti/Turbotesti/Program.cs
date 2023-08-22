using System;
using Fclp;
using TurboReader;

class Program
{
    public static void Main(string[] args)
    {
        string[] notNumber;
        string filePath = "sanat.txt";

        var p = new FluentCommandLineParser();

        p.Setup<string>('f', "file")
            .Callback(file => filePath = file);

        p.Parse(args);



    }
}