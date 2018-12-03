using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Musics.Tags
{
    public class Tag
    {
        public Tag(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Color Color { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
