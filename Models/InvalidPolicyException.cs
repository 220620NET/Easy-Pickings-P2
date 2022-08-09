using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class InvalidPolicyException : Exception
    {
        public InvalidPolicyException()
        {
        }

        public InvalidPolicyException(string? message) : base(message)
        {
        }

        public InvalidPolicyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPolicyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
