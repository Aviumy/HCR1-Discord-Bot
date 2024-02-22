namespace HCR1DiscordBot.Models
{
    public class Vehicle
    {
        public string Name { get; set; }
        public string FuelDuration { get; set; }
        public int? PurchaseCost { get; set; }
        public int? UpgradeCost { get; set; }
        public string Emoji { get; set; }
        public string[] Aliases { get; set; }

        public Vehicle(string name, string fuelDuration, int? purchaseCost, int? upgradeCost, string emoji, string[] aliases)
        {
            Name = name;
            FuelDuration = fuelDuration;
            PurchaseCost = purchaseCost;
            UpgradeCost = upgradeCost;
            Emoji = emoji;
            Aliases = aliases;
        }
    }
}
