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

            string token = File.ReadAllText("token.txt");
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
            var context = new SocketCommandContext(_client, message);
            var channel = _client.GetChannel(_logChannelID) as SocketTextChannel;

            Console.WriteLine("-------------\nUser: " 
                + message.Author.Username + " with ID  " + message.Author.Id 
                + "\nWrote:\n" + message.ToString());

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
