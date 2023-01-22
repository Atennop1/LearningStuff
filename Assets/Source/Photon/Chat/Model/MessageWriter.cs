using System;
using Photon.Pun;
using UnityEngine;

namespace LearningStuff.Photon.Chat
{
    public class MessageWriter : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private MessageWriterView _messageWriterView;
        private Chat _chat;

        public void Init(Chat chat)
        {
            _chat = chat ?? throw new ArgumentException("Chat can't be null");
        }

        public void WriteMessage(Message message)
        {
            _photonView.RPC("SendMessageToOtherPeople", RpcTarget.All,
                message.Nickname, message.Text);
            
            _photonView.RPC("PlayNotificationSound", RpcTarget.Others);
        }

        [PunRPC]
        private void SendMessageToOtherPeople(string nickName, string text)
            => _chat.AddMessage(new Message(nickName, text));

        [PunRPC]
        private void PlayNotificationSound()
            => _messageWriterView.PlayNotificationSound();
    }
}