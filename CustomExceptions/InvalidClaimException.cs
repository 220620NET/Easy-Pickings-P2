using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    [System.Serializable]
    public class InvalidClaimException : Exception
    {
        public InvalidClaimException()
        {
        }

        public InvalidClaimException(string? message) : base(message)
        {
        }

        public InvalidClaimException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidClaimException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
