using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Common.Exceptions.Server;

namespace SpaceMUD.Server.Connection
{
    public class SocketConnectionHandler : ISocketConnection, IDisposable
    {
        public Socket ClientSocket { get; private set; }
        public bool IsRunning {
            get => _isRunning;
            set {
                if (_isRunning = true)
                {
                    if (value == false) throw new ServerFlowException("Something tried to terminate a socket connection incorrectly. Correct way is through Disconnect()");
                }
                    _isRunning = value; }
        }
        private bool _isRunning;
        public SocketConnectionHandler(Socket socket)
        {
            ClientSocket = socket;
            Thread onConnectThread = new Thread(((IConnection) this).OnConnect);
            onConnectThread.Start();
        }

        void IConnection.Disconnect()
        {
            throw new NotImplementedException();
        }

        void IConnection.OnConnect()
        {
            throw new NotImplementedException();
        }

        void IConnection.OnDisconnect()
        {
            throw new NotImplementedException();
        }

        void IConnection.OnUpdate()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
