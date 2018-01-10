using System;
using System.Collections.Generic;
using System.Text;

namespace ReefTankCore.Models.System.Notifications
{
    public class MessageViewModel
    {
        public static string Name = "Message";

        public string Message { get; set; }
        public MessageType Type { get; set; }

        public MessageViewModel(string message, MessageType type)
        {
            Message = message;
            Type = type;
        }

        public MessageViewModel()
        {
            Message = string.Empty;
            Type = MessageType.Success;
        }
    }
}
