using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace DiscordLogger.Commands
{
    public static class Log
    {
        public static async Task DoLogAsync(SocketUserMessage msg)
        {
            File.AppendAllLines(Program.path, new string[] {  msg.Author.Username +
                "[" + msg.Timestamp.ToString() + "] " +
                msg.ToString()
                });
        }
    }
}
