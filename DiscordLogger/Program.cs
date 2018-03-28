using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordLogger
{
    class Program
    {
        DiscordSocketClient _client;
        CommandService _commands;
        IServiceProvider _services;

        public static bool IsLoggerOn = false;
        public static string path { get; set; }

        static void Main(string[] args)
        {
            new Program().RunBotAsync().GetAwaiter();
            Console.ReadKey();
        }

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.Log += log;

            string token = "NDI4NTkwMjk3MDgyMTAxNzgw.DZ1TVA.xIbgEApNqTu_SJzDkjim7yc8bho";

            await RegisterCommandAsync();
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("%", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }

            if (IsLoggerOn)
            {
                await Commands.Log.DoLogAsync(message);
            }
        }

        private Task log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}
