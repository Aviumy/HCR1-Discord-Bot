using System.IO;
using System.Threading.Tasks;
using Discord.Commands;

namespace HCR1DiscordBot.Modules
{
    public class HelpModule : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            string text = File.ReadAllText("_help.txt");
            await Context.Channel.SendMessageAsync(text);
        }
    }
}
