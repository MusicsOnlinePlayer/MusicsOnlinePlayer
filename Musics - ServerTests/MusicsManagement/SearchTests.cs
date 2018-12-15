using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.MusicsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musics___Server.MusicsManagement.Tests
{
    [TestClass()]
    public class SearchTests
    {
        [TestMethod()]
        public void FindTest()
        {
            string s2 = "Test1.test2";
            string t2 = "Test2";

            Assert.AreEqual(false, Search.Find(s2, t2));
            Assert.AreEqual(true,Search.Find(t2, s2));
        }
    }
}