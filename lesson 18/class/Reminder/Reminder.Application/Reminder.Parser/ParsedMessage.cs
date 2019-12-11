using System;

namespace Reminder.Parser
{
    public class ParsedMessage
    {
        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }
    }
}
