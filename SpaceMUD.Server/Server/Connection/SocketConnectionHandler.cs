using System;
using System.Net.Sockets;
using System.Text;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Common.Exceptions.Server;
using SpaceMUD.Server.Base.Interface;
using SpaceMUD.Entities.Network;
using SpaceMUD.Server.Connection.Events;

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
                    if (value == false)
                        throw new ServerFlowException("Something tried to terminate a socket connection incorrectly. " +
                            "Correct way is through Disconnect()");
                }
                _isRunning = value; }
        }

        public Account Account { get; set; } = null;
        public event EventHandler<MessageReceivedArgs> MessageReceived;

        private bool _isRunning;
        private readonly IServer Server;
        private const int RECEIVE_BUFFER_SIZE = 512;
        private Byte[] receiveStream = new Byte[RECEIVE_BUFFER_SIZE];
        private string sendingStream;
        
        public SocketConnectionHandler(Socket socket, IServer server)
        {
            ClientSocket = socket;
            Server = server;
            socket.BeginReceive(receiveStream, 0, RECEIVE_BUFFER_SIZE, SocketFlags.None, SendToServer, null);
        }

        void IConnection.Disconnect()
        {
            throw new NotImplementedException();
        }

        void IConnection.OnConnect(string message)
        {
            SendToClient(message);
            //throw new NotImplementedException();
        }

        void IConnection.OnDisconnect(string message)
        {
            throw new NotImplementedException();
        }

        void IConnection.PrepareUpdate(string message)
        {
            sendingStream += message;
        }

        void IConnection.Update()
        {
            SendToClient(sendingStream);
            sendingStream = string.Empty;
        }

        void IDisposable.Dispose()
        {
            ClientSocket.Dispose();
        }

        private void SendToClient(string message)
        {
            Byte[] messageAsBytes = Encoding.ASCII.GetBytes(message);
            ClientSocket.Send(messageAsBytes, messageAsBytes.Length, SocketFlags.None);
        }
        private void SendToServer(IAsyncResult asyncResult)
        {
            var receivedBytesNumber = ClientSocket.EndReceive(asyncResult);
            var messageReceived = Encoding.ASCII.GetString(receiveStream, 0, receivedBytesNumber);
            var tempStream = new Byte[RECEIVE_BUFFER_SIZE];
            receiveStream.CopyTo(tempStream, 0);
            receiveStream = new Byte[RECEIVE_BUFFER_SIZE];//reset the buffer
            ClientSocket.BeginReceive(receiveStream, 0, RECEIVE_BUFFER_SIZE, SocketFlags.None, SendToServer, null);

            MessageReceived.Invoke(this, new MessageReceivedArgs { Message = messageReceived, RawData = tempStream, Account = this.Account});
        }
    }
}
