using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public class TicketNotAvailable : Exception
    {
        public TicketNotAvailable()
        {
        }

        public TicketNotAvailable(string? message) : base(message)
        {
        }

        public TicketNotAvailable(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TicketNotAvailable(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
