using System;
using LearningStuff.Exceptions;

namespace LearningStuff.Photon.Chat
{
    public readonly struct Message
    {
        public readonly string Nickname;
        public readonly string Text;

        private const int MAX_MESSAGE_LENGTH = 150;

        public Message(string nickname, string text)
        {
            if (text == null)
                throw new ArgumentException("Text can't be null");

            if (text.Length > MAX_MESSAGE_LENGTH)
                throw new MessageIsTooLongException();
            
            Nickname = nickname ?? throw new ArgumentException("Nickname can't be null");
            Text = text;
        }
    }
}