using System;
using System.Threading.Tasks;
using Discord.Commands;
using HCR1DiscordBot.Services.ModuleServices;

namespace HCR1DiscordBot.Modules
{
    public class ComboModule : ModuleBase<SocketCommandContext>
    {
        private ComboModuleService _service = new ComboModuleService(
            vehiclesFilePath: "_vehicles.json",
            stagesFilePath: "_stages.json"
        );

        [Command("combo")]
        public async Task GenerateComboAsync()
        {
            await Context.Channel.SendMessageAsync(
                $"Try to drive with {_service.GetRandomVehicle().Name} " +
                $"on {_service.GetRandomStage(excludeMissions: true).Name}!"
            );
        }
    }
}
