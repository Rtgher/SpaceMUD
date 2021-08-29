using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Common.Exceptions.Server;
using SpaceMUD.Server.Base.Interface;

namespace SpaceMUD.Server.Connection
{
    public class SocketConnectionHandler : ISocketConnection, IDisposable
    {
        public Socket ClientSocket { get; private set; }
        public bool IsRunning {
            get => _isRunning;
            set {
                if (_isRunning == true)
                {
                    if (value == false) throw new ServerFlowException("Something tried to terminate a socket connection incorrectly. Correct way is through Disconnect()");
                }
                    _isRunning = value; }
        }
        private bool _isRunning;
        private readonly IServer Server;
        
        public SocketConnectionHandler(Socket socket, IServer server)
        {
            ClientSocket = socket;
            Server = server;
        }

        void IConnection.Disconnect()
        {
            throw new NotImplementedException();
        }

        void IConnection.OnConnect(string message)
        {
            throw new NotImplementedException();
        }

        void IConnection.OnDisconnect(string message)
        {
            throw new NotImplementedException();
        }

        void IConnection.OnUpdate(string message)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
