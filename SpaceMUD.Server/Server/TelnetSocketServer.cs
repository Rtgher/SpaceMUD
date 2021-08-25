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

namespace SpaceMUD.Server
{
    public class TelnetSocketServer : IServer, IDisposable
    {
        Socket serverSocket;
        List<ISocketConnection> Connections;
        List<IDisposable> Disposables;
        ILog Log;

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
            Log = new Logger(DirectoryHelper.GetInstalationDirectoryRoot().FullName);

            Connections = new List<ISocketConnection>();
            Disposables = new List<IDisposable>();
            serverSocket = BuildSocket(_portNumber);
            Game = game;
            //TODO: Innitialise game 
            //TODO: set Running to true when game starts.
            Disposables.AddRange(new IDisposable[]{ serverSocket, (IDisposable)Log });
            try
            {
                StartServer(_portNumber);
            }
            catch (Exception any)
            {
                Log.LogError($"Caught exception while trying to start server. \r\n Aborting...", any);
                this.Dispose();
                return;
            }
        }

        public void StartServer(int portNumber)
        {
            throw new NotImplementedException();
            Running = true;
        }

        public void Stop()
        {
            throw new NotImplementedException();
            Running = false;
        }

        public void Dispose()
        {
            if (Running) Stop();
            foreach (IDisposable disposable in Disposables) disposable.Dispose();
        }
    }
}
