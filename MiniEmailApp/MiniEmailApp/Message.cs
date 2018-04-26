using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEmailApp
{
    public class Message
    {
        private int messageID;
        private string sender_Username;
        private string receiver_Username;
        private string message_Data;
        private bool isread;
        private DateTime datetime;

        public Message(int messageID, string sender_Username, string receiver_Username, string message_Data, bool isread, DateTime datetime)
        {
            MessageID = messageID;
            Sender_Username = sender_Username;
            Receiver_Username = receiver_Username;
            Message_Data = message_Data;
            Isread = isread;
            Datetime = datetime;
        }

        public int MessageID { get => messageID; set => messageID = value; }
        public string Sender_Username { get => sender_Username; set => sender_Username = value; }
        public string Receiver_Username { get => receiver_Username; set => receiver_Username = value; }
        public string Message_Data { get => message_Data; set => message_Data = value; }
        public bool Isread { get => isread; set => isread = value; }
        public DateTime Datetime { get => datetime; set => datetime = value; }

        
    }
}
