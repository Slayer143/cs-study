using System.Net;
using Telegram.Bot;
using Reminder.Sender.Core;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        private TelegramBotClient _botClient;

        public TelegramReminderSender(string token, IWebProxy proxy)
        {
            _botClient = new TelegramBotClient(token, proxy);
        }

        public void Send(string contactId, string message)
        {
            var chatId = new global::Telegram.Bot.Types.ChatId(
                long.Parse(contactId));

            _botClient.SendTextMessageAsync(chatId, message);
        }
    }
}