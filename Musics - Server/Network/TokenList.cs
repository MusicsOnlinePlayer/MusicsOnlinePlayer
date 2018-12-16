using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Utility.Network;

namespace Musics___Server.Network
{
    public class TokenList : Dictionary<Socket,Token>
    {
        public bool AddToken(Socket socket, Token token)
        {
            if (ContainsKey(socket) || ContainsValue(token))
                return false;
            Add(socket, token);
            return true;
        }

        public bool CheckTokenValidity(Token token, Socket socket)
        {
            if(TryGetValue(socket, out Token tk))
            {
                return tk.THash == token.THash;
            }
            return false;
        }
        public void RemoveToken(Socket socket)
            => Remove(socket);
    }
}
