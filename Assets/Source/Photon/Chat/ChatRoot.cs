using UnityEngine;

namespace LearningStuff.Photon.Chat
{
    public class ChatRoot : MonoBehaviour
    {
        [SerializeField] private MessageWriterView _messageWriterView;
        [SerializeField] private ChatView _chatView;

        private void Awake()
        {
            var chat = new Chat(_chatView, 10);
            _messageWriterView.Init(new MessageWriter(chat));
        }
    }
}