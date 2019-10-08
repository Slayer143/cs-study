using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory.Test
{
    [TestClass]
    public class InMemoryReminderStorageTest
    {
        [TestMethod]
        public void Method_Add_Should_Add_New_Item_To_Internal_Dictionary()
        {
            // prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
            const string contactId = "ABCD123",
                testMessage = "test message";

            var item = new ReminderItem(
                date,
                testMessage,
                contactId
                );
            var storage = new InMemoryReminderStorage();

            // do test
            storage.Add(item);

            // check results
            Assert.IsTrue(storage.Reminders.ContainsKey(item.Id));
            Assert.AreEqual(testMessage, storage.Reminders[item.Id].Message);
            Assert.AreEqual(contactId, storage.Reminders[item.Id].ContactId);
            Assert.AreEqual(date, storage.Reminders[item.Id].Date);
        }

        [TestMethod]
        public void Method_Get_Should_Get_New_Item_From_Internal_Dictionary()
        {
            // prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
            const string contactId = "ABCD123",
                testMessage = "test message";

            var item = new ReminderItem(
                date,
                testMessage,
                contactId
                );
            var storage = new InMemoryReminderStorage();

            // do test
            storage.Add(item);
            var testGet = storage.Get(item.Id);

            // check results
            Assert.IsTrue(storage.Reminders.ContainsKey(testGet.Id));
            Assert.AreEqual(testMessage, testGet.Message);
            Assert.AreEqual(contactId, testGet.ContactId);
            Assert.AreEqual(date, testGet.Date);
        }

        [TestMethod]
        public void Method_Get_Should_Get_Null_From_Internal_Dictionary_If_Not_Found()
        {
            // prepare data
            var storage = new InMemoryReminderStorage();

            // do test
            var testGet = storage.Get(Guid.NewGuid());

            // check results
            Assert.IsNull(testGet);
        }

        [TestMethod]
        public void Method_Get_Should_Get_New_Items_In_List_From_Internal_Dictionary()
        {
            // prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
            const string contactId = "ABCD123",
                testMessage = "test message";

            var item = new ReminderItem(
                date,
                testMessage,
                contactId
                );

            var item1 = new ReminderItem(
                date,
                testMessage,
                contactId
                );
            var storage = new InMemoryReminderStorage();

            // do test
            storage.Add(item);
            storage.Add(item1);

            List<ReminderItem> items = new List<ReminderItem>();
            items = storage.Get(ReminderItemStatus.Awaiting);

            // check results
            foreach (var oneItem in items)
            {
                Assert.IsTrue(storage.Reminders.ContainsKey(oneItem.Id));
                Assert.AreEqual(testMessage, oneItem.Message);
                Assert.AreEqual(contactId, oneItem.ContactId);
                Assert.AreEqual(date, oneItem.Date);
            }
        }

        [TestMethod]
        public void Method_Get_Should_Get_Null_Items_In_List_From_Internal_Dictionary()
        {
            // prepare data
            var storage = new InMemoryReminderStorage();

            // do test
            var testGet = storage.Get(ReminderItemStatus.Awaiting);

            // check results
            Assert.IsFalse(testGet.Count != 0);
        }

        [TestMethod]
        public void Method_Get_Should_Update_New_Item_In_Internal_Dictionary()
        {
            // prepare data
            DateTimeOffset date = DateTimeOffset.Parse("2019-01-01T00:00:00+00:00");
            const string contactId = "ABCD123",
                testMessage = "test message";

            var item = new ReminderItem(
                date,
                testMessage,
                contactId
                );
            var storage = new InMemoryReminderStorage();

            // do test
            storage.Add(item);
            storage.Update(item.Id, ReminderItemStatus.Ready);

            // check results
            Assert.IsTrue(storage.Reminders.ContainsKey(item.Id));
            Assert.AreEqual(ReminderItemStatus.Ready, item.Status);
        }

        [TestMethod]
        public void Method_Get_Should_Return_Null_If_Item_Does_Not_Exist_In_Internal_Dictionary()
        {
            // prepare data
            var doesNotExist = Guid.NewGuid();
            var storage = new InMemoryReminderStorage();

            // do test
            storage.Update(doesNotExist, ReminderItemStatus.Ready);

            // check results
            Assert.IsFalse(storage.Reminders.ContainsKey(doesNotExist));
        }
    }
}
