using System;
using System.Linq;

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

        public override bool Equals(object obj)
        {
            return obj is Vehicle other &&
                this.Name == other.Name &&
                this.FuelDuration == other.FuelDuration &&
                this.PurchaseCost == other.PurchaseCost &&
                this.UpgradeCost == other.UpgradeCost &&
                this.Emoji == other.Emoji &&
                (
                    (this.Aliases == null && other.Aliases == null) ||
                    (
                        this.Aliases != null && other.Aliases != null &&
                        this.Aliases.SequenceEqual(other.Aliases)
                    )
                );
        }

        // No need to include aliases into hash code
        // because equal arrays result in different hash code
        public override int GetHashCode()
        {
            return Name?.ToLower().GetHashCode() ?? 0 +
                FuelDuration?.ToLower().GetHashCode() ?? 0 +
                PurchaseCost?.GetHashCode() ?? 0 +
                UpgradeCost?.GetHashCode() ?? 0 +
                Emoji?.ToLower().GetHashCode() ?? 0;
        }
    }
}
