using System;

namespace LearningStuff.Photon.Chat
{
    public class MessageWriter
    {
        private readonly Chat _chat;

        public MessageWriter(Chat chat)
        {
            _chat = chat ?? throw new ArgumentException("Chat can't be null");
        }

        public void WriteMessage(Message message) => _chat.AddMessage(message);
    }
}