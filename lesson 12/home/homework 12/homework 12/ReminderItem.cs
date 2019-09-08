using System;
using System.Collections.Generic;
using System.Text;

namespace homework_12
{
    class ReminderItem
    {
        public DateTimeOffset _alarmDate;
        public string _alarmMessage;

        public DateTimeOffset AlarmDate
        {
            get { return _alarmDate; }
            set
            {
                _alarmDate = value;
            }
        }
        public string AlarmMessage
        {
            get { return _alarmMessage; }
            set
            {
                _alarmMessage = value;
            }
        }
        public TimeSpan TimeToAlarm
        {
            get
            {
                return AlarmDate - DateTimeOffset.Now;
            }
        }
        public bool IsOutdated
        {
            get
            {
                return AlarmDate < DateTimeOffset.Now;
            }
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public ReminderItem() { }

        public virtual string AlarmInfo
        {
            get
            {
                return $"Alarm date: {_alarmDate}\n" +
                     $"Alarm message: {_alarmMessage}\n" +
                     $"Time to alarm: {TimeToAlarm}\n" +
                     $"Outdated: {(IsOutdated ? "Yes" : "No")}\n";
            }
        }

        public void WriteOutAlarmInfo()
        {
            Console.WriteLine(AlarmInfo);
        }
    }
}
