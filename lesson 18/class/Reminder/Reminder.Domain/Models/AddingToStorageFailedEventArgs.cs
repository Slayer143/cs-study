using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.Models
{
    public class AddingToStorageFailedEventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }

        public Exception AddingException { get; set; }

    }
}
