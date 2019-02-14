using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ProtonDB_Parsing.Parser
{
    public class ProtonDbParser
    {
        public FirefoxDriver Driver { get; }

        public ProtonDbParser(FirefoxDriver driver)
        {
            this.Driver = driver;
        }

        public Game GetGameStatus(int appID)
        {
            string protonUrl = "https://www.protondb.com/app/" + appID;
            string titlePath = "/html/body/div[1]/div[1]/main/div/div[1]/span";
            string statusPath = "/html/body/div[1]/div[1]/main/div/div[1]/div[1]/div/span";
            
            Driver.Navigate().GoToUrl(protonUrl);
            
            if (ElementExists((By.XPath(titlePath)),
                out var titleNode))
            {
                titleNode = Driver
                    .FindElementByXPath(titlePath);
                
                Game game = new Game(titleNode.Text, appID);

                if (ElementExists((By.XPath(statusPath)),
                    out var statusNode))
                {
                    statusNode = Driver
                        .FindElementByXPath(statusPath);

                    game.Status = game.GetStatus(statusNode.Text);
                    return game;
                }
                else
                {
                    game.Status = Status.None;
                    return game;
                }
            }
            else
            {
                Game game = new Game("_missing_", appID) {Status = Status.None};
                return game;
            }


        }
        

        // Thanks to Arran at stack overflow for the idea
        // https://stackoverflow.com/questions/10934305/selenium-c-sharp-webdriver-how-to-detect-if-element-is-visible
        private bool ElementExists(By by, out IWebElement element)
        {
            try
            {
                element = Driver.FindElement(by);
            }
            catch (NoSuchElementException e)
            {
                element = null;
                return false;
            }

            return true;
        }
    }
}