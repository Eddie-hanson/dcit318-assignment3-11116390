using System;
namespace SchoolGradingSystem.Exceptions
{
    public class StudentMissingFieldException : Exception
    {
        public StudentMissingFieldException() { }
        public StudentMissingFieldException(string message) : base(message) { }
        public StudentMissingFieldException(string message, Exception inner) : base(message, inner) { }
    }
}
