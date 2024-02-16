using System;
using System.Threading.Tasks;
using Discord.Commands;
using HCR1DiscordBot.Services;

namespace HCR1DiscordBot.Modules
{
    public class ComboModule : ModuleBase<SocketCommandContext>
    {
        private Random _rand = new Random();
        private JsonReaderService _jsonReader = new JsonReaderService();

        [Command("combo")]
        public async Task GenerateComboAsync()
        {
            var vehicles = _jsonReader.ReadAllVehicles();
            var stages = _jsonReader.ReadAllStages(excludeMissions: true);
            await Context.Channel.SendMessageAsync(
                $"Try to drive with {vehicles[_rand.Next(vehicles.Length)].Name} on {stages[_rand.Next(stages.Length)].Name}!"
            );
        }
    }
}
