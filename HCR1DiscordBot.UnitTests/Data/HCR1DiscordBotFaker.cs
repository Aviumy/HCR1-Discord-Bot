using HCR1DiscordBot.Models;

namespace HCR1DiscordBot.UnitTests.Data
{
    public class HCR1DiscordBotFaker
    {
        public Vehicle[] GetAllExampleVehicles()
        {
            return new Vehicle[]
            {
                new Vehicle
                (
                    name: "Hill Climber",
                    fuelDuration: "40s",
                    purchaseCost: 0,
                    upgradeCost: 3711000,
                    emoji: ":hill_climber:",
                    aliases: new string[] {"jeep", "hc"}
                ),
                new Vehicle
                (
                    name: "Motocross Bike",
                    fuelDuration: "40s",
                    purchaseCost: 75000,
                    upgradeCost: 4634500,
                    emoji: ":motocross_bike:",
                    aliases: new string[] { }
                ),
                new Vehicle
                (
                    name: "Garage",
                    fuelDuration: "68s (electric zap)",
                    purchaseCost: 300,
                    upgradeCost: 0,
                    emoji: ":garage:",
                    aliases: new string[] {"garage race car", "garage rally car", "garage rc", "grc", "garaj", "garag"}
                )
            };
        }

        public Vehicle[] GetExampleVehiclesWithNullProps()
        {
            return new Vehicle[]
            {
                new Vehicle
                (
                    name: "Hill Climber",
                    fuelDuration: null,
                    purchaseCost: 0,
                    upgradeCost: 3711000,
                    emoji: ":hill_climber:",
                    aliases: new string[] {"jeep", "hc"}
                ),
                new Vehicle
                (
                    name: null,
                    fuelDuration: "40s",
                    purchaseCost: 75000,
                    upgradeCost: 4634500,
                    emoji: ":motocross_bike:",
                    aliases: new string[] { }
                ),
                new Vehicle
                (
                    name: "Garage",
                    fuelDuration: null,
                    purchaseCost: null,
                    upgradeCost: null,
                    emoji: null,
                    aliases: null
                ),
                new Vehicle
                (
                    name: null,
                    fuelDuration: null,
                    purchaseCost: null,
                    upgradeCost: null,
                    emoji: null,
                    aliases: null
                )
            };
        }

        public Stage[] GetAllExampleStages()
        {
            return new Stage[]
            {
                new Stage
                (
                    name: "Countryside",
                    purchaseCost: 0,
                    aliases: new string[] {"country", "contry", "contryside" }
                ),
                new Stage
                (
                    name: "Seasons",
                    purchaseCost: 50000,
                    aliases: new string[] {"season" }
                ),
                new Stage
                (
                    name: "Suburbs",
                    purchaseCost: 1500000,
                    aliases: new string[] { }
                ),
                new Stage
                (
                    name: "Retro Mission",
                    purchaseCost: 500000,
                    aliases: new string[] {"retro", "retro mision" }
                ),
                new Stage
                (
                    name: "Space Mission",
                    purchaseCost: 1500000,
                    aliases: new string[] {"space", "space mision" }
                )
            };
        }

        public Stage[] GetExampleStagesWithNullProps()
        {
            return new Stage[]
            {
                new Stage
                (
                    name: "Countryside",
                    purchaseCost: 0,
                    aliases: null
                ),
                new Stage
                (
                    name: null,
                    purchaseCost: 50000,
                    aliases: new string[] {"season" }
                ),
                new Stage
                (
                    name: "Suburbs",
                    purchaseCost: null,
                    aliases: null
                ),
                new Stage
                (
                    name: null,
                    purchaseCost: null,
                    aliases: null
                )
            };
        }

        public Stage[] GetExampleStagesWithoutMissons()
        {
            return new Stage[]
            {
                new Stage
                (
                    name: "Countryside",
                    purchaseCost: 0,
                    aliases: new string[] {"country", "contry", "contryside" }
                ),
                new Stage
                (
                    name: "Seasons",
                    purchaseCost: 50000,
                    aliases: new string[] {"season" }
                )
            };
        }

        public string[] GetExampleVehiclesAndStagesInfo()
        {
            return new string[]
            {
                ":hill_climber: **Hill Climber**\r\nPurchase cost: Free\r\nUpgrade cost: 3,711,000\r\nTotal cost (Purchase + Upgrade): 3,711,000\r\nFuel duration: 40s\r\n",
                "**Countryside**\r\nPurchase cost: Free\r\nFuel locations: coming soon...\r\n",
            };
        }
    }
}
