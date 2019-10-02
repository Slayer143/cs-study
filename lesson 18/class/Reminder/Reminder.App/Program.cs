using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Parser;
using Reminder.Reciever.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Telegram Bot Application!");

            var storage = new InMemoryReminderStorage();
            var domain = new ReminderDomain(storage);

            IWebProxy proxy = new HttpToSocks5Proxy(
                "proxy.golyakov.net", 
                1080);
            string token = "979765455:AAE5XgfCXVA3C7LfRWF_VWy1NcCp28Z9R4I";

            var sender = new TelegramReminderSender(token, proxy);
            var reciever = new TelegramReminderReciever(token, proxy);

            reciever.MessageRecieved += (s, e) =>
            {
                Console.WriteLine($"Message from contact ID {e.ContactId} with text '{e.Message}' recieved");

                // add new ReminderItem to the storage
                try
                {
                    var parsedMessage = MessageParser.Parse(e.Message);
                    var item = new ReminderItem(
                    parsedMessage.Date,
                    parsedMessage.Message,
                    e.ContactId);

                    storage.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wrong message format!\n {ex.Message}");
                }               
            };

            reciever.Run();

            domain.SendReminder = (ReminderItem ri) =>
                sender.Send(ri.ContactId, ri.Message);

            domain.Run();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
