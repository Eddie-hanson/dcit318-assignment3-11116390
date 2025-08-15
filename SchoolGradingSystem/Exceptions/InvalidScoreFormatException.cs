using System;

namespace SchoolGradingSystem.Exceptions
{
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException() { }

        public InvalidScoreFormatException(string message) : base(message) { }

        public InvalidScoreFormatException(string message, Exception inner) : base(message, inner) { }
    }
}
