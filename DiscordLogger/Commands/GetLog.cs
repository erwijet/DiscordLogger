using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Discord;
using Discord.Commands;

namespace DiscordLogger.Commands
{
    public class GetLog : ModuleBase<SocketCommandContext>
    {
        [Command("gl")]
        public async Task GetLogAsync(params string[] args)
        {
            try
            {
                using (StreamReader r = new StreamReader(args[0]))
                {
                    await ReplyAsync(r.ReadToEnd());
                }
            }
            catch
            {
                await ReplyAsync("Error, no path specified or log file does not exist");
            }
        }
    }
}
