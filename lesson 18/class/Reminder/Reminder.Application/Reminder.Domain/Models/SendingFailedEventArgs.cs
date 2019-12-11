using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.Models
{
    public class SendingFailedEventArgs : EventArgs
    {
        public ReminderItem SendingItem { get; set; }

        public Exception SendingException;
    }
}