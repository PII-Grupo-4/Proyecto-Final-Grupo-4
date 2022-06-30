using System;
namespace Battleship
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }
        public InvalidInputException(string message) : base(message) { }
        public InvalidInputException(string message, Exception inner) : base(message, inner) { }
        protected InvalidInputException(
            Runtime.Serialization.SerializationInfo info,
            Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}