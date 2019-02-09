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

            // Look for appid's on the page
            var nodes = doc.DocumentNode.SelectSingleNode("//body");

            if (nodes != null)
            {
                foreach (var node in nodes.InnerText.Split('{').Where(
                    node => node.Contains("\"appid\":")))
                {
                    // We got 'em!
                    var gameEntry = node.Split(':');
                    var gameId = gameEntry[1].Split(',')[0];
                    Console.WriteLine(gameId);
                }

            }
            else
            {
                Console.WriteLine("Node empty.");
            }

//            Console.ReadKey(true);
        }
    }
}