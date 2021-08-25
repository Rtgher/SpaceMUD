using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Server.Base.Interface.Connection
{
    /// <summary>
    /// Server-side object wrapping the client connection.
    /// </summary>
    public interface IConnection
    {
        IConnection OnConnect();
        IConnection OnDisconnect();
        IConnection Disconnect();
        IConnection OnUpdate();

    }
}
