using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SpaceMUD.Server.Base.Interface;
using SpaceMUD.Server.Base.Interface.Connection;
using SpaceMUD.Common.Interfaces;
using SpaceMUD.Common.Logging;
using SpaceMUD.Common.Tools;
using SpaceMUD.Base.Tools.Dependency.ServiceContainer;
using Microsoft.Extensions.DependencyInjection;
using SpaceMUD.Server.Connection;

namespace SpaceMUD.Server
{
    public class TelnetSocketServer : IServer, IDisposable
    {
        Socket serverSocket;
        public List<ISocketConnection> Connections { get; private set; }
        List<IDisposable> Disposables;
        ILog Log;
        const int Backlog = 40;

        public bool Running { get; private set; } = false;
        public IGame Game{ get; private set;}

        private int _portNumber;
        private Socket BuildSocket(int portNumber)
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, portNumber));
            return socket;
        }

        public TelnetSocketServer(IGame game, int portNumber=4000)
        {
            _portNumber = portNumber;
            Log = new Logger(DirectoryHelper.GetInstalationDirectoryRoot().FullName+"/Logs/");

            Connections = new List<ISocketConnection>();
            Disposables = new List<IDisposable>();
            Game = game;
            //TODO: Innitialise game 
            Disposables.AddRange(new IDisposable[]{ serverSocket, Log });
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
                this.Dispose();
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
                var connection = new SocketConnectionHandler(serverSocket.EndAccept(asyncResult), this);
                ((IConnection)connection).OnConnect("Connection successful.");
                Connections.Add(connection);

                serverSocket.BeginAccept(OnConnect, null);
            }catch(SocketException sok)
            {
                Log.LogError($"Caught exception while trying to connect to client.", sok);
                //try to play it cool.
                serverSocket.BeginAccept(OnConnect, null);
            }
            catch(Exception other)
            {
                Log.LogError($"Caught unexpected exception while trying to connect to client.", other);
                Dispose();
                throw;
            }
        }
    }
}
