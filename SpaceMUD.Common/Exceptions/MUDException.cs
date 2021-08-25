using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Exceptions
{
    /// <summary>
    /// A Base exception class for throwing custom exceptions.
    /// </summary>
    public class MUDException : Exception
    {
        public MUDException() : base()
        {

        }

        public MUDException(string message) : base(message)
        {

        }

        public MUDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MUDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
