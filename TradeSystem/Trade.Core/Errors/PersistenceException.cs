﻿using System;
using System.Runtime.Serialization;

namespace Trade.Core.Errors
{
    [Serializable]
    public class PersistenceException : BaseException
    {
        public PersistenceException()
        {
        }

        public PersistenceException(string message) : base(message)
        {
        }

        public PersistenceException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PersistenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}