using SpaceMUD.Entities.Network;
using SpaceMUD.Server.Connection.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Server.ActionHandler;
using SpaceMUD.Common.Commands.Base;

namespace SpaceMUD.Server.Base.Interface.Connection
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
        Account Account { get; set; }
        event EventHandler<MessageReceivedArgs> MessageReceived;
    }
}
