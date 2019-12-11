using System;

namespace Reminder.Receiever.Core
{
    public interface IReminderReceiever
    {
        void Run();

        event EventHandler<MessageReceivedEventArgs> MessageRecieved;
    }
}
