using System;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace ProtonDB_Parsing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Scratch work to eventually factor into sane compartments
            Console.WriteLine("Please enter your Steam username:");
            string personaName = Console.ReadLine();
            string libraryUrl = "https://steamcommunity.com/id/" + personaName + "/games/?tab=all";

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(libraryUrl);

            var entry = doc.DocumentNode.SelectNodes("/html/body/div//div//div//div//div//div//div//div//div//div//div//a");

            if (entry != null)
            {
                foreach (var node in entry)
                {
                    Console.WriteLine(node.InnerText);
                }
            }
            else
            {
                Console.WriteLine("Node empty.");
            }

            Console.ReadKey(true);
        }
    }
}