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
        [SerializeField] private PhotonView _photonView;

        private MessageWriter _messageWriter;

        public void Init(MessageWriter messageWriter)
        {
            _messageWriter = messageWriter ?? throw new ArgumentException("MessageWriter can't be null");
        }

        private void Start()
        {
            _sendMessageButton.onClick.AddListener(() =>
            {
                if (_messageField.text == string.Empty)
                    return;
                
                _photonView.RPC("SendMessageToOtherPeople", RpcTarget.AllBuffered,
                    PhotonNetwork.NickName, _messageField.text);
            });
        }

        [PunRPC]
        private void SendMessageToOtherPeople(string nickName, string text) 
            => _messageWriter.WriteMessage(new Message(nickName, text));
    }
}