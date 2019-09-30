using System;
using System.Collections.Generic;
using System.Text;

namespace home_13
{
    interface ILogWriter
    {
       void LogInfo(string message);

       void LogMessage(string message);

        void LogError(string message);
    }
}
