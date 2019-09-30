using System;
using System.Collections.Generic;
using System.Text;

namespace home_13
{
    class FileLogWriter : ILogWriter
    {
        public void LogError(string message)
        {
            Console.WriteLine($"YYYY-MM-DDTHH:MM:SS+0000    Error   {message}");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"YYYY-MM-DDTHH:MM:SS+0000    Info   {message}");
        }

        public void LogMessage(string message)
        {
            Console.WriteLine($"YYYY-MM-DDTHH:MM:SS+0000    Message     {message}");
        }
    }
}
