using System;

namespace Reminder.Parser
{
    public static class MessageParser
    {
        public static ParsedMessage Parse(string message)
        {
            // 2019-10-02T21:20:00 Congratulations guys!

            int spaceIndex = message.IndexOf(' ');
            return new ParsedMessage
            {
                Date = DateTimeOffset.Parse(message.Substring(0, spaceIndex)),
                Message = message.Substring(spaceIndex + 1)
            };
        }
    }
}
