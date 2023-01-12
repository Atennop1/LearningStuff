using System;

namespace LearningStuff.Photon.Chat
{
    public readonly struct Message
    {
        public readonly string Nickname;
        public readonly string Text;

        public Message(string nickname, string text)
        {
            Nickname = nickname ?? throw new ArgumentException("Nickname can't be null");
            Text = text ?? throw new ArgumentException("Text can't be null");
        }
    }
}