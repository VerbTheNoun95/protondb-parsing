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
            Console.WriteLine("What is your Steam username?");
            string username = Console.ReadLine();
            string libraryUrl = "https://steamcommunity.com/id/" + username + "/games/?tab=all";
            
            Console.WriteLine("Enter your SteamID");
            string loginId = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            
            HtmlWeb web = new HtmlWeb();
            var webClient = new WebClient();
            webClient.Credentials = new NetworkCredential(loginId, password);

            WebRequest wr = WebRequest.Create(libraryUrl);
            wr.Credentials = webClient.Credentials;
            if (wr.ContentLength != 0)
            {
                Console.Write("Yeet\n");

            }

        }
    }
}