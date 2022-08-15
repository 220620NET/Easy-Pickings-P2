using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class CommentNotAvailableException : Exception
    {
        public CommentNotAvailableException()
        {
        }

        public CommentNotAvailableException(string? message) : base(message)
        {
        }

        public CommentNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CommentNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
