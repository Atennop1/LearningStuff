using System;
using LearningStuff.Exceptions;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LearningStuff.Photon.Chat
{
    public class MessageWriterView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _messageField;
        [SerializeField] private TextMeshProUGUI _sendingStatusText;
        
        [Space]
        [SerializeField] private Button _sendMessageButton;
        [SerializeField] private AudioSource _notificationSound;

        private MessageWriter _messageWriter;

        public void Init(MessageWriter messageWriter)
        {
            _messageWriter = messageWriter ? messageWriter : throw new ArgumentException("MessageWriter can't be null");
        }

        public void PlayNotificationSound()
            => _notificationSound.Play();

        private void Start()
        {
            _sendMessageButton.onClick.AddListener(() =>
            {
                if (_messageField.text == string.Empty)
                    return;

                try
                {
                    _messageWriter.WriteMessage(new Message(PhotonNetwork.NickName, _messageField.text));
                    _sendingStatusText.text = "Message sent";
                }
                catch (MessageIsTooLongException)
                {
                    _sendingStatusText.text = "Max message length is 200";
                }
            });
        }
    }
}