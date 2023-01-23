using LearningStuff.Photon.Chat;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace LearningStuff.Photon.Callbacks
{
    public class JoinRoomCallback : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private MessageWriter _messageWriter;

        public override void OnPlayerEnteredRoom(Player newPlayer)
            => WriteMessage($"{newPlayer.NickName} has joined the room");
        
        public override void OnJoinedRoom()
            => WriteMessage($"{PhotonNetwork.NickName} has joined the room");
        
        private void WriteMessage(string message)
            => _messageWriter.WriteMessage(new Message("SYSTEM", message));
    }
}