using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Network
{
    [Serializable]
    public class Token : TokenGenerator
    {
       public bool IsExpired { get; set; }

       public Token(string UserUID)
       {
            Generate(UserUID);
       }
    }

    [Serializable]
    public class TokenGenerator
    {
        public string THash { get; set; }

        public void Generate(string UserUID)
        {
            THash = Hash.SHA256Hash(UserUID + (new Random()).Next());
        }
    }
}
