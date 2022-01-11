using Microsoft.Extensions.DependencyInjection;
using MUS.Common.Exceptions;
using MUS.Common.Interfaces;
using MUS.Server.Base.Interface;
using MUS.Server.Base.Interface.Connection;
using MUS.Server.Server.ActionHandler;
using MUS.Server.Server.Connection;
using MUS.Server.Server.Connection.Events;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace MUS.Server.Server
{
    public class TelnetSocketServer : IServer, IDisposable
    {
        Socket serverSocket;
        public List<ISocketConnection> Connections { get; private set; }
        List<IDisposable> Disposables;
        ILog Log;
        const int Backlog = 40;

        public bool Running { get; private set; } = false;
        public IGame Game { get; private set; }
        public ActionHandlers ActionHandlers { get; } = new ActionHandlers();

        private int _portNumber;
        private Socket BuildSocket(int portNumber)
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, portNumber));
            return socket;
        }

        public TelnetSocketServer(IGame game, int portNumber = 4000)
        {
            _portNumber = portNumber;
            Log = MUS.Common.Dependency.DependencyContainer.Provider.GetService<ILog>();

            Connections = new List<ISocketConnection>();
            Disposables = new List<IDisposable>();
            Game = game;
            //TODO: Innitialise game 
            Disposables.AddRange(new IDisposable[] { serverSocket, Log });
        }

        public void StartServer()
        {
            try
            {
                serverSocket = BuildSocket(_portNumber);
                Log.LogInfo($"Starting server on port number {_portNumber}.");
                serverSocket.Listen(Backlog);
                Running = true;
                serverSocket.BeginAccept(OnConnect, null);
                Log.LogInfo("Server started. Waiting for conenctions...");
            }
            catch (Exception any)
            {
                Log.LogError($"Caught exception while trying to start server. \r\n Aborting...", any);
                Dispose();
                throw;
            }
        }

        public void Stop()
        {
            //throw new NotImplementedException();
            Running = false;
        }

        public void Dispose()
        {
            if (Running) Stop();
            foreach (IDisposable disposable in Disposables) disposable?.Dispose();
        }

        private void OnConnect(IAsyncResult asyncResult)
        {
            try
            {
                var sok = serverSocket.EndAccept(asyncResult);
                var connection = new SocketConnectionHandler(sok, this);

                if (sok != null)
                {
                    ((IConnection)connection).OnConnect("Connection successful.");
                    ActionHandlers.AddConnection(connection);
                    connection.MessageReceived += Connection_MessageReceived;
                    Connections.Add(connection);
                    Log.LogInfo("New client connection established.");
                }
                else
                {
                    throw new MUDException("Connection failed, socket is null.");
                }

                serverSocket.BeginAccept(OnConnect, null);
            }
            catch (Exception sok) when (sok is SocketException || sok is MUDException)
            {
                Log.LogError($"Caught exception while trying to connect to client.", sok);
                //try to play it cool.
                serverSocket.BeginAccept(OnConnect, null);
            }
            catch (Exception other)
            {
                Log.LogError($"Caught unexpected exception while trying to connect to client.", other);
                Dispose();
                throw;
            }
        }

        private void Connection_MessageReceived(object sender, MessageReceivedArgs e)
        {
            Log.LogInfo($@"Account '{e.Account?.Username ?? "Unknown"}' has sent message '{e.Message.TrimEnd()}' to server, of {e.RawData.Length} bytes lenght.");
            if (e.Account == null)
            {
                IConnection conn = sender as IConnection;

                var action = ActionHandlers.Delegate(conn, e);
            }
        }
    }
}
