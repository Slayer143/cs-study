using System;
using System.Net;
using MihaZupan;
using Reminder.Domain;
using Reminder.Parser;
using Reminder.Reciever.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Core;
using Reminder.Domain.Models;
using MessageRecievedEventArgs = Reminder.Domain.Models.MessageRecievedEventArgs;
using ColorChanging = Reminder.Domain.Models.ColorChanging;
using Reminder.Storage.WebApi.Client;


namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Telegram Bot Application!");

            var storage = new ReminderStorageWebApiClient(
				"http://localhost:5000/api/reminders");

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
			var colorChanger = new ColorChanging();

			colorChanger.WriteRed(
				$"for time = {e.Date}" +
				$"sent by user = {e.ContactId}" +
				$"with message = {e.Message}" +
				$"in status = {e.Status} failed adding to the storage" +
				$"with exception = {e.AddingException}.");
		}

        private static void Domain_AddingToStorageSucceeded(object sender, AddingToStorageSucceddedEventArgs e)
        {
			var colorChanger = new ColorChanging();

			colorChanger.WriteGreen(
				$"Item Id = {e.Id}" +
				$"for time = {e.Date}" +
				$"sent by user = {e.ContactId}" +
				$"with message = {e.Message}" +
				$"in status = {e.Status} successfully added to the storage.");
		}

        private static void Domain_MessageParsingFailed(object sender, MessageParsingFailedEventArgs e)
        {
			var colorChanger = new ColorChanging();

			colorChanger.WriteRed(
				$"Sent by user = {e.ContactId}" +
				$"with message = {e.Message}" +
				$"in status = {e.ParsingException} failed parsing.");
        }

        private static void Domain_MessageParsingSuccedded(object sender, MessageParsingSucceddedEventArgs e)
        {
			var colorChanger = new ColorChanging();

			colorChanger.WriteGreen(
				$"Sent by user = {e.ContactId}" +
				$"for time = {e.Date}" +
				$"with message = {e.Message} succedded parsing.");
        }

        private static void Domain_MessageRecieved(object sender, MessageRecievedEventArgs e)
        {
			var colorChanger = new ColorChanging();

			colorChanger.WriteOrchid(
				$"Sent by user = {e.ContactId}" +
				$"with message = {e.Message} recieved.");
        }
    }
}
