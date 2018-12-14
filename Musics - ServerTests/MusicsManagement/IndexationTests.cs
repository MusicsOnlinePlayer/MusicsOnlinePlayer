using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.MusicsManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Musics;
using Utility.Network.Dialog.Uploads;

namespace Musics___Server.MusicsManagement.Tests
{
    [TestClass()]
    public class IndexationTests
    {
        [TestMethod()]
        public void GetElementPathTest()
        {
            string AuthorPathExpected = "TestPath1";
            string AlbumPathExpected = "TestPath2";
            string MusicPathExpected = "TestPath3";
            Author a = new Author("Author1", AuthorPathExpected);
            a.Albums.Add(new Album(a, "Album1", AlbumPathExpected));
            a.Albums[0].Add(new Music("Music1", a, a.Albums[0], MusicPathExpected));
            Indexation.ServerMusics.Add(a);

            var result1 = Indexation.GetElementPath(a);
            var result2 = Indexation.GetElementPath(a.Albums[0]);
            var result3 = Indexation.GetElementPath(a.Albums[0].Musics.First());

            Assert.AreEqual(AuthorPathExpected, result1);
            Assert.AreEqual(AlbumPathExpected, result2);
            Assert.AreEqual(MusicPathExpected, result3);
        }

        [TestMethod()]
        public void GetMusicByIDTest()
        {
            //Author a = new Author("Author1", "TestPath1");
            //a.Albums.Add(new Album(a, "Album1", "TestPath2"));
            //a.Albums[0].Add(new Music("Music1", a, a.Albums[0], "TestPath3"));
            //Indexation.ServerMusics.Add(a);

            var r = Indexation.GetMusicByID(Indexation.ServerMusics[0].Albums[0].Musics.First().MID);

            Assert.AreEqual(Indexation.ServerMusics[0].Albums[0].Musics.First(), r);
        }

        [TestMethod()]
        public void GetAuthorTest()
        {
            var r = Indexation.GetAuthor(Indexation.ServerMusics[0].MID);

            Assert.AreEqual(Indexation.ServerMusics[0], r);
        }

        [TestMethod()]
        public void AddMusicTest()
        {

        }
    }
}