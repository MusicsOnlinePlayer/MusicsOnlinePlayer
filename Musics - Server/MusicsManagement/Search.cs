using System;

namespace Musics___Server.MusicsManagement
{
    static class Search
    {
        public static bool Find(string s, string t)
        {
            string[] st = s.Split(' ');
            string[] tt = t.Split(' ');

            int i =0;

            foreach(var c in st)
            {
                foreach (var cs in tt)
                {
                    if(cs.ToLower() == c.ToLower())
                    {
                        i++;
                    }
                }
            }
            if(i >= st.Length)
            {
                return true;
            }
            return false;
        }
    }

}

