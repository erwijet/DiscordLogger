using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordLogger;

using Discord;
using Discord.Commands;

namespace DiscordLogger.Commands
{
    public class DisableLogger : ModuleBase<SocketCommandContext>
    {
        [Command("logend")]
        public async Task DisableLoggerAsync()
        {
            DiscordLogger.Program.IsLoggerOn = false;
            await ReplyAsync("...logger terminated");
        }
    }
}
