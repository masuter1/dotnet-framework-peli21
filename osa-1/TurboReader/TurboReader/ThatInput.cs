using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace TurboReader
{
    public class ThatInput
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
    }
    public class Checks
    {
        public static bool IsInt32(string prompt)
        {
            try
            {
                int lol = Convert.ToInt32(prompt);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
    public class FileInput
    {
        public static int[] ReadInts(string prompt)
        {
            string[] lines = File.ReadAllLines(prompt);
            // Figure out a way to read ints from a file
        }
    }
}