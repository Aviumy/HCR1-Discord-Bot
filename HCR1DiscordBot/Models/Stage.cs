namespace HCR1DiscordBot.Models
{
    public class Stage
    {
        public string Name { get; set; }
        public int? PurchaseCost { get; set; }
        public string[] Aliases { get; set; }

        public Stage(string name, int? purchaseCost, string[] aliases)
        {
            Name = name;
            PurchaseCost = purchaseCost;
            Aliases = aliases;
        }
    }
}
