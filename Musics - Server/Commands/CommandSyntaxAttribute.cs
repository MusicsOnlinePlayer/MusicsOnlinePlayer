using System;

namespace Musics___Server.Commands
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    internal class CommandSyntaxAttribute : Attribute
    {
        public string Command { get; }
        public string Arguments { get; }

        public CommandSyntaxAttribute(string command, string arguments = "")
        {
            Command = command;
            Arguments = arguments;

        }
    }
}
