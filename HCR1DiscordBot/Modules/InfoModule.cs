using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Discord.Commands;
using HCR1DiscordBot.Services;
using Discord;

namespace HCR1DiscordBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private Random _rand = new Random();
        private JsonReaderService _jsonReader = new JsonReaderService(
            vehiclesFilePath: "_vehicles.json",
            stagesFilePath: "_stages.json"
        );
        private InfoSearchService _searchService = new InfoSearchService();

        [Command("hcrinfo")]
        public async Task InfoHelpAsync()
        {
            dynamic item;
            if (_rand.Next(2) == 0)
            {
                var vehicles = _jsonReader.ReadAllVehicles();
                item = vehicles[_rand.Next(vehicles.Length)];
            }
            else
            {
                var stages = _jsonReader.ReadAllStages();
                item = stages[_rand.Next(stages.Length)];
            }

            await Context.Channel.SendMessageAsync(
                "Type the name of the vehicle or stage you want to check\n" +
                $"For example: *hcrinfo {item.Name.ToLower()}"
            );
        }

        [Command("hcrinfo")]
        public async Task InfoAsync([Remainder] string parameter)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            StringBuilder sb = new StringBuilder();

            var vehicles = _jsonReader.ReadAllVehicles();
            dynamic item = _searchService.FindIn(vehicles, parameter);
            if (item != null)
            {
                sb.AppendLine($"{item.Emoji} **{item.Name}**");
                if (item.Name.ToLower() == "garage")
                {
                    sb.AppendLine($"Purchase cost: 300 gems");
                    sb.AppendLine($"Upgrade cost: Random");
                    sb.AppendLine($"Total cost (Purchase + Upgrade): Random");
                }
                else
                {
                    sb.AppendLine($"Purchase cost: {item.PurchaseCost:n0}");
                    sb.AppendLine($"Upgrade cost: {item.UpgradeCost:n0}");
                    sb.AppendLine($"Total cost (Purchase + Upgrade): {(item.PurchaseCost + item.UpgradeCost):n0}");
                }
                sb.AppendLine($"Fuel Duration: {item.FuelDuration}");
            }
            else
            {
                var stages = _jsonReader.ReadAllStages();
                item = _searchService.FindIn(stages, parameter);
                if (item != null)
                {
                    sb.AppendLine($"**{item.Name}**");
                    sb.AppendLine($"Purchase cost: {item.PurchaseCost:n0}");
                    sb.AppendLine($"Fuel locations: coming soon...");
                }
                else
                {
                    sb.AppendLine("Couldn't find such vehicle or stage");
                }
            }

            var embed = new EmbedBuilder();
            embed.Description = sb.ToString();
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
