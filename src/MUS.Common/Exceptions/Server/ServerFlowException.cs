using MUS.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Exceptions.Server
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
