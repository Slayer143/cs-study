using System;
using System.Collections.Generic;
using System.Text;

namespace homework_12
{
    class PhoneReminderItem : ReminderItem
    {
        public string PhoneNumber { get; set; }

        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage, string phoneNumber)
            : base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }

        public override string AlarmInfo
        {
            get
            {
                return base.AlarmInfo +
                    $"Phone number: {PhoneNumber}\n";
            }
        }
    }
}
