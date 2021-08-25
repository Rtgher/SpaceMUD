using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SpaceMUD.Server.Base.Interface.Connection;

namespace SpaceMUD.Server.Connection
{
    public class SocketConnectionHandler : ISocketConnection, IDisposable
    {
        Socket ISocketConnection.ClientSocket => throw new NotImplementedException();

        IConnection IConnection.Disconnect()
        {
            throw new NotImplementedException();
        }

        IConnection IConnection.OnConnect()
        {
            throw new NotImplementedException();
        }

        IConnection IConnection.OnDisconnect()
        {
            throw new NotImplementedException();
        }

        IConnection IConnection.OnUpdate()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
