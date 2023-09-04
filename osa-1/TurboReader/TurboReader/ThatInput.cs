using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Fclp.Internals.Parsing.OptionParsers;

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
            int val = 0;
            int[] ints = (from s  in lines where int.TryParse(s, out val) select val).ToArray();
            // Figure out a way to read ints from a file
            return ints;
        }
        public static IDictionary<int,string> ReadNaNs(string prompt)
        {
            string[] lines = File.ReadAllLines(prompt);

            IDictionary<int,string> whereNaNs = new Dictionary<int,string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (!Checks.IsInt32(lines[i])) {
                    whereNaNs.Add(i+1, lines[i]);
                }
            }
            return whereNaNs;
        }
        public static bool CanReadFile(string prompt)
        {
            if (!File.Exists(prompt))
            {
                return false;           // Jos tiedosto on olemassa, truesta tulee false ja if ei toteudu
            }
            const char nulchar = '\0';
            const int charstocheck = 8000;
            int nulcount = 0;
            //muista try lause
            using (var streamreader = new StreamReader(prompt))
            {
                for (var i = 0; i < charstocheck; i++)
                {
                    if (streamreader.EndOfStream)
                    {
                        return true;
                    }
                    if ((char) streamreader.Read() == nulchar)
                    {
                        nulcount++;
                        if (nulcount >= 1)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        nulcount = 0;
                    }
                }
            }
            return false;
        }
    }
}