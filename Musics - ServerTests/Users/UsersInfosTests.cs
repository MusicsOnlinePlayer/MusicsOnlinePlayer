using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.Usersinfos;
using System;
using System.IO;
using System.Xml;
using Utility.Network;

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
            File.Delete(@"users.xml");
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
            File.Delete(@"users.xml");
        }

        [TestMethod()]
        public void AddVoteMusicTest()
        {
            Authentification.AuthentificationService a = new Authentification.AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            XmlDocument doc = new XmlDocument();
            doc.Load(@"users.xml");

            UsersInfos.AddVoteMusic("MusicMID", "abC");
            Assert.AreEqual("e0c5d6856147fbaf2888fc1720e9f7c8", Function.GetMD5(@"users.xml"));
            UsersInfos.AddVoteMusic("MusicMID", "abc");
            Assert.AreEqual("3f8c88f5cad87ebbae3ad701842c876e", Function.GetMD5(@"users.xml"));
            UsersInfos.AddVoteMusic("MusicMID", "abc");
            Assert.AreEqual("e0424ec3aad221f0f22836728db397f7", Function.GetMD5(@"users.xml"));
            File.Delete(@"users.xml");
        }
    }
}