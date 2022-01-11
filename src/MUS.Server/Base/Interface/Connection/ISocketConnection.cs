using System;
using System.Net.Sockets;

namespace MUS.Server.Base.Interface.Connection
{
    public interface ISocketConnection : IConnection, IDisposable
    {
        Socket ClientSocket { get; }

    }
}
