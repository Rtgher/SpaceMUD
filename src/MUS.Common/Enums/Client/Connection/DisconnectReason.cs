using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Enums.Client.Connection
{
    public enum DisconnectReason
    {
        /// <summary>
        /// Blanked Disconnect Reason for when we have no idea what happened. Also works as Default.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Disconnect because of player input/loss of connection
        /// </summary>
        PlayerDisconnect = 1,
        /// <summary>
        /// Disconnect Reason for when the server kicks the client out.
        /// </summary>
        ServerKick = 2,
        /// <summary>
        /// Disconnect as server is shutting down.
        /// </summary>
        ServerClose = 3
    }
}
