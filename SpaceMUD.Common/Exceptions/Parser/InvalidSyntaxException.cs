using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Exceptions.Parser
{
    public class InvalidSyntaxException : MUDException
    {
        public InvalidSyntaxException()
        {
        }

        public InvalidSyntaxException(string message) : base(message)
        {
        }

        public InvalidSyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSyntaxException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
