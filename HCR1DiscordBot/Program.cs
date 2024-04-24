using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace HCR1DiscordBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().RunBotAsync().GetAwaiter().GetResult();
        }

        private DiscordSocketClient _client;
        public CommandService _commands;
        private IServiceProvider _services;

        private SocketGuild _guild;

        private ulong _logChannelID;
        private SocketTextChannel _logChannel;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig() 
            { 
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages | GatewayIntents.MessageContent 
            });
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.Log += _ClientLog;

            await RegisterCommandsAsync();

            string token = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task _ClientLog(LogMessage msg)
        {
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task HandleCommandAsync(SocketMessage msg)
        {
            var message = msg as SocketUserMessage;
            // We are going to log only commands and bot responses,
            // so we need to explicitly exclude messages
            // that start with bold formatting, since it starts with * too
            if (!message.Author.IsBot && 
                (!message.ToString().StartsWith("*") || message.ToString().StartsWith("**")))
                return;

            var context = new SocketCommandContext(_client, message);
            var channel = _client.GetChannel(_logChannelID) as SocketTextChannel;

            StringBuilder messageText = new StringBuilder();
            messageText.AppendLine(message.ToString());
            if (message.Embeds.Any())
            {
                messageText.AppendLine(string.Join("\n", message.Embeds.Select(e => e.Description)));
            }

            Console.WriteLine($"------------------------\n[{DateTime.Now}]\n{messageText}");

            if (message.Author.IsBot)
                return;

            int argPos = 0;
            if (message.HasStringPrefix("*", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
                if (result.Error.Equals(CommandError.UnmetPrecondition))
                    await message.Channel.SendMessageAsync(result.ErrorReason);
            }
        }
    }
}
