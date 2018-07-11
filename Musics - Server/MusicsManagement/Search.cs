using System;

namespace Musics___Server.MusicsManagement
{
    class Search
    {
        public static bool Find(string s, string t)
        {
            s = s.ToLower();
            t = t.ToLower();

            if (t.Contains(s))
            {
                return true;
            }
            return false;
        }
    }

}
