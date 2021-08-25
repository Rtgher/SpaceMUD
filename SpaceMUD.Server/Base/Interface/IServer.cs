using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Server.Base.Interface
{
    /// <summary>
    /// An interface to detail a basic server.
    /// </summary>
    public interface IServer
    {
        /// <summary>
        /// Start the server for connection on the given port number.
        /// </summary>
        /// <param name="portNumber">The port number to connect to.</param>
        void StartServer(int portNumber);

        /// <summary>
        /// Stop the server and end connections.
        /// </summary>
        void Stop();
    }
}
