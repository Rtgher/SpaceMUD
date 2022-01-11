using MUS.Common.Commands.Base;
using MUS.Entities.Network;
using MUS.Server.Server.Connection.Events;
using System;

namespace MUS.Server.Base.Interface.Connection
{
    /// <summary>
    /// Server-side object wrapping the client connection.
    /// </summary>
    public interface IConnection
    {
        bool IsRunning { get; set; }
        void OnConnect(string message);
        void OnDisconnect(string message);
        void Disconnect();
        void PrepareUpdate(string message);
        void Update();
        ICommand ExecutingCommand { get; set; }
        bool IsExecutingACommand { get; }
        Account Account { get; set; }
        event EventHandler<MessageReceivedArgs> MessageReceived;
    }
}
