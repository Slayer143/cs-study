using System;
using Reminder.Reciever.Telegram;

namespace Reminder.Reciever.Core
{
    public interface IReminderReciever
    {
        void Run();

        event EventHandler<MessageRecievedEventArgs> MessageRecieved;
    }
}
