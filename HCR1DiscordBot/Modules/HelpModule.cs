using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using HCR1DiscordBot.Services.ModuleServices;

namespace HCR1DiscordBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        private HelpModuleService _service = new HelpModuleService("_help.txt");

        [Command("help")]
        public async Task HelpAsync()
        {
            var embed = new EmbedBuilder();
            embed.Description = _service.ReadHelpText();

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
