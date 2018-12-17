using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.Usersinfos;
using System;
using System.IO;
using System.Xml;
using Utility.Network;
using Utility.Network.Users;

namespace Musics___Server.Usersinfos.Tests
{
    [TestClass()]
    public class UsersInfosTests
    {
        [TestMethod()]
        public void CreateVoteByNodeTest()
        {
            //3f8c88f5cad87ebbae3ad701842c876e
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            UsersInfos.CreateVoteByNode("MusicMID", doc, nodes[0]);
            doc.Save(@"users.xml");

            Assert.AreEqual("3f8c88f5cad87ebbae3ad701842c876e", Function.GetMD5(@"users.xml"));
        }

        [TestMethod()]
        public void RemoveVoteByNodeTest()
        {
            //e0424ec3aad221f0f22836728db397f7
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("User");

            UsersInfos.CreateVoteByNode("MusicMID", doc, nodes[0]);
            UsersInfos.RemoveVoteByNode("MusicMID", nodes[0]);
            doc.Save(@"users.xml");
            Assert.AreEqual("e0424ec3aad221f0f22836728db397f7", Function.GetMD5(@"users.xml"));
        }

        [TestMethod()]
        public void AddVoteMusicTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            UsersInfos.AddVoteMusic("MusicMID", "abC");
            Assert.AreEqual("e0c5d6856147fbaf2888fc1720e9f7c8", Function.GetMD5(@"users.xml"));
            UsersInfos.AddVoteMusic("MusicMID", "abc");
            Assert.AreEqual("3f8c88f5cad87ebbae3ad701842c876e", Function.GetMD5(@"users.xml"));
            UsersInfos.AddVoteMusic("MusicMID", "abc");
            Assert.AreEqual("e0424ec3aad221f0f22836728db397f7", Function.GetMD5(@"users.xml"));
        }

        [TestMethod()]
        public void VoteExistTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));
            Assert.AreEqual(false, UsersInfos.VoteExist("IncorrectMID", "abc"));
            Assert.AreEqual(false, UsersInfos.VoteExist("MusicMID", "IncorrectUID"));
            Assert.AreEqual(false, UsersInfos.VoteExist("MusicMID", "abc"));
            UsersInfos.AddVoteMusic("MusicMID", "abc");
            Assert.AreEqual(false, UsersInfos.VoteExist("IncorrectMID", "abc"));
            Assert.AreEqual(false, UsersInfos.VoteExist("MusicMID", "IncorrectUID"));
            Assert.AreEqual(true, UsersInfos.VoteExist("MusicMID", "abc"));
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User2", "abc2"));

            var getall = UsersInfos.GetAllUsers();
            Assert.AreEqual(true, getall[0].Name == "User1");
            Assert.AreEqual(true, getall[0].UID == "abc");
            Assert.AreEqual(true, getall[1].Name == "User2");
            Assert.AreEqual(true, getall[1].UID == "abc2");
        }

        [TestMethod()]
        public void GetUserTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            var getuser = UsersInfos.GetUser("abc");
            Assert.AreEqual(true, getuser.Name == "User1");
            Assert.AreEqual(true, getuser.UID == "abc");

            var getuser2 = UsersInfos.GetUser("abC");
            Assert.AreEqual(true, getuser2 == null);
        }

        [TestMethod()]
        public void SearchUserTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            var getuser = UsersInfos.SearchUser("User1");
            Assert.AreEqual(true, getuser[0].Name == "User1");
            Assert.AreEqual(true, getuser[0].UID == "abc");
        }

        [TestMethod()]
        public void GetRankOfUserTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));
            Assert.AreEqual(true, UsersInfos.GetRankOfUser("abc") == Rank.Viewer);
            Assert.AreEqual(true, UsersInfos.GetRankOfUser("abC") == Rank.Viewer);//TODO: add some test for other rank
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(@"users.xml");
        }

        [TestMethod()]
        public void SetRankOfUserTest()
        {
            //59fdab60bac3fb5c3bdf9e8cb772e637
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            UsersInfos.SetRankOfUser("abc", Rank.Creator);
            Assert.AreEqual("59fdab60bac3fb5c3bdf9e8cb772e637", Function.GetMD5(@"users.xml"));
        }
    }
}