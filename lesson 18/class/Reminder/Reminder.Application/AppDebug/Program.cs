using System;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;

namespace AppDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageClient = new ReminderStorageWebApiClient(
                "http://localhost:5000/api/reminders");

            // check that data storage returns empty list
            var emptyList = storageClient.Get(ReminderItemStatus.Awaiting);
            if (emptyList == null || emptyList.Count > 0)
                throw new Exception();

            // add reminder to the storage
            var id = storageClient.Add(
                    DateTimeOffset.Now.AddMinutes(1),
                    "test message",
                    "1432025143",
                    ReminderItemStatus.Awaiting);

            // check that reminder that was added and can be returned by id
            var item = storageClient.Get(id);
            if(item == null)
                throw new Exception();

            // check that reminder that was added and can be returned by status
            var awaitingList = storageClient.Get(ReminderItemStatus.Awaiting);
            if (awaitingList.Count != 1 || awaitingList == null)
                throw new Exception();

            // check that reminder that was added and can not be returned by wrong status
            var readyList = storageClient.Get(ReminderItemStatus.Ready);
            if (readyList.Count != 0 || readyList == null)
                throw new Exception();

            // update reminder`s status to failed
            storageClient.Update(id, ReminderItemStatus.Failed);

            // check that status is correct
            var failedList = storageClient.Get(ReminderItemStatus.Failed);
            if (failedList.Count != 1 || failedList == null)
                throw new Exception();
        }
    }
}
