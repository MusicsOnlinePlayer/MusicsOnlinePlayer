using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musics___Server.Authentification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Network;

namespace Musics___Server.Authentification.Tests
{
    [TestClass()]
    public class AuthentificationServiceTests
    {
        [TestMethod()]
        public void SignupUserTest()
        {
            //e0c5d6856147fbaf2888fc1720e9f7c8
            AuthentificationService a = new AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));

            Assert.AreEqual("e0c5d6856147fbaf2888fc1720e9f7c8", Function.GetMD5(@"users.xml"));
            File.Delete(@"users.xml");
        }

        [TestMethod()]
        public void EditUserTest()
        {
            //06a0f0fcffbf4f74aac1dc5b22afb9b7
            AuthentificationService a = new AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));
            a.EditUser("abc", new Utility.Network.Users.User(new Utility.Network.Users.CryptedCredentials("User2", "abd")));
            Assert.AreEqual("06a0f0fcffbf4f74aac1dc5b22afb9b7", Function.GetMD5(@"users.xml"));
            File.Delete(@"users.xml");
        }

        [TestMethod()]
        public void SetupAuthTest()
        {
            //2401b58e19ceab051ae3d9c1fda093f2
            AuthentificationService a = new AuthentificationService();
            a.SetupAuth();
            Assert.AreEqual("2401b58e19ceab051ae3d9c1fda093f2", Function.GetMD5(@"users.xml"));
            File.Delete(@"users.xml");
        }

        [TestMethod()]
        public void UserIDExistTest()
        {
            AuthentificationService a = new AuthentificationService();
            a.SetupAuth();
            a.SignupUser(new Utility.Network.Users.CryptedCredentials("User1", "abc"));
            Assert.AreEqual(true, a.UserIDExist("abc"));
            Assert.AreEqual(false, a.UserIDExist("abC"));
            File.Delete(@"users.xml");
        }
    }
}