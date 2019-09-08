using System;
using System.Collections.Generic;
using System.Text;

namespace homework_12
{
    class ChatReminderItem : ReminderItem
    {
        public string ChatName { get; set; }
        public string AccountName { get; set; }

        public ChatReminderItem(DateTimeOffset alarmDate, string alarmMessage, string chatName, string accountName)
            : base(alarmDate, alarmMessage)
        {
            ChatName = chatName;
            AccountName = accountName;
        }

        public override string AlarmInfo
        {
            get
            {
                return base.AlarmInfo +
                    $"Chat name: {ChatName}\n" +
                    $"Account name: {AccountName}\n";
            }
        }

    }
}
