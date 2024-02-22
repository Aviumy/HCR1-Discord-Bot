using System;
using System.Linq;

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

        public override bool Equals(object obj)
        {
            return obj is Stage other &&
                this.Name == other.Name &&
                this.PurchaseCost == other.PurchaseCost &&
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
                PurchaseCost?.GetHashCode() ?? 0;
        }
    }
}
