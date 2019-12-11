using Newtonsoft.Json;
using Reminder.Storage.Core;
using Reminder.Storage.SqlServer.ADO;
using System;

namespace Reminder.Storage.SqlServer.ADO.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new SqlReminderStorage(
                @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Reminder;Integrated Security=true;");

            // Test Add
            Guid id = storage.Add(
                DateTimeOffset.Now.AddMinutes(1),
                "Test message",
                "012345",
                ReminderItemStatus.Failed);

            Console.WriteLine(id);

            // Test Get(id)
            var reminderItem = storage.Get(id);

            Console.WriteLine(
                JsonConvert.SerializeObject(reminderItem));

            // Test Get(status)

            storage.Add(
                DateTimeOffset.Now.AddMinutes(1),
                "Test message 2",
                "543210",
                ReminderItemStatus.Failed);

            var list = storage.Get(ReminderItemStatus.Failed);
            Console.WriteLine(list.Count);

            list = storage.Get(ReminderItemStatus.Ready);
            Console.WriteLine(list.Count); // check for null reference exception

            // Test Update

            storage.Update(id, ReminderItemStatus.Sent);

            reminderItem = storage.Get(id);

            Console.WriteLine(
                JsonConvert.SerializeObject(reminderItem));

            Console.ReadKey();

        }
    }
}

