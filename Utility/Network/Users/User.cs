using System;
using Utility.Musics;

namespace Utility.Network.Users
{
    [Serializable]
    public class User : UidCredentials
    {
    
        public Rank Rank { get; set; }

        public string Name { get; set; }
        public bool Connected { get; set; }

        public User(ICredentials credential) 
            : base(credential)
        {
            Name = credential.Login;
        }
        public User() 
            : this(new UserCredentials("","")){ }

        public User(string name)
            : this (new UserCredentials(name, ""))
        {
        }
        public User(string name, string UserPassword)
            : this(new UserCredentials(name, UserPassword))

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

        public bool IsValidCredential=> IsValidLogin && IsValidPassword;
        

        private bool IsValidLogin  => Login.Trim().Length != 0;
        private bool IsValidPassword => Password.Trim().Length != 0;


    }
    [Serializable]
    public abstract class UidCredentials
    {
        public string UID { get; set; }

        protected UidCredentials(ICredentials credentials)
        {
            UID = GenerateUID(credentials);
        }
        protected virtual string GenerateUID(ICredentials credentials)
            => Hash.SHA256Hash(credentials.Login + credentials.Password);
    }

    public abstract class UserUidCredentials : UidCredentials
    {

        protected UserUidCredentials(ICredentials credentials)
            : base(credentials)
        {
        }


    }
}
