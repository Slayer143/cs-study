using System;

namespace Reminder.Domain.Models
{
    public class MessageParsingSucceddedEventArgs : EventArgs
    {
        public string ContactId { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }
    }
}