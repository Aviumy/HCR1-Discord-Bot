using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace HCR1DiscordBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            string text = File.ReadAllText("_help.txt");

            var embed = new EmbedBuilder();
            embed.Description = text;

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
}
