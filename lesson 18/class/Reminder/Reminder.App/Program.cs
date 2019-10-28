using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Parser;
using Reminder.Reciever.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain.Models;
using MessageRecievedEventArgs = Reminder.Domain.Models.MessageRecievedEventArgs;


namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Telegram Bot Application!");

            var storage = new InMemoryReminderStorage();

            IWebProxy proxy = new HttpToSocks5Proxy(
                "proxy.golyakov.net", 
                1080);

            string token = "979765455:AAE5XgfCXVA3C7LfRWF_VWy1NcCp28Z9R4I";

            var reciever = new TelegramReminderReciever(token, proxy);

            var domain = new ReminderDomain(storage, reciever);
            var sender = new TelegramReminderSender(token, proxy);

            domain.SendReminder = (ReminderItem ri) =>
            {
                sender.Send(ri.ContactId, ri.Message);
            };

            domain.MessageRecieved += Domain_MessageRecieved;
            domain.MessageParsingSuccedded += Domain_MessageParsingSuccedded;
            domain.MessageParsingFailed += Domain_MessageParsingFailed;
            domain.AddingToStorageSucceeded += Domain_AddingToStorageSucceeded;
            domain.AddingToStorageFailed += Domain_AddingToStorageFailed;

            domain.Run();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Domain_AddingToStorageFailed(object sender, AddingToStorageFailedEventArgs e)
        {
            Console.WriteLine($"Message from contact ID = {e.ContactId} parsing failed. Text \"{e.Message}\"");
        }

        private static void Domain_AddingToStorageSucceeded(object sender, AddingToStorageSucceddedEventArgs e)
        {
            Console.WriteLine($"Item from contact Id = {e.ContactId} successfully parsed. Text = \"{e.Message}\"");
        }

        private static void Domain_MessageParsingFailed(object sender, MessageParsingFailedEventArgs e)
        {
            Console.WriteLine(
                $"Message from contact ID = {e.ContactId} parsing failed. Text = \"{e.Message}\"");
        }

        private static void Domain_MessageParsingSuccedded(object sender, MessageParsingSucceddedEventArgs e)
        {
            Console.WriteLine(
                $"Message from contact ID = {e.ContactId} successfully parsed. Date = \"{e.Date}\" Text = \"{e.Message}\"");
        }

        private static void Domain_MessageRecieved(object sender, MessageRecievedEventArgs e)
        {
            Console.WriteLine(
                $"Message from contact ID = {e.ContactId} received. Text = \"{e.Message}\"");
        }
    }
}
