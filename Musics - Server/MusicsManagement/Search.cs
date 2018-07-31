using System;

namespace Musics___Server.MusicsManagement
{
    static class Search
    {
        public static bool Find(string s, string t)
        {
            if (t.ToLower().Contains(s.ToLower()))
            {
                return true;
            }
            return false;
        }
    }

}
