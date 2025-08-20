using System;
using System.IO;

namespace LoggingLib
{
    public static class AppLogger
    {
        static readonly string LogDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "CalculatorApp", "logs");
        static readonly string LogFile = Path.Combine(LogDir, "app.log");

        static AppLogger() { Directory.CreateDirectory(LogDir); }

        public static void Info(string message) { Write("INFO", message); }
        public static void Error(string message) { Write("ERROR", message); }

        static void Write(string level, string message)
        {
            File.AppendAllText(LogFile,
                string.Format("{0:yyyy-MM-dd HH:mm:ss} [{1}] {2}{3}",
                    DateTime.Now, level, message, Environment.NewLine));
        }
    }
}
