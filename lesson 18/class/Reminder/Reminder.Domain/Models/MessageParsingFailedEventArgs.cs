using System;

namespace Reminder.Domain.Models
{
    public class MessageParsingFailedEventArgs : EventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }

        public Exception ParsingException { get; set; }
    }
}
