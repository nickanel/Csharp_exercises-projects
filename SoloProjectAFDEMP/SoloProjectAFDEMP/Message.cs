using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloProjectAFDEMP
{
    public  class Message
    {
        private int _messageid;
        private int _senderid;
        private int _receiverid;
        private DateTime _creationtime;
        private string _messagedata;

        public int Messageid { get => _messageid; set => _messageid = value; }        
        public string Messagedata { get => _messagedata; set => _messagedata = value; }
        public int Senderid { get => _senderid; set => _senderid = value; }
        public int Receiverid { get => _receiverid; set => _receiverid = value; }
        public DateTime Creationtime { get => _creationtime; set => _creationtime = value; }

        public Message() { }
        public Message(int messageid,int senderid,int receiverid,string messagedata)
        {
            Messageid = messageid;
            Senderid = senderid;
            Receiverid = receiverid;
            Messagedata = messagedata;
            Creationtime = DateTime.Now;

        }
    }
}
