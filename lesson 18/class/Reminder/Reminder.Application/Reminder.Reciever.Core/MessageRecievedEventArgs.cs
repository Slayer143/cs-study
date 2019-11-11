using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Reciever.Core
{
    public class MessageRecievedEventArgs
    {
        public string ContactId { get; set; }

        public string Message { get; set; }
    }
}
