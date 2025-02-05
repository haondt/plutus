﻿using Midas.Domain.NodeRed.Models;

namespace Midas.Domain.Import.Exceptions
{
    public class SendToNodeRedException : Exception
    {
        public required SendToNodeRedRequestDto Request { get; set; }

        public SendToNodeRedException()
        {
        }

        public SendToNodeRedException(string? message) : base(message)
        {
        }

        public SendToNodeRedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
