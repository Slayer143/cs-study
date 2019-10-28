using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.Models
{
    public class AddingToStorageSucceddedEventArgs
    {
        public string Message { get; set; }

        public string ContactId { get; set; }
    }
}
