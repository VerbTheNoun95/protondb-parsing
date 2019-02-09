using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace ProtonDB_Parsing.Parser
{
    public class SteamParser
    {
        private string PersonaName { get; set; }
        private string LibraryUrl { get; set; }

        public SteamParser(string personaName)
        {
            this.PersonaName = personaName;
            this.LibraryUrl = "https://steamcommunity.com/id/" + personaName + "/games/?tab=all";
        }

        public List<int> GetSteamAppIds()
        {
            List<int> appIdList = new List<int>();
            
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(LibraryUrl);
            
            var nodes = doc.DocumentNode.SelectSingleNode("//body");

            if (nodes == null)
            {
                Console.WriteLine("Node empty.");
            }
            else
            {
                foreach (var node in nodes.InnerText.Split('{').Where(
                    node => node.Contains("\"appid\":")))
                {
                    var gameEntry = node.Split(':');
                    var gameId = gameEntry[1].Split(',')[0];
                    appIdList.Add(int.Parse(gameId));
                }
            }

            return appIdList;
        }
    }
}