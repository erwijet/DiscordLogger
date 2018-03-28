using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using System.IO;

namespace DiscordLogger.Commands
{
    public class EnableLogger : ModuleBase<SocketCommandContext>
    {
        [Command("logstart")]
        public async Task EnableLoggerAsync(params string[] args)
        {
            if (args is null) await ReplyAsync("Please provide a path to store the data");
            else
            {
                Program.IsLoggerOn = true;
                Program.path = args[0];
                using (File.Create(Program.path))
                {
                }
                await ReplyAsync("Started logger...");
            }
        }
    }
}
