using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.Models
{
    public class SendingSucceededEventArgs : EventArgs
    {
        public ReminderItem SendingItem { get; set; }

    }
}