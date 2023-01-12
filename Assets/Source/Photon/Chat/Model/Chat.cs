using System;
using System.Collections.Generic;

namespace LearningStuff.Photon.Chat
{
    public class Chat //maybe i add logger in this place sometime...
    {
        private readonly List<Message> _messages = new();
        private readonly ChatView _view;
        private readonly int _bufferSize;

        public Chat(ChatView view, int bufferSize)
        {
            if (bufferSize <= 0)
                throw new ArgumentException("Buffer size can't be less or equals zero");

            _bufferSize = bufferSize;
            _view = view ? view : throw new ArgumentException("View can't be null");
        }

        public void AddMessage(Message message)
        {
            if (_messages.Count == _bufferSize)
                _messages.RemoveAt(0);
            
            _messages.Add(message);
            _view.Display(_messages);
        }
    }
}