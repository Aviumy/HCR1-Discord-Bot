using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Discord.Commands;
using HCR1DiscordBot.Services;

namespace HCR1DiscordBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private Random _rand = new Random();
        private JsonReaderService _jsonReader = new JsonReaderService();

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
    }
}
