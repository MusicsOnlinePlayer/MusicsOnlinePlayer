using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public static class Hash
    {
        public static string SHA256Hash(string value)
        {
            using (var hash = SHA256.Create())
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
