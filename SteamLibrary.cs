using System.Collections.Generic;

namespace ProtonDB_Parsing
{
    public class SteamLibrary
    {
        public string PersonaName { get; set; }
        
        public List<Game> GameLibrary = new List<Game>();
    }
}