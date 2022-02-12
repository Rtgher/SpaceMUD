using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MUS.Common.Exceptions.Database.Base;

namespace MUS.Common.Exceptions.Database
{
    public class MUSDatabaseNoDataException : MUSDatabaseException
    {
        public MUSDatabaseNoDataException()
        {
        }

        public MUSDatabaseNoDataException(string message) : base(message)
        {
        }

        public MUSDatabaseNoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MUSDatabaseNoDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
