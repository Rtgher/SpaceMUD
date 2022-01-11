using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MUS.Common.Exceptions.Database.Base;

namespace MUS.Common.Exceptions.Database
{
    public class MUDDatabaseNoDataException : MUDDatabaseException
    {
        public MUDDatabaseNoDataException()
        {
        }

        public MUDDatabaseNoDataException(string message) : base(message)
        {
        }

        public MUDDatabaseNoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MUDDatabaseNoDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
