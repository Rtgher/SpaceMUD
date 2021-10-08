using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SpaceMUD.Server.Base.Interface.Connection
{
    public interface ISocketConnection : IConnection, IDisposable
    {
        Socket ClientSocket { get; }

    }
}
