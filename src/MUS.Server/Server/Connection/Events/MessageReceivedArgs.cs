using MUS.Entities.Network;
using System;


namespace MUS.Server.Server.Connection.Events
{
    public class MessageReceivedArgs : EventArgs
    {
        public string Message { get; set; }
        public byte[] RawData { get; set; }
        public Account Account { get; set; }
    }
}
