using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Chat
{
    public class MessageWriterView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _messageField;
        [SerializeField] private Button _sendMessageButton;

        private MessageWriter _messageWriter;

        public void Init(MessageWriter messageWriter)
        {
            _messageWriter = messageWriter ? messageWriter : throw new ArgumentException("MessageWriter can't be null");
        }

        private void Start()
        {
            _sendMessageButton.onClick.AddListener(() =>
            {
                if (_messageField.text == string.Empty)
                    return;

                _messageWriter.WriteMessage(new Message(PhotonNetwork.NickName, _messageField.text));
            });
        }
    }
}