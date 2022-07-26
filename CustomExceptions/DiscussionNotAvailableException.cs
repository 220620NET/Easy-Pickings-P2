﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    [Serializable]
    public class DiscussionNotAvailableException : Exception
    {
        public DiscussionNotAvailableException()
        {
        }

        public DiscussionNotAvailableException(string? message) : base(message)
        {
        }

        public DiscussionNotAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DiscussionNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
