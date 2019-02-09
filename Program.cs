using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace ProtonDB_Parsing
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string libraryUrl = "https://steamcommunity.com/id/" + username + "/games/?tab=all";
            string loginId = Console.ReadLine();
            string password = Console.ReadLine();
            
            HtmlWeb web = new HtmlWeb();
            var webClient = new WebClient();
            webClient.Credentials = new NetworkCredential(loginId, password);

            WebRequest wr = WebRequest.Create(libraryUrl);
            wr.Credentials = webClient.Credentials;

        }
    }
}