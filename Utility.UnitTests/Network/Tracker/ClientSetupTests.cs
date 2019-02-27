using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility.Network.Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Utility.Network.Tracker.Tests
{
    [TestClass()]
    public class ClientSetupTests
    {
        ClientSetup Cs;

        [TestInitialize]
        public void Start()
        {
            Cs = new ClientSetup();
        }

        [TestMethod()]
        public void SetupSocketTest()
        {
            Cs.SetupSocket(2003, 1000);

            Assert.AreEqual(Cs.PORT, 2003);
            Assert.AreEqual(Cs.BUFFER_SIZE, 1000);
            Assert.AreEqual(Cs.buffer.Length, Cs.BUFFER_SIZE);
        }
    }
}