using System;
using System.Drawing;

namespace Utility.Musics
{
    [Serializable]
    public abstract class Element : IElement
    {
        public ElementType Type { get; set; }
        public string MID { get; set; }
        public byte[] Image { get; set; }
        public abstract string Name { get; set; }

        protected abstract string KeyToHash();
        protected string GenerateHash() => Hash.SHA256Hash(KeyToHash());
    }
}
