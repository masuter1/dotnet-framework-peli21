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
}