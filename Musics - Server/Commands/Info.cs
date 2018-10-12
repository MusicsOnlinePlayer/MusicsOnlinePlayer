using System;
using System.IO;

namespace Musics___Server.Commands
{
    static class Info
    {
        public static string LogPath;

        public static void CreateLog()
        {
            LogPath = "Log"+ DateTime.Now.ToString("HHmmss")+".txt";
            File.Create(LogPath).Dispose();
        }

        public static void Say(string message,MsgType type,bool LogInFile = true)
        {
            string LogLine = "[" + type.ToString().ToUpper() + " - " + DateTime.Now.ToString("HH:mm:ss") + "] " + message;
            Console.WriteLine(LogLine);
            if (LogInFile)
            {
                SaveLogLine(LogLine);
            }
        }

        public static void SaveLogLine(string LogLine)
        {
            if (!File.Exists(LogPath))
            {
                CreateLog();
            }
            File.AppendAllText(LogPath, LogLine + Environment.NewLine);
        }
    }

    enum MsgType
    {
        Alert,
        Important,
        Info,
        Debug
    }
}
