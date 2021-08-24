using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using SpaceMUD.Base.Interface;
using SpaceMUD.Common.Interfaces;
using System.Net;

namespace SpaceMUD.Server
{
    public class TelnetSocketServer : IServer
    {
        Socket serverSocket;

        private Socket BuildSocket()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, _portNumber));
            return socket;
        }
        
        private int _portNumber;

        public TelnetSocketServer(IGame game)
        {

        }

        public void StartServer(int portNumber)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
