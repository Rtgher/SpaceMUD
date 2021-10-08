using SpaceMUD.Entities.Network;
using System;


namespace SpaceMUD.Server.Connection.Events
{
    public class MessageReceivedArgs : EventArgs
    {
        public string Message { get; set; }
        public Byte[] RawData { get; set; }
        public Account Account { get; set; }
    }
}
