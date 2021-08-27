using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Exceptions.Database.Base
{
    public class MUDDatabaseException : MUDException
    {
        public MUDDatabaseException()
        {
        }

        public MUDDatabaseException(string message) : base(message)
        {
        }

        public MUDDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MUDDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
