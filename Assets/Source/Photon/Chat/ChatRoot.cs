using UnityEngine;

namespace LearningStuff.Photon.Chat
{
    public class ChatRoot : MonoBehaviour
    {
        [SerializeField] private MessageWriterView _messageWriterView;
        [SerializeField] private ChatView _chatView;
        [SerializeField] private MessageWriter _messageWriter;

        private void Awake()
        {
            var chat = new Chat(_chatView, 9);
            _messageWriter.Init(chat);
            _messageWriterView.Init(_messageWriter);
        }
    }
}