using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTest
    {
        [TestMethod]
        public void Constructor_Parameters_Should_Fill_Properties_Correctly()
        {
            // prepare test data
            DateTimeOffset date = DateTimeOffset.Parse("2010-01-01T00:00:00");
            const string contactId = "0123ABC",
                message = "testMessage";

            // do test
            var reminderItem = new ReminderItem(
                date,
                message,
                contactId);

            // check result
            Assert.IsNotNull(reminderItem);
            Assert.AreEqual(date, reminderItem.Date);
            Assert.AreEqual(message, reminderItem.Message);
            Assert.AreEqual(contactId, reminderItem.ContactId);
        }

    }
}
