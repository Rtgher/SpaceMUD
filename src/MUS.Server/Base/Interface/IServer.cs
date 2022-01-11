using MUS.Server.Base.Interface.Connection;
using System.Collections.Generic;

namespace MUS.Server.Base.Interface
{
    /// <summary>
    /// An interface to detail a basic server.
    /// </summary>
    public interface IServer
    {
        List<ISocketConnection> Connections
        {
            get;
        }
        /// <summary>
        /// Start the server for connection on the given port number.
        /// </summary>
        /// <param name="portNumber">The port number to connect to.</param>
        void StartServer();

        /// <summary>
        /// Stop the server and end connections.
        /// </summary>
        void Stop();
    }
}
