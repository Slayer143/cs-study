using System;
using System.Net;
using Telegram.Bot;
using Reminder.Receiever.Core;

namespace Reminder.Receiever.Telegram
{
    public class TelegramReminderReciever : IReminderReceiever
    {
        private TelegramBotClient _botClient;

        public event EventHandler<MessageReceivedEventArgs> MessageRecieved;

        public TelegramReminderReciever(string token, IWebProxy proxy)
        {
            _botClient = new TelegramBotClient(token, proxy);
        }

        public void Run()
        {
            _botClient.OnMessage += _botClient_OnMessage;
            _botClient.StartReceiving();
        }

        private void _botClient_OnMessage(object sender, global::Telegram.Bot.Args.MessageEventArgs e)
        {
            //e.Message.Chat.Id
            //e.Message.Text
            if (e.Message.Type != global::Telegram.Bot.Types.Enums.MessageType.Text)
                return;

            MessageRecieved?.Invoke(
                this,
                new MessageReceivedEventArgs
                {
                    ContactId = Convert.ToString(e.Message.Chat.Id),
                    Message = e.Message.Text
                });
        }
    }
}
