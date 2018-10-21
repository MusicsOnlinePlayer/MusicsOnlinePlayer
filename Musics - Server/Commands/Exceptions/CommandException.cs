using System;
using System.Runtime.Serialization;

namespace Musics___Server.Commands.Exceptions

{
    [Serializable]
    internal class CommandException : System.Exception
    {
        public CommandException()
        {
        }

        public CommandException(string message) : base(message)
        {
        }

        public CommandException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected CommandException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}