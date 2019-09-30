using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;

namespace Reminder.Storage.InMemory.Test
{
    [TestClass]
    public class InMemoryReminderStorageTest
    {
        [TestMethod]
        public void Method_Should_Add_Object_Correctly()
        {
            var dictionary = new InMemoryReminderStorage();

            var reminder = new ReminderItem(
                DateTimeOffset.Parse("2010-01-01T00:00:00"),
                "testMessage",
                 "0123ABC");

            dictionary.Add(reminder);

            Assert.IsNotNull(dictionary);
            Assert.AreEqual(reminder, dictionary);
        }

        [TestMethod]
        public void Method_Should_Get_Object_Correctly()
        {
            var dictionary = new InMemoryReminderStorage();

            var reminder = new ReminderItem(
                DateTimeOffset.Parse("2010-01-01T00:00:00"),
                "testMessage",
                 "0123ABC");

            dictionary.Add(reminder);
            dictionary.Get(reminder.Id);

            Assert.IsNotNull(dictionary.Get(reminder.Id));
            Assert.IsNotNull(dictionary);
        }
        [TestMethod]
        public void Method_Should_Get_Object_By_Status_Correctly()
        {
            var dictionary = new InMemoryReminderStorage();

            var reminder = new ReminderItem(
                DateTimeOffset.Parse("2010-01-01T00:00:00"),
                "testMessage",
                 "0123ABC");

            dictionary.Add(reminder);

            Assert.IsNotNull(dictionary.Get(ReminderItemStatus.Awaiting));
            Assert.IsNull(dictionary.Get(ReminderItemStatus.Failed));
        }
        [TestMethod]
        public void Method_Should_Update_Object_Correctly()
        {
            var dictionary = new InMemoryReminderStorage();

            var reminder = new ReminderItem(
                DateTimeOffset.Parse("2010-01-01T00:00:00"),
                "testMessage",
                 "0123ABC");

            dictionary.Add(reminder);
            dictionary.Update(reminder.Id, ReminderItemStatus.Ready);

            Assert.AreNotEqual(reminder, dictionary);
        }
    }
}
