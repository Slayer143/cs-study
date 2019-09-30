using Reminder.Storage.Core;
using System;
using System.Threading;
using Reminder.Domain.Models;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        private IReminderStorage _storage;

        private TimeSpan _awaitingRemindersCheckingPeriod;

        private TimeSpan _readyRemindersSendingPeriod;

        private Timer _awaitingRemindersCheckingTimer;

        private Timer _readyRemindersCheckingTimer;

        public Action<ReminderItem> SendReminder { get; set; }

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;

        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public ReminderDomain(
            IReminderStorage storage,
            TimeSpan awaitingRemindersCheckingPeriod,
            TimeSpan readyRemindersSendingPeriod)
        {
            storage = _storage;
            _awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
            _readyRemindersSendingPeriod = readyRemindersSendingPeriod;
        }

        public ReminderDomain(IReminderStorage storage)
            : this(storage, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
        {
        }

        public void Run()
        {
            _awaitingRemindersCheckingTimer = new Timer(
                CheckAwaitingReminders,
                null,
                TimeSpan.Zero,
                _awaitingRemindersCheckingPeriod);

            _readyRemindersCheckingTimer = new Timer(
                SendReadyReminders,
                null,
                TimeSpan.FromSeconds(1),
                _readyRemindersSendingPeriod);
        }

        private void CheckAwaitingReminders(object state)
        {
            // here will check storage for awaiting items 
            // check each for it`s date
            // if it is time to send, change the status to ready

            var awaitingReminders = _storage.Get(ReminderItemStatus.Awaiting);

            foreach (var awaitingReminder in awaitingReminders)
            {
                if (awaitingReminder.IsReadyToSend)
                    _storage.Update(awaitingReminder.Id, ReminderItemStatus.Ready);
            }
        }

        private void SendReadyReminders(object state)
        {
            // find ready reminders
            // try "send"
            // if success update status to Sent
            // else update statud to Failed
            var readyReminders = _storage.Get(ReminderItemStatus.Ready);

            foreach (var readyReminder in readyReminders)
            {
                try
                {
                    // try "send"
                    SendReminder(readyReminder);

                    // update status to Sent
                    _storage.Update(readyReminder.Id, ReminderItemStatus.Sent);

                    SendingSucceeded?.Invoke(
                        this,
                        new SendingSucceededEventArgs
                        {
                            SendingItem = readyReminder
                        });
                }
                catch (Exception e)
                {
                    // update status to Failed
                    _storage.Update(readyReminder.Id, ReminderItemStatus.Failed);

                    SendingFailed?.Invoke(
                        this,
                        new SendingFailedEventArgs
                        {
                            SendingItem = readyReminder,
                            SendingException = e
                        });
                }
            }
        }

        public void Dispose()
        {
            _awaitingRemindersCheckingTimer?.Dispose();
            _readyRemindersCheckingTimer?.Dispose();
        }
    }
}
