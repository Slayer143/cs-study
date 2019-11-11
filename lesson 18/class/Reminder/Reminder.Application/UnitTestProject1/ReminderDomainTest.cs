using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System;

namespace Reminder.Domain.Tests
{
    [TestClass]
    public class ReminderDomainTest
    {
        [TestMethod]
        public void Method_Run_Should_Update_Ready_To_Send_Reminders_To_Status_Ready()
        {
            var storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(1)))
            {
                domain.Run();
                System.Threading.Thread.Sleep(200);
            }

            var readyList = storage.Get(ReminderItemStatus.Ready);
            Assert.IsNotNull(readyList);
            Assert.AreEqual(1, readyList.Count);
        }

        [TestMethod]
        public void Method_Run_Should_Call_Failed_Event_When_Sending_Throw_Exception()
        {
            var storage = new InMemoryReminderStorage();
            storage.Add(new ReminderItem(DateTimeOffset.Now, null, null));

            bool failedEventCalled = false;

            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (r) =>
                {
                    throw new Exception("Test Exception");
                };

                domain.SendingFailed += (s, e) =>
                {
                    if(e.SendingException.Message == "Test Exception")
                    failedEventCalled = true;
                };

                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }
           
            Assert.IsTrue(failedEventCalled);
        }

        [TestMethod]
        public void Method_Run_Should_Call_Succeeded_Event_When_Sending_Is_Completed()
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            const string readyMessage = "ready message",
                contactId = "ABCD123";

            var storage = new InMemoryReminderStorage();

            storage.Add(new ReminderItem(
                dateTime,
                readyMessage,
                contactId));

            bool failedEventNotCalled = false;
            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (item) => { };

                domain.SendingSucceeded += (s, e) =>
                {
                    failedEventNotCalled = true;
                };
                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }

            Assert.IsTrue(failedEventNotCalled); 
        }

        [TestMethod]
        public void Method_Run_Should_Call_SendReminder_Method_When_Sending_Is_Completed()
        {
            DateTimeOffset dateTime = DateTimeOffset.Now;
            const string readyMessage = "ready message",
                contactId = "ABCD123";

            var storage = new InMemoryReminderStorage();

            storage.Add(new ReminderItem(
                dateTime,
                readyMessage,
                contactId));

            bool SendReminderMethodCalled = false;
            using (var domain = new ReminderDomain(
                storage,
                TimeSpan.FromMilliseconds(50),
                TimeSpan.FromMilliseconds(60)))
            {
                domain.SendReminder += (ReminderItem reminder) => 
                {
                    if (reminder.Message == readyMessage)
                    {
                        SendReminderMethodCalled = true;
                    }
                };

                domain.Run();
                System.Threading.Thread.Sleep(1200);
            }

            Assert.IsTrue(SendReminderMethodCalled);
        }
    }
}
