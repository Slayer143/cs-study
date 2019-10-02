using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Reciever.Telegram
{
    public class MessageRecievedEventArgs : EventArgs
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
    }
}
