using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using Fclp.Internals.Parsing.OptionParsers;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

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
        public static char CharQuery(string prompt, string[] excludedChars, string errExcluded = "Annoit jo {0}", string errNotChar = "{0} ei ole kirjain")
        {
            const string promptField = ": _";
            int promptLenght = prompt.Length + promptField.Length;
            string input = "this is not a char";
            bool existsOnList;
            bool isChar;
            while (true)
            {
                (int cursorPosX, int cursorPosY) = Console.GetCursorPosition();
                existsOnList = false;
                isChar = false;
                Console.Write(prompt + promptField);
                Console.SetCursorPosition(cursorPosX + promptLenght - 1, cursorPosY);
                input = Console.ReadLine();
                if (excludedChars.Contains(input.ToLower()))
                {
                    existsOnList = true;
                }
                if (Checks.IsChar(input))
                {
                    isChar = true;
                }

                if (input != null && Regex.IsMatch(input, @"^[a-zA-ZåÅäÄöÖ]+$") && isChar && !existsOnList)
                {
                    return Convert.ToChar(input);
                }
                else if (input != null && Regex.IsMatch(input, @"^[a-zA-ZåÅäÄöÖ]+$") && isChar)
                {
                    Console.WriteLine(errExcluded, input);
                }
                else
                {
                    Console.WriteLine(errNotChar, input);
                }
            }
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
        public static bool IsChar(string prompt)
        {
            try
            {
                char lol = Convert.ToChar(prompt);
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
            int[] ints = (from s in lines where int.TryParse(s, out val) select val).ToArray();
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
        public static string[] ReadStrings(string prompt)
        {
            string[] lines = File.ReadAllLines(prompt);
            string text = "a";
            string[] pureText = (from s in lines where Regex.IsMatch(s, @"^[a-zA-ZåÅäÄöÖ]+$") select s).ToArray();
            return pureText;
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