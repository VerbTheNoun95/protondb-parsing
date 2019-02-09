using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using HtmlAgilityPack;
using ProtonDB_Parsing.Parser;

namespace ProtonDB_Parsing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Scratch work to eventually factor into sane compartments
            Console.WriteLine("Please enter your Steam username:");
            string personaName = Console.ReadLine();
            
            SteamParser parser = new SteamParser(personaName);

            List<int> appIds = parser.GetSteamAppIds();

            foreach (var id in appIds)
            {
                Console.WriteLine(id);

                string ProtonUrl = "https://www.protondb.com/app/" + id;
                Console.WriteLine(ProtonUrl);
                
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(ProtonUrl);

                var titleNode = doc.DocumentNode
                    .SelectSingleNode("/html/body/div[1]/div[1]/main/div/div[1]/span");

                var statusNode = doc.DocumentNode
                    .SelectSingleNode("/html/body/div[1]/div[1]/main/div/div[1]/div[1]/div/span");

                var nodes = doc.DocumentNode.SelectSingleNode("/html");

                if (nodes == null)
                {
                    Console.WriteLine("Node empty.");
                }
                else
                {
                    Console.WriteLine(nodes.InnerHtml);
                }

                break;
            }

//            Console.ReadKey(true);
        }
    }
}

