using System;
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
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            FirefoxDriver driver = new FirefoxDriver(options);
            
            SteamParser steamParser = new SteamParser(personaName);
            ProtonDbParser protonParser = new ProtonDbParser(driver);

            List<int> appIds = steamParser.GetSteamAppIds();

            foreach (var appId in appIds)
            {
                Game game = protonParser.GetGameStatus(appId);
                CompatibilityList.Add(game);
                Console.WriteLine(game.Name + " " + game.AppId + " " +  game.Status);
            }
            
            driver.Close();
        }
    }
}