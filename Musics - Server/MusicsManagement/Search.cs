namespace Musics___Server.MusicsManagement
{
    static class Search
    {
        public static bool Find(string s, string t)
        {
            string[] st = s.Split(' ','.','\'');
            string[] tt = t.Split(' ','.','\'');

            int i = 0;

            foreach(var c in st)
            {
                foreach (var cs in tt)
                {
                    if(cs.ToLower().Contains(c.ToLower()))
                    {
                        i++;
                    }
                }
            }

            return i >= st.Length;
        }
    }

}

