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

            WebRequest request = WebRequest.Create(libraryUrl);
            request.Credentials = webClient.Credentials;
            if (request.ContentLength != 0)
            {
                Console.Write("Yeet\n");

            }
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            // Display the status.
            Console.WriteLine (response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();
            // Display the content.
            Console.WriteLine (responseFromServer);
            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();

        }
    }
}