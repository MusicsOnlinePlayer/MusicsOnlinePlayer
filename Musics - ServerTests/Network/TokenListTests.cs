using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.Network.Tests
{
    [TestClass()]
    public class TokenListTests
    {
        [TestMethod()]
        public void AddTokenTest()
        {
            TokenList TkL = new TokenList();
            var tk = new Utility.Network.Token("Test1");

            Assert.AreEqual(true, TkL.AddToken(new System.Net.Sockets.Socket(System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp), tk));
            Assert.AreEqual(false, TkL.AddToken(new System.Net.Sockets.Socket(System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp), tk));
        }

        [Obsolete]
        public void CheckTokenValidityTest()
        {
            TokenList TkL = new TokenList();
            var tk = new Utility.Network.Token("Test1");
            var sk = new System.Net.Sockets.Socket(System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
            TkL.AddToken(sk,tk);

            Assert.AreEqual(true, TkL.CheckTokenValidity( tk,sk));
            Assert.AreEqual(false, TkL.CheckTokenValidity(new Utility.Network.Token("Test2"), sk));
            Assert.AreEqual(false, TkL.CheckTokenValidity(tk, new System.Net.Sockets.Socket(System.Net.Sockets.SocketType.Raw, System.Net.Sockets.ProtocolType.Icmp)));
        }
    }
}