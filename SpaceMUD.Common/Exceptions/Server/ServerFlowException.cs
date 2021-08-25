using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Exceptions.Server
{
    public class ServerFlowException : MUDException
    {
        public ServerFlowException()
        {
        }

        public ServerFlowException(string message) : base(message)
        {
        }
    }
}
