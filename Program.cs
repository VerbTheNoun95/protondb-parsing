using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Firefox.Internal;
using ProtonDB_Parsing.Parser;

namespace ProtonDB_Parsing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter your Steam username:");
            string personaName = Console.ReadLine();

            SteamLibrary library = new SteamLibrary();
            library.GetCompatibilityList(personaName);
            
            library.WriteToCsv();
        }
    }
}

