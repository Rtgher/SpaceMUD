using MUS.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MUS.Common.Exceptions.Database.Base
{
    public class MUSDatabaseException : MUDException
    {
        public MUSDatabaseException()
        {
        }

        public MUSDatabaseException(string message) : base(message)
        {
        }

        public MUSDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MUSDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
