using System;

namespace LearningStuff.Exceptions
{
    public class MessageIsTooLongException : Exception
    {
        public MessageIsTooLongException()
            : base("Message is too long") { }
    }
}