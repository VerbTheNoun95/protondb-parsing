using HtmlAgilityPack;

namespace ProtonDB_Parsing
{
    public class Game
    {
        public string Name { get; }
        public int AppId { get; }
        public Status Status;

        public Game(string name, int appId)
        {
            this.Name = name;
            this.AppId = appId;
        }

        public Status GetStatus(string status)
        {
            switch (status)
            {
                case "NATIVE": return Status.Native;
                case "PLATINUM": return Status.Platinum;
                case "GOLD": return Status.Gold;
                case "SILVER": return Status.Silver;
                case "BRONZE": return Status.Bronze;
                case "BORKED": return Status.Borked;
                default: return Status.None;
            }
        }
    }
}