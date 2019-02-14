using System;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium.Firefox;
using ProtonDB_Parsing.Parser;

namespace ProtonDB_Parsing
{
    public class SteamLibrary
    {        
        private readonly List<Game> CompatibilityList = new List<Game>();

        public void GetCompatibilityList(string personaName)
        {
            SteamParser steamParser = new SteamParser(personaName);
            List<int> appIds = steamParser.GetSteamAppIds();

            foreach (var appId in appIds)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArgument("--headless");
                FirefoxDriver driver = new FirefoxDriver(options);
                
                ProtonDbParser protonParser = new ProtonDbParser(driver);
                Game game = protonParser.GetGameStatus(appId);
                CompatibilityList.Add(game);
                Console.WriteLine(game.Name + " " + game.AppId + " " +  game.Status);
                
                driver.Quit();
            }
            
            
        }

        public void WriteToCsv()
        {
            using (StreamWriter writer = new StreamWriter("ProtonDB_CompatibilityList.csv"))
            {
                writer.WriteLine("Name,AppID,Status");
            
                foreach (var game in CompatibilityList)
                {
                    string entry = game.Name + "," + game.AppId + "," + game.Status;
                    writer.WriteLine(entry);
                }
            }
        }

        public void WriteToCsv(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Name,AppID,Status");
            
                foreach (var game in CompatibilityList)
                {
                    string entry = game.Name + "," + game.AppId + "," + game.Status;
                    writer.WriteLine(entry);
                }
            }
        }
    }
}