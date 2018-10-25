using System;
using Utility.Musics;

namespace Utility.Network.Users
{
    [Serializable]
    public class User : CryptedCredentials
    {

        public Rank Rank { get; set; }

        public string Name => Login;

        public User(ICredentials credential)
            : base(credential)
        {

        }
        public User()
            : this(new UserCredentials("", "")) { }

        public User(string name)
            : this(new UserCredentials(name, ""))
        {
        }
        public User(CryptedCredentials cryptedCredential)
            : base(cryptedCredential)
        {
        }



    }


    public interface ICredentials : ICredentialValidator
    {
        string Login { get; }
        string Password { get; }
    }

    public interface ICredentialValidator
    {
        bool IsValidCredential { get; }
    }

    public class UserCredentials : ICredentials
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool IsValidCredential => IsValidLogin && IsValidPassword;


        private bool IsValidLogin => Login.Trim().Length != 0;
        private bool IsValidPassword => Password.Trim().Length != 0;


    }
    [Serializable]
    public class CryptedCredentials
    {
        protected string Login { get; }
        public string UID { get; set; }

        public CryptedCredentials(string login, string uid)
        {
            Login = login;
            UID = uid;
        }

        protected CryptedCredentials(CryptedCredentials copy)
        {
            Login = copy.Login;
            UID = copy.UID;
        }

        protected CryptedCredentials(ICredentials credentials)
        {
            Login = credentials.Login;
            UID = GenerateUID(credentials);
        }
        protected virtual string GenerateUID(ICredentials credentials)
            => Hash.SHA256Hash(credentials.Login + credentials.Password);
    }

    public abstract class UserUidCredentials : CryptedCredentials
    {

        protected UserUidCredentials(ICredentials credentials)
            : base(credentials)
        {
        }


    }
}
