using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Discord.Commands;
using Discord;
using HCR1DiscordBot.Services.ModuleServices;

namespace HCR1DiscordBot.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        private InfoModuleService _service = new InfoModuleService(
            vehiclesFilePath: "_vehicles.json",
            stagesFilePath: "_stages.json"
        );

        [Command("hcrinfo")]
        public async Task InfoHelpAsync()
        {
            await Context.Channel.SendMessageAsync(
                "Type the name of the vehicle or stage you want to check\n" +
                $"For example: *hcrinfo {_service.GetRandomVehicleOrStage().Name.ToLower()}"
            );
        }

        [Command("hcrinfo")]
        public async Task InfoAsync([Remainder] string parameter)
        {
            // For formatting numbers with commas, like 1,000,000
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            var embed = new EmbedBuilder();
            embed.Description = _service.GetVehicleOrStageInfo(parameter);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
