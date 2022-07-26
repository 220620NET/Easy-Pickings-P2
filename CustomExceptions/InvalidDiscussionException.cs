﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    [Serializable]
    public class InvalidDiscussionException : Exception
    {
        public InvalidDiscussionException()
        {
        }

        public InvalidDiscussionException(string? message) : base(message)
        {
        }

        public InvalidDiscussionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidDiscussionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
