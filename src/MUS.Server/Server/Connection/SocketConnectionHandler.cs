using MUS.Common.Commands.Base;
using MUS.Common.Exceptions.Server;
using MUS.Entities.Network;
using MUS.Server.Base.Interface;
using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server.Connection.Events;
using System;
using System.Net.Sockets;
using System.Text;

namespace MUS.Server.Server.Connection
{
    public class SocketConnectionHandler : ISocketConnection, IDisposable
    {
        public Socket ClientSocket { get; private set; }
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning == true)
                {
                    if (value == false)
                        throw new ServerFlowException("Something tried to terminate a socket connection incorrectly. " +
                            "Correct way is through Disconnect()");
                }
                _isRunning = value;
            }
        }

        public Account Account { get; set; } = null;
        public ICommand ExecutingCommand { get; set; } = null;

        public bool IsExecutingACommand => ExecutingCommand != null && !ExecutingCommand.Completed;

        public event EventHandler<MessageReceivedArgs> MessageReceived;

        private bool _isRunning;
        private readonly IServer Server;
        private const int RECEIVE_BUFFER_SIZE = 512;
        private byte[] receiveStream = new byte[RECEIVE_BUFFER_SIZE];
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
            byte[] messageAsBytes = Encoding.ASCII.GetBytes(message);
            ClientSocket.Send(messageAsBytes, messageAsBytes.Length, SocketFlags.None);
        }
        private void SendToServer(IAsyncResult asyncResult)
        {
            var receivedBytesNumber = ClientSocket.EndReceive(asyncResult);
            var messageReceived = Encoding.ASCII.GetString(receiveStream, 0, receivedBytesNumber);
            var tempStream = new byte[RECEIVE_BUFFER_SIZE];
            receiveStream.CopyTo(tempStream, 0);
            receiveStream = new byte[RECEIVE_BUFFER_SIZE];//reset the buffer
            ClientSocket.BeginReceive(receiveStream, 0, RECEIVE_BUFFER_SIZE, SocketFlags.None, SendToServer, null);

            MessageReceived.Invoke(this, new MessageReceivedArgs { Message = messageReceived, RawData = tempStream, Account = Account });
        }
    }
}
