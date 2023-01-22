using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Logger = LearningStuff.Logging.Logger;

namespace LearningStuff.Photon.Chat
{
    public class Chat
    {
        private readonly List<Message> _messages = new();
        private readonly ChatView _view;
        
        private readonly int _bufferSize;
        private readonly Logger _logger = new();

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
            var logMessage = $"Player \"{message.Nickname}\" in room \"{PhotonNetwork.CurrentRoom.Name}\": {message.Text}";
            
            _logger.Log(logMessage, LogType.Log);
            _view.Display(_messages);
        }
    }
}