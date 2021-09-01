using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMUD.Common.Exceptions.Server.Account
{
    public class PasswordEncryptionException : MUDException
    {
        public PasswordEncryptionException()
        {
        }

        public PasswordEncryptionException(string message) : base(message)
        {
        }

        public PasswordEncryptionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PasswordEncryptionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
